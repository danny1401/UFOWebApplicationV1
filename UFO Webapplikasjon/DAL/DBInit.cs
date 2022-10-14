namespace UFO_Webapplikasjon.Model
{
    public static class DBInit
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<SightingContext>();

                // må slette og opprette databasen hver gang når den skal initieres (seed`es)
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var poststed1 = new Clients { Firstname = "Testing", Lastname = "Test", PhoneNr = "12345678" };
                var poststed2 = new Clients { Firstname = "Ola", Lastname = "Nordmann", PhoneNr = "11111111" };

                var kunde1 = new Sightings { City = "Oslo", Country = "Norway", Duration = "2 hours", Dateposted = "03/12/2022", Datetime = "10 seconds", Comments = "Just testing this application", PhoneNr = poststed1 };
                var kunde2 = new Sightings { City = "Kobenhagen", Country = "Denmark", Duration = "3 min", Dateposted = "11/11/2011", Datetime = "About 23 minutes", Comments = "Nothing really happened", PhoneNr = poststed2 };

                context.Sightings.Add(kunde1);
                context.Sightings.Add(kunde2);

                context.SaveChanges();
            }
        }
    }    
}
