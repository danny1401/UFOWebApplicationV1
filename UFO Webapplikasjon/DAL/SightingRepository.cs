using UFO_Webapplikasjon.Model;
using Microsoft.EntityFrameworkCore;

namespace UFO_Webapplikasjon.DAL
{
    public class SightingRepository : InSightingRepository
    {
        private readonly SightingContext _db;

        public SightingRepository(SightingContext db)
        {
            _db = db;
        }

        public async Task<bool> Lagre(Sighting innSighting)
        {
            try
            {
                var newSightingRow = new Sightings();

                newSightingRow.City = innSighting.City;
                newSightingRow.Country = innSighting.Country;
                newSightingRow.Duration = innSighting.Duration;
                newSightingRow.Dateposted = innSighting.Dateposted;
                newSightingRow.Datetime = innSighting.Datetime;
                newSightingRow.Comments = innSighting.Comments;

                _db.Sightings.Add(newSightingRow);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<List<Sighting>?> HentAlle()
        {
            try
            {
                List<Sighting> everySightings = await _db.Sightings.Select(k => new Sighting
                {
                    Id = k.Id,
                    City = k.City,
                    Country = k.Country,
                    Duration = k.Duration,
                    Datetime = k.Datetime,
                    Dateposted = k.Dateposted,
                    Comments = k.Comments,
                }).ToListAsync();

                return everySightings;
            }
            catch
            {
                return null;
            }
        }


        public async Task<Sighting> HentEn(int Id)
        {
            Sightings singleSighting = await _db.Sightings.FindAsync(Id);
            var hentetKunde = new Sighting()
            {
                Id = singleSighting.Id,
                City = singleSighting.City,
                Country = singleSighting.Country,
                Duration = singleSighting.Duration,
                Dateposted = singleSighting.Dateposted,
                Datetime = singleSighting.Datetime,
                Comments = singleSighting.Comments,
            };
            return hentetKunde;
        }


        public async Task<bool> Slett(int id)
        {
            try
            {
                Sightings singleDBSighting = await _db.Sightings.FindAsync(id);
                _db.Sightings.Remove(singleDBSighting);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> Endre(Sighting endreSighting)
        {
            try
            {
                var endreObjekt = await _db.Sightings.FindAsync(endreSighting.Id);

                endreObjekt.City = endreSighting.City;
                endreObjekt.Country = endreSighting.Country;
                endreObjekt.Duration = endreSighting.Duration;
                endreObjekt.Dateposted = endreSighting.Dateposted;
                endreObjekt.Datetime = endreSighting.Datetime;
                endreObjekt.Comments = endreSighting.Comments;

        await _db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
