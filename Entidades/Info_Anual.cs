//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entidades
{
    using System;
    using System.Collections.Generic;
    
    public partial class Info_Anual
    {
        public string codigo_prd { get; set; }
        public decimal id_franqueado { get; set; }
        public short ano { get; set; }
        public int quantidade { get; set; }
    
        public virtual Franqueado_Vende_Produto Franqueado_Vende_Produto { get; set; }
    }
}