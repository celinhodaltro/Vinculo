namespace Person.Domain.ValueObjects;

public class Cpf
{
    public string Value { get; }

    public Cpf(string value)
    {
        if (!IsValid(value))
            throw new Exception("CPF inválido");

        Value = value;
    }

    private bool IsValid(string cpf)
    {
        return !string.IsNullOrWhiteSpace(cpf) && cpf.Length == 11;
    }

    public override string ToString() => Value;
}
