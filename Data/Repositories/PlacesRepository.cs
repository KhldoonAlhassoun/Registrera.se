using Registrera.se.Models;
using System.Collections.Generic;
using System.Linq;

namespace Registrera.se.Data.Repositories
{
    public class PlacesRepository
    {
        private readonly ApplicationDbContext db;

        public PlacesRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Place> GetPlaces()
        {
            return db.Places.ToList();
        }
    }
}
