using QuoteMachine_ExerciceGit;

var manager = new QuoteManager();
string path = "citations.csv";

// Charger les citations sauvegardées dès le démarrage
try
{
    manager.LoadFromCSVFile(path);
}
catch (Exception ex)
{
    Console.WriteLine($"[Info] Impossible de charger les citations au démarrage : {ex.Message}");
}

bool quitter = false;

while (!quitter)
{
    Console.Clear();
    Console.WriteLine("=== QuoteMachine ===");
    Console.WriteLine("1. Afficher une citation aléatoire");
    Console.WriteLine("2. Ajouter une citation");
    Console.WriteLine("3. Afficher toutes les citations");
    Console.WriteLine("4. Recharger les citations depuis le fichier");
    Console.WriteLine("5. Sauvegarder les citations dans le fichier");
    Console.WriteLine("0. Quitter");
    Console.Write("\nChoix : ");

    var choix = Console.ReadLine();
    Console.Clear();

    switch (choix)
    {
        case "1":
            ShowRandomQuote(manager);
            break;
        case "2":
            AddNewQuote(manager);
            break;
        case "3":
            foreach (var quote in manager.GetAllQuotes())
                Console.WriteLine(quote);
            break;
        case "4":
            LoadQuotesFromFile(manager);
            break;
        case "5":
            SaveQuotesToFile(manager);
            break;
        case "0":
            try
            {
                manager.SaveToCSVFile(path); // ✅ Sauvegarde automatique
                Console.WriteLine("Citations sauvegardées avant de quitter.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la sauvegarde avant de quitter : {ex.Message}");
            }
            quitter = true;
            Console.WriteLine("Merci d’avoir utilisé QuoteMachine !");
            break;
        default:
            Console.WriteLine("Choix invalide. Réessayez.");
            break;
    }

    if (!quitter)
    {
        Console.WriteLine("\nAppuyez sur une touche pour continuer...");
        Console.ReadKey(true);
    }
}

// === Méthodes du menu ===

static void ShowRandomQuote(QuoteManager manager)
{
    try
    {
        Console.WriteLine(manager.GetRandomQuote());
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur : {ex.Message}");
    }
}

static void AddNewQuote(QuoteManager manager)
{
    Console.Write("Texte : ");
    var texte = Console.ReadLine();
    Console.Write("Auteur : ");
    var auteur = Console.ReadLine();

    try
    {
        manager.AddQuote(texte, auteur);
        Console.WriteLine("Citation ajoutée !");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur : {ex.Message}");
    }
}

static void SaveQuotesToFile(QuoteManager manager)
{
    try
    {
        manager.SaveToCSVFile(" citations.csv");
        Console.WriteLine("Citations sauvegardées !");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur : {ex.Message}");
    }
}

static void LoadQuotesFromFile(QuoteManager manager)
{
    try
    {
        manager.LoadFromCSVFile("citations.csv");
        Console.WriteLine("Citations chargées avec succès !");
    }
    catch (QuoteFileException ex)
    {
        Console.WriteLine($"Erreur lors du chargement : {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur inattendue : {ex.Message}");
    }
}
