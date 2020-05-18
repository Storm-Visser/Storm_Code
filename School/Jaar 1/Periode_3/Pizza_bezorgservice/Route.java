import java.util.ArrayList;
import java.util.Iterator;
/**
 * Write a description of class Route here.
 *
 * @author (Storm)
 * @version (1)
 */
public class Route
{
    //variabelen
    private double distance;
    private int monthNr;
    private int dayNr;
    private int id;
    private ArrayList<Pizza> pizzas;
    //constructor
   public Route(int distance, int monthNr, int dayNr, int id)
   {
       this.distance = distance;
       this.monthNr = monthNr;
       this.dayNr = dayNr;
       this.id = id;
       //arraylist aanmaken voor pi
   }
    //methods
    //getters
   public double getDistance()
   {
       return this.distance;
   }
   
   public int getMonthNr()
   {
       return this.monthNr;
   }
   
   public int getDayNr()
   {
       return this.dayNr;
   }
    //setters
   public void setDistance(double distance)
   {
       this.distance = distance;
   }
   
   public void setMonthNr(int monthNr)
   {
       this.monthNr = monthNr;
   }
   
   public void setDayNr(int dayNr)
   {
       this.dayNr = dayNr;
   }
   //methods
   //addpizza
   public void addPizza(double price)
   {
       pizzas.add(new Pizza(price));
       //ook remove functie
   }
   //getpizzaprice
   public double getPizzaPrice()
   {
       double total = 0.0;
       Iterator<Pizza> it = this.pizzas.iterator();
       while (it.hasNext())
       {
           Pizza pizza = it.next();
           total += pizza.getPrice();
       }
       return total;
   }
}
