 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{  
    [Subject(typeof(ViewMainDepartmentsInTheStore))]  
    public class ViewMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<IProcessAnApplicationBehaviour,
                                            ViewMainDepartmentsInTheStore>
        {
        
        }

   
        public class when_processing_a_request : concern
        {
        
            It first_observation = () =>        
                
        }
    }
}
