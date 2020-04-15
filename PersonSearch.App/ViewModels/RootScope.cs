using DotNetify;
using JetBrains.Annotations;

namespace PersonSearch.App.ViewModels
{
    [UsedImplicitly]
    public class RootScope : BaseVM
    {
        //this class needs to exist to allow a default root scope to be defined in the main app view
        //but it needs no implementation unless you want to re-act to child VM changes at the root level.
        //commonly this is done within a more specific child scope
    }
}