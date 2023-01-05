Considerações

A classe abstrata `Creator` serve mais para caso as classes tenham um processo, ou uma implementação em comum.

Dessa forma você tem o método específico de cada classe, definido pela interface `IImposto`,
o `Creator` usa o resultado deste método em seu próprio método (que acaba sendo comun à todos as classes), e no final
você pode criar um método que receba uma instância de `Creator` e assim poderá executar o método de específico de `Creator`.

Creator da Classe concreta. Neste ponto, de ter um Creator só para retornar uma instância de 'Brasil', por exemplo, ficou meio sem sentido.
Talvez neste cenário mais simples não faça sentido mesmo, porém podem existir casos do Creator retornar um objeto mais rico, com mais especialidades.
ou até mesmo terem diferentes Creators da classe Brasil, com objetos com outros valores. Enfim. É uma ideia.

```

new Client().Main();

abstract class Creator
{
    // Método de criação dos objetos das classes que implementam a interface IImposto
    public abstract IImposto FactoryMethod();

    // Método comum à todas as classes que implementam a interface IImposto
    public string SomeCalculoDeImposto()
    {

        var product = FactoryMethod();

        var result = "Calculo global: "
            + product.CalculoDeImposto();
        return result;
    }
}

// Creator da Classe 'Brasil'. Neste ponto, de ter um Creator só para retornar uma instância de 'Brasil' que ficou meio sem sentido.
// Talvez neste cenário mais simples não faça sentido mesmo, porém podem existir casos do Creator retornar um objeto mais rico, com mais especialidades.
// Ou até mesmo terem diferentes Creator da classe Brasil, com objetos com outros valores. Enfim. É uma ideia.
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
    string CalculoDeImposto();
}

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

```
