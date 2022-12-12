using System.Xml.Serialization;

namespace XMLModel.Model
{
    public abstract class Attributes
    {
        [XmlIgnore]
        public string TagName { get; set; }

        public Attributes()
        {

        }

        public Attributes(string tagName)
        {
            TagName = tagName;
        }

        public Attributes(string tagName, string attributeValue) : this(tagName)
        {
        }
    }
}
