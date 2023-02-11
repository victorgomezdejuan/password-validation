using PasswordValidation.PasswordChecks;

namespace PasswordValidation;

public interface PasswordValidator
{
    List<string> Errors { get; init; }
    int MinLength { get; set; }

    bool IsValid();

    void AddCheck(PasswordCheck check);
}
