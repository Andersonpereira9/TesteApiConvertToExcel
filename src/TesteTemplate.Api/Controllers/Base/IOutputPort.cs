namespace TesteTemplate.Api.Controllers.Base
{
    public interface IOutputPort<in TUseCaseResponse>
    {
        void Handler(TUseCaseResponse response);
    }
}