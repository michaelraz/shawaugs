using developwithpassion.specifications.extensions;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(Container))]
    public class ContainerSpecs
    {
        public abstract class concern : Observes
        {
        }

        public class when_providing_access_to_container_services : concern
        {
            Establish c = () =>
            {
                the_container_facade = fake.an<IFetchDependencies>();
                resolver = () => the_container_facade;
                spec.change(() => Container.facade_resolver).to(resolver);
            };
            Because b = () =>
                result = Container.fetch;

            It should_return_the_container_facade_that_has_been_configured = () =>
                result.ShouldEqual(the_container_facade);


            static IFetchDependencies result;
            static IFetchDependencies the_container_facade;
            static ContainerFacadeResolver resolver;
        }

        public class when_asked_for_an_object : concern
        {
            Establish c = () =>
            {
                the_container_facade = fake.an<IFetchDependencies>();
                resolver = () => the_container_facade;
                spec.change(() => Container.facade_resolver).to(resolver);
            };

            Because b = () =>
                Container.fetch.an<IMyObject>();

            It should_return_an_instance = () =>
                result.ShouldBeAn<IMyObject>();

            static IMyObject result;
            static IFetchDependencies the_container_facade;
            static ContainerFacadeResolver resolver;
        }

        interface IMyObject
        {
        }
    }
}