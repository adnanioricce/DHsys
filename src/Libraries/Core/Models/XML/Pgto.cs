using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="pgto")]
	public class Pgto {
		[XmlElement(ElementName="MP")]
		public MP MP { get; set; }
		[XmlElement(ElementName="vTroco")]
		public string VTroco { get; set; }
	}
}