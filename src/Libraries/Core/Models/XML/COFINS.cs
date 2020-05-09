using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="COFINS")]
	public class COFINS {
		[XmlElement(ElementName="COFINSSN")]
		public COFINSSN COFINSSN { get; set; }
	}
}