using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Models;
using WebShop.Repositories;
using WebShop.Utilities;

namespace WebShop.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileController(IProfileRepository profileRepository)
        {
            this._profileRepository = profileRepository;
        }

        public IActionResult Details(int id)
        {
            Profile profile = _profileRepository.GetProfileById(id);
            return View(profile);
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            Profile profile = _profileRepository.GetProfileById(id);

            return View(profile);
        }

        // POST: Profile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Profile profile)
        {
            try
            {
                var oldProfile = _profileRepository.GetProfileById(id);

                profile.ID = id;
                _profileRepository.UpdateProfile(profile);

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }
    }
}