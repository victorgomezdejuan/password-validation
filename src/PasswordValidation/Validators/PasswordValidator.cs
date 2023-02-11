using PasswordValidation.PasswordChecks;

namespace PasswordValidation.Validators;

public class PasswordValidator
{
    public virtual List<string> Errors { get { return _errors; } }
    public int MinLength { get; set; }
    private readonly string password;
    private readonly List<PasswordCheck> checks;
    private readonly List<string> _errors;

    internal PasswordValidator(string password)
    {
        this.password = password;
        MinLength = 0;
        checks = new();
        _errors = new();
    }

    public virtual bool IsValid()
    {
        bool result = true;

        foreach (PasswordCheck check in checks)
        {
            if (!check.IsValid(password))
            {
                result = false;
                _errors.Add(check.Error);
            }
        }

        return result;
    }

    public virtual void AddCheck(PasswordCheck check)
        => checks.Add(check);
}