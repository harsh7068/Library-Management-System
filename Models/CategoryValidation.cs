using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Management_System.Models
{
    [MetadataType(typeof(categoryMetaData))]
    public partial class tblCategory
    {
        public class categoryMetaData
        {
            [DisplayName("Category Name")]
            public string catName { get; set; }
            [DisplayName("Category Status")]
            public string catStatus { get; set; }
        }
    }
}