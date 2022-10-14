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

                var checkPhoneNr = await _db.Clients.FindAsync(innSighting.PhoneNr);
                if (checkPhoneNr == null)
                {
                    var ClientsRow = new Clients
                    {
                        Firstname = innSighting.Firstname,
                        Lastname = innSighting.Lastname,
                        PhoneNr = innSighting.PhoneNr
                    };
                    newSightingRow.PhoneNr = ClientsRow;
                }
                else
                {
                    newSightingRow.PhoneNr = checkPhoneNr;
                }
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
                    
                    Firstname = k.PhoneNr.Firstname,
                    Lastname = k.PhoneNr.Lastname,
                    PhoneNr = k.PhoneNr.PhoneNr
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

                Firstname= singleSighting.PhoneNr.Firstname,
                Lastname = singleSighting.PhoneNr.Lastname,
                PhoneNr = singleSighting.PhoneNr.PhoneNr
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
                if (endreObjekt.PhoneNr.PhoneNr != endreSighting.PhoneNr)
                {
                    var sjekkPostnr = _db.Clients.Find(endreSighting.PhoneNr);
                    if (sjekkPostnr == null)
                    {
                        var ClientsRow = new Clients
                        {
                            Firstname = endreSighting.Firstname,
                            Lastname = endreSighting.Lastname,
                            PhoneNr = endreSighting.PhoneNr
                        };
                        endreObjekt.PhoneNr = ClientsRow;
                    }
                    else
                    {
                        endreObjekt.PhoneNr.PhoneNr = endreSighting.PhoneNr;
                    }
                }
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
