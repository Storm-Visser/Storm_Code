namespace Cars
{
    class Engine
    {
        public Engine(string Name, int pk)
        {
            this.Name = Name;
            this.Pk = pk;
        }

        public string Name { get; private set; }
        public int Pk { get; private set; }
    }
}
