using DotNetify;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace PersonSearch.App.Startup
{
    public static class EndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapDotNetifyHub(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            const string dotnetifyHubPath = "/dotnetify";

            endpointRouteBuilder.MapHub<DotNetifyHub>((PathString)dotnetifyHubPath);
            return endpointRouteBuilder;
        }
    }
}