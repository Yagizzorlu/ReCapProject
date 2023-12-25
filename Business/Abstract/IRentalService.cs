using Core.Utilites.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);

        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();
        IDataResult<List<RentalDetailDto>> GetAllRentalDetailsById(int rentalId);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetailsByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetailsByCustomerId(int customerId);
    }
}
