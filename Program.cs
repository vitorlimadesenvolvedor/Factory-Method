// See https://aka.ms/new-console-template for more information
new Client().Main();

abstract class Creator
{

    public abstract IImposto FactoryMethod();


    public string SomeCalculoDeImposto(decimal valor)
    {

        var product = FactoryMethod();

        var result = $"taxa : {product.CalculoDeImposto(valor)}";
        return result;
    }
}


class BrasilCreator : Creator
{
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
    decimal CalculoDeImposto(decimal valor);
}

class Brasil : IImposto
{
    private const decimal Taxa = 5.1m; 

    public decimal CalculoDeImposto(decimal valor)
    {
        return (valor * (Taxa/100)) + valor;
    }
}

class Italia : IImposto
{
    private const decimal Taxa = 8.1m; 
    
    public decimal CalculoDeImposto(decimal valor)
    {
        return (valor * (Taxa/100)) + valor;
    }
}

class Client
{
    public void Main()
    {
        Console.WriteLine("App: Launched with the BrasilCreator.");
        ClientCode(new BrasilCreator(), 10);

        Console.WriteLine("App: Launched with the ItaliaCreator.");
        ClientCode(new ItaliaCreator(), 10);

    }

    public void ClientCode(Creator creator, decimal valor)
    {
        // ...
        Console.WriteLine(creator.SomeCalculoDeImposto(valor));
        // ...
    }

}