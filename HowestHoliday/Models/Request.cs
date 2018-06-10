using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HowestHoliday.Models
{

    public enum StatusCode: byte
    {
        New = 0,
        Approved = 1,
        Denied = 2
    }

    public partial class Request
    {
        public int RequestId { get; set; }
        public string Requestor { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [Display(Name = "Requestor's motivation")]
        public string MotivationRequestor { get; set; }
        public StatusCode Status { get; set; } = StatusCode.New;
        public string Manager { get; set; }
        
        [Display(Name = "Manager's motivation")]
        public string MotivationManager { get; set; }
    }
}
