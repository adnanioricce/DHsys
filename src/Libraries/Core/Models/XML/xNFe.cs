   /* 
    Licensed under the Apache License, Version 2.0
    
    http://www.apache.org/licenses/LICENSE-2.0
    */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace Core.Models.XML
{
	[XmlRoot(ElementName="ide")]
	public class Ide {
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

	[XmlRoot(ElementName="dest")]
	public class Dest {
		[XmlElement(ElementName="CPF")]
		public string CPF { get; set; }
	}

	[XmlRoot(ElementName="prod")]
	public class Prod {
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

	[XmlRoot(ElementName="ICMSSN102")]
	public class ICMSSN102 {
		[XmlElement(ElementName="Orig")]
		public string Orig { get; set; }
		[XmlElement(ElementName="CSOSN")]
		public string CSOSN { get; set; }
	}

	[XmlRoot(ElementName="ICMS")]
	public class ICMS {
		[XmlElement(ElementName="ICMSSN102")]
		public ICMSSN102 ICMSSN102 { get; set; }
	}

	[XmlRoot(ElementName="PISSN")]
	public class PISSN {
		[XmlElement(ElementName="CST")]
		public string CST { get; set; }
	}

	[XmlRoot(ElementName="PIS")]
	public class PIS {
		[XmlElement(ElementName="PISSN")]
		public PISSN PISSN { get; set; }
	}

	[XmlRoot(ElementName="COFINSSN")]
	public class COFINSSN {
		[XmlElement(ElementName="CST")]
		public string CST { get; set; }
	}

	[XmlRoot(ElementName="COFINS")]
	public class COFINS {
		[XmlElement(ElementName="COFINSSN")]
		public COFINSSN COFINSSN { get; set; }
	}

	[XmlRoot(ElementName="imposto")]
	public class Imposto {
		[XmlElement(ElementName="ICMS")]
		public ICMS ICMS { get; set; }
		[XmlElement(ElementName="PIS")]
		public PIS PIS { get; set; }
		[XmlElement(ElementName="COFINS")]
		public COFINS COFINS { get; set; }
	}

	[XmlRoot(ElementName="det")]
	public class Det {
		[XmlElement(ElementName="prod")]
		public Prod Prod { get; set; }
		[XmlElement(ElementName="imposto")]
		public Imposto Imposto { get; set; }
		[XmlAttribute(AttributeName="nItem")]
		public string NItem { get; set; }
	}

	[XmlRoot(ElementName="ICMSTot")]
	public class ICMSTot {
		[XmlElement(ElementName="vICMS")]
		public string VICMS { get; set; }
		[XmlElement(ElementName="vProd")]
		public string VProd { get; set; }
		[XmlElement(ElementName="vDesc")]
		public string VDesc { get; set; }
		[XmlElement(ElementName="vPIS")]
		public string VPIS { get; set; }
		[XmlElement(ElementName="vCOFINS")]
		public string VCOFINS { get; set; }
		[XmlElement(ElementName="vPISST")]
		public string VPISST { get; set; }
		[XmlElement(ElementName="vCOFINSST")]
		public string VCOFINSST { get; set; }
		[XmlElement(ElementName="vOutro")]
		public string VOutro { get; set; }
	}

	[XmlRoot(ElementName="total")]
	public class Total {
		[XmlElement(ElementName="ICMSTot")]
		public ICMSTot ICMSTot { get; set; }
		[XmlElement(ElementName="vCFe")]
		public string VCFe { get; set; }
	}

	[XmlRoot(ElementName="MP")]
	public class MP {
		[XmlElement(ElementName="cMP")]
		public string CMP { get; set; }
		[XmlElement(ElementName="vMP")]
		public string VMP { get; set; }
	}

	[XmlRoot(ElementName="pgto")]
	public class Pgto {
		[XmlElement(ElementName="MP")]
		public MP MP { get; set; }
		[XmlElement(ElementName="vTroco")]
		public string VTroco { get; set; }
	}

	[XmlRoot(ElementName="infCFe")]
	public class InfCFe {
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

	[XmlRoot(ElementName="CanonicalizationMethod", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class CanonicalizationMethod {
		[XmlAttribute(AttributeName="Algorithm")]
		public string Algorithm { get; set; }
	}

	[XmlRoot(ElementName="SignatureMethod", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class SignatureMethod {
		[XmlAttribute(AttributeName="Algorithm")]
		public string Algorithm { get; set; }
	}

	[XmlRoot(ElementName="Transform", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class Transform {
		[XmlAttribute(AttributeName="Algorithm")]
		public string Algorithm { get; set; }
	}

	[XmlRoot(ElementName="Transforms", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class Transforms {
		[XmlElement(ElementName="Transform", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public List<Transform> Transform { get; set; }
	}

	[XmlRoot(ElementName="DigestMethod", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class DigestMethod {
		[XmlAttribute(AttributeName="Algorithm")]
		public string Algorithm { get; set; }
	}

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

	[XmlRoot(ElementName="SignedInfo", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class SignedInfo {
		[XmlElement(ElementName="CanonicalizationMethod", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public CanonicalizationMethod CanonicalizationMethod { get; set; }
		[XmlElement(ElementName="SignatureMethod", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public SignatureMethod SignatureMethod { get; set; }
		[XmlElement(ElementName="Reference", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public Reference Reference { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}

	[XmlRoot(ElementName="X509Data", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class X509Data {
		[XmlElement(ElementName="X509Certificate", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public string X509Certificate { get; set; }
	}

	[XmlRoot(ElementName="KeyInfo", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class KeyInfo {
		[XmlElement(ElementName="X509Data", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public X509Data X509Data { get; set; }
	}

	[XmlRoot(ElementName="Signature", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class Signature {
		[XmlElement(ElementName="SignedInfo", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public SignedInfo SignedInfo { get; set; }
		[XmlElement(ElementName="SignatureValue", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public string SignatureValue { get; set; }
		[XmlElement(ElementName="KeyInfo", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public KeyInfo KeyInfo { get; set; }
		[XmlAttribute(AttributeName="xmlns")]
		public string Xmlns { get; set; }
	}

	[XmlRoot(ElementName="CFe")]
	public class CFe {
		[XmlElement(ElementName="infCFe")]
		public InfCFe InfCFe { get; set; }
		[XmlElement(ElementName="Signature", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public Signature Signature { get; set; }
	}

}
