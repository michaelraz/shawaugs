using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : IFindCommandsThatCanProcessRequests
    {
        readonly IEnumerable<IProcessOneSpecificRequest> commands;

        public CommandRegistry(IEnumerable<IProcessOneSpecificRequest> commands)
        {
            this.commands = commands;
        }

        public IProcessOneSpecificRequest get_command_for(IContainRequestInformation the_request)
        {
            foreach (var command in commands.Where(command => command.can_process(the_request)))
            {
                return command;
            }

            return new NullCommand();
        }
    }

    public class NullCommand : IProcessOneSpecificRequest
    {
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