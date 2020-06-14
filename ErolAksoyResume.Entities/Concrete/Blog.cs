using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Entities.Concrete
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
