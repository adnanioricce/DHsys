namespace Core.Entities.Catalog
{
    public class Category : BaseEntity
    {
        public Category(){}        
        /// <summary>
        /// Get or set the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Get or set the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Get or set if this <see cref="Category"/> should be shown on homepage
        /// </summary>
        public bool ShowOnHomepage { get; set; } = false;
    }
}
