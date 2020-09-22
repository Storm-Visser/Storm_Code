class airport
{
    constructor(name)
    {
        this.name = name;
        this.flights = [];
    }

    getName()
    {
        return this.name;
    }

    setName(name)
    {
        this.name = name;
    }

    getFlights()
    {
        for(let i = 0; i < this.flights.length; i++)
        {
            return this.flights[i];
        }
    }

    getFlight(number)
    {
        for(let i = 0; i < this.flights.length; i++)
        {
            if(this.flight[i].flightNr = number)
            {
                return this.flights[i];
            }
            return "there are no flights with this number";
        }
        
    }
    addFlight(flight)
    {
        this.flights.push[flight];
    }
}
class flight
{
    constructor(flightNr, airplane, destination, departure, cost, distanceKM)
    {
        this.flightNr = flightNr;
        this.cost = cost;
        this.departure = departure;
        this.destination = destination;
        this.distanceKM = distanceKM;
        this.airplane = airplane;
        this.costumers = [];
    }
    getFlightNr()
    {
        return this.flightNr;
    }
    getAirplane()
    {
        return this.airplane;
    }
    getCost()
    {
        return this.cost;
    }
    getDeparture()
    {
        return this.departure;
    }
    getDestination()
    {
        return this.destination;
    }
    getDistance()
    {
        return this.distanceKM;
    }
    getCostumers()
    {
        for(let i = 0; i <= this.costumers.length; i++)
        {
            return this.costumers[i];
        }
    }
    
    getCostumers(number)
    {
        for(let i = 0; i < this.costumers.length; i++)
        {
            if(this.costumers[i].name = number)
            {
                return this.costumers[i];
            }
            return "there are no customers with this name";
        }
        
    }

    calcDurationMin()
    {
        let AVGSpeedMS = this.airplane.getAVGSpeed() / 3.6;
        let distanceM = this.distanceKM * 100;
        return distanceM/AVGSpeedMS/60;
    }
}
class customer
{
    constructor(name, age)
    {
        this.name = name;
        this.age = age;
    }
    getName()
    {
        return this.name;
    }
    getAge()
    {
        return this.age;
    }
    setName(name)
    {
        this.name = name;
    }
    setAge(age)
    {
        this.age = age;
    }
}
class airplane
{
    constructor(model, AVGSpeedKMPH)
    {
        this.model = model;
        this.AVGSpeedKMPH = AVGSpeedKMPH;
    }
    getModel()
    {
        return this.model;
    }
    getAVGSpeed()
    {
        return this.AVGSpeedKMPH;
    }
    setModel(model)
    {
        this.model = model;
    }
    setAVGSpeed(AVGSpeedKMPH)
    {
        this.AVGSpeedKMPH = AVGSpeedKMPH;
    }
}