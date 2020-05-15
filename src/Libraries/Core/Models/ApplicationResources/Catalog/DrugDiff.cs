using System.Collections.Generic;
using Core.Entities.Catalog;

namespace Core.Models.ApplicationResources.Catalog
{
    public class DrugDiff
    {
        public Drug PreviousDrug { get; set; }
        public Drug CurrentDrug { get; set; }
        public Dictionary<string,PropertyDiff> ChangedProperties { get; set; }
        public DiffOperation Operation { get; set; }
    }
}