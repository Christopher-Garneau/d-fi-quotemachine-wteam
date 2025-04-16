using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteMachine_ExerciceGit
{
    public class QuoteManager
    {
        private List<Quote> _quotes;

        public QuoteManager()
        {
            _quotes = new List<Quote>
            {
                new Quote { Text = "Le succès, c’est d’aller d’échec en échec sans perdre son enthousiasme.", Author = "Winston Churchill" },
                new Quote { Text = "Soyez vous-même, tous les autres sont déjà pris.", Author = "Oscar Wilde" },
                new Quote { Text = "La vie, c’est comme une bicyclette, il faut avancer pour ne pas perdre l’équilibre.", Author = "Albert Einstein" }
            };
        }

        /// <summary>
        /// Méthode qui permet de récuperer une quote aléatoire parmi les quotes
        /// </summary>
        /// <returns></returns>
        public Quote GetRandomQuote()
        {
            if (_quotes == null || _quotes.Count < 0 )
            {
                return null;
            }

            Random random = new Random();

            int i = random.Next(_quotes.Count);

            return _quotes[i];
        }


        public void AddQuote(string text, string author)
        {
            //Avant de commencer, décommenter le test suivant:
            //AddQuote_ShouldIncreaseQuoteCount
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(author))
            {
                throw new ArgumentNullException("Le text et l'auteur sont obligatoire.");
            }
            Quote newQuote = new Quote { Text = text, Author = author };
            _quotes.Add(newQuote);

            //Avant de créer votre PR, faites un git rebase sur main pour vous assurer que vous avez la dernière version du code.
            //throw new NotImplementedException("À implémenter dans feature/add-quote");
        }

        /// <summary>
        /// Crer un chemin d'accès pour le nouveau fichier créé.
        /// </summary>
        /// <param name="path"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="QuoteFileException"></exception>
        public void SaveToCSVFile(string path)
        {
            //Avant de commencer, décommenter les tests suivants:
            //SaveToFile_ShouldCreateFile
            //SaveToFile_ShouldThrowIfNotInCSVExtension

            string lastThreeChars = path.Substring(path.Length - 3);

            if(path == null)
            {
                throw new ArgumentNullException("Le chemin d'accès est vide!");
            }
            else if(lastThreeChars != "csv")
            {
                throw new QuoteFileException("Erreur lors de la sauvegarde : le fichier doit avoir l'extension .csv");
            }
            else
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }

            //Avant de créer votre PR, faites un git rebase sur main pour vous assurer que vous avez la dernière version du code.
        }




        public void LoadFromCSVFile(string path)
        {
            if (!IsCSVFile(path))
            {
                throw new QuoteFileException("Erreur lors de la sauvegarde : le fichier doit avoir l'extension .csv");
            }

            if (!File.Exists(path))
            {
                throw new QuoteFileException("Erreur lors du chargement : le fichier n'existe pas");
            }

            try
            {
                var lignes = File.ReadAllLines(path);
                foreach (var ligne in lignes)
                {
                    var parties = ligne.Split(',');
                    if (parties.Length == 2)
                    {
                        _quotes.Add(new Quote
                        {
                            Text = parties[0].Trim(),
                            Author = parties[1].Trim()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new QuoteFileException("Erreur lors du chargement du fichier.", ex);
            }
        }


        /// <summary>
        /// Cette fonction récupère la liste de toutes les quotes enregistrées
        /// </summary>
        /// <returns>La liste de quotes</returns>

        public List<Quote> GetAllQuotes()
        {
            return _quotes; // Pas besoin d'ajouter de test pour cette méthode
        }

        private bool IsCSVFile(string path)
        {
            return path.EndsWith(".csv");
        }
    }
}
