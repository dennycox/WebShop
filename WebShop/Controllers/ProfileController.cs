using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Repositories;
using WebShop.Utilities;
using WebShop.ViewModels;

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
            ProfileViewModel profileViewModel = _profileRepository.GetProfileById(id);
            return View(profileViewModel);
        }
    }
}