
using UFO_Webapplikasjon.Model;

namespace UFO_Webapplikasjon.DAL
{
    public interface InSightingRepository
    {
        Task<bool> Create(Sighting innSighting);
        Task<List<Sighting>> ReadAll();
        Task<List<Sighting>> ReadIdDesc();
        Task<List<Sighting>> ReadCountryAsc();
        Task<List<Sighting>> ReadCountryDesc();
        Task<List<Sighting>> ReadCityAsc();
        Task<List<Sighting>> ReadCityDesc();
        Task<bool> Delete(int id);
        Task<Sighting> HentEn(int id);
        Task<bool> Endre(Sighting endreSighting);
    }
}
