using System;

namespace MyProxyPattern
{
    // Subject
    interface IResource
    {
        void Access();
    }

    // RealSubject
    class RealResource : IResource
    {
        public void Access()
        {
            Console.WriteLine("RealResource's Access called");
        }
    }

    // Proxy
    class AccessProxy : IResource
    {
        private RealResource _realResource;

        public void Access()
        {
            if (_realResource == null)
            {
                _realResource = new RealResource();
            }

            Console.WriteLine("AccessProxy is managing access.");
            _realResource.Access();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage
            IResource proxyResource = new AccessProxy();
            proxyResource.Access();
        }
    }
}
