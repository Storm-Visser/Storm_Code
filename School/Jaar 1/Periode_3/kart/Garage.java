import java.util.ArrayList;
import java.util.Iterator;
/**
 * Write a description of class Garage here.
 *
 * @author (your name)
 * @version (a version number or a date)
 */
public class Garage
{
    //Bereid de motor uit zodat deze een totaal afstand bij houd
    //Een Garage
    //Met allemaal karts
    //Ik wil een lijst returnen met alle karts die nog 25% batterij hebben (of minder)
    //Alle karts die meer dan 200 km hebben gereden moeten uit de garage worden verwijdert
    //Print een lijst met alle merken van de karts
    private ArrayList<Kart> karts;
    
    public Garage()
    {
        this.karts = new ArrayList<>();
    }
    
    public void getLowBattery()
    {
       Iterator<Kart> it = this.karts.iterator();
       int i = 1;
       while(it.hasNext())
       {
           Kart kart = it.next();
           double battery = kart.getEngine().getBatteryLevel();
           if (battery <= 25)
           {
               System.out.println("kart " + i + "has a baterrylevel of : " + battery + "%");
           }
           i++;
       }
    }
    
    public void addKart(Kart kart)
    {
       karts.add(kart);
    }
    
    public void getKartBrands()
    {
       Iterator<Kart> it = this.karts.iterator();
       int i = 1;
       while(it.hasNext())
       {
           Kart kart = it.next();
           System.out.println("kart " + i + " is from brand " + kart.getBrand());
           i++;
       }
    }
    
    public void removeKarts()
    {
       Iterator<Kart> it = this.karts.iterator();
       while(it.hasNext())
       {
           Kart kart = it.next();
           if (kart.getEngine().getDistance() > 200)
           {
               it.remove();
           }
       }
    }
    
    public void getKartDistance()
    {
       Iterator<Kart> it = this.karts.iterator();
       int i = 1;
       while(it.hasNext())
       {
           Kart kart = it.next();
           System.out.println("kart " + i + " drove a distance of " + kart.getEngine().getDistance());
           i++;
       }
    }
}
