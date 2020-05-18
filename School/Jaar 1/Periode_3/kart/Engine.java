
/**
 * Write a description of class engine here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class Engine
{
    public double batteryLevel;
    public double usagePerKm;
    private String brand;
    private int torque;
    private boolean running;
    public int totalDistance;
    
    public Engine(double usagePerKm, String brand, int torque)
    {
        this.batteryLevel = 100.0;
        this.running = false;
        this.usagePerKm = usagePerKm;
        this.brand = brand;
        this.torque = torque;
    }
    
    public int getDistance()
    {
        return totalDistance;
    }
    
    public boolean isRunning()
    {
        return this.running;
    }
    
    public void setRunning(boolean running)
    {
        this.running = running;
    }
    
    public double getBatteryLevel()
    {
        return batteryLevel;
    }
    
    public void driveDistance(int distance){
        this.batteryLevel = this.batteryLevel - (distance * this.usagePerKm);     
        this.totalDistance = this.totalDistance + distance;
    }
}
