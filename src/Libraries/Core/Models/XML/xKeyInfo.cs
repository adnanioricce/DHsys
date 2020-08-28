using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="KeyInfo", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class KeyInfo {
		[XmlElement(ElementName="X509Data", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public X509Data X509Data { get; set; }
	}
}