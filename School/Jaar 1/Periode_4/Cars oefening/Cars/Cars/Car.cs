using System.Dynamic;

namespace Cars
{
    class Car
    {
        public Car(string Name, Engine engine, WheelType wheels, int weightKG)
        {
            this.Name = Name;
            Engine = engine;
            Wheels = wheels;
            WeightKG = weightKG;
        }
        public string Name { get; private set; }
        public Engine Engine { get; private set; }
        public WheelType Wheels { get; private set; }
        public int WeightKG { get; private set; }

        public double GetAcceleration()
        {
            int F = Engine.Pk;
            int M = this.WeightKG;
            double A = F / M;
            return A * Wheels.AccellerationFactor;
        }
    }
}
