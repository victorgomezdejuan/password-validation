using PasswordValidation.PasswordChecks;

namespace PasswordValidation.Validators;

public class OneFailPasswordValidator : PasswordValidator
{
   public OneFailPasswordValidator(string password) : base(password) {}

    public override bool IsValid()
    {
        bool isValid = base.IsValid();

        if (isValid)
            return true;

        return Errors.Count == 1;
    }
}