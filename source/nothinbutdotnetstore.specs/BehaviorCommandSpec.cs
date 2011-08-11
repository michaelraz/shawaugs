using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(BehaviorCommand<,>))]
    public class BehaviorCommandSpec<ModelType, ResponseType>
    {
        public abstract class concern : Observes<IProcessAnApplicationBehaviour,
                                            BehaviorCommand<ModelType, ResponseType>>
        {
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                view_engine = depends.on<IRenderReports>();
                query_factory = depends.on<IQueryFactory>();
                the_query = fake.an<IQuery<ModelType, ResponseType>>();
                ResponseType repository = default(ResponseType);

                query_factory.setup(x=>x.create<ModelType, ResponseType>()).Return(the_query);
                the_query.setup(x=>x.execute(model_type)).Return((ResponseType) repository);
            };

            Because b = () =>
                sut.process(request);

            It should_pass_the_response_from_the_repository_to_the_view_engine_to_be_rendered = () =>
                view_engine.received(x => x.render(repository));

            static IContainRequestInformation request;
            static IRenderReports view_engine;
            static IQueryFactory query_factory;
            static IQuery<ModelType, ResponseType> the_query;
            static ModelType model_type;
            static ResponseType repository;
        }
    }
}