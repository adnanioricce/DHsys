using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="Transform", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class Transform {
		[XmlAttribute(AttributeName="Algorithm")]
		public string Algorithm { get; set; }
	}
}