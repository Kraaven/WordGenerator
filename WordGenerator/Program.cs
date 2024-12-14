using System.ComponentModel;

static class Program
{
    private static Random _random = new Random();
    static Dictionary<Char, List<Char>> CharacterProbabilities = new Dictionary<char, List<char>>();

    private static List<Char> RawLetters = new List<char>()
    {
        'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
        'w', 'x', 'y', 'z'
    };

    public static void Main()
    {

        var Words = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(),
            "Resources" + Path.DirectorySeparatorChar + "WordLib.txt"));
        
        Console.WriteLine(Words.Length);
        InitCharDictionary();

        for (int x=0; x<Words.Length; x++)
        {
            var word = Words[x];
            int i = word.Length;
            Console.WriteLine($"Processing Word {word} with Index {x} with Letter Count {i}");
            if(i==1) continue;
            word = word.ToLower();
            for (int j = 0; j < i-1; j++)
            {
                CharacterProbabilities[word[j]].Add(word[j+1]);
            }
        }

        for (int i = 0; i < 30; i++)
        {
            Console.WriteLine(GenerateWord());
        }
        

        char check = 'j';
        Console.WriteLine($"Displaying Probabilities for {check}");
        Console.WriteLine(string.Join(',', CharacterProbabilities[check]));
        
        
        
    }


    static void InitCharDictionary()
    {
        CharacterProbabilities.Add('a', new List<char>());
        CharacterProbabilities.Add('b', new List<char>());
        CharacterProbabilities.Add('c', new List<char>());
        CharacterProbabilities.Add('d', new List<char>());
        CharacterProbabilities.Add('e', new List<char>());
        CharacterProbabilities.Add('f', new List<char>());
        CharacterProbabilities.Add('g', new List<char>());
        CharacterProbabilities.Add('h', new List<char>());
        CharacterProbabilities.Add('i', new List<char>());
        CharacterProbabilities.Add('j', new List<char>());
        CharacterProbabilities.Add('k', new List<char>());
        CharacterProbabilities.Add('l', new List<char>());
        CharacterProbabilities.Add('m', new List<char>());
        CharacterProbabilities.Add('n', new List<char>());
        CharacterProbabilities.Add('o', new List<char>());
        CharacterProbabilities.Add('p', new List<char>());
        CharacterProbabilities.Add('q', new List<char>());
        CharacterProbabilities.Add('r', new List<char>());
        CharacterProbabilities.Add('s', new List<char>());
        CharacterProbabilities.Add('t', new List<char>());
        CharacterProbabilities.Add('u', new List<char>());
        CharacterProbabilities.Add('v', new List<char>());
        CharacterProbabilities.Add('w', new List<char>());
        CharacterProbabilities.Add('x', new List<char>());
        CharacterProbabilities.Add('y', new List<char>());
        CharacterProbabilities.Add('z', new List<char>());

    }

    static char GetRandomValue(this List<Char> chars)
    {
        return chars[_random.Next() % chars.Count];
    }

    static string GenerateWord()
    {
        int WordLength = (_random.Next() % 9) + 3;
        Char InitLetter = RawLetters.GetRandomValue();
        string Word = "";
        // Word += InitLetter;

        char current = InitLetter;
        char next = ' ';
        for (int i = 0; i < WordLength-1; i++)
        {
            next = CharacterProbabilities[current].GetRandomValue();
            Word += current;
            current = next;
        }

        return Word;
    }
}