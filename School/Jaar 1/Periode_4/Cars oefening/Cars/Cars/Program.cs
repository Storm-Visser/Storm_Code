using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Cars
{
    class Program
    {
        static void Main()
        {
            //declare the engines
            Engine EngineType1 = new Engine("Porche GT150", 340);
            Engine EngineType2 = new Engine("Tesla E100", 400);
            Engine EngineType3 = new Engine("Ferrari R45", 280);
            //declare the wheeltypes
            WheelType Type1 = new WheelType("Michelin 23", 0.8, 1.2);
            WheelType Type2 = new WheelType("SpaceX Y23", 1.4, 0.9);
            WheelType Type3 = new WheelType("Ferrari GT 230", 0.5, 2.1);
            //make the cars
            Car Car1 = new Car("Porche", EngineType1, Type1, 120);
            Car Car2 = new Car("Tesla", EngineType2, Type2, 140);
            Car Car3 = new Car("Ferrari", EngineType3, Type3, 100);
            //echo the contendors with info
            Console.WriteLine("the contendors are:");
            Console.WriteLine("{0} with engine {1} and wheeltype {2}", Car1.Name, Car1.Engine.Name, Car1.Wheels.Type);
            Console.WriteLine("{0} with engine {1} and wheeltype {2}", Car2.Name, Car2.Engine.Name, Car2.Wheels.Type);
            Console.WriteLine("{0} with engine {1} and wheeltype {2}", Car3.Name, Car3.Engine.Name, Car3.Wheels.Type);
            Console.WriteLine();
            //race the cars
            double time1 = 100 / Car1.GetAcceleration();
            double time2 = 100 / Car2.GetAcceleration();
            double time3 = 100 / Car3.GetAcceleration();
            //echo results
            Console.WriteLine("the results are:");
            Console.WriteLine("{0} with a time of {1} seconds", Car1.Name, time1);
            Console.WriteLine("{0} with a time of {1} seconds", Car2.Name, time2);
            Console.WriteLine("{0} with a time of {1} seconds", Car3.Name, time3);
            Console.WriteLine();
            //check the winner
            double[] Times = {time1, time2, time3};
            // Finding fastest
            double fastest = Times.Max();
            // what time is the fastest
            int carNr = Array.IndexOf(Times, fastest);
            //echo the winner
            Console.WriteLine("the winner is:");
            switch(carNr)
            {
                case 1:
                    Console.WriteLine("{0}", Car1.Name);
                    break;
                case 2:
                    Console.WriteLine("{0}", Car2.Name);
                    break;
                case 3:
                    Console.WriteLine("{0}", Car3.Name);
                    break;
            }
            Console.ReadLine();
            
        }
    }
}
