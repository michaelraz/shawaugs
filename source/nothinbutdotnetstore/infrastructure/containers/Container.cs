using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class Container
    {
        public static ContainerFacadeResolver facade_resolver = delegate
        {
            throw new NotImplementedException("The container has no configured facade resolver. This should be configured at startup");
        };

        public static IFetchDependencies fetch
        {
            get { return facade_resolver(); }
        }
    }
}