namespace Factory;

abstract class Transportation
{
    public abstract void Deliver();
}

class Car : Transportation
{
    public override void Deliver()
    {
        throw new NotImplementedException();
    }
}

class Airplane : Transportation
{
    public override void Deliver()
    {
        throw new NotImplementedException();
    }
}

class Ship : Transportation
{
    public override void Deliver()
    {
        throw new NotImplementedException();
    }
}

abstract class TransportationFactory
{
    public abstract Transportation Construct();
}

class CarFactory : TransportationFactory
{
    public override Transportation Construct()
    {
        return new Car();
    }
}

class AirplaneFactory : TransportationFactory
{
    public override Transportation Construct()
    {
        return new Airplane();
    }
}

class ShipFactory : TransportationFactory
{
    public override Transportation Construct()
    {
        return new Ship();
    }
}

internal static class Program
{
    private static void Main()
    {
        var car = new CarFactory().Construct();
        var ship = new ShipFactory().Construct();
        var airplane = new AirplaneFactory().Construct();
    }
}