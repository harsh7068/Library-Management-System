//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Library_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblIssueBook
    {
        public int issueID { get; set; }
        public Nullable<int> memID { get; set; }
        public string bookID { get; set; }
        public Nullable<System.DateTime> issueDate { get; set; }
        public Nullable<System.DateTime> returnDate { get; set; }
        public string ISBN_Number { get; set; }
    }
}
