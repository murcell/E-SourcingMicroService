using ESourcing.Sourcing.Data.Interfaces;
using ESourcing.Sourcing.Entities;
using ESourcing.Sourcing.Settings;
using MongoDB.Driver;

namespace ESourcing.Sourcing.Data
{
    public class SourcingContext : ISourcingContext
    {
        public SourcingContext(ISourcingDatabaseSettings sourcingDatabaseSettings)
        {
            var client = new MongoClient(sourcingDatabaseSettings.ConnectionStrings);
            var database = client.GetDatabase(sourcingDatabaseSettings.DatabaseName);
            Auctions = database.GetCollection<Auction>(sourcingDatabaseSettings.AuctionCollectionName);
            Bids = database.GetCollection<Bid>(sourcingDatabaseSettings.BidCollectionName);

            SourcingContextSeed.SeedData(Auctions);
        }

        public IMongoCollection<Auction> Auctions { get; }

        public IMongoCollection<Bid> Bids { get; }
    }
}
