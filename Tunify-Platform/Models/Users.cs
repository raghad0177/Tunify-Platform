namespace Tunify_Platform.Models
{
    public class Users
    {
        public int UsersId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string JoinDate { get; set; }
        public int SubscriptionsId { get; set; } 
        public Subscriptions Subscriptions { get; set; }
        public ICollection<Playlists> Playlists { get; set; }
    }
}