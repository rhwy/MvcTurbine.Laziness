﻿using MvcTurbine.ComponentModel;
using MvcTurbine.StructureMap;

namespace MvcTurbine.Laziness.StructureMap
{
    public class StructureMapLazySetup : ILazySetup
    {
        public bool CanSetup(IServiceLocator serviceLocator)
        {
            return serviceLocator.GetType() == typeof (StructureMapServiceLocator);
        }

        public void Setup(IServiceLocator serviceLocator)
        {
            var structureMapServiceLocator = (StructureMapServiceLocator)serviceLocator;
            var container = structureMapServiceLocator.Container;
            container.Configure(x => { x.ForRequestedType(typeof (ILazy<>)).TheDefaultIsConcreteType(typeof (StructureMapLazy<>)); });
        }
    }
}