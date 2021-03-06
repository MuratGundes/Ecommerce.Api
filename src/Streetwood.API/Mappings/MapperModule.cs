﻿namespace Streetwood.API.Mappings
{
    using Autofac;
    using AutoMapper;

    public class MapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize()).As<IMapper>().SingleInstance();
        }
    }
}
