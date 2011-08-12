using System.Web;
using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public interface IReportTemplate<Model> : IHttpHandler
    {
        Model model { get; set; }
    }

    public class ReportTemplate<Model> : Page,IReportTemplate<Model>
    {
        public Model model { get; set; }
    }
}