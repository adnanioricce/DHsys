using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="imposto")]
	public class Imposto {
		[XmlElement(ElementName="ICMS")]
		public ICMS ICMS { get; set; }
		[XmlElement(ElementName="PIS")]
		public PIS PIS { get; set; }
		[XmlElement(ElementName="COFINS")]
		public COFINS COFINS { get; set; }
	}
}