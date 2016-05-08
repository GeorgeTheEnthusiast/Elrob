using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elrob.Webservice.Extensions
{
    using Ninject;
    using Ninject.Syntax;

    public static class NinjectExtensions
    {
        public static T GetNamedInstance<T>(this IResolutionRoot root, string fullName)
        {
            var allJobInstances = Global.Kernel.GetAll<T>();
            return allJobInstances.FirstOrDefault(x => x.ToString() == fullName);
        }
    }
}