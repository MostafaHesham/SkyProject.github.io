//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SkyTravelsSys.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OperationTbl
    {
        public int ID { get; set; }
        public Nullable<int> OperationDay { get; set; }
        public Nullable<System.DateTime> OperationDate { get; set; }
        public string REG { get; set; }
        public string FlightNumber { get; set; }
        public string AirportFrom { get; set; }
        public string AirportTo { get; set; }
        public string TakeOFF { get; set; }
        public string Landing { get; set; }
        public Nullable<int> PAX { get; set; }
        public Nullable<int> CaptainID { get; set; }
        public Nullable<int> FirstOfficerID { get; set; }
        public string Cabin { get; set; }
        public string Client { get; set; }
        public Nullable<bool> IsCanceled { get; set; }
    }
}
