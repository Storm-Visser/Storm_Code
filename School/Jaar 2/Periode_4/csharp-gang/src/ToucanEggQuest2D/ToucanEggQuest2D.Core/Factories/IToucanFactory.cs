namespace ToucanEggQuest2D.Core.Factories
{
    public interface IToucanFactory
    {
        Toucan Create(ToucanFactoryModel model);
        string[] Names();
    }

    public class ToucanFactoryModel
    {
        public string Name { get; set; }
        public int Lives { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}