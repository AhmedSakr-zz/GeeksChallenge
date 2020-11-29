using GeeksChallenge.CloudLibrary.ServiceProvider.EventArgs;

namespace GeeksChallenge.CloudLibrary.ServiceProvider
{
    public abstract  class  CloudServices
    {
      public abstract void OnCreateService(object source, CreateInfraEventArgs s);

      public abstract void OnDeleteService(object source, DeleteInfraEventArgs s);
    }
}
