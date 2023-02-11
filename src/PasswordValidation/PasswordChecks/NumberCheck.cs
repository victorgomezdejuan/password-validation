namespace PasswordValidation.PasswordChecks;

internal class NumberCheck : PasswordCheck
{
    internal NumberCheck() : base() { }

    internal override bool IsValid(string password)
    {
        if (password.Any(char.IsDigit))
            return true;

        Error = "The password must contain at least one number";
        return false;
    }
}