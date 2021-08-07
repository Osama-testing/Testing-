using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMeeting.DAL
{
    [Table("Venue")]
    public class VenueModel
    {
        public int ID { get; set; }
        public string RoomName { get; set; }
        public string Location { get; set; }
        public int Limit { get; set; }

    }
}
