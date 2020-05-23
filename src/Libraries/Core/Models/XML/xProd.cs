using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="prod")]
	public class Prod 
	{
		[XmlElement(ElementName="cProd")]
		public string CProd { get; set; }
		[XmlElement(ElementName="xProd")]
		public string XProd { get; set; }
		[XmlElement(ElementName="CFOP")]
		public string CFOP { get; set; }
		[XmlElement(ElementName="uCom")]
		public string UCom { get; set; }
		[XmlElement(ElementName="qCom")]
		public string QCom { get; set; }
		[XmlElement(ElementName="vUnCom")]
		public string VUnCom { get; set; }
		[XmlElement(ElementName="vProd")]
		public string VProd { get; set; }
		[XmlElement(ElementName="indRegra")]
		public string IndRegra { get; set; }
		[XmlElement(ElementName="vItem")]
		public string VItem { get; set; }
	}
}