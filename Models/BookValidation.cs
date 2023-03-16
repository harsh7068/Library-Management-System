using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Library_Management_System.Models.tblMember;

namespace Library_Management_System.Models
{
    [MetadataType(typeof(BookMetaData))]
    public partial class tblBook
    {
        public class BookMetaData
        {
            [DisplayName("Book Name")]
            public string bookName { get; set; }
            [DisplayName("Category")]
            public Nullable<int> catID { get; set; }
            [DisplayName("Author")]
            public Nullable<int> authID { get; set; }
            [DisplayName("Publisher")]
            public Nullable<int> pubId { get; set; }
            [DisplayName("Book Contents")]
            public string bookContents { get; set; }
            [DisplayName("Book Pages")]
            public Nullable<int> bookPages { get; set; }
            [DisplayName("Book Edition")]
            public string bookEdition { get; set; }

            public virtual tblAuthor tblAuthor { get; set; }
            public virtual tblCategory tblCategory { get; set; }
            public virtual tblPublisher tblPublisher { get; set; }

        }
    }
}