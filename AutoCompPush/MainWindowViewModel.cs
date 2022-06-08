using AutoCompPush.ClearCaseContracts;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AutoCompPush
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IProjectRetriever projectRetriever)
        {
            this.projectRetriever = projectRetriever;
            ProjectList = new ObservableCollection<IProject>();
            Initialization = Initialize();
        }

        private async Task Initialize()
        {
            await foreach (var project in projectRetriever.GetAllProjectsAsync(new Pvob("pvob")))
            {
                ProjectList.Add(project);
            }
        }

        internal ObservableCollection<IProject> ProjectList;

        public Task Initialization { get; }

        private readonly IProjectRetriever projectRetriever;

        public int GetProjectCount => ProjectList.Count;
    }
}
