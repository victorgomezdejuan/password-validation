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

    public static PasswordValidator MakeShortValidator(string password)
        => new PasswordValidatorBuilder(password)
            .MustHaveMinLength(7)
            .MustHaveCapitalLetter()
            .MustHaveLowercase()
            .MustHaveNumber()
            .Build();

    public static PasswordValidator MakeLongValidator(string password)
        => new PasswordValidatorBuilder(password)
            .MustHaveMinLength(17)
            .MustHaveCapitalLetter()
            .MustHaveLowercase()
            .MustHaveUnderscore()
            .Build();
}