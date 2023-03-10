using FluentAssertions.Common;
using System.Configuration;

namespace ApiMongo
{
    public class StartUp(IConfiguration configuration)
    {
        Configuration = configuration;
    }

public IConfiguration Configuration { get; }
}
