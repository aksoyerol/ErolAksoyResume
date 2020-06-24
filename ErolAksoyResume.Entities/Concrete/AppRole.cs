using ErolAksoyResume.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Entities.Concrete
{
    public class AppRole :IdentityRole<int>, ITable
    {
    }
}
