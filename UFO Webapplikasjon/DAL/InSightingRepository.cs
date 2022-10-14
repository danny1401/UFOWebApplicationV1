
using UFO_Webapplikasjon.Model;

namespace UFO_Webapplikasjon.DAL
{
    public interface InSightingRepository
    {
        Task<bool> Lagre(Sighting innSighting);
        Task<List<Sighting>> HentAlle();
        Task<bool> Slett(int id);
        Task<Sighting> HentEn(int id);
        Task<bool> Endre(Sighting endreSighting);
    }
}
