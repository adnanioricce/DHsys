using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="ICMSTot")]
	public class ICMSTot {
		[XmlElement(ElementName="vICMS")]
		public string VICMS { get; set; }
		[XmlElement(ElementName="vProd")]
		public string VProd { get; set; }
		[XmlElement(ElementName="vDesc")]
		public string VDesc { get; set; }
		[XmlElement(ElementName="vPIS")]
		public string VPIS { get; set; }
		[XmlElement(ElementName="vCOFINS")]
		public string VCOFINS { get; set; }
		[XmlElement(ElementName="vPISST")]
		public string VPISST { get; set; }
		[XmlElement(ElementName="vCOFINSST")]
		public string VCOFINSST { get; set; }
		[XmlElement(ElementName="vOutro")]
		public string VOutro { get; set; }
	}
}