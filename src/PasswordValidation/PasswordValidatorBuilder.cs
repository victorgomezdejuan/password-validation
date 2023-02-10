namespace PasswordValidation;

internal class PasswordValidatorBuilder
{
    private PasswordValidator validator;

    internal PasswordValidatorBuilder(string password)
        => validator = new(password);

    internal PasswordValidatorBuilder MustHaveMinLength(int length)
    {
        validator.MinLength = length;
        validator.AddValidator(validator.IsLengthCorrect);
        return this;
    }

    internal PasswordValidatorBuilder MustHaveCapitalLetter()
    {
        validator.AddValidator(validator.HasAnyCapitalLetter);
        return this;
    }

    internal PasswordValidatorBuilder MustHaveLowercase()
    {
        validator.AddValidator(validator.HasAnyLowercase);
        return this;
    }

    internal PasswordValidatorBuilder MustHaveNumber()
    {
        validator.AddValidator(validator.HasAnyNumber);
        return this;
    }

    internal PasswordValidatorBuilder MustHaveUnderscore()
    {
        validator.AddValidator(validator.HasAnyUnderscore);
        return this;
    }

    internal PasswordValidator Build()
        => validator;
}