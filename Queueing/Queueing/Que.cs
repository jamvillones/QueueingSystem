//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Queueing
{
    using System;
    using System.Collections.Generic;
    
    public partial class Que
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Que()
        {
            this.Counters = new HashSet<Counter>();
        }
    
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Number { get; set; }
        public bool Pending { get; set; }
        public bool Priority { get; set; }
    
        public virtual Item Item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Counter> Counters { get; set; }
    }
}
