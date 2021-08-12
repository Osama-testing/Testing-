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
        IEnumerable<MeetingModel> FliterMeeting(string Filter);
        IEnumerable<MeetingModel> FilterDate(string Filter);


    }
}
