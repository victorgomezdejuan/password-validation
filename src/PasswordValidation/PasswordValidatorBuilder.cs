using PasswordValidation.PasswordChecks;
using PasswordValidation.Validators;

namespace PasswordValidation;

internal class PasswordValidatorBuilder
{
    private PasswordValidator validator;

    internal PasswordValidatorBuilder(string password, bool allowOneFail = false)
        => validator = allowOneFail ?
            new OneFailPasswordValidator(password) : new PasswordValidator(password);

    internal PasswordValidatorBuilder MustHaveMinLength(int length)
    {
        validator.MinLength = length;
        validator.AddCheck(new MinLengthCheck(length));
        return this;
    }

    internal PasswordValidatorBuilder MustHaveCapitalLetter()
    {
        validator.AddCheck(new CapitalLetterCheck());
        return this;
    }

    internal PasswordValidatorBuilder MustHaveLowercase()
    {
        validator.AddCheck(new LowercaseCheck());
        return this;
    }

    internal PasswordValidatorBuilder MustHaveNumber()
    {
        validator.AddCheck(new NumberCheck());
        return this;
    }

    internal PasswordValidatorBuilder MustHaveUnderscore()
    {
        validator.AddCheck(new UnderscoreCheck());
        return this;
    }

    internal PasswordValidator Build()
        => validator;
}