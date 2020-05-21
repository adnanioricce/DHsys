using System;
using System.Collections.Generic;
using System.Text;

namespace Desktop.Models.Settings
{
    public class ApplicationUpdateSettingsModel : GalaSoft.MvvmLight.ObservableObject
    {
        public string UpdateFileUrl { get; set; }
        public string DsaPublicKey { get; set; }
        public bool ShouldUpdateSilently { get; set; }

    }
}
