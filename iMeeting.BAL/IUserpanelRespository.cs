using iMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMeeting.BAL
{
  public   interface IUserpanelRespository
    {
        IEnumerable<MeetingModel> GetMeeting();
        IEnumerable<MeetingModel> FliterMeeting(string Filter, String currentLoginUserId);
        IEnumerable<MeetingModel> FilterDate(string Filter);
        void UpdateMeetingStatus(Meeting_Participants Participants);
        Meeting_Participants GetById(int? id);

    }
}
