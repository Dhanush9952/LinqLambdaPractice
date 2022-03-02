using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqLambdaPractice
{
    public delegate void MyDelegate(string msg);
    public delegate void Notify();
    class Program
    {
        static void Main(string[] args)
        {
            List<int> num = new List<int>()
                            { 1,2,3,4,5,6,7,2,5,3,2,6,7,10,12,1,2 };
            List<int> distinct = num.Distinct().ToList();
            foreach (var n in distinct)
            {
                System.Console.WriteLine(n);
            }

            Test test = new Test();
            test.TestEvent();

            MyDelegate del = ClassA.MethodA;
            del("Hello World");

            del = ClassB.MethodB;
            del("Hello World");

            del = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            del("Hello World");

            DateTime now = DateTime.Now;
            System.Console.WriteLine(now);

            var theGalaxies = new List<Galaxy>
        {
            new Galaxy() { Name="Tadpole", MegaLightYears=400},
            new Galaxy() { Name="Pinwheel", MegaLightYears=25},
            new Galaxy() { Name="Milky Way", MegaLightYears=0},
            new Galaxy() { Name="Andromeda", MegaLightYears=3}
        };

            var frog = from g in theGalaxies
                       where g.Name.StartsWith("P")
                       select g.Name;
            System.Console.WriteLine("P found !!! ");

            foreach (var t in frog)
            {
                System.Console.WriteLine("Name starting with P is: {0}",t);
            }

            foreach (Galaxy theGalaxy in theGalaxies)
            {
                Console.WriteLine(theGalaxy.Name + "  " + theGalaxy.MegaLightYears);
            }

        }


        public event Notify ProcessCompleted; // event

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            // some code here..
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted() //protected virtual method
        {
            //if ProcessCompleted is not null then call delegate
            ProcessCompleted?.Invoke();
        }
    }


    public class Galaxy
    {
        public string Name { get; set; }
        public int MegaLightYears { get; set; }
    }

    public class MyTest
    {
        public event EventHandler MyEvent
        {
            add
            {
                Console.WriteLine("add operation");
            }
            remove
            {
                Console.WriteLine("remove operation");
            }
        }
    }
    public class Test
    {
        public void TestEvent()
        {
            MyTest myTest = new MyTest();
            myTest.MyEvent += myTest_MyEvent;
            myTest.MyEvent -= myTest_MyEvent;
        }
        public void myTest_MyEvent(object sender, EventArgs e)
        {
        }
    }

    class ClassA
    {
        internal static void MethodA(string message)
        {
            Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
        }

    }

    class ClassB
    {
        internal static void MethodB(string message)
        {
            Console.WriteLine("Called ClassB.MethodB() with parameter: " + message);
        }
    }
}
