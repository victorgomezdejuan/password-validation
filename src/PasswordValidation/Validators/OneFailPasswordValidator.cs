using PasswordValidation.PasswordChecks;

namespace PasswordValidation.Validators;

public class OneFailPasswordValidator : PasswordValidator
{
    public override List<string> Errors { get { return validator.Errors; } }
    private PasswordValidator validator;

    public OneFailPasswordValidator(string password) : base(password)
        => validator = new PasswordValidator(password);

    public override bool IsValid()
    {
        bool isValid = validator.IsValid();

        if (isValid)
            return true;

        return validator.Errors.Count == 1;
    }

    public override void AddCheck(PasswordCheck check)
        => validator.AddCheck(check);
}