Considerações

A classe abstrata `Creator` serve mais para caso as classes tenham um processo, ou uma implementação em comum.
Dessa forma você tem o método específico de cada classe, definido pela interface `IImposto`,
o `Creator` usa o resultado deste método em seu próprio método (que acaba sendo comun à todos as classes), e no final
você pode criar um método que receba uma instância de `Creator` e assim poderá executar o método de específico de `Creator`.