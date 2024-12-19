using Spectre.Console;
using Spectre.Console.Cli;

// Valeur de base
List<double> listNombres = new List<double>();


do
{
            AnsiConsole.Write(
         new FigletText("Calculatrice.NET")
             .Color(Color.Red));
;
    AnsiConsole.MarkupLine("[bold red] -- Menu --[/]");
    Console.WriteLine("1 -- Saisie des nombres");
    Console.WriteLine("2 -- Addition");
    Console.WriteLine("3 -- Soustraction");
    Console.WriteLine("4 -- Multiplication");
    Console.WriteLine("5 -- Division");
    Console.WriteLine("0 -- Quitter");

    Console.Write("Faites un choix : ");
    int choice;
    bool successChoice = int.TryParse(Console.ReadLine(), out choice);


    if (!successChoice)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\tVous avez utiliser un caractère non autorisé.");
        Console.ResetColor();
        continue;
    }


    switch (choice)
    {
        case 0: // Quitter l'application
            Environment.Exit(0);
            break;
        case 1: // Saisie des nombres
            Console.Clear();
             int compteur = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--- Saisir les notes ---");
            Console.WriteLine("(999 pour stoper la saisie) \n");
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
                else if (nombresInput.Equals(999)) // Si la saisie de l'user = 999 je sors de ma "case 1"
                {
                    Console.Clear();
                    break;
                }
                else // Si la saisie de l'user != 999, alors j'ajoute sa saisie a ma list et j'incrémente compteur
                {
                    listNombres.Add(nombresInput);
                    compteur++;
                }
            }
            break;
        case 2: // Addition
            if (listNombres.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas saisie de nombre.");
                Console.ResetColor ();
                break;
            }
            else
            {
                Console.Clear();
                double somme = listNombres.Sum();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"La somme des nombres que vous avez saisie est : {somme}");
                Console.ResetColor();
                listNombres.Clear();

            }
            break;
        case 3: // Soustraction
            if (listNombres.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas saisie de nombre.");
                Console.ResetColor () ;
                break;
            }
            else
            {
                double difference = listNombres.Aggregate((a, b) => a - b);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"La différence des nombres que vous avez saisie est : {difference}");
                listNombres.Clear();
                Console.ResetColor();
            }
            break;
        case 4: // Multiplication
            if (listNombres.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas saisie de nombre.");
                Console.ResetColor();
                break;
            }
            else
            {
                double multiplicateur = listNombres.Aggregate((a, b) => a * b);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"La multiplication des nombres que vous avez saisie est : {multiplicateur}");
                listNombres.Clear();
                Console.ResetColor();
            }
            break;
        case 5: // Division
            if (listNombres.Count == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas saisie de nombre.");
                Console.ResetColor();
                break;
            }
            else
            {
                double division = listNombres.Aggregate((a, b) => a / b);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"La division des nombres que vous avez saisie est : {division}");
                listNombres.Clear();
                Console.ResetColor();
            }
            break;
        default: // Tout ce qui n'éxiste pas en tant que case, valeur de défault
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            AnsiConsole.MarkupLine("[red underline]Vous n'étes pas autorisé a effectué cette action !.[/]");
            Console.ResetColor();
            break;
    }
} while (true);
