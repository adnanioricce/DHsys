   /* 
    Licensed under the Apache License, Version 2.0
    
    http://www.apache.org/licenses/LICENSE-2.0
    */
using System.Xml.Serialization;
namespace Core.Models.XML
{
	[XmlRoot(ElementName="ide")]
	public class Ide 
	{
		[XmlElement(ElementName="cUF")]
		public string CUF { get; set; }
		[XmlElement(ElementName="cNF")]
		public string CNF { get; set; }
		[XmlElement(ElementName="mod")]
		public string Mod { get; set; }
		[XmlElement(ElementName="nserieSAT")]
		public string NserieSAT { get; set; }
		[XmlElement(ElementName="nCFe")]
		public string NCFe { get; set; }
		[XmlElement(ElementName="dEmi")]
		public string DEmi { get; set; }
		[XmlElement(ElementName="hEmi")]
		public string HEmi { get; set; }
		[XmlElement(ElementName="cDV")]
		public string CDV { get; set; }
		[XmlElement(ElementName="tpAmb")]
		public string TpAmb { get; set; }
		[XmlElement(ElementName="CNPJ")]
		public string CNPJ { get; set; }
		[XmlElement(ElementName="signAC")]
		public string SignAC { get; set; }
		[XmlElement(ElementName="assinaturaQRCODE")]
		public string AssinaturaQRCODE { get; set; }
		[XmlElement(ElementName="numeroCaixa")]
		public string NumeroCaixa { get; set; }
	}
}
