namespace ESourcing.Sourcing.Settings
{
    public interface ISourcingDatabaseSettings
    {
        public string ConnectionStrings { get; set; }
        public string DatabaseName { get; set; }
        public string AuctionCollectionName { get; set; }
        public string BidCollectionName { get; set; }
    }
}

