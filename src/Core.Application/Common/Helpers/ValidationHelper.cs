namespace Core.Application.Common.Helpers;

public static class ValidationHelper
{
    /// <summary>
    /// E-posta adresi doğrulama.<br/>
    /// Validates an email address format.
    /// </summary>
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Telefon numarası doğrulama.<br/>
    /// Validates a phone number format.
    /// </summary>
    public static bool IsValidPhoneNumber(string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
            return false;

        return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^\+?[1-9]\d{1,14}$");
    }

    /// <summary>
    /// Şifre güçlülüğünü kontrol eder.<br/>
    /// Checks the strength of the password.
    /// </summary>
    public static bool IsPasswordStrong(string password)
    {
        if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
            return false;

        bool hasUpperCase = false;
        bool hasLowerCase = false;
        bool hasDigit = false;
        bool hasSpecialChar = false;

        foreach (var c in password)
        {
            if (char.IsUpper(c)) hasUpperCase = true;
            if (char.IsLower(c)) hasLowerCase = true;
            if (char.IsDigit(c)) hasDigit = true;
            if (!char.IsLetterOrDigit(c)) hasSpecialChar = true;
        }

        return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
    }
}
