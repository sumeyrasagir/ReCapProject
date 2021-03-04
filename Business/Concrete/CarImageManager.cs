using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == imageId));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfCarImageLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }
            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\logo.png";

            var result = _carImageDal.GetAll(c => c.CarId == id).Any();

            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }

            return _carImageDal.GetAll(p => p.CarId == id);
        }
    }
}
