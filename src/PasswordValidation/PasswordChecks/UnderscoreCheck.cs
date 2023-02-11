namespace PasswordValidation.PasswordChecks;

internal class UnderscoreCheck : PasswordCheck
{
    internal UnderscoreCheck() : base() { }

    internal override bool IsValid(string password)
    {
        if (password.Contains("_"))
            return true;

        Error = "The password must contain at least one underscore";
        return false;
    }
}