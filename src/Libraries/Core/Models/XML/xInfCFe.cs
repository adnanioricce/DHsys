using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="infCFe")]
	public class InfCFe 
	{
		[XmlElement(ElementName="ide")]
		public Ide Ide { get; set; }
		[XmlElement(ElementName="emit")]
		public Emit Emit { get; set; }
		[XmlElement(ElementName="dest")]
		public Dest Dest { get; set; }
		[XmlElement(ElementName="det")]
		public List<Det> Det { get; set; }
		[XmlElement(ElementName="total")]
		public Total Total { get; set; }
		[XmlElement(ElementName="pgto")]
		public Pgto Pgto { get; set; }
		[XmlAttribute(AttributeName="Id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName="versao")]
		public string Versao { get; set; }
		[XmlAttribute(AttributeName="versaoDadosEnt")]
		public string VersaoDadosEnt { get; set; }
		[XmlAttribute(AttributeName="versaoSB")]
		public string VersaoSB { get; set; }
	}
}