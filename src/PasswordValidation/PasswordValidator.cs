namespace PasswordValidation;

public class PasswordValidator
{
    internal int MinLength { get; set; }
    private readonly string password;
    internal delegate bool Validator();
    private readonly List<Validator> validators;

    internal PasswordValidator(string password)
    {
        this.password = password;
        MinLength = 0;
        validators = new();
    }

    public bool IsValid()
    {
        foreach(Validator validator in validators)
        {
            if (!validator())
                return false;
        }

        return true;
    }

    internal void AddValidator(Validator validator)
        => validators.Add(validator);

    internal bool IsLengthCorrect()
        => password.Length >= MinLength;

    internal bool HasAnyCapitalLetter()
        => password.Any(char.IsUpper);

    internal bool HasAnyLowercase()
        => password.Any(char.IsLower);

    internal bool HasAnyNumber()
        => password.Any(char.IsDigit);

    internal bool HasAnyUnderscore()
        => password.Contains("_");
}