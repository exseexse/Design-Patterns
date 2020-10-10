using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Design_Patterns.BridgeOld
{
    public class ReadingApp
    {
        public string Text { get; set; }

        public virtual void Display()
        {
            Console.WriteLine(Text);
        }

        public virtual void ReverseDisplay()
        {
            Console.WriteLine(new String(Text.Reverse().ToArray()));
        }
    }

    public class Windows8App : ReadingApp
    {
        public override void Display()
        {
            Console.WriteLine("Display in windows 8");
            base.Display();
        }

        public override void ReverseDisplay()
        {
            Console.WriteLine("Reverse display in windows 8".Reverse());
            base.ReverseDisplay();
        }
    }

    public class Windows10App : ReadingApp
    {
        public override void Display()
        {
            Console.WriteLine("Display in windows 10");
            base.Display();
        }

        public override void ReverseDisplay()
        {
            Console.WriteLine("Reverse display in windows 10".Reverse());
            base.ReverseDisplay();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            ReadingApp readingApp = new Windows10App() { Text = "Read this text" };
            readingApp.Display();

            ReadingApp readingAppon8 = new Windows8App() { Text = "Read this text" };
            readingAppon8.Display();

            Console.Read();
        }
    }
}
