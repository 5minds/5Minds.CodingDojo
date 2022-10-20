using System;

namespace Infrastructure.Module
{
    public abstract class BaseModule : IModule
    {
        public string ModuleName { get; set; } = "Module name not set";

        public BaseModule(string moduleName)
        {
            ModuleName = moduleName;
        }

        public void Run()
        {
            Console.WriteLine("\n{0}", ModuleName);

            Process();

            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
        }

        protected virtual void Process()
        {
            throw new NotImplementedException("Process has not been implemented!");
        }
    }
}
