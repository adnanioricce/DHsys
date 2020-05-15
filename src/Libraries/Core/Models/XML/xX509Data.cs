using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="X509Data", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class X509Data {
		[XmlElement(ElementName="X509Certificate", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public string X509Certificate { get; set; }
	}
}