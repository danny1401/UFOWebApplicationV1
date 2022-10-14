using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UFO_Webapplikasjon.Model
{
    public class Sightings
    {        
        public int Id { get; set; } // LAGE EN ID FOR BEGGE KLASSENE FOR RELASJONER?
        public string City { get; set; }
        public string Country { get; set; }
        public string Duration { get; set; }
        public string Dateposted { get; set; }
        public string Datetime { get; set; }
        public string Comments { get; set; }

        virtual public Clients PhoneNr { get; set; }
    }
    
    public class Clients
    {
        [Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNr { get; set; }

        // denne listen ikke nødvendig med mindre man skal finne kundene på et gitt postnr (altså gå inn via Poststeder-collection)
        virtual public List<Sightings> Sightings { get; set; }  
    }

    public class SightingContext : DbContext
    {
        public SightingContext (DbContextOptions<SightingContext> options)
                    : base(options)
            {
                // denne brukes for å opprette databasen fysisk dersom den ikke er opprettet
                // dette er uavhenig av initiering av databasen (seeding)
                // når man endrer på strukturen på KundeContxt her er det fornuftlig å slette denne fysisk før nye kjøringer
                Database.EnsureCreated();
        }

        public DbSet<Sightings> Sightings { get; set; }
        public DbSet<Clients> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // må importere pakken Microsoft.EntityFrameworkCore.Proxies
            // og legge til"viritual" på de attriuttene som ønskes å lastes automatisk (LazyLoading)
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
