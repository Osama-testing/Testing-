using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMeeting.DAL
{
    [Table("Meeting_Participants")]
  public  class Meeting_Participants
    {
        [Key]
        public int Table_Id { get; set; }
        public string Prticipants_Id { get; set; }
        // Foreign key
        public int Id { get; set; }
        public int Status { get; set; }
        [ForeignKey("Id")]
        public virtual MeetingModel Meeting { get; set; }

    }

}
