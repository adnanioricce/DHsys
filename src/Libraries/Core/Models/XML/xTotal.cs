using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="total")]
	public class Total {
		[XmlElement(ElementName="ICMSTot")]
		public ICMSTot ICMSTot { get; set; }
		[XmlElement(ElementName="vCFe")]
		public string VCFe { get; set; }
	}
}