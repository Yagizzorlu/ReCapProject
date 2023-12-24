using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)               //Liste halinde değil ve filtre zorunlu ondan liste yapmadan sadece returnluyoruz.
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Update(Car entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
