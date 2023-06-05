using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entity;
using MyLeasing.Web.Helpers;
using MyLeasing.Web.Models;

namespace MyLeasing.Web.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUserHelper _userhelper;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        public OwnersController(IOwnerRepository repository,
            IUserHelper userhelper,
            IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _ownerRepository = repository;
            _userhelper = userhelper;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        // GET: Owners
        public IActionResult Index()
        {
            return View(_ownerRepository.GetAll().OrderBy(o => o.FirstName).ThenBy(o => o.LastName));
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _ownerRepository.GetByIdAsync(id.Value);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OwnersViewModel model) //[Bind("Id,Document,FirstName,LastName,Fixed_Phone,Cell_Phone,Address")]
        {
            if (ModelState.IsValid)
            {
                model.user = new User
                {
                    Document = model.Document,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                };

                var path = string.Empty;

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile, "owners");
                }

                var owner = _converterHelper.ToOwners(model, path, true);//ToOwner(model, path);

                await _ownerRepository.CreateAsync(owner);

                await _userhelper.AddUserAsync(model.user, "123456");

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var owner = await _ownerRepository.GetByIdAsync(id.Value);
            

            if (owner == null)
            {
                return NotFound();
            }

            var model = _converterHelper.ToOwnersViewModel(owner);
            return View(model);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OwnersViewModel model) //[Bind("Id,Document,Name,Fixed_Phone,Cell_Phone,Address")]
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = model.ImageURL;

                    if (model.ImageFile != null && model.ImageFile.Length > 0)
                    {
                        path = await _imageHelper.UploadImageAsync(model.ImageFile, "owners");
                    }

                    var owner = _converterHelper.ToOwners(model, path, false);

                    //TODO: Modificar para o user que estiver logado
                    //product.user = await _userhelper.getuserbyemailasync("email");

                    await _ownerRepository.UpdateAsync(owner);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _ownerRepository.ExistAsync(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _ownerRepository.GetByIdAsync(id.Value);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            await _ownerRepository.DeleteAsync(owner);
            return RedirectToAction(nameof(Index));
        }
    }
}
