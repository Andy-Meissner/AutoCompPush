using AutoCompPush;
using AutoCompPush.ClearCaseContracts;
using Moq;

namespace AutoCompPushTests
{
    public class SourceProjectTests
    {
        Mock<IProjectRetriever> mock;

        public static async IAsyncEnumerable<IProject> GetProjectList()
        {
            using StreamReader reader = File.OpenText("ProjectList.txt");
            while (!reader.EndOfStream)
            {
                var mock = new Mock<IProject>();
                mock.Setup(p => p.Name).Returns(await reader.ReadLineAsync());
                yield return mock.Object;
            }
        }

        [SetUp]
        public void Setup()
        {
            mock = new Mock<IProjectRetriever>();
            mock.Setup(c => c.GetAllProjectsAsync(It.IsAny<Pvob>()))
                .Returns(GetProjectList);
        }

        [Test]
        public async Task AfterInitialization_ViewModel_DoesHaveProjectList()
        {
            var vm = new MainWindowViewModel(mock.Object);
            await vm.Initialization;
            Assert.That(vm.GetProjectCount, Is.EqualTo(401));
        }
    }
}