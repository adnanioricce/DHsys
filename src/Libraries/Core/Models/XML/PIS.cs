using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="PIS")]
	public class PIS {
		[XmlElement(ElementName="PISSN")]
		public PISSN PISSN { get; set; }
	}
}