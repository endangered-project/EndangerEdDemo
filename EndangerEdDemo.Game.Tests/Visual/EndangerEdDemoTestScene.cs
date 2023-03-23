using osu.Framework.Allocation;
using osu.Framework.Testing;

namespace EndangerEdDemo.Game.Tests.Visual
{
    public partial class EndangerEdDemoTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new EndangerEdDemoTestSceneTestRunner();

        public new DependencyContainer Dependencies { get; private set; }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        {
            var baseDependencies = base.CreateChildDependencies(parent);
            Dependencies = new DependencyContainer(baseDependencies);

            return Dependencies;
        }

        private partial class EndangerEdDemoTestSceneTestRunner : EndangerEdDemoGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
