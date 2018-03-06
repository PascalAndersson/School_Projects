using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GenericSorting
{
    class FileHandler
    {
        public int[] GetIntegerListFromFile()
        {
            string path = @"C:\Users\Pascal Andersson\source\repos\GenericSorting\GenericSorting\Textfile\IntegerFile.txt";

            var arrayFromFile = File.ReadAllLines(path);

            int[] integerArray = Array.ConvertAll(arrayFromFile, int.Parse);

            return integerArray;
        }

        public char[] GetCharListFromFile()
        {
            string path = @"C:\Users\Pascal Andersson\source\repos\GenericSorting\GenericSorting\Textfile\CharFile.txt";

            var arrayFromFile = File.ReadAllLines(path);

            char[] charArray = Array.ConvertAll(arrayFromFile, char.Parse);

            return charArray;
        }

        public List<string> AddIntegersToList()
        {
            List<string> integerList = new List<string>();

            var random = new Random();

            for (int i = 0; i <= 20 - 1; i++)
            {
                var numberToAdd = random.Next(-10000, 10000);

                integerList.Add(numberToAdd.ToString());
            }

            return integerList;
        }

        public char GetRandomChar()
        {
            var random = new Random();

            int num = random.Next(0, 26);
            char let = (char)('a' + num);
            return let;
        }

        public List<string> AddCharsToList()
        {
            List<string> charList = new List<string>();

            for (int i = 0; i <= 19; i++)
            {
                var charToAdd = GetRandomChar();
                charList.Add(charToAdd.ToString());
            }

            return charList;
        }

        public void AddListsToFile()
        {
            var integerListToAdd = AddIntegersToList();
            var charListToAdd = AddCharsToList();

            File.WriteAllLines(@"C:\Users\Pascal Andersson\source\repos\GenericSorting\GenericSorting\Textfile\IntegerFile.txt", integerListToAdd);
            File.WriteAllLines(@"C:\Users\Pascal Andersson\source\repos\GenericSorting\GenericSorting\Textfile\CharFile.txt", charListToAdd);
        }

        public void WriteResultToFile<T>(T[] array)
        {
            string path = @"C:\Users\Pascal Andersson\source\repos\GenericSorting\GenericSorting\Textfile\Results.txt";

            var convertedArray = Array.ConvertAll(array, a => a.ToString());

            File.AppendAllLines(path, convertedArray);
            
        }
    }
}
