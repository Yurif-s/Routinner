using Mapster;
using Routinner.Communication.Requests;

namespace Routinner.Application.Services.Mappings;

public static class MapConfigurations
{
    public static void Configure()
    {
        TypeAdapterConfig<RequestRegisterUserJson, Domain.Entities.User>
            .NewConfig()
            .Ignore(user => user.Password);
    }
}
