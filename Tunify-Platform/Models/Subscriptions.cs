namespace Tunify_Platform.Models
{
    public class Subscriptions
    {
        public int SubscriptionsId { get; set; }
        public string SubscriptionsType { get; set; }   
        public int SubscriptionsPrice {  get; set; }
        public ICollection<Users> Users { get; set; }
    }
}