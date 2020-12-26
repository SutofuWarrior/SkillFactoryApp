using System;

namespace Snadbox
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var client = new Client();
            var sender = new Sender<int>();

            sender.SomeEvent += client.Foo;
            sender.SomeEvent -= client.Foo;
            Console.WriteLine(sender.SenderFoo());

            Console.ReadKey();
        }
    }

    class Client
    {
        public int Foo(string str) 
            => str.Length;
    }

    class Sender<T>
    {
        public delegate T MyHandler(string str);
        public event MyHandler SomeEvent;

        public T SenderFoo()
        {
            if (SomeEvent != null)
                return SomeEvent.Invoke("Some string");
            else
                return default;
        }
    }
}
