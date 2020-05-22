namespace Cars
{
    class WheelType
    {
        public WheelType(string type, double accellerationFactor, double maxspeedfactor)
        {
            this.Type = type;
            this.AccellerationFactor = accellerationFactor;
            this.MaxSpeedFactor = maxspeedfactor;
        }
        public string Type { get; private set; }
        public double AccellerationFactor { get; private set; }
        public double MaxSpeedFactor { get; private set; }
    }
}
