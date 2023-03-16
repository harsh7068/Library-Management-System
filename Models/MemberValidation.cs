using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Library_Management_System.Models.tblPublisher;

namespace Library_Management_System.Models
{
    [MetadataType(typeof(MemberMetaData))]
    public partial class tblMember
    {
        public class MemberMetaData
        {
            [DisplayName("Member Name")]
            public string memName { get; set; }
            [DisplayName("Member Address")]
            public string memAddress { get; set; }
            [DisplayName("Member Phone Number")]
            public Nullable<long> memPhoen { get; set; }
        }
    }
}