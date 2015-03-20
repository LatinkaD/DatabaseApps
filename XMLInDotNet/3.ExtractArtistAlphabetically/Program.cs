namespace ExtractArtistAlphabetically
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    // Write a program that extracts all artists in alphabetical order from catalog.xml. 
    // Use the DOM parser. Keep the artists in a SortedSet<string> to avoid duplicates 
    // and to keep the artist in alphabetical order

    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            SortedSet<string> artists = new SortedSet<string>();

            foreach (XmlNode node in rootNode.ChildNodes)
	        {
		        artists.Add(node["artist"].InnerText);
	        }

            foreach (var artist in artists)
            {
                Console.WriteLine("Artist: {0}", artist);
                Console.WriteLine();
            }
        }
    }
}
