﻿using ErolAksoyResume.Dto.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.TestimionalDtos
{
    public class TestimionalAddDto : IDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDraft { get; set; }
    }
}
