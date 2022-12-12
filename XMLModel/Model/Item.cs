using System.Xml.Serialization;

namespace XMLModel.Model
{
    public class Item : Attributes
    {
        public string Text { get; set; }

        public Item()
        {

        }

        public Item(string tagName, string text) : base(tagName)
        {
            Text = text;
        }
    }
}