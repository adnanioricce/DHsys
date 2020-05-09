using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="ICMSSN102")]
	public class ICMSSN102 {
		[XmlElement(ElementName="Orig")]
		public string Orig { get; set; }
		[XmlElement(ElementName="CSOSN")]
		public string CSOSN { get; set; }
	}
}