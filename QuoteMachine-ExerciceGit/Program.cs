using QuoteMachine_ExerciceGit;

Console.WriteLine("Bienvenue dans QuoteMachine!");
Console.WriteLine("Ce projet est collaboratif et utilise le GitHub Flow.");
Console.WriteLine("Développez une application console pour gérer et afficher des citations inspirantes.\n");
Console.WriteLine("Prochaines étapes : implémentez les fonctionnalités dans des branches distinctes.\n");
Console.WriteLine("\n=== Menu Principal ===");
Console.WriteLine("Implémentez le menu du programme dans feature/menu");
Console.ReadKey(true);
var manager = new QuoteManager();
string path = "citations.csv";

List<Quote> quotes = manager.GetAllQuotes();

foreach (Quote quote in quotes)
    Console.WriteLine(quote);

Console.ReadKey(true);
static void ShowRandomQuote(QuoteManager manager)
{

    Console.WriteLine(manager.GetRandomQuote());
}

static void AddNewQuote(QuoteManager manager)
{
    Console.WriteLine("[Simulation] On ajouterait une nouvelle citation ici.");
    // Exemple futur :
    Console.Write("Texte : ");
    var texte = Console.ReadLine();
    Console.Write("Auteur : ");
    var auteur = Console.ReadLine();
    manager.AddQuote(texte, auteur);
    Console.WriteLine("Citation ajoutée !");
}

static void SaveQuotesToFile(QuoteManager manager)
{
    try
    {
        Console.WriteLine("[Simulation] On sauvegarderait les citations ici.");
        // Exemple futur :
        manager.SaveToCSVFile("citations.csv");
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
        string path = "citations.csv";
        manager.LoadFromCSVFile(path);
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



