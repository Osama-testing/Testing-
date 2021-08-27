using iMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMeeting.BAL
{
    public class VenueRepository : IVenueRepository
    {
        private DB_Context _context;
        private  ApplicationDbContext _applicationDb;
        public VenueRepository(DB_Context dB_Context, ApplicationDbContext applicationDb)
        {
            this._context = dB_Context;
            this._applicationDb = applicationDb;
        }

        public IEnumerable<VenueModel> GetVenue()
        {
            return _context.Venue.ToList();
        }

        public void InsertVenue(VenueModel Venue)
        {
            _context.Venue.Add(Venue);
            _context.SaveChanges();
        }

        public void DeleteVenue(int? Id)
        {
            VenueModel Venue = _context.Venue.Find(Id);
             _context.Venue.Remove(Venue);
             _context.Venue.Remove(Venue);
            _context.SaveChanges();
        }
        
        public VenueModel GetById(int? id)
        {
            return _context.Venue.FirstOrDefault(x => x.ID == id);
        }

        public void UpdateVenue(VenueModel Venue)
        {
            _context.Entry(Venue).State = EntityState.Modified;
            _context.SaveChanges();
        }

  
    }
}
