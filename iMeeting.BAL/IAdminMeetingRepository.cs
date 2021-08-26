﻿using iMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMeeting.BAL
{
   public interface IAdminMeetingRepository
    {
        IEnumerable<MeetingModel> GetMeeting(string Filter);
        IEnumerable<MeetingModel> GetMeeting();

        IEnumerable<MeetingModel> FilterDate(string Filter);

        void CreateMeeting(MeetingModel Meeting);
        void CreateMeetingParticipants(Meet_Participants_Models meet_Participants);



    }
}
