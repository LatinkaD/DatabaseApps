//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityMapping
{
    using System;
    using System.Collections.Generic;
    
    public partial class Team
    {
        public Team()
        {
            this.TeamMatches = new HashSet<TeamMatch>();
            this.TeamMatches1 = new HashSet<TeamMatch>();
            this.Leagues = new HashSet<League>();
        }
    
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string CountryCode { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual ICollection<TeamMatch> TeamMatches { get; set; }
        public virtual ICollection<TeamMatch> TeamMatches1 { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
    }
}
