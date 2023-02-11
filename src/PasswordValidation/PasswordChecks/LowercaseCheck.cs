namespace PasswordValidation.PasswordChecks;

internal class LowercaseCheck : PasswordCheck
{
    internal LowercaseCheck() : base() { }

    internal override bool IsValid(string password)
    {
        if (password.Any(char.IsLower))
            return true;

        Error = "The password must contain at least one lowercase";
        return false;
    }
}