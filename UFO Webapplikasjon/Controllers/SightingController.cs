using UFO_Webapplikasjon.DAL;
using UFO_Webapplikasjon.Model;
using Microsoft.AspNetCore.Mvc;

namespace UFO_Webapplikasjon.Controllers
{
    [Route("[controller]/[action]")]
    public class SightingController : ControllerBase
    {
        private readonly InSightingRepository _db;

        public SightingController(InSightingRepository db)
        {
            _db = db;
        }

        public async Task<bool> Lagre(Sighting innSighting)
        {
            return await _db.Lagre(innSighting);
        }

        public async Task<List<Sighting>> HentAlle()
        {
            return await _db.HentAlle();
        }

        public async Task<bool> Slett(int id)
        {
            return await _db.Slett(id);
        }

        public async Task<Sighting> HentEn(int id)
        {
            return await _db.HentEn(id);
        }

        public async Task<bool> Endre(Sighting endreSighting)
        {
            return await _db.Endre(endreSighting);
        }
    }
}
