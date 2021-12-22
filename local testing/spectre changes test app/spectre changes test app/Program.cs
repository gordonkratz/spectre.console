using System;
using Spectre.Console;

namespace spectre_changes_test_app
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var input = AnsiConsole.Prompt(new TextSelectionPrompt<string>().Title("Test input").AddChoices("one", "two", "dog", "apple"));
                AnsiConsole.WriteLine($"Selected {input}");
            }
        }
    }
}
