using PasswordValidation;
using PasswordValidation.Validators;

namespace PasswordValidationTest;

public class LongPasswordValidationTests
{
    [Fact]
    public void ValidPassword()
        => AssertPassword("Abcdefghijklmnop_", true);

    [Fact]
    public void LenghtMoreThan16()
        => AssertPassword("Abcdefghijklmno_", false, "Password length must be greater than 16");

    [Fact]
    public void CapitalLetter()
        => AssertPassword("abcdefghijklmnop_", false, "The password must contain at least one capital letter");

    [Fact]
    public void Lowercase()
        => AssertPassword("ABCDEFGHIJKLMNOP_", false, "The password must contain at least one lowercase");

    [Fact]
    public void Underscore()
        => AssertPassword("Abcdefghijklmnopq", false, "The password must contain at least one underscore");

    private void AssertPassword(string password, bool isValid = false, string errorMessage = "")
    {
        PasswordValidator validator = PasswordValidatorFactory.MakeLongValidator(password);
        Assert.Equal(isValid, validator.IsValid());
        if (errorMessage != "")
            Assert.Contains(errorMessage, validator.Errors);
    }
}