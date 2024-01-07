using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join customer in context.Customers
                             on r.CustomerId equals customer.UserId
                             select new RentalDetailDto
                             {
                                 CarId = r.CarId,
                                 CustomerId = customer.UserId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 RentalId = r.RentalId
                             };
                return result == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public RentalDetailDto GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join customer in context.Customers
                             on r.CustomerId equals customer.UserId
                             select new RentalDetailDto
                             {
                                 CarId = r.CarId,
                                 CustomerId = customer.UserId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 RentalId = r.RentalId
                             };
                return result.Where(filter).SingleOrDefault();
            }
        }
    }
}
