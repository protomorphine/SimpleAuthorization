using System.Text;
using System.Security.Cryptography;

namespace SimpleAuthorization.Core.Extensions;

/// <summary>
/// Метод расшиерния для вычисления SHA265 хэша строки
/// </summary>
internal static class ComputeHashExtensions
{
    public static string ComputeSha256Hash(this string st)
    {
        using var sha = new SHA256Managed();

        var stBytes = Encoding.UTF8.GetBytes(st);
        var hashedStBytes = sha.ComputeHash(stBytes);

        return BitConverter.ToString(hashedStBytes, 0, hashedStBytes.Length).Replace("-", String.Empty);
    }
}

