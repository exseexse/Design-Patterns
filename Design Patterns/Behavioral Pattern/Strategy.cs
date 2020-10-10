using System;
using System.Collections.Generic;
using System.Text;
//This pattern allows a client to choose an algorithm from a family 
//of algorithms at run-time and gives it a simple way to access it.
namespace RefactoringGuru.DesignPatterns.Strategy.Conceptual
{
    public class Client
    {
        public IStrategy Strategy { get; set; }

        public void CallAlgorithm()
        {
            Console.WriteLine(Strategy.Algorithm());
        }
    }

    public interface IStrategy
    {
        string Algorithm();
    }

    public class ConcreteStrategyA : IStrategy
    {
        public string Algorithm()
        {
            return "Concrete Strategy A";
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public string Algorithm()
        {
            return "Concrete Strategy B";
        }
    }

}
