//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SHIVAMFaceEcomm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tax
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public string Category { get; set; }
        public double Rate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int Sort { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
    }
}
