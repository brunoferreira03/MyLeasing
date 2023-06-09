﻿using MyLeasing.Web.Data.Entity;
using MyLeasing.Web.Models;

namespace MyLeasing.Web.Helpers
{
    public interface IConverterHelper
    {
        Owner ToOwners(OwnersViewModel model, string path, bool isNew);

        OwnersViewModel ToOwnersViewModel(Owner owner);

        Lessee ToLessee (LesseeViewModel model, string path, bool isNew);

        LesseeViewModel ToLesseeViewModel(Lessee lessee);

    }
}
