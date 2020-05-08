using Membership_.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Membership_.Areas.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(2048)]
        public string Description { get; set; }

        [DisplayName("Image Url")]
        [MaxLength(1024)]
        public string ImageUrl { get; set; }

        public int ProductLinkTextId { get; set; }

        public int ProductTypeId { get; set; }

        public ICollection<ProductLinkText> ProductLinkTexts { get; set; }

        public ICollection<ProductType> ProductTypes { get; set; }

        public string ProductType 
        { 
            get
            {
                return ProductTypes == null || ProductTypes.Count == 0 ? "" : ProductTypes.First(pt => pt.Id == ProductTypeId).Title;
            }
        }

        public string ProductLinkText
        {
            get
            {
                return ProductLinkTexts == null || ProductLinkTexts.Count == 0 ? "" :
                    ProductLinkTexts.First(pt => pt.Id == ProductLinkTextId).Title;
            }
        }
    }
}