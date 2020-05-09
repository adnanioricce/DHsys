using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="Signature", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class Signature {
		[XmlElement(ElementName="SignedInfo", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public SignedInfo SignedInfo { get; set; }
		[XmlElement(ElementName="SignatureValue", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public string SignatureValue { get; set; }
		[XmlElement(ElementName="KeyInfo", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public KeyInfo KeyInfo { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}
}