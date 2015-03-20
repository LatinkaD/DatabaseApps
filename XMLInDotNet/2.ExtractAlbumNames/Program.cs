namespace _2.ExtractAlbumNames
{
    using System;
    using System.Xml;

    // Write a program that extracts all album names from catalog.xml. Use the DOM parser

    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                Console.WriteLine("Album name: {0}", node["name"].InnerText);
                Console.WriteLine();
            }
        }
    }
}
