using MyLeasing.Web.Data.Entity;
using MyLeasing.Web.Models;

namespace MyLeasing.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Lessee ToLessee(LesseeViewModel model, string path, bool isNew)
        {
            return new Lessee
            {
                Id = isNew ? 0 : model.Id,
                ImageURL = path,
                Address = model.Address,
                Cell_Phone = model.Cell_Phone,
                Document = model.Document,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Fixed_Phone = model.Fixed_Phone,
                User = model.User,
            };
        }

        public LesseeViewModel ToLesseeViewModel(Lessee lessee)
        {
            return new LesseeViewModel
            {
                Document = lessee.Document,
                Id = lessee.Id,
                FirstName = lessee.FirstName,
                LastName = lessee.LastName,
                Fixed_Phone= lessee.Fixed_Phone,
                Cell_Phone = lessee.Cell_Phone,
                Address = lessee.Address,
                ImageURL= lessee.ImageURL,
                User = lessee.User,
            };
        }

        public Owner ToOwners(OwnersViewModel model, string path, bool isNew)
        {
            return new Owner
            {
                Id = isNew ? 0 : model.Id,
                ImageURL = path,
                Address = model.Address,
                Cell_Phone = model.Cell_Phone,
                Document = model.Document,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Fixed_Phone = model.Fixed_Phone,
                user = model.user
            };
        }

        public OwnersViewModel ToOwnersViewModel(Owner owner)
        {
            return new OwnersViewModel
            {
                Document = owner.Document,
                Id = owner.Id,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Fixed_Phone = owner.Fixed_Phone,
                Cell_Phone = owner.Cell_Phone,
                Address = owner.Address,
                ImageURL = owner.ImageURL,
                user = owner.user,
            };
        }

    }
}
