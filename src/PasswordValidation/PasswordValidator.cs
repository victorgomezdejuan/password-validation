using PasswordValidation.PasswordChecks;

namespace PasswordValidation;

public class PasswordValidator
{
    public List<string> Errors { get; init; }
    internal int MinLength { private get; set; }
    private readonly string password;
    private readonly List<PasswordCheck> checks;

    internal PasswordValidator(string password)
    {
        this.password = password;
        MinLength = 0;
        checks = new();
        Errors = new();
    }

    public bool IsValid()
    {
        bool result = true;

        foreach(PasswordCheck check in checks)
        {
            if (!check.IsValid(password))
            {
                result = false;
                Errors.Add(check.Error);
            }
        }

        return result;
    }

    internal void AddCheck(PasswordCheck check)
        => checks.Add(check);
}