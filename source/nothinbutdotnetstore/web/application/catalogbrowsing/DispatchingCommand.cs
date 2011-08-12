using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class DispatchingCommand : IProcessAnApplicationBehaviour
    {
        IRenderReports report_engine;

        public DispatchingCommand(IRenderReports report_engine)
        {
            this.report_engine = report_engine;
        }

        public void process(IContainRequestInformation request)
        {
            report_engine.render(dispatch_to_controller);
        }
    }
}