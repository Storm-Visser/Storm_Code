import java.util.ArrayList;
import java.util.Iterator;
/**
 * Write a description of class Kart here.
 *
 * @author (Storm)
 * @version (06/02/2020)
 */
public class Kart
{
   private int number;
   private int amountOfWheels;//next lesson
   private int topSpeed;
   private String brand;
   //float is minder precies en double is precieser
   private float weight;
   private Engine engine;
   private ArrayList<Wheel>wheels;
   
   
   public Kart(int kartNumber, int topSpeed, String brand, float weight)
   {
       this.number = kartNumber;
       this.topSpeed = topSpeed;
       this.brand = brand;
       this.weight = weight;
       this.amountOfWheels = 0;
       this.engine = null;
       this.wheels = new ArrayList<>();
   }
   
   public String getBrand()
   {
       return brand;
   }
   
   public void addWheel(String brand, int diameter)
   {
       if(amountOfWheels>=4)
       {
           System.out.println("er zijn al vier wielen");
       }
       else
       {
           wheels.add(new Wheel(brand, diameter));
           this.amountOfWheels = wheels.size();
       }
   }
   
   public void pitstop(String brand, int diameter)
   {
       int nececary = 4 - wheels.size();
       for (int i = nececary; i > 0; i--) {
           wheels.add(new Wheel(brand, diameter));
       }
       this.amountOfWheels = wheels.size();
   }
   //voeg 1 wheels toe              x
   //voeg meer wheels toe           x
   //arraylist heeft add functie    x
   //band afbreek methode           x
   //voeg een band toe              x
   public void removeWheels(int amount)
   {
       int numberOfWheels = wheels.size();
       if(numberOfWheels >= amount)
       {
           for (int i = 0; i < amount; i++) 
           {
               wheels.remove(0);
           }
       }
       else
       {
           System.out.println("You cant remove more wheels than the kart has.");
       }
   }
    
   public void removeBrandTires(String brand)
   {
       Iterator<Wheel> it = this.wheels.iterator();   //set een itterator met wheels genaamd "it", en zet hem gelijk aan de array
       while(it.hasNext())                            //checkt of er een volgende is
       {
           Wheel wheel = it.next();                   // haal de volgende op
           if (wheel.getBrand() .equals(brand))             //kijk welke band het gevraagde merk heeft
           {
               it.remove();                           //verwijder de band
           }
       }
   }
   
   public void setNumber(int number)
   {
           this.number = number;
   }
   
   public Engine getEngine()
   {
       return this.engine;
   }
   
   public void setengine(double usagePerKm, String brand, int torque)
   {
       this.engine = new Engine(usagePerKm, brand, torque);
   }
   
   public void setSpeed(int speed)
   {
       this.topSpeed = speed;
   }
   
   public void setBrand(String brand)
   {
       this.brand = brand;
   }
   
   public void setWeight(float weight)
   {
       this.weight = weight;
   }
   
   public void setAmountOfWheels(String brand, int diameter, int amount)
   {
       if(amount <= 4 && amount >= 0)
       {
           wheels.clear();
           for (int i = amount; i > 0; i--) 
           {
               wheels.add(new Wheel(brand, diameter));
           }
           this.amountOfWheels = wheels.size();
       }
       else
       {
           System.out.println("you cant add that many wheels, there can only be four.");
       }
   }
   
   public double getBatteryLevel()
   {
       return this.engine.getBatteryLevel();
   }
   
   public int getAmountOfWheels()
   {
      return wheels.size();//aanpassen  x
   }
   
   public void driveDistance(int distance)
   {
       if (this.engine != null)
       {
           this.engine.driveDistance(distance);
       }
       else
       {
           System.out.println("Er is nog geen motor.");
       }
   }
}
