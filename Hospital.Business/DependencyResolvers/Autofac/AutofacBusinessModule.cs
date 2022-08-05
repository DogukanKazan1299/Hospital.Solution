using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Hospital.Business.Abstract;
using Hospital.Business.Concrete;
using Hospital.Core.Utilities.Interceptors;
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

            builder.RegisterType<NurseManager>().As<INurseService>();
            builder.RegisterType<EfNurseDal>().As<INurseDal>();

            builder.RegisterType<PatientManager>().As<IPatientService>();
            builder.RegisterType<EfPatientDal>().As<IPatientDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()//Aspect var mı kontrolü 
                }).SingleInstance();
        }
    }
}
