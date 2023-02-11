using PasswordValidation;
using PasswordValidation.Validators;

namespace PasswordValidationTest;

public class ShortPasswordValidationTests
{
    [Fact]
    public void ValidPassword()
        => AssertPassword("Ab12345", true);

    [Fact]
    public void LenghtMoreThan6()
        => AssertPassword("Ab1234", false, "Password length must be greater than 6");

    [Fact]
    public void CapitalLetter()
        => AssertPassword("ab12345", false, "The password must contain at least one capital letter");

    [Fact]
    public void Lowercase()
        => AssertPassword("AB12345", false, "The password must contain at least one lowercase");

    [Fact]
    public void Number()
        => AssertPassword("Abcdefgh", false, "The password must contain at least one number");

    private void AssertPassword(string password, bool isValid = false, string errorMessage = "")
    {
        PasswordValidator validator = PasswordValidatorFactory.MakeShortValidator(password);
        Assert.Equal(isValid, validator.IsValid());
        if (errorMessage != "")
            Assert.Contains(errorMessage, validator.Errors);
    }
}