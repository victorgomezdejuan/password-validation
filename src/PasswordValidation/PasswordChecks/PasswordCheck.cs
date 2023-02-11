namespace PasswordValidation.PasswordChecks;

internal abstract class PasswordCheck
{
    internal string Error { get; set; }

    protected PasswordCheck()
    {
        Error = "";
    }

    internal abstract bool IsValid(string password);
}