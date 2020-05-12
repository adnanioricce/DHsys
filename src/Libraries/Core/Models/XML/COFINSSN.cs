using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="COFINSSN")]
	public class COFINSSN {
		[XmlElement(ElementName="CST")]
		public string CST { get; set; }
	}
}