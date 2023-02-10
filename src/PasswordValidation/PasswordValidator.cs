namespace PasswordValidation;

public abstract class PasswordValidator
{
    protected readonly string password;

    protected PasswordValidator(string password)
        => this.password = password;

    public abstract bool IsValid();
}
