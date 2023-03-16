using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Library_Management_System.Models.tblCategory;

namespace Library_Management_System.Models
{
    [MetadataType(typeof(AuthorMetaData))]
    public partial class tblAuthor
    {
        public class AuthorMetaData
        {
            [DisplayName("Author Name")]
            public string authName { get; set; }
            [DisplayName("Author Address")]
            public string authAddress { get; set; }
            [DisplayName("Author Phone Number")]
            public Nullable<long> authPhone { get; set; }
        }
    }
}