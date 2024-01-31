using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilites.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal _modelDal)
        {
            _modelDal = _modelDal;
        }

        [CacheRemoveAspect("IModelService.GetAll")]
        [ValidationAspect(typeof(ModelValidator))]
        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult(Messages.ModelAdded);
        }

        [CacheRemoveAspect("IModelService.Get")]
        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult(Messages.ModelDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Model> GetById(int modelId)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(m=>m.ModelId == modelId));
        }

        [CacheRemoveAspect("IModelService.Get")]
        [ValidationAspect(typeof(ModelValidator))]
        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult(Messages.ModelUpdated);
        }
    }
}
