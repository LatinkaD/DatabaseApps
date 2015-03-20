namespace _6.DeleteAlbums
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml;

    class Program
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");

            XmlNode rootNode = doc.DocumentElement;
            var culture = rootNode.Attributes["culture"].Value;
            var numberFormat = new CultureInfo(culture);

            foreach (XmlNode node in rootNode)
            {
                try
                {
                    if (decimal.Parse(node["price"].InnerText, numberFormat) > 20)
                    {
                        rootNode.RemoveChild(node);
                    }
                }
                catch (FormatException) { return; }
            }

            doc.Save("../../../cheap-albums-catalog.xml");
        }
    }
}
