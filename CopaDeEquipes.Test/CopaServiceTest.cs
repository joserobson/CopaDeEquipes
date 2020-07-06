using CopaDeEquipes.Application.Services;
using System.Linq;
using Xunit;

namespace CopaDeEquipes.Test
{
    public class CopaServiceTest
    {
        [Fact]
        public void CopaService_ObterEquipes_ObterComSucesso()
        {
            ICopaService service = new CopaService();

            var equipes = service.ObterEquipes();

            var result = equipes.Result;

            Assert.True(result.Any());
        }
    }
}
