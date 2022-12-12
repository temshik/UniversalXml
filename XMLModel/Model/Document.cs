using System.Xml.Serialization;

namespace XMLModel.Model
{
    public class Document : Attributes
    {
        [XmlIgnore]
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }

        public List<Node> Nodes;

        public Document()
        {

        }

        public Document(string tagName, List<Node> nodes) : base(tagName)
        {
            Nodes = nodes;
        }
    }
}
