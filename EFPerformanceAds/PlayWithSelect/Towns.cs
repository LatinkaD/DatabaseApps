//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlayWithSelect
{
    using System;
    using System.Collections.Generic;
    
    public partial class Towns
    {
        public Towns()
        {
            this.Ads = new HashSet<Ads>();
            this.AspNetUsers = new HashSet<AspNetUsers>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Ads> Ads { get; set; }
        public virtual ICollection<AspNetUsers> AspNetUsers { get; set; }
    }
}