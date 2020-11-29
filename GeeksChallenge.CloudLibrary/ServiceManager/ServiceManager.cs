using System;
using GeeksChallenge.CloudLibrary.Dtos;
using GeeksChallenge.CloudLibrary.ServiceProvider;
using GeeksChallenge.CloudLibrary.ServiceProvider.EventArgs;
using GeeksChallenge.Domain.Models;

namespace GeeksChallenge.CloudLibrary.ServiceManager
{
    public class ServiceManager
    {
        public event EventHandler<CreateInfraEventArgs> CreateInfrastructure;
        public event EventHandler<DeleteInfraEventArgs> DeleteInfrastructure;

        public bool Create(InfrastructureUpsertDto infrastructure)
        {
            var eventArgs = new CreateInfraEventArgs { InfrastructureForPostDto = infrastructure, Created = false };
            OnCreateInfrastructure(eventArgs);
            return eventArgs.Created;

        }
        protected void OnCreateInfrastructure(CreateInfraEventArgs e)
        {
            CreateInfrastructure?.Invoke(this, e);
        }

        public bool Delete(Infrastructure infrastructure)
        {
            var eventArgs = new DeleteInfraEventArgs { Infrastructure = infrastructure, Deleted = false };
            OnDeleteInfrastructure(eventArgs);
            return eventArgs.Deleted;
        }
        protected void OnDeleteInfrastructure(DeleteInfraEventArgs e)
        {
            DeleteInfrastructure?.Invoke(this, e);
        }
    }
}
