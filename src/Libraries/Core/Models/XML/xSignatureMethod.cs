using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="SignatureMethod", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class SignatureMethod {
		[XmlAttribute(AttributeName="Algorithm")]
		public string Algorithm { get; set; }
	}
}