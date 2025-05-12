namespace Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Temiz fonksiyon kuralları:
             * 1. One job at a time: Birim zamanda sadece bir iş yapmalı.
             * 2. Parametre sayısı ne kadar az o kadar iyi....
             * 3. Fonksiyon gövdesi; ne kadar küçük o kadar iyi...
             */

            /*
             *  Adam asmaca algoritması:
             *  
             *   1. Kelime listesi içinden rastgele kelime seç.
             *   2. Seçilen kelimenin harflerini '*' semboluüne çevir.
             *   3. Ekranda bulmacayı göster.
             *   4. Kullanıcıdan harf iste
             *   5. Harfin kelimede olup olmadığına bak.
             *      Varsa: harfin yerine gelen * ile harfi değiştir.
             *      Yoksa: Hakkını bir azalt.
             *   6. Kelimeyi tahmin edip etmeyeceğini sor.
             *      -- Evet ise tahmin iste ve 7..
             *      -- Hayır ise 4. Adıma git
             *   7. Tahmin edilen ile seçilen kelimeyi karşılaştır.
             *   
             *      
             *       
             */

            string selectedWord = GetRandomWordFrom(new List<string>());
            string puzzle = ConvertToPuzzle(selectedWord);
            ShowPuzzle(puzzle);
            string letter = getLetterFromUser();
            bool isWordIncludingLetter = IsWordIncludeLetter(selectedWord, letter);
            if (isWordIncludingLetter)
            {
                puzzle = replaceLetterInPuzzle(puzzle, letter);
            }

            Console.WriteLine("Hello, World!");


        }
        static string GetRandomWordFrom(List<string> words)
        {
            return "ağaç";
        }
        static string ConvertToPuzzle(string selectedWord)
        {
           return  "****";
        }

        static void ShowPuzzle(string puzzle) {
            Console.WriteLine(puzzle);
        }

        static string getLetterFromUser()
        {
            return "a";
        }

        static bool IsWordIncludeLetter(string word, string letter) {
            return true;
        }

        static string replaceLetterInPuzzle(string puzzle, string letter) 
        {
            return "a*a*";        
        }

        void cyclomatic_complexity(dynamic customer, dynamic order)
        {
            decimal discount = 0M;
            if (customer.IsVIP) //+1
            {
                discount += 0.1M;
            }

            if (order.Amount > 1000) //+1
            {
                discount += 0.05M;
            }

            foreach (var item in order.Items) //+1
            {
                //bi şeyler yap...
                if (item.Category ="PC") //+1
                {
                    
                }
                
            }

            //Thomas McCabe
        }




    }
}
