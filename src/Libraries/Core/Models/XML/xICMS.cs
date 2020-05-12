using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="ICMS")]
    public class ICMS {
		[XmlElement(ElementName="ICMSSN102")]
		public ICMSSN102 ICMSSN102 { get; set; }
	}
}