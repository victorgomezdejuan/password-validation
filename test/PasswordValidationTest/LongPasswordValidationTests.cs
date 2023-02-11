using PasswordValidation;

namespace PasswordValidationTest;

public class LongPasswordValidationTests
{
    [Fact]
    public void ValidPassword()
        => AssertPassword("Abcdefghijklmnop_", true);

    [Fact]
    public void LenghtMoreThan16()
        => AssertPassword("Abcdefghijklmno_");

    [Fact]
    public void CapitalLetter()
        => AssertPassword("abcdefghijklmnop_");

    [Fact]
    public void Lowercase()
        => AssertPassword("ABCDEFGHIJKLMNOP_");

    [Fact]
    public void Underscore()
        => AssertPassword("Abcdefghijklmnopq");

    private void AssertPassword(string password, bool isValid = false)
    {
        PasswordValidator validator = PasswordValidatorFactory.MakeLongValidator(password);
        Assert.Equal(isValid, validator.IsValid());
    }
}