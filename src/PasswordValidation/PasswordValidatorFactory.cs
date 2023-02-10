namespace PasswordValidation;

public static class PasswordValidatorFactory
{
    public static PasswordValidator MakeStandardValidator(string password)
        => new PasswordValidatorBuilder(password)
            .MustHaveMinLength(9)
            .MustHaveCapitalLetter()
            .MustHaveLowercase()
            .MustHaveNumber()
            .MustHaveUnderscore()
            .Build();
}