//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practic
{
    using System;
    using System.Collections.Generic;
    
    public partial class Record
    {
        public int id_Record { get; set; }
        public string Familiy { get; set; }
        public string Name { get; set; }
        public string Otchestvo { get; set; }
        public Nullable<int> Datero { get; set; }
        public string Pochta { get; set; }
        public Nullable<int> Telefon { get; set; }
        public Nullable<int> id_Otdels { get; set; }
        public Nullable<System.DateTime> dataTime { get; set; }
    
        public virtual Otdels Otdels { get; set; }
    }
}
