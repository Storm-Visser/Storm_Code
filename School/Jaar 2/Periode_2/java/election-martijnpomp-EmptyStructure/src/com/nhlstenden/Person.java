package com.nhlstenden;

import java.time.LocalDate;
import java.time.Period;
import java.time.format.DateTimeFormatter;

public class Person
{
    private String name;
    private LocalDate dateOfBirth;

    public Person(String name, String  dateOfBirth)
    {
        this.name = name;
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("yyyy-MM-dd");
        this.dateOfBirth = LocalDate.parse(dateOfBirth, dtf);
    }

    public String getName()
    {
        return this.name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public LocalDate getDateOfBirth()
    {
        return this.dateOfBirth;
    }

    public void setDateOfBirth(LocalDate dateOfBirth)
    {
        this.dateOfBirth = dateOfBirth;
    }

    protected int getAge()
    {
        return Period.between(dateOfBirth, LocalDate.now()).getYears();
    }
}
