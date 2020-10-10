using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Design_Patterns.BridgeNew
{
    public abstract class ReadingApp
    {
        protected IDisplayFormatter displayformatter;
        public ReadingApp(IDisplayFormatter displayformatter)
        {
            this.displayformatter = displayformatter;
        }

        public string Text { get; set; }
        public abstract void Display();
    }

    public class Windows8App : ReadingApp
    {
        public Windows8App(IDisplayFormatter displayFormatter) : base(displayFormatter)
        {
        }

        public override void Display()
        {
            displayformatter.Display("This is for Windows8\n" + Text);
        }
    }

    public class Windows10App : ReadingApp
    {
        public Windows10App(IDisplayFormatter displayFormatter) : base(displayFormatter)
        {
        }

        public override void Display()
        {
            displayformatter.Display("This is for Windows10\n" + Text);
        }
    }

    public interface IDisplayFormatter
    {
        void Display(string text);
    }

    public class NormalDisplay : IDisplayFormatter
    {
        public void Display(string text)
        {
            Console.WriteLine(text);
        }
    }

    public class ReverseDisplay : IDisplayFormatter
    {
        public void Display(string text)
        {
            Console.WriteLine(new String(text.Reverse().ToArray()));
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ReadingApp readingApp = new Windows10App(new NormalDisplay()) { Text = "Read this text" };
            readingApp.Display();

            ReadingApp readingAppon8 = new Windows8App(new NormalDisplay()) { Text = "Read this text" };
            readingAppon8.Display();

            ReadingApp readingAppR = new Windows10App(new ReverseDisplay()) { Text = "Read this text" };
            readingAppR.Display();

            ReadingApp readingAppon8R = new Windows8App(new ReverseDisplay()) { Text = "Read this text" };
            readingAppon8R.Display();
        }
    }
}
