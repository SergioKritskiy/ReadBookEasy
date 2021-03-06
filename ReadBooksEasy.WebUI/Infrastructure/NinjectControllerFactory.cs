﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using ReadBooksEasy.Domain.Concrete;
using ReadBooksEasy.Domain.Abstract;
using ReadBooksEasy.Domain.Entities;
using Moq;
namespace ReadBooksEasy.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext,
        Type controllerType)
        {
            // получение объекта контроллера из контейнера
            // используя его тип
            return controllerType == null
            ? null
            : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            ninjectKernel.Bind<IBookRepository>().To<EFBooksRepository>();
         //   ninjectKernel.Bind<IUserBookRepository>().To<EFUserBookRepository>();
            // конфигурирование контейнера
        }
    }
}