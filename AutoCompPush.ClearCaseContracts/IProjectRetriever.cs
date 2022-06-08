using System.Collections.Generic;

namespace AutoCompPush.ClearCaseContracts
{
    public interface IProjectRetriever
    {
        IEnumerable<IProject> GetAllProjects(Pvob pvob);
        IAsyncEnumerable<IProject> GetAllProjectsAsync(Pvob pvob);
    }
}
