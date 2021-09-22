using Autofac;
using Autofac.Integration.WebApi;
using CELTAPI.Services;
using CELTAPI.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace CELTAPI.App_Start
{
    public class ContainerConfig
    {
        public static IContainer container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<SentimentService>()
                   .As<ISentimentService>()
                   .InstancePerRequest();

            builder.RegisterType<FileStreamReader>()
                    .As<IStreamReader>()
                    .InstancePerRequest();

            //Set the dependency resolver to be Autofac.  
            container = builder.Build();

            return container;
        }

    }
}