namespace Elrob.NtService.Extensions
{
    using System.Linq;

    using Ninject;
    using Ninject.Syntax;

    public static class NinjectExtensions
    {
        public static T GetNamedInstance<T>(this IResolutionRoot root, string fullName)
        {
            var allJobInstances = Program.Kernel.GetAll<T>();
            return allJobInstances.FirstOrDefault(x => x.ToString() == fullName);
        }
    }
}