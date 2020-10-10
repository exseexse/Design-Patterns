
using System;
//Yeni bir sey eklenmek istendi.
//The Bridge pattern provides an alternative to inheritance 
//when there is more than one version of abstraction. 
namespace RefactoringGuru.DesignPatterns.Bridge.Conceptual
{

    public abstract class Abstraction
    {
        public Bridge NewImplementation { get; set; }

        public virtual void Operation()
        {
            Console.WriteLine("ImplementationBase:Operation()");
            NewImplementation.OperationImplementation();
        }
    }

    public class RefinedAbstractionA : Abstraction
    {
        public override void Operation()
        {
            Console.WriteLine("RefinedAbstraction:Operation()");
            NewImplementation.OperationImplementation();
        }
    }

    public class RefinedAbstractionB : Abstraction
    {
        public override void Operation()
        {
            Console.WriteLine("RefinedAbstraction:Operation()");
            NewImplementation.OperationImplementation();
        }
    }

    public interface Bridge
    {
        void OperationImplementation();
    }

    public class ImplementationA : Bridge
    {
        public void OperationImplementation()
        {
            Console.WriteLine("ImplementationA:OperationImplementation()");
        }
    }

    public class ImplementationB : Bridge
    {
        public void OperationImplementation()
        {
            Console.WriteLine("ImplementationB:OperationImplementation()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bridge email = new ImplementationA();
            Bridge queue = new ImplementationB();
         

            Abstraction message = new RefinedAbstractionA();
            message.NewImplementation = email;
            message.Operation();

            Abstraction message2 = new RefinedAbstractionB();
            message2.NewImplementation = queue;
            message2.Operation();

            Console.ReadKey();
        }
    }
}
