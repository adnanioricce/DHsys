using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="PISSN")]
	public class PISSN {
		[XmlElement(ElementName="CST")]
		public string CST { get; set; }
	}
}