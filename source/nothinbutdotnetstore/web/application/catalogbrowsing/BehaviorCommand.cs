using System;
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class BehaviorCommand<ModelType, ResponseType> : IProcessAnApplicationBehaviour
    {
        IRenderReports report_engine;
        IQueryFactory queryFactory;

        public BehaviorCommand(IRenderReports report_engine, IQueryFactory queryFactory)
        {
            this.report_engine = report_engine;
            this.queryFactory = queryFactory;
        }

        public BehaviorCommand()
            : this(Stub.of<StubReportEngine>(), Stub.of<StubQueryFactory>())
        {
        }

        public void process(IContainRequestInformation request)
        {
            report_engine.render(queryFactory.create<ModelType, ResponseType>().execute(request.map<ModelType>()));
        }
    }

    public interface IQueryFactory
    {
        IQuery<FilterType, ResponseType> create<FilterType, ResponseType>();
    }

    public class StubQueryFactory:IQueryFactory
    {
        public IQuery<FilterType, ResponseType> create<FilterType, ResponseType>()
        {
            throw new NotImplementedException();
        }
    }

    public interface IQuery<FilterType, ResponseType>
    {
        ResponseType execute(FilterType filter);
    }
}