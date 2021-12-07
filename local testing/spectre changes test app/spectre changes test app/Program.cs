using System;
using Spectre.Console;

namespace spectre_changes_test_app
{
    class Program
    {
        static void Main(string[] args)
        {
            AnsiConsole.Prompt(new TextSelectionPrompt<string>().Title("Test input").AddChoices("one", "two", "dog", "apple"));
        }
    }
}
