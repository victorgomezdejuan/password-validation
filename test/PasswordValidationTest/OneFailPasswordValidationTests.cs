using PasswordValidation;

namespace PasswordValidationTest;

public class OneFailPasswordValidationTests
{
    [Fact]
    public void ValidPassword()
        => AssertPassword("A_1234567", true);

    [Fact]
    public void LenghtMoreThan8()
        => AssertPassword("A_123456", true, "Password length must be greater than 8");

    [Fact]
    public void CapitalLetter()
        => AssertPassword("a_1234567", true, "The password must contain at least one capital letter");

    [Fact]
    public void Number()
        => AssertPassword("A_bcdefgh", true, "The password must contain at least one number");

    [Fact]
    public void Underscore()
        => AssertPassword("Ab1234567", true, "The password must contain at least one underscore");

    [Fact]
    public void TwoFails()
    {
        PasswordValidator validator = PasswordValidatorFactory.MakeOneFailValidator("ab1234567");
        
        Assert.Equal(false, validator.IsValid());
        Assert.Contains("The password must contain at least one capital letter", validator.Errors);
        Assert.Contains("The password must contain at least one underscore", validator.Errors);
    }

    private void AssertPassword(string password, bool isValid = false, string errorMessage = "")
    {
        PasswordValidator validator = PasswordValidatorFactory.MakeOneFailValidator(password);
        Assert.Equal(isValid, validator.IsValid());
        if (errorMessage != "")
            Assert.Contains(errorMessage, validator.Errors);
    }
}