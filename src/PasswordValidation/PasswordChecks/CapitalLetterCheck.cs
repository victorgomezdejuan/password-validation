namespace PasswordValidation.PasswordChecks;

internal class CapitalLetterCheck : PasswordCheck
{
    internal CapitalLetterCheck() : base() { }

    internal override bool IsValid(string password)
    {
        if (password.Any(char.IsUpper))
            return true;

        Error = "The password must contain at least one capital letter";
        return false;
    }
}