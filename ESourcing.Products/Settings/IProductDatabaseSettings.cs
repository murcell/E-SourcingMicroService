namespace ESourcing.Products.Settings
{
    public interface IProductDatabaseSettings
    {
        public string ProductCollectionName { get; set; }
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
    }
}
