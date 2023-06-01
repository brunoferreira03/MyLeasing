using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Web.Data;
using MyLeasing.Web.Data.Entity;
using MyLeasing.Web.Helpers;

namespace MyLeasing.Web.Controllers
{
    public class OwnersController : Controller
    {
        private readonly IOwnerRepository _repository;
        private readonly IUserHelper _userhelper;

        public OwnersController(IOwnerRepository repository, IUserHelper userhelper)
        {
            _repository = repository;
            _userhelper = userhelper;
        }

        // GET: Owners
        public IActionResult Index()
        {
            return View(_repository.GetAll().OrderBy(o => o.FirstName).ThenBy(o => o.LastName));
        }

        // GET: Owners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _repository.GetByIdAsync(id.Value);
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
        public async Task<IActionResult> Create(Owner owner) //[Bind("Id,Document,FirstName,LastName,Fixed_Phone,Cell_Phone,Address")]
        {
            if (ModelState.IsValid)
            {
                owner.user = new User
                {
                    Document = owner.Document,
                    FirstName = owner.FirstName,
                    LastName = owner.LastName,
                    Address = owner.Address,
                };
                await _repository.CreateAsync(owner);

                await _userhelper.AddUserAsync(owner.user, "123456");

                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var owner = await _repository.GetByIdAsync(id.Value);
            

            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Owner owner) //[Bind("Id,Document,Name,Fixed_Phone,Cell_Phone,Address")]
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.UpdateAsync(owner);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _repository.ExistAsync(owner.Id))
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
            return View(owner);
        }

        // GET: Owners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var owner = await _repository.GetByIdAsync(id.Value);
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
            var owner = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(owner);
            return RedirectToAction(nameof(Index));
        }
    }
}
