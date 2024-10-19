using UrQuanMastersSaveEditor.Tests.Framework;

namespace UrQuanMastersSaveEditor.Tests.TestFixtures
{
    internal class TestsAll : TestFixture
    {
        public TestsAll(): base(typeof(TestsAll).Name)
        {
            // todo
        }

        public override List<Test> Tests()
        {
            return new List<Test>()
            {
                new Test("AlwaysFail", () => alwaysFail() )
            };
        }

        // Tests.

        private void alwaysFail()
        {
            Assert.IsTrue(false);
        }

    }
}
