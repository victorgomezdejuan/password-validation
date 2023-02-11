namespace PasswordValidation.PasswordChecks;

internal class MinLengthCheck : PasswordCheck
{
    private readonly int minLength;

    internal MinLengthCheck(int minLength) : base()
        => this.minLength = minLength;

    internal override bool IsValid(string password)
    {
        if (password.Length >= minLength)
            return true;

        Error = $"Password length must be greater than {minLength - 1}";
        return false;
    }
}