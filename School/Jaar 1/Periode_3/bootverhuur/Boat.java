
/**
 * Write a description of class Boot here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class Boat
{
    private int weight;
    private int horsePower;
    private double length;
    private double price;//per hour
    private int id;
    
    public Boat(int weight, int horsepower, double priceperhour, double length, int id)
    {
        this.weight = weight;
        this.horsePower = horsepower;
        this.length = length;
        this.price = priceperhour;
        this.id = id;
    }
}
