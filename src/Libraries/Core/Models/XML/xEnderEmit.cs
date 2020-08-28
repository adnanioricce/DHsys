using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="enderEmit")]
	public class EnderEmit {
		[XmlElement(ElementName="xLgr")]
		public string XLgr { get; set; }
		[XmlElement(ElementName="nro")]
		public string Nro { get; set; }
		[XmlElement(ElementName="xCpl")]
		public string XCpl { get; set; }
		[XmlElement(ElementName="xBairro")]
		public string XBairro { get; set; }
		[XmlElement(ElementName="xMun")]
		public string XMun { get; set; }
		[XmlElement(ElementName="CEP")]
		public string CEP { get; set; }
	}
}