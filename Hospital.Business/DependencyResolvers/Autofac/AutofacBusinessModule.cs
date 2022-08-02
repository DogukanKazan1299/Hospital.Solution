﻿using Autofac;
using Hospital.Business.Abstract;
using Hospital.Business.Concrete;
using Hospital.DataAccess.Abstract;
using Hospital.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DoctorManager>().As<IDoctorService>();
            builder.RegisterType<EfDoctorDal>().As<IDoctorDal>();
        }
    }
}
