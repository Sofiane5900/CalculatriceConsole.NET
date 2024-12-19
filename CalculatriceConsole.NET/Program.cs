using Spectre.Console;
using Spectre.Console.Cli;

// Valeur de base
List<double> listNombres = new List<double>();

do
{
    AnsiConsole.Write(
        new FigletText("Calculatrice.NET")
            .Color(Color.Red));

    var choix = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Quel option [green]choisissez-vous[/]?")
            .PageSize(10)
            .MoreChoicesText("[grey](Utilisez les flèches pour naviguer)[/]")
            .AddChoices(new[] {
                "Saisie des nombres", "Addition", "Soustraction",
                "Multiplication", "Division", "Quitter"
            }));

    switch (choix)
    {
        case "Quitter": // Quitter l'application
            Environment.Exit(0);
            break;
        case "Saisie des nombres": // Saisie des nombres
            Console.Clear();
            int compteur = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Saisir les notes ---");
            Console.WriteLine("(999 pour stopper la saisie) \n");
            Console.ResetColor();
            while (true)
            {
                Console.Write($"Merci de saisir le nombre {compteur + 1}: ");
                double nombresInput;
                bool successInput = double.TryParse(Console.ReadLine(), out nombresInput);

                if (!successInput)
                {
                    AnsiConsole.MarkupLine("\t\t[red underline]Erreur de saisie, veuillez saisir un nombre.[/]");
                }
                else if (nombresInput.Equals(999)) // Si la saisie de l'utilisateur = 999 je sors de ma "case 1"
                {
                    Console.Clear();
                    break;
                }
                else // Si la saisie de l'utilisateur != 999, alors j'ajoute sa saisie à ma liste et j'incrémente compteur
                {
                    listNombres.Add(nombresInput);
                    compteur++;
                }
            }
            break;
        case "Addition": // Addition
            if (listNombres.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas saisi de nombre.");
                Console.ResetColor();
                break;
            }
            else
            {
                Console.Clear();
                double somme = listNombres.Sum();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"La somme des nombres que vous avez saisis est : {somme}");
                Console.ResetColor();
                listNombres.Clear();
            }
            break;
        case "Soustraction": // Soustraction
            if (listNombres.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas saisi de nombre.");
                Console.ResetColor();
                break;
            }
            else
            {
                double difference = listNombres.Aggregate((a, b) => a - b);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"La différence des nombres que vous avez saisis est : {difference}");
                listNombres.Clear();
                Console.ResetColor();
            }
            break;
        case "Multiplication": // Multiplication
            if (listNombres.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas saisi de nombre.");
                Console.ResetColor();
                break;
            }
            else
            {
                double multiplicateur = listNombres.Aggregate((a, b) => a * b);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"La multiplication des nombres que vous avez saisis est : {multiplicateur}");
                listNombres.Clear();
                Console.ResetColor();
            }
            break;
        case "Division": // Division
            if (listNombres.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas saisi de nombre.");
                Console.ResetColor();
                break;
            }
            else
            {
                double division = listNombres.Aggregate((a, b) => a / b);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"La division des nombres que vous avez saisis est : {division}");
                listNombres.Clear();
                Console.ResetColor();
            }
            break;
        default: // Tout ce qui n'existe pas en tant que case, valeur de défaut
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            AnsiConsole.MarkupLine("[red underline]Vous n'êtes pas autorisé à effectuer cette action ![/]");
            Console.ResetColor();
            break;
    }
} while (true);
