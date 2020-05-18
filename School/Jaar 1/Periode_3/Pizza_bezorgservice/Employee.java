import java.util.ArrayList;
import java.util.Iterator;
/**
 * Write a description of class Employee here.
 *
 * @author (Storm)
 * @version (1)
 */
public class Employee
{
    //variabelen
    private int age;
    private String name;
    private ArrayList<Route> routes;
    
    //constructor
    public Employee(int age, String name){
       if (age > 14)
       {
           this.age = age;
           this.name = name;
           this.routes = new ArrayList<>();
       }
       // else en else uit comany weg
    }
    //methods
    //getters
    public int getAge()
    {
        return this.age;
    }
    
    public String getName()
    {
        return this.name;
    }
    //setters
    public void setAge(int age)
    {
        this.age = age;
    }
    
    public void setName(String name)
    {
        this.name = name;
    }
    //addroute
    public void addRoute(int distance, int monthNr, int dayNr)
    {
        if (monthNr > 0 && monthNr <= 12)
        {
            if (distance > 0)
            {
                if (dayNr > 0 && dayNr <= 31)
                {
                    int id = routes.size() + 1;
                    routes.add(new Route(distance, monthNr, dayNr, id));
                    System.out.println("Route succesfully added");
                    System.out.println("id: " + id);
                    System.out.println("Distance: "+ distance);
                    System.out.println("date: " + dayNr + "/" + monthNr);
                } 
                else 
                {
                    System.out.println("Route not added");
                    System.out.println("Error: invalid day");
                }
            } 
            else 
            {
                System.out.println("Route not added");
                System.out.println("Error: distance too short");
            }
        } 
        else 
        {
            System.out.println("Route not added");
            System.out.println("Error: invalid month");
        }
    }
    //removeRoute
    public void removeRoute(int id)
    {
        if (id <= routes.size() && id >= 0)
        {
            id--;
            routes.remove(id);
            id++;
            System.out.println("Route removed");
            System.out.println("Id: " + id);
        } 
        else
        {
            System.out.println("Route not removed");
            System.out.println("Error: invalid id");
        }
    }
    //calcDailySalary
    public double calcDailySalary(int age)
    {
        double x = 0;       //nodig om te rekenen
        x  = age * 1.50;
        x -= 2.50;
        return x;
    }
    //calcMonthlSalary
    public double calcMonthSalary(int age, int monthNr)
    {
        double x = 0;
        int count = 0;
        Iterator<Route> it = this.routes.iterator();
        while(it.hasNext())
        {
            Route route = it.next();
            if (route.getMonthNr() == monthNr)
            {
                count++;
                // loopt door alle routes, als de route in de juiste maand zit
                // tel er een bij op zodat je het aantal routes krijgt
            }
        }
        x = calcDailySalary(age) * count;
        return x;
    }
    //calcTotalDistance
    public double calcTotalDistanceCost(int monthNr)
    {
        double total = 0.0;
        double pizzaCost = 0.0;
        Iterator<Route> it = this.routes.iterator();
        while(it.hasNext())
        {
            Route route = it.next();
            if (route.getMonthNr() == monthNr)
            {
                total += route.getDistance();
                // loopt door alle routes, als de route in de juiste maand zit
                // tel de afstand erbijop zodat de totale afstand wordt bijgehouden
            }
            pizzaCost += route.getPizzaPrice();
        }
        total *= 0.12;
        total -= pizzaCost;
        return total;
    }
}