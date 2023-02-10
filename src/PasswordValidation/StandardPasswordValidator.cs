namespace PasswordValidation;

public class StandardPasswordValidator : PasswordValidator
{
    public StandardPasswordValidator(string password) : base(password) { }

    public override bool IsValid()
    {
        if (SomeRequirementNotMet())
            return false;

        return true;
    }

    private bool SomeRequirementNotMet()
    {
        return NoMinLength() ||
                    NoCapitalLetter() ||
                    NoLowercase() ||
                    NoNumber() ||
                    NoUnderscore();
    }

    private bool NoMinLength()
        => password.Length < 9;

    private bool NoCapitalLetter()
        => !password.Any(char.IsUpper);

    private bool NoLowercase()
        => !password.Any(char.IsLower);

    private bool NoNumber()
        => !password.Any(char.IsDigit);

    private bool NoUnderscore()
        => !password.Contains("_");

    public override bool Equals(object? obj)
        => base.Equals(obj);

    public override int GetHashCode()
        => base.GetHashCode();

    public override string? ToString()
        => base.ToString();
}
