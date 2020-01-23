using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SkyTravelsSys.ViewModels
{
    public class TaskViewModel
    {
        [Required]
        [Display(Name = "Operation Day")]
        public List<DropDownListModel> Days { get; set; }
        public string DayId { get; set; }
        public string DayName { get; set; }

        [Required]
        [Display(Name = "Day")]
        public DateTime Calender { get; set; }

        [Required]
        [Display(Name = "REG")]
        public string Reg { get; set; }

        [Required]
        [Display(Name = "FLT NO.SME")]
        public string FlightNumber { get; set; }

        [Required]
        [Display(Name = "Airport From")]
        public string AirportFrom { get; set; }

        [Required]
        [Display(Name = "Airport To")]
        public string AirportTo { get; set; }

        [Required]
        [Display(Name = "Take Off")]
        public string TakeOff { get; set; }

        [Required]
        [Display(Name = "Landing")]
        public string Landing { get; set; }

        [Required]
        [Display(Name = "PAX")]
        public int Pax { get; set; }

        [Required]
        [Display(Name = "CPT")]
        public List<DropDownListModel> Captain { get; set; }
        public string CaptinId { get; set; }
        public string CaptinName { get; set; }

        [Required]
        [Display(Name = "FO")]
        public List<DropDownListModel> FirstOfficer { get; set; }
        public string firstOfficerId { get; set; }
        public string firstOfficerName { get; set; }

      
        public List<DropDownListModel> CABIN { get; set; }
        public string CabindId { get; set; }
        [Required]
        [Display(Name = "CABIN")]
        public string CabindName { get; set; }


        [Required]
        [Display(Name = "Client")]
        public string Client { get; set; }
    }
}