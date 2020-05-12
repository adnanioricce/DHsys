using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="emit")]
	public class Emit {
		[XmlElement(ElementName="CNPJ")]
		public string CNPJ { get; set; }
		[XmlElement(ElementName="xNome")]
		public string XNome { get; set; }
		[XmlElement(ElementName="xFant")]
		public string XFant { get; set; }
		[XmlElement(ElementName="enderEmit")]
		public EnderEmit EnderEmit { get; set; }
		[XmlElement(ElementName="IE")]
		public string IE { get; set; }
		[XmlElement(ElementName="cRegTrib")]
		public string CRegTrib { get; set; }
		[XmlElement(ElementName="cRegTribISSQN")]
		public string CRegTribISSQN { get; set; }
		[XmlElement(ElementName="indRatISSQN")]
		public string IndRatISSQN { get; set; }
	}
}