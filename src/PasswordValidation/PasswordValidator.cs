namespace PasswordValidation;

public class PasswordValidator
{
    private readonly string password;

    public PasswordValidator(string password)
        => this.password = password;

    public bool IsValid()
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
}
