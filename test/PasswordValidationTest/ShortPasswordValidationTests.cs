using PasswordValidation;

namespace PasswordValidationTest;

public class ShortPasswordValidationTests
{
    [Fact]
    public void ValidPassword()
        => AssertPassword("Ab12345", true);

    [Fact]
    public void LenghtMoreThan6()
        => AssertPassword("Ab1234");

    [Fact]
    public void CapitalLetter()
        => AssertPassword("ab12345");

    [Fact]
    public void Lowercase()
        => AssertPassword("AB12345");

    [Fact]
    public void Number()
        => AssertPassword("Abcdefgh");

    private void AssertPassword(string password, bool isValid = false)
    {
        PasswordValidator validator = PasswordValidatorFactory.MakeShortValidator(password);
        Assert.Equal(isValid, validator.IsValid());
    }
}