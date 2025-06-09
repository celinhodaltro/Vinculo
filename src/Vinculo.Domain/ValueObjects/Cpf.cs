namespace Vinculo.Domain.ValueObjects;

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
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        var cpfWithOutAccentuations = cpf.Replace("-", "").Replace(".", "").Replace(" ", "");

        return !string.IsNullOrWhiteSpace(cpfWithOutAccentuations) && cpfWithOutAccentuations.Length == 11;
    }

    public override string ToString() => Value;
}
