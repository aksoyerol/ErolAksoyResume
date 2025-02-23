﻿using ErolAksoyResume.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Entities.Concrete
{
    public class Category : ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SubCategory> SubCategories { get; set; }

    }
}
