using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="SignedInfo", Namespace="http://www.w3.org/2000/09/xmldsig#")]
    public class SignedInfo {
		[XmlElement(ElementName="CanonicalizationMethod", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public CanonicalizationMethod CanonicalizationMethod { get; set; }
		[XmlElement(ElementName="SignatureMethod", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public SignatureMethod SignatureMethod { get; set; }
		[XmlElement(ElementName="Reference", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public Reference Reference { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}
}