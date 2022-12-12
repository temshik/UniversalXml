using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using XMLModel;
using XMLModel.Model;

SerializeObject();

static void Serialize(Document document, XmlAttributeOverrides overrides)
{
    var ns = new XmlSerializerNamespaces();
    ns.Add("", "urn:unused");

    using (var s = new StringWriter())
    {
        var serializer = (overrides == null)
            ? new XmlSerializer(typeof(Document))
            : new XmlSerializer(typeof(Document), overrides);

        serializer.Serialize(s, document, ns);
        Console.WriteLine(s);
    }
}

static XmlAttributeOverrides GetOverrides(Document document)
{
    return new OverrideXml()
        .Override<Document>()
            .XmlRoot(document.TagName)           
            .Member("Nodes").XmlElement(document.Nodes[0].TagName)
            .Member("AttributeValue").XmlAttribute(document.AttributeName)
        .Override(typeof(Node))
            .Member("Nodes").XmlElement(document.Nodes[0].Nodes[0].TagName)
            .Member("Items").XmlElement(document.Nodes[0].Items[0].TagName)
        .Commit();
}

static void SerializeObject()
{
    var document = new Document { TagName = "users",  AttributeName = "id" ,AttributeValue = "1",
        Nodes = new List<Node>
        {
            new Node("user", new Item("first-name","Rui")),
        } 
    };

    var document1 = new Document
    {        
        TagName = "users",
        AttributeName = "id",
        AttributeValue = "1",
        Nodes = new List<Node>
        {
            new Node() { TagName = "user", Items = new List<Item>(){ new Item("first-name", "Rui"),
                                                                     new Item("last-name", "Jarimba"),
                                                                     new Item("age", "30"),
                                                                     new Item("email", "email@somewhere.com")},

                Nodes = new List<Node>
                {
                    new Node() { TagName = "address", Items = new List<Item>() { new Item("street", "my street 1"),
                                                                                 new Item("postal-code", "1000-001"),
                                                                                 new Item("city", "Lisbon"),
                                                                                 new Item("country", "Portugal")}},

                    new Node() { TagName = "delivey-address", Items = new List<Item>() { new Item("street", "another street"),
                                                                                         new Item("postal-code", "1000-002"),
                                                                                         new Item("city", "Lisbon"),
                                                                                         new Item("country", "Portugal")}},                  
                }
            },            
        }
    };

    Serialize(document1, GetOverrides(document1));

    XDocument xdoc = new XDocument(
        new XElement(document1.TagName,
            new XElement(document1.Nodes[0].TagName,
                new XElement("first-name", "Rui"),
                new XElement("last-name", "Jarimba"),
                new XElement("age", "30"),
                new XElement("email", "email@somewhere.com"),

                new XElement(document1.Nodes[0].Nodes[0].TagName,
                new XElement("street", "my street 1"),
                new XElement("postal-code", "1000-001"),
                new XElement("city", "Lisbon"),
                new XElement("country", "Portugal")),

                new XElement(document1.Nodes[0].Nodes[1].TagName,
                new XElement("street", "another street"),
                new XElement("postal-code", "1000-002"),
                new XElement("city", "Lisbon"),
                new XElement("country", "Portugal"))
                )));

    xdoc.Save("people2.xml");

    Console.WriteLine();
}
