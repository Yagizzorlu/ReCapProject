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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalContext> , ICustomerDal
    {
            public List<CustomerDetailDto> GetAllCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
            {
                using (CarRentalContext context = new CarRentalContext())
                {
                    var result = (from customer in context.Customers
                                  join user in context.Users on customer.UserId equals user.UserId
                                  select new CustomerDetailDto
                                  {
                                      CustomerId = customer.CustomerId,
                                      UserId = user.UserId,
                                      FirstName = user.UserFirstName,
                                      LastName = user.UserLastName,
                                      CompanyName = customer.CompanyName
                                  });

                    return filter == null ? result.ToList() : result.Where(filter).ToList();
                }
            }

            public CustomerDetailDto GetCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter)
            {
                using (CarRentalContext context = new CarRentalContext())
                {
                    var result = (from customer in context.Customers
                                  join user in context.Users on customer.UserId equals user.UserId
                                  select new CustomerDetailDto
                                  {
                                      CustomerId = customer.CustomerId,
                                      UserId = user.UserId,
                                      FirstName = user.UserFirstName,
                                      LastName = user.UserLastName,
                                      CompanyName = customer.CompanyName
                                  });

                    return result.Where(filter).SingleOrDefault();
                }
            }
        }
    }

