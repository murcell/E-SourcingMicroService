namespace ESourcing.Products.Settings
{
    public class ProductDatabaseSettings : IProductDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
