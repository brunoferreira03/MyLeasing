using MyLeasing.Web.Data.Entity;
using MyLeasing.Web.Models;

namespace MyLeasing.Web.Helpers
{
    public interface IConverterHelper
    {
        Owner ToOwners(OwnersViewModel model, string path, bool isNew);

        OwnersViewModel ToOwnersViewModel(Owner owner);
    }
}
