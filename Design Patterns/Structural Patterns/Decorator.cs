using System;
//farklı farklı şapkalar
//Decorator pattern is used to add new functionality to an existing 
//object without changing its structure.
namespace RefactoringGuru.DesignPatterns.Decorator.Conceptual
{
    /// <summary>
    /// The 'Component' interface
    /// </summary>
    public interface Component
    {
        string ComponentProp1 { get; }
        string ComponentProp2 { get; }
        string ComponentProp3 { get; }

        void Operation();
    }

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    public class ConcreteComponent : Component
    {
        public string ComponentProp1
        {
            get { return "ComponentProp1"; }
        }

        public string ComponentProp2
        {
            get { return "ComponentProp2"; }
        }

        public string ComponentProp3
        {
            get { return "ComponentProp3"; }
        }

        public void Operation()
        {
            Console.WriteLine("Component Operation");
        }
    }

 
    public abstract class Decorator : Component
    {
        private Component _component;

        public Decorator(Component component)
        {
            _component = component;
        }

        public string ComponentProp1
        {
            get { return _component.ComponentProp1; }
        }

        public string ComponentProp2
        {
            get { return _component.ComponentProp2; }
        }

        public string ComponentProp3
        {
            get { return _component.ComponentProp3; }
        }
        public virtual void Operation()
        {
            _component.Operation();
        }
    }


    public class ConcreteDecorator : Decorator
    {
        public ConcreteDecorator(Component component) : base(component) { }

        public string ConcreteDecoratorProp1 { get; set; }
        public string ConcreteDecoratorProp2 { get; set; }

        public string ConcreteDecoratorProp3
        {
            get
            {
                return base.ComponentProp3;
            }
        }

    }

    /// <summary>
    /// Decorator Pattern Demo
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        
            ConcreteComponent concreteComponent = new ConcreteComponent();

            Console.WriteLine("ComponentProp3", concreteComponent.ComponentProp3);

        
            ConcreteDecorator offer = new ConcreteDecorator(concreteComponent);
            offer.ConcreteDecoratorProp1 = "ConcreteDecoratorProp1";
            offer.ConcreteDecoratorProp2 = "ConcreteDecoratorProp2";

            Console.WriteLine("{1}  {0} ", offer.ConcreteDecoratorProp3, offer.ConcreteDecoratorProp2);

            Console.ReadKey();

        }
    }
}
