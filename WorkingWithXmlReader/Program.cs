using System;
using System.Xml;

namespace WorkingWithXmlReader
{
    class Program
    {
        static void Main(string[] args)
        {
            // XmlReader - Represents a reader that provides fast, noncached, forward-only access to XML data.
            using (XmlReader reader = XmlReader.Create("C:\\Users\\micha\\Source\\Repos\\Microsoft Technology Associate\\Software Development Fundamentals\\Lesson06\\WorkingWithXmlReader\\Customers.xml"))
            {
                // Read  - When overridden in a derived class, reads the next node from the stream.
                while (reader.Read())
                {
                    // IsStartElement - Tests if the current content node is a start tag.
                    if (reader.IsStartElement())
                    {
                        // Name - When overridden in a derived class, gets the qualified name of the current node.
                        switch (reader.Name)
                        {
                            case "CompanyName":
                                if(reader.Read())
                                {
                                    Console.WriteLine("Company Name: {0}, ", reader.Value);
                                }
                                break;
                            case "Phone":
                                if(reader.Read())
                                {
                                    Console.WriteLine("Phone: {0}", reader.Value);
                                }
                                break;
                        }
                    }
                }
            }
        }
    }
}
