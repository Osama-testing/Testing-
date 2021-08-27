
using iMeeting.DAL;
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
        public DbSet<Meeting_Participants> Meeting_Participants { get; set; }
      //  public DbSet<MeeetingStatus> Meetings { get; set; }
       // public DbSet<TestingTbl2> TestingTbl2 { get; set; }
    }
}
