using PasswordValidation;
using PasswordValidation.Validators;

namespace PasswordValidationTest;

public class StandardPasswordValidationTests
{
    [Fact]
    public void ValidPassword()
        => AssertPassword("A1b2_C3d4", true);

    [Fact]
    public void LenghtMoreThan8()
        => AssertPassword("Ab_45678", false, "Password length must be greater than 8");

    [Fact]
    public void CapitalLetter()
        => AssertPassword("_aaaa1111", false, "The password must contain at least one capital letter");

    [Fact]
    public void Lowercase()
        => AssertPassword("_AAAA1111", false, "The password must contain at least one lowercase");

    [Fact]
    public void Number()
        => AssertPassword("_AAAAbbbb", false, "The password must contain at least one number");

    [Fact]
    public void Underscore()
        => AssertPassword("AAAAbbbb1", false, "The password must contain at least one underscore");

    private void AssertPassword(string password, bool isValid = false, string errorMessage = "")
    {
        PasswordValidator validator = PasswordValidatorFactory.MakeStandardValidator(password);
        Assert.Equal(isValid, validator.IsValid());
        if (errorMessage != "")
            Assert.Contains(errorMessage, validator.Errors);
    }
}