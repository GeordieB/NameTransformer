namespace NameTransformer;

public static class Transformer
{
    private static readonly char[] _vowels = { 'a', 'e', 'i', 'o', 'u' };

    public static string? Transform(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            return null;

        if (!IsFullName(fullName))
            return fullName;

        var names = fullName.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

        return IsMultipleConsonantName(names) ? GetTransformedComplexName(names) :
            GetTransformedSimpleName(names);
    }

    private static bool IsFullName(string fullName)
    {
        return fullName.Contains(' ');
    }

    private static int FindFirstVowel(string name)
    {
        return name.ToLower().IndexOfAny(_vowels);
    }

    private static bool IsMultipleConsonantName(string[] names)
    {
        var firstNameFirstVowel = FindFirstVowel(names[0]);
        var lastNameFirstVowel = FindFirstVowel(names[1]);

        return firstNameFirstVowel > 1 || lastNameFirstVowel > 1;
    }

    private static string GetTransformedSimpleName(string[] names)
    {
        var firstName = $"{GetFirstLetter(names[1])}{names[0][1..]}";
        var lastName = $"{GetFirstLetter(names[0])}{names[1][1..]}";
        
        return $"{firstName} {lastName}";
    }

    private static string GetTransformedComplexName(string[] names)
    {
        var firstNameFirstVowel = FindFirstVowel(names[0]);
        var lastNameFirstVowel = FindFirstVowel(names[1]);

        var firstName =  $"{names[1][..lastNameFirstVowel]}{names[0][firstNameFirstVowel..]}";
        var lastName = $"{names[0][..firstNameFirstVowel]}{names[1][lastNameFirstVowel..]}";

        return $"{firstName} {lastName}";
    }

    private static char GetFirstLetter(string name)
    {
        return name[0];
    }
}
