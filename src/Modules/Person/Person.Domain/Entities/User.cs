using Core.Domain.Entities.Base;
using Person.Domain.ValueObjects;

namespace Person.Domain.Entities;

public class User : AggregateRoot
{
    public string Name { get; private set; }
    public Cpf Cpf { get; private set; }
    public int Age { get; private set; }

    public User(string name, Cpf cpf, int age)
    {
        Name = name;
        Cpf = cpf ?? throw new ArgumentNullException(nameof(cpf));
        Age = age;
    }

    public User() { }
    
}
