//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MoviesCatalog.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Movie
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<short> Year { get; set; }
        public string Producer { get; set; }
        public string ImageName { get; set; }
    
        public virtual User User { get; set; }
    }
}
