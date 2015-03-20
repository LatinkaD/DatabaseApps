namespace _7.OldAlbums
{
    using System;
    using System.Globalization;
    using System.Xml;
    // Write a program, which extract from the file catalog.xml the titles and 
    // prices for all albums, published 5 years ago or earlier. Use XPath query
    
    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            int fiveYearsAgo = DateTime.Now.Year - 5;
            XmlNode rootNode = doc.DocumentElement;
            string albumQuery = "catalog/album[year <= " + fiveYearsAgo + "]";
            XmlNodeList albums = doc.SelectNodes(albumQuery);

            foreach (XmlNode album in albums)
            {
                Console.WriteLine("Title: {0}, Price: {1}", 
                    album["name"].InnerText, album["price"].InnerText);
                Console.WriteLine();
            }
        }
    }
}
