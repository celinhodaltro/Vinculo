using Core.Domain.Entities.Base;
using Vinculo.Domain.ValueObjects;

namespace Vinculo.Domain.Entities;

public class Person : AggregateRoot
{
    public string Name { get; private set; }
    public Cpf Cpf { get; private set; }
    public int Age { get; private set; }

    public Person(string name, Cpf cpf, int age)
    {
        Name = name;
        Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
        Age = age;
    }

    public Person() { }
    
}
