using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using CarRentalSystem.API.Headears;
using CarStore.Model;
using CarStore.Service.Models;

namespace CarStore.Service.Controllers
{
    public class CarsController : BaseApiController
    {
        public CarsController()
            : this(new CarStoreSystemContextFactory())
        {
        }

        public CarsController(IDbContextFactory<DbContext> contextFactory)
            : base(contextFactory)
        {
        }

        //user
        public IQueryable<CarModel> GetAllFree()
        {
            var response =
            this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();

                var freeCarModels = context.Set<Car>()
                              .Where(car => car.IsTaken == false)
                              .Select(CarModel.FromCar);
                return freeCarModels;
            });
            return response;
        }

        //admin
        [HttpGet]
        [ActionName("all")]
        public IQueryable<Car> GetAll([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var response =
            this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();
                var user = this.LoginUser(sessionKey, context);
                if (user.Role.Permission != "admin")
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You have no permissions to do change cars");
                    throw new HttpResponseException(errResponse);
                }

                return context.Set<Car>();
            });
            return response;
        }

        //user
        public CarFullModel GetById(int id)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {

                var context = this.ContextFactory.Create();
                using (context)
                {
                    var carsDbSet = context.Set<Car>();
                    var entityCar = carsDbSet.FirstOrDefault(u => u.CarId == id);
                    if (entityCar == null || entityCar.IsTaken)
                    {
                        var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such car or car isn't aviable");
                        throw new HttpResponseException(errResponse);
                    }

                    var extrasDbSet = context.Set<Customization>();
                    var entityExtras = extrasDbSet.FirstOrDefault(u => u.Id == entityCar.CarId);

                    var searchedCar = new CarFullModel
                        {
                            Id = entityCar.CarId,
                            Model = entityCar.Model,
                            Make = entityCar.Make,
                            Year = entityCar.Year,
                            Engine = entityCar.Engine,
                            Seats = entityCar.Seats,
                            Doors = entityCar.Doors,
                            PricePerDay = entityCar.PricePerDay,
                            Price = entityCar.Price,
                            Power = entityCar.Power,
                            PictureUrl = entityCar.PictureUrl
                        };
                    
                    if(entityExtras != null)
                    {
                        searchedCar.Extras = new Customization
                            {
                                AirCondition = entityExtras.AirCondition,
                                AudioSystem = entityExtras.AudioSystem,
                                AutomaticTransmission = entityExtras.AutomaticTransmission,
                                CrouseControl = entityExtras.CrouseControl,
                                Parktronic = entityExtras.Parktronic,
                                PowerLock = entityExtras.PowerLock,
                                PowerWindows = entityExtras.PowerWindows
                            };
                    };

                    return searchedCar;
                }
            });
        }

        //registered
        [HttpPut]
        [ActionName("rent")]
        public HttpResponseMessage PutRentCar(RentedCar model,
          [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();
                var user = this.LoginUser(sessionKey, context);

                var car = context.Set<Car>().Find(model.Id);
                if (car == null)
                {
                    throw new InvalidOperationException("The car does not exist");
                }

                
                if (car.IsTaken)
                {
                    throw new InvalidOperationException("The car is already rented");
                }


                car.IsTaken = true;
                car.RentedBy = user;
                car.DropOffDate = model.DropOffDate;
                car.PickUpDate = model.PickUpDate;
                TimeSpan timeSpan = (model.PickUpDate - model.DropOffDate);
                int days = timeSpan.Days;
                decimal change = user.Amount.Value - (days * car.PricePerDay);
                user.Amount = change;
                context.SaveChanges();
                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            });
        }

        //registered
        [HttpPut]
        [ActionName("return")]
        public HttpResponseMessage PutReturnCar(int carId,
          [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();
                var user = this.LoginUser(sessionKey, context);

                var car = context.Set<Car>().Find(carId);
                if (car == null)
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.Conflict, "The car does not exist");
                    throw new HttpResponseException(errResponse);
                }

                if (car.IsTaken || car.RentedBy != user)
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.Conflict, "The car is not rented by you");
                    throw new HttpResponseException(errResponse);
                }
                car.IsTaken = false;
                car.RentedBy = null;
                car.DropOffDate = null;
                car.PickUpDate = null;
                context.SaveChanges();
                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            });
        }

        //admin
        [HttpPut]
        [ActionName("edit")]
        public HttpResponseMessage PutEditCar(Car model,
          [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();
                var user = this.LoginUser(sessionKey, context);

                var car = context.Set<Car>().Find(model.CarId);
                if (car == null)
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.Conflict, "The car does not exist");
                    throw new HttpResponseException(errResponse);
                }
                if (user.Role.Permission != "admin")
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You have no permissions to do change cars");
                    throw new HttpResponseException(errResponse);
                }

                if(model.IsTaken != car.IsTaken)
                {
                    car.IsTaken = model.IsTaken;
                }
                if (model.Doors != car.Doors && model.Doors != 0)
                {
                    car.Doors = model.Doors;
                }
                if (model.Engine != car.Engine && model.Engine != null)
                {
                    car.Engine = model.Engine;
                }
                if (model.Make != null && model.Make != car.Model)
                {
                    car.Make = model.Make;
                }
                if (model.Model != null && model.Model != car.Model)
                {
                    car.Model = model.Engine;
                }
                if (model.PictureUrl != null && model.PictureUrl != car.PictureUrl)
                {
                    car.PictureUrl = model.PictureUrl;
                }
                if (model.Power != 0 && model.Power != car.Power)
                {
                    car.Power = model.Power;
                }
                if (model.Price != 0 && model.Price != car.Price)
                {
                    car.Price = model.Price;
                }
                if (model.PricePerDay != 0 && model.PricePerDay != car.PricePerDay)
                {
                    car.PricePerDay = model.PricePerDay;
                }
                if (model.Seats != 0 && model.Seats != car.Seats)
                {
                    car.Seats = model.Seats;
                }
                if (model.Year != 0 && model.Year != car.Year)
                {
                    car.Year = model.Year;
                }

                context.SaveChanges();
                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            });
        }

        //change extras admin
        [HttpPut]
        [ActionName("extras")]
        public HttpResponseMessage PutEditExtras(int id, Customization model,
          [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();
                var user = this.LoginUser(sessionKey, context);

                var car = context.Set<Car>().Find(id);
                var extras = context.Set<Customization>().FirstOrDefault(e => e.Car == car);
                if (car == null)
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "The car does not exist");
                    throw new HttpResponseException(errResponse);
                }
                if (user.Role.Permission != "admin")
                {
                    var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You have no permissions to do change cars");
                    throw new HttpResponseException(errResponse);
                }

                if (model.AirCondition != extras.AirCondition)
                {
                    extras.AirCondition = model.AirCondition;
                }
                if (model.AudioSystem != extras.AudioSystem)
                {
                    extras.AudioSystem = model.AudioSystem;
                }
                if (model.AutomaticTransmission != extras.AutomaticTransmission)
                {
                    extras.AutomaticTransmission = model.AutomaticTransmission;
                }
                if (model.CrouseControl != extras.CrouseControl)
                {
                    extras.CrouseControl = model.CrouseControl;
                }
                if (model.Parktronic != extras.Parktronic)
                {
                    extras.Parktronic = model.Parktronic;
                }
                if (model.PowerLock != extras.PowerLock)
                {
                    extras.PowerLock = model.PowerLock;
                }
                if (model.PowerWindows != extras.PowerWindows)
                {
                    extras.PowerWindows = model.PowerWindows;
                }

                context.SaveChanges();
                var response = this.Request.CreateResponse(HttpStatusCode.NoContent);
                return response;
            });
        }
    }
}
