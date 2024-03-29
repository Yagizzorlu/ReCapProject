﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilites.Helpers.FileHelper;
using Core.Utilites.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [CacheRemoveAspect("ICarImageService.GetAll")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.CarImageId));

            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            carImage.CarImagePath = imageResult.Message;
            carImage.CarImageDate = DateTime.Now;          //resmin eklendiği tarih sistem tarafından atanıyor.

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            var result = FileHelper.Delete(carImage.CarImagePath);

            if (!result.Success)
            {
                return new ErrorResult();
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(DefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));


        }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId));
        }

        [CacheAspect]
        public IDataResult<List<CarImageDetailDto>> GetAllCarImageDetails()
        {
            return new SuccessDataResult<List<CarImageDetailDto>>(_carImageDal.GetAllCarImageDetails());
        }

        [CacheAspect]
        public IDataResult<CarImageDetailDto> GetCarImageDetailsById(int carImageId)
        {
            return new SuccessDataResult<CarImageDetailDto>(_carImageDal.GetCarImageDetails(c => c.CarId == carImageId));
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = FileHelper.Update(file, carImage.CarImagePath);
            if(!result.Success)
            {
                return result;
            }

            carImage.CarImagePath = result.Message;
            carImage.CarImageDate = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (result >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private static IDataResult<List<CarImage>> DefaultImage (int carId)
        {
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>{new CarImage
            {
                CarId = carId,
                CarImageDate = DateTime.Now,
                CarImagePath = @"/Images/default.png"
            }});
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (!result)
            {
                return new ErrorResult(Messages.CarImageNotExist);
            }

            return new SuccessResult();
        }
    }
}
