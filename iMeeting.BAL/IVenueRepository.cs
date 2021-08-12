

using iMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMeeting.BAL
{
    public interface IVenueRepository
    {
        IEnumerable<VenueModel> GetVenue();
        void InsertVenue(VenueModel Venue);
        void DeleteVenue(int? Id);
        VenueModel GetById(int? id);
        void UpdateVenue(VenueModel Venue);
        
    }
}
