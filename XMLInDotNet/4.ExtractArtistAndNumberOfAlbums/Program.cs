namespace ExtractArtistAndNumberOfAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    // Write a program that extracts all different artists, which are found in the
    // catalog.xml. For each artist print the number of albums in the catalogue. Use the DOM
    // parser and a Dictionary<string, int> (use the artist name as key and the number of
    // albums as value in the dictionary)

    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            Dictionary<string, int> artistAndAlbums = new Dictionary<string, int>();

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                var currentArtist = node["artist"].InnerText;

                if (artistAndAlbums.ContainsKey(currentArtist))
                {
                    artistAndAlbums[currentArtist] += 1;
                }
                else
                {
                    artistAndAlbums[currentArtist] = 1;
                }
            }

            foreach (var artistAndAlbum in artistAndAlbums)
            {
                Console.WriteLine("{0}: {1}", artistAndAlbum.Key, artistAndAlbum.Value);
                Console.WriteLine();
            }
        }
    }
}
