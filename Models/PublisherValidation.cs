using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Library_Management_System.Models.tblAuthor;

namespace Library_Management_System.Models
{
    [MetadataType(typeof(PublisherMetaData))]
    public partial class tblPublisher
    {
        public class PublisherMetaData
        {
            [DisplayName("Publisher Name")]
            public string pubName { get; set; }
            [DisplayName("Publisher Address")]
            public string pubAddress { get; set; }
            [DisplayName("Publisher Phone Number")]
            public Nullable<long> pubPhone { get; set; }
        }
    }
}