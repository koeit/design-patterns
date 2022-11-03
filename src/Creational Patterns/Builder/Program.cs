namespace Builder;

// example 1 ##########################################################################################################
class Engine {}
class Wheel {}
class Car
{
    public string? Brand { get; set; }
    public int Seats { get; set; }
    public int PS { get; set; }

    public List<Wheel>? Wheels { get; set; }
    public Engine? Engine { get; set; }
}

/* In the build class there are build methods, these take over individual steps of the construction of the car.
 The methods that are really needed should be called, the order does not matter. */ 
class CarBuilder
{
    private Car car;

    public CarBuilder()
    {
        car = new Car();
    }

    public CarBuilder SetPs(int ps)
    {
        car.PS = ps;
        return this;
    }

    public CarBuilder SetBrand(string? brand)
    {
        car.Brand = brand;
        return this;
    }
    
    public CarBuilder SetSeats(int seatsCount)
    {
        car.Seats = seatsCount;
        return this;
    }

    public Car GetProduct()
    {
        return car;
    }
}

// end example 1 #######################################################################################################

// example 2 ###########################################################################################################
// "abstract" class: an implementation is missing or incomplete
// a class will be marked as "abstract" if the class is only the base class for another class and should not be instantiated itself.
abstract class Builder
{
    // protected member can be accessed within it's class and from instances of derived class
    protected Car car;

    public Car? GetProduct()
    {
        return car;
    }

    // abstract marked members must be implemented by classes that derive from the abstract class
    public abstract Builder SetBrand(string brand);
}

class BMWBuilder : Builder
{
    public BMWBuilder()
    {
        car = new Car();
    }

    // override modifier is needed to extend or modify the abstract or virtual implementation.
    public override Builder SetBrand(string brand)
    {
        car.Brand = brand;
        return this;
    }
}

class Director
{
    public Car BuildBMW()
    {
        return new CarBuilder()
            .SetBrand("BMW")
            .SetPs(400)
            .SetSeats(2)
            .GetProduct();
    } 
    
    public Car BuildAudi()
    {
        return new CarBuilder()
            .SetBrand("Audi")
            .SetPs(700)
            .SetSeats(2)
            .GetProduct();
    }
}
// end example 2 #######################################################################################################

// "internal" class can be accessed within a file or in the same assembly
internal class Program
{
    static void Main(string[] args)
    {
        // example 1
        var builder = new CarBuilder();
        var car = builder
            .SetBrand("BMW")
            .SetPs(400)
            .SetSeats(2)
            .GetProduct();
        
        // example 2
        var bmwCar = new Director().BuildBMW();
        var audiCar = new Director().BuildAudi();
        
        Console.WriteLine(audiCar.PS);
        Console.Read();
    }
}