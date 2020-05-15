using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="Reference", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class Reference {
		[XmlElement(ElementName="Transforms", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public Transforms Transforms { get; set; }
		[XmlElement(ElementName="DigestMethod", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public DigestMethod DigestMethod { get; set; }
		[XmlElement(ElementName="DigestValue", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public string DigestValue { get; set; }
		[XmlAttribute(AttributeName="URI")]
		public string URI { get; set; }
	}
}