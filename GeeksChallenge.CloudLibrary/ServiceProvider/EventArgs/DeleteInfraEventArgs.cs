using GeeksChallenge.Domain.Models;

namespace GeeksChallenge.CloudLibrary.ServiceProvider.EventArgs
{
    public class DeleteInfraEventArgs : System.EventArgs
    {
        public Infrastructure Infrastructure { get; set; }
        public bool Deleted { get; set; }
        
    }
}
