using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinyllistan
{
    class Program
    {
        static string[] artist = new string[10];
        static string[] album = new string[10];
        static int[] year = new int[10];

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            int menuChoiceLoop;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("          MUSIC COLLECTION           ");
                Console.WriteLine("");
                Console.WriteLine("************************************");
                Console.WriteLine("* (1) - Add a new album            *");
                Console.WriteLine("* (2) - Remove an existing album   *");
                Console.WriteLine("* (3) - Edit an existing Album     *");
                Console.WriteLine("* (4) - Show album collection      *");
                Console.WriteLine("* (5) - Quit                       *");
                Console.WriteLine("************************************");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("************************************");
                Console.WriteLine("*               By:                *");
                Console.WriteLine("*  Pascal, Robin, Love and Alex    *");
                Console.WriteLine("*                                  *");
                Console.WriteLine("************************************");
                menuChoiceLoop = int.Parse(Console.ReadLine());
                switch (menuChoiceLoop)
                {
                    case 1: NewAlbum(); break;
                    case 2: DeleteAlbum(); break;
                    case 3: EditExistingAlbum(); break;
                    case 4: ShowMusicCollection(); break;
                    case 5: Environment.Exit(0); break;
                    default: break;
                }
            }
        }
        static void ShowMusicCollection()
        {
            Console.Clear(); 
           // var loadMusicCollection = File.ReadAllText(@"C:\Users\ander\Documents\GitHub\AlfaHangman\AlphaGroupHangMan\ConsoleApplication1\ConsoleApplication1\Vinyllista\Vinyllista.txt");
            //Console.WriteLine(loadMusicCollection);
           // Console.ReadLine(); 
             for (int i = 0; i < artist.Length; i++)
            {
                Console.Write(album[i] + " ");
                Console.Write(artist[i] + " ");
                if (year[i] != 0)
                {
                Console.WriteLine(year[i] + " ");
                }
            }
            Console.ReadLine(); 
        }
        static void NewAlbum()
        {
            Console.Clear();
            Console.Write("Album: "); string albumName = Console.ReadLine();
            Console.Write("Artist: "); string artistName = Console.ReadLine();
            Console.Write("Year: "); int yearName = int.Parse(Console.ReadLine());

            
            for (int i = 0; i < artist.Length; i++)
            {
                if (artist[i] == null)
                {
                    artist[i] = artistName;
                    album[i] = albumName;
                    year[i] = yearName;
                    i = artist.Length;
                }
            }
           // string fullAlbum = "Album: " + albumName + " " + "Artist: " + artistName + " " + "Year: " + yearName + Environment.NewLine;
           // File.AppendAllText(@"C:\Users\ander\Documents\GitHub\AlfaHangman\AlphaGroupHangMan\ConsoleApplication1\ConsoleApplication1\Vinyllista\Vinyllista.txt", fullAlbum); 

        }
        static void EditExistingAlbum()
        {

            Console.Clear();
            //var loadMusicCollection = File.ReadAllText(@"C:\Users\ander\Documents\GitHub\AlfaHangman\AlphaGroupHangMan\ConsoleApplication1\ConsoleApplication1\Vinyllista\Vinyllista.txt");
            //Console.WriteLine(loadMusicCollection);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("Which album would you like to edit?: "); string albumToEdit = Console.ReadLine();
            Console.Write("New Album name: "); string albumNamn = Console.ReadLine();
            Console.Write("New Artist: "); string artistNamn = Console.ReadLine();
            Console.Write("New year: "); int yearName = int.Parse(Console.ReadLine());

            for (int i = 0; i < album.Length; i++)
            {
                if (album[i] != null && album[i].ToLower() == albumToEdit)
                {
                    artist[i] = artistNamn;
                    album[i] = albumNamn;
                    year[i] = yearName;
                }
            }
           // string fullAlbumUpdate = "Artist: " + artistNamn + " " + "Album: " + albumNamn + " " + "Year: " + yearName;
           // File.AppendAllText(@"C:\Users\ander\Documents\GitHub\AlfaHangman\AlphaGroupHangMan\ConsoleApplication1\ConsoleApplication1\Vinyllista\Vinyllista.txt", fullAlbumUpdate);
        }
        static void DeleteAlbum()
        {
            Console.Clear();
            Console.Write("Specify the name of the album you would like to delete: ");
            string nameToRemove = Console.ReadLine();
            for (int i = 0; i < album.Length; i++)
            {
                if (album[i] != null && album[i].ToLower() == nameToRemove)
                {
                    artist[i] = null;
                    album[i] = null;

                    year[i] = 0;
                }
            }
        }
        //static void SaveListToFile()



    }
}