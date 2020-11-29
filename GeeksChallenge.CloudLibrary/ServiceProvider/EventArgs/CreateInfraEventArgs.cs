using GeeksChallenge.CloudLibrary.Dtos;

namespace GeeksChallenge.CloudLibrary.ServiceProvider.EventArgs
{
    public class CreateInfraEventArgs:System.EventArgs
    {
        public InfrastructureUpsertDto InfrastructureForPostDto { get; set; }
        public bool Created { get; set; }
        
    }
}
