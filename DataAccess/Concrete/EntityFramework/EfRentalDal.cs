using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental,bool>> filter=null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rental in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rental.RentalId,
                                 BrandName = brand.BrandName,
                                 CompanyName = customer.CompanyName,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = (DateTime)rental.ReturnDate
                             };
                return result.ToList();


            }
        }
    }
}
