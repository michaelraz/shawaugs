namespace nothinbutdotnetstore.web.core
{
    public interface IProvideReportTemplates
    {
        IReportTemplate<Model> get_template_for<Model>(Model data);
    }
}