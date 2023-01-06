Considerações

A classe abstrata `Creator` serve mais para caso as classes tenham um processo, ou uma implementação em comum.

Dessa forma você tem o método específico de cada classe, definido pela interface `IImposto`,
o `Creator` usa o resultado deste método em seu próprio método (que acaba sendo comun à todos as classes), e no final
você pode criar um método que receba uma instância de `Creator` e assim poderá executar o método de específico de `Creator`.

Creator da Classe concreta. Neste ponto, de ter um Creator só para retornar uma instância de 'Brasil', por exemplo, ficou meio sem sentido.
Talvez neste cenário mais simples não faça sentido mesmo, porém podem existir casos do Creator retornar um objeto mais rico, com mais especialidades.
ou até mesmo terem diferentes Creators da classe Brasil, com objetos com outros valores. Enfim. É uma ideia.


Abstract Factory é um conjunto de Factory Methods. É legal utilizar quando se tem uma família de objetos com relações entre si.

Builder é um Pattern parecido mas com steps, ou seja, posso montar meu objeto por etapas, assim posso entregar várias versões da mesma classe.
Ótimo para aquelas classes que possue vários parâmetros opcionais. 


Prototype é basicamente um Pattern para clonar seu objeto.

```
public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return (Person) this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person clone = (Person) this.MemberwiseClone();
            clone.IdInfo = new IdInfo(IdInfo.IdNumber);
            clone.Name = String.Copy(Name);
            return clone;
        }
    }
    
```

