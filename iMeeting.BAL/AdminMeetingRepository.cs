using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iMeeting.DAL;

namespace iMeeting.BAL
{
    public class AdminMeetingRepository : IAdminMeetingRepository
    {
        private DB_Context _context;
        public AdminMeetingRepository(DB_Context dB_Context)
        {
            this._context = dB_Context;
        }

        public IEnumerable<MeetingModel> FilterDate(string Filter)
        {
            DateTime dtFrom = Convert.ToDateTime(Filter);
            return _context.Meeting.Where(x => x.IsActive == 1 && dtFrom.Day == x.DateTime.Day).ToList();
            //return _context.Meeting.Where(x => x.IsActive == 1 && x.DateTime == dtFrom).ToList();
        }

        public IEnumerable<MeetingModel> GetMeeting(string Filter)
        {
            if (Filter == "Today")
            {
                return _context.Meeting.Where(x => DateTime.Now.Day == x.DateTime.Day && DateTime.Now.Month == x.DateTime.Month && DateTime.Now.Year == x.DateTime.Year && x.IsActive == 1).ToList();
            }
            else if (Filter == "Tomorrow")
            {
                var Today = DateTime.Now;
                var Tomorrow = Today.AddDays(1);
                return _context.Meeting.Where(x => DateTime.Now.Day + 1 == x.DateTime.Day && DateTime.Now.Month == x.DateTime.Month && DateTime.Now.Year == x.DateTime.Year && x.IsActive == 1).ToList();
            }
            else if (Filter == "ThisMonth")
            {
                DateTime dateTime = DateTime.Now;
                var Today = dateTime.Month;
                return _context.Meeting.Where(x => x.DateTime.Month == Today && x.IsActive == 1).ToList();

            }
            else if (Filter == "ThisWeek")
            {
                var Today = DateTime.Today;
                var ThisWeek = Today.AddDays(7);
                return _context.Meeting.Where(x => x.DateTime >= Today && x.DateTime < ThisWeek && x.IsActive == 1).ToList();

            }
            return _context.Meeting.Where(x => x.IsActive == 1).ToList();
        }

        public IEnumerable<MeetingModel> GetMeeting()
        {
            return _context.Meeting.Where(x => x.IsActive == 1).ToList();

        }

        public void CreateMeeting(MeetingModel Meeting)
        {
            _context.Meeting.Add(Meeting);
            _context.SaveChanges();
          

        }

        public void CreateMeetingParticipants(Meeting_Participants meet_Participants)
        {
            _context.Meeting_Participants.Add(meet_Participants);
            _context.SaveChanges();
        }
        //public void CreateMeetingParticipants(Meet_Participants_Model meet_Participants)
        //{
        //    _context.Meet_Participants_Models.Add(meet_Participants);
        //    _context.SaveChanges();
        //}
    }
}
