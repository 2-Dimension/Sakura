using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using Sakura.Core.Event;
using Sakura.Extensions;
using Xunit;

namespace SakuraTest
{
    public class UnitTest1
    {
        //        SakuraListener listener = new SakuraListener();

        [Fact]
        public void Test1()
        {
            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
            var thread = new Thread(ThreadExec);
            thread.Start();

            var obj = new SakuraListener();
            var obj2 = new SakuraListener2();
            EventBus.Default.Post(new Object());
            EventBus.Default.Post("");
            EventBus.Default.Post(1);
            EventBus.Default.Post(1.1);
            EventBus.Default.Unregister(obj2);
            EventBus.Default.Post(new Object());

        }


        [Fact]
        public void Test2()
        {
            while (true)
            {
                var obj = new SakuraListener();
                EventBus.Default.Post(1);
                EventBus.Default.Unregister(obj);
            }
        }


        [Fact]
        public void Test3()
        {
            var a = Add(1, 2);
            Trace.WriteLine("Hello World!" + a);
        }


        [DllImport("Cpp.dll")]
        private static extern int Add(int n1, int n2);

        private void ThreadExec()
        {

            Trace.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        public class SakuraListener
        {
            public SakuraListener()
            {
                EventBus.Default.Register(this);
            }

            ~SakuraListener()
            {
                //                EventBus.Default.Unregister(this);
                //                Trace.WriteLine("SakuraListener.Deinit");
            }

            public void Test(object args)
            {
                Trace.WriteLine("test");
            }

            [Subscribe]
            public void Callback(int args)
            {
                Trace.WriteLine("test");
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
                //            EventBus.Default.Unregister(this);
            }

            [Subscribe]
            public void Callback(object args)
            {
                Trace.WriteLine("test2");
            }

            [Subscribe]
            public void Callback(string args)
            {
                Trace.WriteLine("test4");
            }

            [Subscribe]
            public void Callback(int args)
            {
                Trace.WriteLine("test5");
            }

            [Subscribe]
            public void Callback(double args)
            {
                Trace.WriteLine("test6");
            }
        }
    }
}
