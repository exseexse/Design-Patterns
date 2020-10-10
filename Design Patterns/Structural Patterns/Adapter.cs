
using System;
using System.Collections.Generic;
//Aracı kullanarak list içindeki itemlare  hat ekleme
//The Adapter Design pattern allows a system to use classes of another system 
//that is incompatible with it. It is especially used for toolkits and libraries. 
namespace RefactoringGuru.DesignPatterns.Adapter.Conceptual
{
    public class Client
    {
        private ITarget target;

        public Client(ITarget target)
        {
            this.target = target;
        }

        public void MakeARequest()
        {
            List<string> childList = target.MethodA();

            Console.WriteLine("######### childList ##########");
            foreach (var item in childList)
            {
                Console.Write(item);
            }

        }
    }


    public interface ITarget
    {
        List<string> MethodA();
    }


    public class Adaptee
    {
        public string[][] MethodB()
        {
            string[][] children = new string[4][];

            children[0] = new string[] { "1", "A", "AA" };
            children[1] = new string[] { "2", "B", "BB" };
            children[2] = new string[] { "3", "C", "BB" };
            children[3] = new string[] { "4", "D", "DD" };

            return children;
        }
    }


    public class Adapter : Adaptee, ITarget
    {
        public List<string> MethodA()
        {
            List<string> childList = new List<string>();
            string[][] children = MethodB();
            foreach (string[] child in children)
            {
                childList.Add(child[0]);
                childList.Add(",");
                childList.Add(child[1]);
                childList.Add(",");
                childList.Add(child[2]);
                childList.Add("\n");
            }

            return childList;
        }
    }

 
    class Program
    {
        static void Main(string[] args)
        {
            ITarget Itarget = new Adapter();
            Client client = new Client(Itarget);
            client.MakeARequest();

            Console.ReadKey();

        }
    }
}
