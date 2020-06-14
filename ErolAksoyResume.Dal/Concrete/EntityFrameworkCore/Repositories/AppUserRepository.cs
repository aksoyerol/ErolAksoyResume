﻿using ErolAksoyResume.Dal.Interfaces;
using ErolAksoyResume.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dal.Concrete.EntityFrameworkCore.Repositories
{
    public class AppUserRepository : GenericRepository<AppUser>, IAppUserDal
    {
    }
}
