namespace PasswordValidation;

public abstract class PasswordValidator
{
    protected readonly string password;

    protected PasswordValidator(string password)
        => this.password = password;

    public bool IsValid()
    {
        if (SomeRequirementNotMet())
            return false;

        return true;
    }

    protected abstract bool SomeRequirementNotMet();
}
