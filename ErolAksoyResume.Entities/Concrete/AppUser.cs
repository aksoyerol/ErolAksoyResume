﻿using ErolAksoyResume.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ProfileImageUrl { get; set; }
        public string CvLinkUrl { get; set; }
        public string Phone { get; set; }
        public string About { get; set; }
        public string Status { get; set; }
        public string Adress { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Github { get; set; }
        public string Medium { get; set; }

        public List<Blog> Blogs { get; set; }

    }
}
