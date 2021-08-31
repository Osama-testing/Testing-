using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMeeting.DAL
{
    [Table("Meeting")]
    public class MeetingModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(1000)]
        public string Agenda { get; set; }
        [MaxLength(1000)]
        public string Notes { get; set; }
        public string File { get; set; }
        public string Links { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Duration { get; set; }
        public string Location { get; set; }
        public string Participants { get; set; }
        public int IsActive { get; set; }
                        
    }
}
