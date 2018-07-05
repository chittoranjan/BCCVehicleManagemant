﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using BCCVehicleRequisitionManagementSystem.Models.EntityModels;
using BCCVehicleRequisitionManagementSystem.ViewModels;

namespace BCCVehicleRequisitionManagementSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<VehicleViewModel, Vehicle>();
                cfg.CreateMap<Vehicle, VehicleViewModel>();

                cfg.CreateMap<VehicleTypeViewModel, VehicleType>();
                cfg.CreateMap<VehicleType, VehicleTypeViewModel>();

                cfg.CreateMap<DriverViewModel, Driver>();
                cfg.CreateMap<Driver, DriverViewModel>();
            });
        }
    }
}
