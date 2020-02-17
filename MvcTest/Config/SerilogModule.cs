using Autofac;
using Serilog;
using System;
using System.IO;

namespace MvcTest.Config
{
    public class SerilogModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<ILogger>(
                 (c, p) =>
                 {

                     var rollingFilePath = AppDomain.CurrentDomain.BaseDirectory + "/_logs/";
                     var iss = Directory.Exists(rollingFilePath);

                     rollingFilePath += " / Log-{Date}.txt";


                     var tmplogger = new LoggerConfiguration()
                         .ReadFrom.AppSettings()
                         .WriteTo.RollingFile(rollingFilePath)
                         .CreateLogger();
                     return tmplogger;

                 }).SingleInstance();
        }

    }
}