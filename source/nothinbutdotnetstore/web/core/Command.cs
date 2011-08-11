using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.core {
    public class Command : IProcessOneSpecificRequest {
        public void process(IContainRequestInformation the_request)
        {
            throw new NotImplementedException();
        }

        public bool can_process(IContainRequestInformation request)
        {
            throw new NotImplementedException();
        }
    }
}
