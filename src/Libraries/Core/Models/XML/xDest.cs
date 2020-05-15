using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="dest")]
	public class Dest {
		[XmlElement(ElementName="CPF")]
		public string CPF { get; set; }
	}
}