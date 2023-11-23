using System;

namespace MyAdapterPattern
{
    // Target interface
    interface ITarget
    {
        void PerformRequest();
    }

    // Adaptee
    class LegacySystem
    {
        public void LegacySpecificRequest()
        {
            Console.WriteLine("Legacy System's SpecificRequest called");
        }
    }

    // Adapter
    class Adapter : ITarget
    {
        private LegacySystem _legacySystem;

        public Adapter(LegacySystem legacySystem)
        {
            _legacySystem = legacySystem;
        }

        public void PerformRequest()
        {
            _legacySystem.LegacySpecificRequest();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Example usage
            LegacySystem legacySystem = new LegacySystem();
            ITarget adaptedSystem = new Adapter(legacySystem);
            adaptedSystem.PerformRequest();
        }
    }
}
