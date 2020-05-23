using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="CanonicalizationMethod", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class CanonicalizationMethod {
		[XmlAttribute(AttributeName="Algorithm")]
		public string Algorithm { get; set; }
	}
}