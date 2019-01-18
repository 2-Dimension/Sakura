using System;
using System.Reflection;
using Sakura.Core.Event;

namespace Demo.Test
{
    public class SakuraTest
    {
        public static void Test()
        {
            Console.WriteLine(1.GetType().IsValueType);
            var obj = new SakuraListener();
            var obj2 = new SakuraListener2();
            EventBus.Default.Post(new Object());
            EventBus.Default.Post(new SakuraTest());
            EventBus.Default.Post("");
            EventBus.Default.Post(1);
            EventBus.Default.Post(1.1);
            EventBus.Default.Unregister(obj2);
            EventBus.Default.Post(new Object());
//            while (true)
//            {
//                var obj3 = new SakuraListener();
//                EventBus.Default.Post(new Object());
//                EventBus.Default.Unregister(obj3);
//            }
        }
        
        public void Callback(Object obj)
        {

        }
    }

    public class SakuraListener
    {
        public SakuraListener()
        {
            EventBus.Default.Register(this);
        }

        ~SakuraListener()
        {
            EventBus.Default.Unregister(this);
        }


        public void Test(object args)
        {
            Console.WriteLine("test");
        }

        [Subscribe]
        public void Callback(object args)
        {
            Console.WriteLine("test");
        }
    }

    public class SakuraListener2
    {
        public SakuraListener2()
        {
            EventBus.Default.Register(this);
        }

        ~SakuraListener2()
        {
            EventBus.Default.Unregister(this);
        }

        [Subscribe]
        public void Callback(object args)
        {
            Console.WriteLine("test2");
        }

        [Subscribe]
        public void Callback(SakuraTest args)
        {
            Console.WriteLine("test3");
        }

        [Subscribe]
        public void Callback(string args)
        {
            Console.WriteLine("test4");
        }

        [Subscribe]
        public void Callback(int args)
        {
            Console.WriteLine("test5");
        }

        [Subscribe]
        public void Callback(double args)
        {
            Console.WriteLine("test6");
        }
    }
}