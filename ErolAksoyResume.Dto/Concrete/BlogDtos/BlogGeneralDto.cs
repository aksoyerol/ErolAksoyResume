using ErolAksoyResume.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErolAksoyResume.Dto.Concrete.BlogDtos
{
    public class BlogGeneralDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
        public int AppUserId { get; set; } = 1;
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public SelectList CategoryList { get; set; }
        public SelectList SubCategoryList { get; set; }
    }
}
