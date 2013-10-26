using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarStore.Service.Models;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using CarStore.Model;

namespace CarStore.Service.Controllers
{
    public class StoresController : BaseApiController
    {
        public StoresController()
            : this(new CarStoreSystemContextFactory())
        {
        }

        public StoresController(IDbContextFactory<DbContext> contextFactory)
            : base(contextFactory)
        {
        }

        //user
        public IQueryable<StoreModel> GetAll()
        {
            var response =
            this.PerformOperationAndHandleExceptions(() =>
            {
                var context = this.ContextFactory.Create();

                var freeCarModels = context.Set<Store>()
                    .Select(StoreModel.FromStore);

                return freeCarModels;
            });
            return response;
        }

        public StoreFullModel GetById(int id)
        {
            return this.PerformOperationAndHandleExceptions(() =>
            {

                var context = this.ContextFactory.Create();
                using (context)
                {
                    var storeDbSet = context.Set<Store>();
                    var entityStore = storeDbSet.FirstOrDefault(s => s.Id == id);
                    if (entityStore == null)
                    {
                        var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "No such store aviable");
                        throw new HttpResponseException(errResponse);
                    }


                    var searchedStore = new StoreFullModel
                    {
                        Id = entityStore.Id,
                        Name = entityStore.Name,
                        City = entityStore.City,
                        Adress = entityStore.Adress,
                        Longitute = entityStore.Longitute,
                        Latitude = entityStore.Latitude
                    };

                    if (entityStore.Cars != null)
                    {
                        searchedStore.Cars = entityStore.Cars.AsQueryable().Select(CarModel.FromCar).AsEnumerable();
                    };

                    return searchedStore;
                }
            });
        }
    }
}
