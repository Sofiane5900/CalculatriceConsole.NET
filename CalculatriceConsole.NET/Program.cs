
// Valeur de base
List<int> listNombres = new List<int>();


do
{

    Console.WriteLine("--- Menu calculatrice ----");

    Console.WriteLine("1 -- Saisie des nombres");
    Console.WriteLine("2 -- Addition");
    Console.WriteLine("3 -- Soustraction");
    Console.WriteLine("4 -- Multiplication");
    Console.WriteLine("5 -- Division");
    Console.WriteLine("0 -- Quitter");

    Console.Write("Faites un choix : ");
    int choice = int.Parse(Console.ReadLine());
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
                int nombresInput;
                bool success = int.TryParse(Console.ReadLine(), out nombresInput);

                if (!success)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t\tErreur de saisie, veuillez saisir un nombre.");
                    Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas saisie de nombre.");
                break;
            }
            else
            {
                int somme = listNombres.Sum();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"La somme des nombres que vous avez saisie est : {somme}");
            } break;
        case 2: // Addition
            if (listNombres.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vous n'avez pas saisie de nombre.");
                break;
            }
            else
            {
                int somme = listNombres.Sum();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"La somme des nombres que vous avez saisie est : {somme}");
            }
            break;
    }
} while (true);
