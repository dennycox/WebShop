﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Repositories
{
    public interface IProfileRepository
    {
        public Profile GetProfileById(int id);
        public void UpdateProfile(Profile profile);
    }
}
