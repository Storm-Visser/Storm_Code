
/**
 * Write a description of class Wheel here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class Wheel
{
    private int gripPercentage;
    private String brand;
    private int diameter;
    
    public Wheel(String brand, int diameter)
    {
        this.brand = brand;
        this.diameter = diameter;
        this.gripPercentage = 100;
    }
    //getters
    public int getGrip()
    {
        return gripPercentage;
    }
    
    public String getBrand()
    {
        return brand;
    }
    
    public int getDiameter()
    {
        return diameter;
    }
    //mutators
    public void setGripPercentage(int newGripPercentage)
    {
        this.gripPercentage = newGripPercentage;
    }
}
