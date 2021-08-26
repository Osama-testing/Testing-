using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMeeting.DAL
{
    [Table("Meeting_Participants")]
    public class Meet_Participants_Models
    {
        public int Id { get; set; }
        public int Prticipants_Id { get; set; }
        public int Meeting_Id { get; set; }
        public int Status { get; set; }
    }
}
