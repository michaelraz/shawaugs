namespace nothinbutdotnetstore.web.core
{
    public class Stub
    {
        public static TheStubImplementation of<TheStubImplementation>() where TheStubImplementation:new()
        {
            return new TheStubImplementation();
        } 

    }
}