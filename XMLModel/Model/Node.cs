using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLModel.Model
{
    public class Node : Attributes
    {
        [XmlIgnore]
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public List<Item> Items { get; set; }
        public List<Node> Nodes { get; set; }

        public Node()
        {

        }

        public Node(string tagName, IEnumerable<Item> items) : base(tagName)
        {
            Items = new List<Item>(items);
        }
        public Node(string tagName, params Item[] items) : base(tagName)
        {
            Items = new List<Item>(items);
        }
    }
}
