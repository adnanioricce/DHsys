using System.Collections.Generic;
using System.Xml.Serialization;

namespace Core.Models.XML
{
    [XmlRoot(ElementName="Transforms", Namespace="http://www.w3.org/2000/09/xmldsig#")]
	public class Transforms {
		[XmlElement(ElementName="Transform", Namespace="http://www.w3.org/2000/09/xmldsig#")]
		public List<Transform> Transform { get; set; }
	}
}