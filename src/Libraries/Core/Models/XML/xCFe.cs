using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="CFe")]
	public class CFe 
    {
		[XmlElement(ElementName="infCFe")]
		public XML.InfCFe InfCFe { get; set; }
		[XmlElement(ElementName="Signature", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public Signature Signature { get; set; }
	}
}