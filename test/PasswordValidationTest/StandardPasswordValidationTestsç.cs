using PasswordValidation;

namespace PasswordValidationTest;

public class StandardPasswordValidationTests
{
    [Fact]
    public void ValidPassword()
        => AssertPassword("A1b2_C3d4", true);

    [Fact]
    public void LenghtMoreThan8()
        => AssertPassword("12345678");

    [Fact]
    public void CapitalLetter()
        => AssertPassword("_aaaa1111");

    [Fact]
    public void Lowercase()
        => AssertPassword("_AAAA1111");

    [Fact]
    public void Number()
        => AssertPassword("_AAAAbbbb");

    [Fact]
    public void Underscore()
        => AssertPassword("AAAAbbbb1");

    private void AssertPassword(string password, bool isValid = false)
    {
        PasswordValidator validator = PasswordValidatorFactory.MakeStandardValidator(password);
        Assert.Equal(isValid, validator.IsValid());
    }
}