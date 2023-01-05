// See https://aka.ms/new-console-template for more information
new Client().Main();

abstract class Creator
{

    public abstract IImposto FactoryMethod();


    public string SomeCalculoDeImposto()
    {

        var product = FactoryMethod();

        var result = "Calculo global: "
            + product.CalculoDeImposto();
        return result;
    }
}


class BrasilCreator : Creator
{
    // Note that the signature of the method still uses the abstract product
    // type, even though the concrete product is actually returned from the
    // method. This way the Creator can stay independent of concrete product
    // classes.
    public override IImposto FactoryMethod()
    {
        return new Brasil();
    }
}

class ItaliaCreator : Creator
{
    public override IImposto FactoryMethod()
    {
        return new Italia();
    }
}


public interface IImposto
{
    string CalculoDeImposto();
}

// Concrete Products provide various implementations of the Product
// interface.
class Brasil : IImposto
{
    public string CalculoDeImposto()
    {
        return "Imposto do Brasil";
    }
}

class Italia : IImposto
{
    public string CalculoDeImposto()
    {
        return "Imposto da Italia";
    }
}

class Client
{
    public void Main()
    {
        Console.WriteLine("App: Launched with the BrasilCreator.");
        ClientCode(new BrasilCreator());

        Console.WriteLine("");

        Console.WriteLine("App: Launched with the ItaliaCreator.");
        ClientCode(new ItaliaCreator());

        Console.WriteLine("App: Launched with the ItaliaCreator.");
        ClientCode(new Italia());
    }

    // The client code works with an instance of a concrete creator, albeit
    // through its base interface. As long as the client keeps working with
    // the creator via the base interface, you can pass it any creator's
    // subclass.
    public void ClientCode(Creator creator)
    {
        // ...
        Console.WriteLine(creator.SomeCalculoDeImposto());
        // ...
    }

     public void ClientCode(IImposto imposto)
    {
        // ...
        Console.WriteLine(imposto.CalculoDeImposto());
        // ...
    }
}