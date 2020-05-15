using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="MP")]
	public class MP {
		[XmlElement(ElementName="cMP")]
		public string CMP { get; set; }
		[XmlElement(ElementName="vMP")]
		public string VMP { get; set; }
	}
}