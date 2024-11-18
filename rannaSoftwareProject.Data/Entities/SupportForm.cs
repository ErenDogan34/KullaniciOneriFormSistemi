using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rannaSoftwareProject.Data.Entities
{
    public class SupportForm:BaseEntity
    {
        public SupportForm()
        {
            CreatedDate = DateTime.Now;
            Status = FormStatus.Pending;
        }

        public string? UserId { get; set; } 
        public string? Subject { get; set; } 
        public string? Message { get; set; } 

        public DateTime CreatedDate { get; set; } 
        public FormStatus Status { get; set; } 
    }

    public enum FormStatus
    {
        Pending,    
        Processed,   
        Deleted      
    }
}

