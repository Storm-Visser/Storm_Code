import java.util.ArrayList;
import java.util.Iterator;
/**
* Write a description of class Pizza_Company here.
*
* @author (Storm)
* @version (1)
*/
public class Pizza_Company
{
    //variabelen
    private ArrayList<Employee> employees;
    //constructor
    public Pizza_Company()
    {
        this.employees = new ArrayList<>();
    }
    //methods
    //calcTotalCost
    public void calcTotalCost(int monthNr)
    {
        double total = 0.0; //de kosten opslaan
        double totalSalaryCost = 0.0;
        double totalRouteCost = 0.0;
        Iterator<Employee> it = this.employees.iterator();
        while(it.hasNext())
        {
            Employee employee = it.next();
            totalRouteCost += employee.calcTotalDistanceCost(monthNr);
            //per employee haal de totale reiskosten op
            totalSalaryCost += employee.calcMonthSalary(employee.getAge(), monthNr);
            //per employee het salaris ophalen
        }
        total = totalRouteCost + totalSalaryCost;
        totalRouteCost = totalRouteCost + 1 - 1;
        
        System.out.println("Total cost: ");
        System.out.println("Salary: " + totalSalaryCost + "0 $");
        System.out.println("Routes: "+ totalRouteCost + " $");
        System.out.println("Total: " + total + " $");
    }
    //getBestEmployeeDay
    public void getBestEmployeeDay()
    {
        //er wordt gerekend met de oudste employee omdat die het meeste per dag verdient
        int highestAge = 0;             //nodig om te rekenen
        String oldestEmployee = null;   //nodig om te rekenen
        double highestSalary = 0.0;     //nodig om te rekenen
        int count = 1;                  //nodig om aantal bij te houden
        Iterator<Employee> it = this.employees.iterator();
        while(it.hasNext())
        {
            Employee employee = it.next();  
            if(employee.getAge() == highestAge)
            {   //check eerst of het gelijk is 
                count += 1;
                highestSalary = employee.calcDailySalary(employee.getAge());
                //als het gelijk is sla het aantal gelijken op en daarna zet je het salaris
            } 
            else if(employee.getAge() > highestAge) 
            {
               oldestEmployee = employee.getName();
               //set de naam van de best verdienende employee(bestEmployee)
               highestSalary = employee.calcDailySalary(employee.getAge());
               //haal het salaris van die employee op
               highestAge = employee.getAge();
            }
        }
        if (count == 1)
        {
            System.out.println("The best employee is");
            System.out.println("Name: " + oldestEmployee);
            System.out.println("Salary: " + highestSalary + "0 $");
        } 
        else 
        {
            System.out.println("There are " + count + " best employees"); 
            System.out.println("Salary: " + highestSalary + "0 $");
        }
    }
    //getBestEmployeeMonth
    public void calcBestEmployeeMonth(int monthNr)
    {
        String bestEmployee = null;     //nodig om te rekenen
        double highestSalary = -1.0;    //nodig om te rekenen kan nooit gebeuren
        int count = 1;                  //nodig om aantal bij te houden
        Iterator<Employee> it = this.employees.iterator();
        while(it.hasNext())
        {
           Employee employee = it.next();  
           //kijk of het salaris van de opgehaalde employee
           //hoger is dan de hoogste tot nu toe(highestSalary) of gelijk is
           if(employee.calcMonthSalary(employee.getAge(), monthNr) == highestSalary)
           {   //check eerst of het gelijk is 
               count += 1;
               highestSalary = employee.calcMonthSalary(employee.getAge(), monthNr);
               //als het gelijk is sla het aantal gelijken op en daarna set je het salaris
           } 
           else if(employee.calcMonthSalary(employee.getAge(), monthNr) > highestSalary)
           {
               bestEmployee = employee.getName();
               //set de naam van de best verdienende employee(bestEmployee)
               highestSalary = employee.calcMonthSalary(employee.getAge(), monthNr);
               //haal het salaris van die employee op en set het salaris
           }    
        }
        
        if (count == 1)
        {
            System.out.println("The best employee is");
            System.out.println("Name: " + bestEmployee);
            System.out.println("Salary: " + highestSalary + "0 $");
        } else {
            System.out.println("There are " + count + " best employees"); 
            System.out.println("Salary: " + highestSalary + "0 $");
        }
    }
    //addEmployee
    public void addEmployee(Employee medewerker)
    {
        String naam = medewerker.getName();
        int age = medewerker.getAge();
        int check = 0;
        if(age > 14)
        {
            Iterator<Employee> it = this.employees.iterator();
            if(employees.size() > 0)
            {
                while(it.hasNext())
                {
                    Employee employee = it.next();
                    if (employee.getName() == medewerker.getName())
                    {
                        //loop door alle bestaande employees heen en check 
                        //of er al een employee met de gegeven naam bestaat
                        System.out.println("Employee not added");
                        System.out.println("Error: employee with this name already exists.");
                    }
                    else
                    {
                        check = 1;
                    }
                }
            }
            else
            {
                check = 1;
            }
        }
        else 
        {
            System.out.println("Employee not added");
            System.out.println("Error: employees must be 15 years old or older.");
        }
        // check of hij kan adden
        if (check == 1)
        {
            System.out.println("Employee succesfully added");
            System.out.println("Name: " + naam);
            System.out.println("Age: " + age);
            employees.add(medewerker);
        }
    }
    //removeEmployee
    public void removeEmployee(String name)
    {
        int removed = 0;
        Iterator<Employee> it = this.employees.iterator();
        if(it.hasNext())
        {
            while(it.hasNext())
            {
                Employee employee = it.next();
                if (employee.getName() .equals(name))
                {
                    //loop deoor alle employees heen, als de naam gelijk is
                    //aan de gegeven naam verwijder dan die employee
                    it.remove();
                    removed++;
                }
            }
        }
        else
        {
            System.out.println("Employee not removed");
            System.out.println("Error: there are no employees");
        }
        if (removed > 0) 
        {
            System.out.println("Employee succesfully removed");
            System.out.println("Name: " + name);
        } 
        else 
        {
            System.out.println("Employee not removed");
            System.out.println("Error: invalid name");
        }
    }
}