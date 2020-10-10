

using System;
using System.Collections;
using System.Collections.Generic;
//iki listeyi birbiriyle merge etme
//Composite pattern is used to separate abstraction from its 
//implementation so that both can be modified independently.
namespace RefactoringGuru.DesignPatterns.Composite.Conceptual
{

    public interface Component
    {
        int prop1 { get; set; }
        string prop2 { get; set; }

        void Operation();
    }


    public class Composite : Component, IEnumerable<Component>
    {
        private List<Component> _children = new List<Component>();

        public int prop1 { get; set; }
        public string prop2 { get; set; }

        public void AddChild(Component child)
        {
            _children.Add(child);
        }

        public void RemoveChild(Component child)
        {
            _children.Remove(child);
        }

        public Component GetChild(int index)
        {
            return _children[index];
        }

        public IEnumerator<Component> GetEnumerator()
        {
            foreach (Component subordinate in _children)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Operation()
        {
            string message = string.Format("Composite with {0} child(ren)", _children.Count);
            Console.WriteLine(message);
        }
    }


    public class Leaf : Component
    {
        public int prop1 { get; set; }
        public string prop2 { get; set; }

        public void Operation()
        {
            Console.WriteLine("Leaf");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Composite Rahul = new Composite { prop1 = 1, prop2 = "Rahul" };

            Composite Amit = new Composite { prop1 = 2, prop2 = "Amit" };
            Composite Mohan = new Composite { prop1 = 3, prop2 = "Mohan" };

            Rahul.AddChild(Amit);
            Rahul.AddChild(Mohan);

            Composite Rita = new Composite { prop1 = 4, prop2 = "Rita" };
            Composite Hari = new Composite { prop1 = 5, prop2 = "Hari" };

            Amit.AddChild(Rita);
            Amit.AddChild(Hari);

            Composite Kamal = new Composite { prop1 = 6, prop2 = "Kamal" };
            Composite Raj = new Composite { prop1 = 7, prop2 = "Raj" };

            Leaf Sam = new Leaf { prop1 = 8, prop2 = "Sam" };
            Leaf tim = new Leaf { prop1 = 9, prop2 = "Tim" };

            Mohan.AddChild(Kamal);
            Mohan.AddChild(Raj);
            Mohan.AddChild(Sam);
            Mohan.AddChild(tim);

            Console.WriteLine("prop1={0}, prop2={1}", Rahul.prop1, Rahul.prop2);

            foreach (Composite manager in Rahul)
            {
                Console.WriteLine("\n prop1={0}, prop2={1}", manager.prop1, manager.prop2);

                foreach (var employee in manager)
                {
                    Console.WriteLine(" \t prop1={0}, prop2={1}", employee.prop1, employee.prop2);
                }
            }
            Console.ReadKey();
        }
    }
}
