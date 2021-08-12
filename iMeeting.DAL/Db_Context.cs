
using MySql.Data.Entity;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMeeting.DAL
{
    public class DB_Context : DbContext
    {
        public DB_Context()
            //Reference the name of your connection string ( WebAppCon )  
            : base("DefaultConnection") { }

        public DbSet<VenueModel> Venue { get; set; }
        public DbSet<MeetingModel> Meeting { get; set; }

    }
}
