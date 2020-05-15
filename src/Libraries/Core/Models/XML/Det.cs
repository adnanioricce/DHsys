using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="det")]
	public class Det {
		[XmlElement(ElementName="prod")]
		public Prod Prod { get; set; }
		[XmlElement(ElementName="imposto")]
		public Imposto Imposto { get; set; }
		[XmlAttribute(AttributeName="nItem")]
		public string NItem { get; set; }
	}
}