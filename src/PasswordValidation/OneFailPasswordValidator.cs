using PasswordValidation.PasswordChecks;

namespace PasswordValidation;

public class OneFailPasswordValidator : PasswordValidator
{
    public List<string> Errors { get; init; }
    public int MinLength { get { return validator.MinLength; } set { validator.MinLength = value; } }
    private PasswordValidator validator;

    public OneFailPasswordValidator(string password)
    {
        validator = new StrictPasswordValidator(password);
        Errors = validator.Errors;
    }

    public bool IsValid()
    {
        bool isValid = validator.IsValid();

        if(isValid)
            return true;

        return validator.Errors.Count == 1;
    }

    public void AddCheck(PasswordCheck check)
        => validator.AddCheck(check);
}