namespace _5.ArtistAndAlbumsXPath
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            string artistQuery = "/catalog/album/artist";

            XmlNodeList albums = doc.SelectNodes(artistQuery);

            Dictionary<string, int> artistAndAlbums = new Dictionary<string, int>();

            foreach (XmlNode album in albums)
            {
                var currentArtist = album["artist"].InnerText;

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
