﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.8.3928.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/nfe")]
[System.Xml.Serialization.XmlRootAttribute("consReciNFe", Namespace="http://www.portalfiscal.inf.br/nfe", IsNullable=false)]
public partial class TConsReciNFe : object, System.ComponentModel.INotifyPropertyChanged {
    
    private TAmb tpAmbField;
    
    private string nRecField;
    
    private string versaoField;
    
    /// <remarks/>
    public TAmb tpAmb {
        get {
            return this.tpAmbField;
        }
        set {
            this.tpAmbField = value;
            this.RaisePropertyChanged("tpAmb");
        }
    }
    
    /// <remarks/>
    public string nRec {
        get {
            return this.nRecField;
        }
        set {
            this.nRecField = value;
            this.RaisePropertyChanged("nRec");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string versao {
        get {
            return this.versaoField;
        }
        set {
            this.versaoField = value;
            this.RaisePropertyChanged("versao");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.portalfiscal.inf.br/nfe")]
public enum TAmb {
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("1")]
    Item1,
    
    /// <remarks/>
    [System.Xml.Serialization.XmlEnumAttribute("2")]
    Item2,
}
