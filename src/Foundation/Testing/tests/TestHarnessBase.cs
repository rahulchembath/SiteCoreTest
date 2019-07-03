using Ploeh.AutoFixture;

namespace Claro.Foundation.Testing
{
    public class TestHarnessBase : ITestHarness
    {
        protected IFixture _fixture;
        public IFixture Fixture { get { return _fixture; } }
    }
}
