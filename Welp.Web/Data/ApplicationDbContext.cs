using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Welp.Web.Models;

namespace Welp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<TagLine> TagLines { get; set; }
        public DbSet<WelpService> Services { get; set; }
        public DbSet<WelpServiceCategory> Categories { get; set; }
        public DbSet<WelpServiceOption> Options { get; set; }
        public DbSet<WelpServiceOptionDropItem> DropItems { get; set; }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Locality> Localities { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public void SeedAll()
        {
            
            SeedTagLines();
            SeedCategories();
            SeedCounties();
            SaveChanges();
            SeedLocalities();
            SaveChanges();
            SeedProfiles().Wait();
            SaveChanges();
        }

        public void SeedTagLines()
        {
            if (!TagLines.Any())
            {
                TagLines.AddRange(
                    new TagLine() { Probability = 100, Text = "Specialiștii tăi" },
                    new TagLine() { Probability = 50, Text = "O dregem cumva" },
                    new TagLine() { Probability = 50, Text = "Specialistul tău" },
                    new TagLine() { Probability = 50, Text = "Alături de tine" },
                    new TagLine() { Probability = 30, Text = "Specialiști în tehnologie" },
                    new TagLine() { Probability = 20, Text = "Toți pentru unul" }
                    );
            }
        }

        public void SeedCategories()
        {
            if (!Categories.Any())
            {
                Categories.AddRange(
                    new WelpServiceCategory() { Text = "Reparații calculatoare și suport tehnic" },
                    new WelpServiceCategory() { Text = "Multimedia, TV și audio" },
                    new WelpServiceCategory() { Text = "Rețele și Internet" },
                    new WelpServiceCategory() { Text = "Telefoane mobile și tablete" },
                    new WelpServiceCategory() { Text = "Jocuri video" },
                    new WelpServiceCategory() { Text = "Automatizări" },
                    new WelpServiceCategory() { Text = "Cursuri de utilizare" },
                    new WelpServiceCategory() { Text = "Asistență" }
                    );
            }
        }


        public void SeedCounties()
        {
            if (!Counties.Any())
            {
                Counties.AddRange(
                    new County() { Name = "București"},
                    new County() { Name = "Ilfov" }
                    );
            }
        }


        public void SeedLocalities()
        {
            if (!Localities.Any())
            {
                var county = Counties.FirstOrDefault(c => c.Name == "București");
                Localities.AddRange(
                    new Locality() { Name = "București, sector 1", County = county, Latitude = 44.4879727, Longitude = 25.9770370 },
                    new Locality() { Name = "București, sector 2", County = county, Latitude = 44.4596066, Longitude = 26.1140066 },
                    new Locality() { Name = "București, sector 3", County = county, Latitude = 44.4181612, Longitude = 26.1254993 },
                    new Locality() { Name = "București, sector 4", County = county, Latitude = 44.3818932, Longitude = 26.0901256 },
                    new Locality() { Name = "București, sector 5", County = county, Latitude = 44.4036918, Longitude = 26.0121403 },
                    new Locality() { Name = "București, sector 6", County = county, Latitude = 44.4428908, Longitude = 25.9833857 }
                    );

                county = Counties.FirstOrDefault(c => c.Name == "Ilfov");
                Localities.AddRange(
                    new Locality() { Name = "Voluntari", County = county, Latitude = 44.5092556, Longitude = 26.1219581 },
                    new Locality() { Name = "Popești - Leordeni", County = county, Latitude = 44.3711727, Longitude = 26.1579426 },
                    new Locality() { Name = "Dobroești", County = county, Latitude = 44.4543766, Longitude = 26.1694805 },
                    new Locality() { Name = "Roșu", County = county, Latitude = 44.4495432, Longitude = 25.9916085 },
                    new Locality() { Name = "Chiajna", County = county, Latitude = 44.4538238, Longitude = 25.963955 },
                    new Locality() { Name = "Moara Vlăsiei", County = county, Latitude = 44.6412579, Longitude = 26.1993395 }
                    );

            }
        }

        public async Task SeedProfiles()
        {
            if (!Profiles.Any())
            {
                var user = await this.Users.FirstAsync(u => u.Email == "rumbu@rumbu.ro");
                if (user != null)
                {
                    var locality = Localities.FirstOrDefault(l => l.Name == "București, sector 2");

                    var profile = new Profile()
                    {
                        Id = user.Id,
                        BirthDate = new DateTime(1975, 3, 14),
                        FirstName = "Răzvan Daniel",
                        LastName = "Ștefănescu",
                        PhoneNo = "+40726767769",
                    };

                    var address1 = new Address()
                    {
                        Profile = profile,
                        Contact = "Răzvan Ștefănescu",
                        AvailableFrom = new DateTime(1, 1, 1, 19, 0, 0),
                        AvailableTo = new DateTime(1, 1, 1, 8, 0, 0),
                        IsDefault = true,
                        Locality = locality,
                        Text = "Șos. Ștefan cel Mare nr. 48, bl. 35A, sc. A, et. 2, ap. 7",
                        Latitude = 44.4525947,
                        Longitude = 26.1141650
                    };

                    var address2 = new Address()
                    {
                        Profile = profile,
                        Contact = "Răzvan Ștefănescu",
                        AvailableFrom = new DateTime(1, 1, 1, 9, 0, 0),
                        AvailableTo = new DateTime(1, 1, 1, 18, 0, 0),
                        IsDefault = true,
                        Locality = locality,
                        Text = "Bd. Dimitrie Pompeiu nr. 6E, et. 5",
                        Latitude = 44.4811764,
                        Longitude = 26.1188864,
                    };

                    Addresses.AddRange(address1, address2);
                    Profiles.Add(profile);
                }

                user = await this.Users.FirstAsync(u => u.Email == "mihai.marincea@gmail.com");
                if (user != null)
                {
                    var profile = new Profile()
                    {
                        Id = user.Id,
                        BirthDate = new DateTime(1990, 4, 14),
                        FirstName = "Petru Mihail",
                        LastName = "Marincea",
                        PhoneNo = "++40754025905",
                    };

                    var locality = Localities.FirstOrDefault(l => l.Name == "București, sector 3");

                    var address1 = new Address()
                    {
                        Profile = profile,
                        Contact = "Mihai Marincea",
                        AvailableFrom = new DateTime(1, 1, 1, 19, 0, 0),
                        AvailableTo = new DateTime(1, 1, 1, 8, 0, 0),
                        IsDefault = true,
                        Locality = locality,
                        Text = "Str. Vlad Județul nr. 8, bl. V11",
                        Latitude = 44.4196964,
                        Longitude = 26.1276043,

                    };

                    locality = Localities.FirstOrDefault(l => l.Name == "București, sector 2");

                    var address2 = new Address()
                    {
                        Profile = profile,
                        Contact = "Mihai Marincea",
                        AvailableFrom = new DateTime(1, 1, 1, 9, 0, 0),
                        AvailableTo = new DateTime(1, 1, 1, 18, 0, 0),
                        IsDefault = true,
                        Locality = locality,
                        Text = "Bd. Dimitrie Pompeiu nr. 6E, et. 5",
                        Latitude = 44.4811764,
                        Longitude = 26.1188864,

                    };

                    Addresses.AddRange(address1, address2);
                    Profiles.Add(profile);
                }
            }
        }



        public void SeedServices()
        {

            if (!Services.Any())
            {
                //categoria din care face parte serviciul
                var category = Categories.FirstOrDefault(c => c.Text == "Reparații calculatoare și suport tehnic");

                //noul serviciu
                var service = new WelpService()
                {
                    Title = "Reparație calculator și asistență",
                    Description = "Dacă calculatorul tău este blocat, o aplicație refuză să pornească sau hard-disk-ul tău dă semne de oboseală, suntem gata să rezolvăm problema",
                    Category = category,
                    IncludedPrestations = String.Join(Environment.NewLine,
                      "Diagnostic și rezolvare",
                      "Verificare sistem",
                      "Costul eventualelor piese de schimb nu este inclus în preț"),
                    Price = 60,
                    OnlineDiscount = 10,
                    CanBePerformedOnline = true                                
                };

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Nu pornește",
                    CanBePerformedOnline = false,
                    Description = "Calculatorul nu pornește",
                    IncreaseOrDecreaseFixed = 30,
                });

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Pornește dar se blochează",
                    CanBePerformedOnline = false,
                    Description = "Calculatorul pornește dar se blochează sau afișează un mesaj de eroare",
                    IncreaseOrDecreaseFixed = 30,
                });

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Face zgomot",
                    CanBePerformedOnline = false,
                    Description = "Calculatorul pornește dar se aud permanent zgomote",
                    IncreaseOrDecreaseFixed = 30,
                });

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Nu se conectează",
                    CanBePerformedOnline = false,
                    Description = "Nu se conectează la Internet sau alt echipament de rețea",
                });

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Nu se conectează",
                    CanBePerformedOnline = false,
                    Description = "Nu se conectează la Internet sau alt echipament de rețea",
                });

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Nu recunoaște un dispozitiv extern",
                    CanBePerformedOnline = false,
                    Description = "Nu detectează un dispozitiv pe care l-am conectat prin portul USB sau altă metodă",
                });

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Nu pot deschide o aplicație",
                    CanBePerformedOnline = true,
                    Description = "O aplicație pe care am instalat-o sau am descărcat-o refuză să pornescă",
                });

                //optiune dropdown
                var opt = (new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Dropdown,
                    Text = "Ce calculator aveți",
                    Description = "Precizați tipul de calculator",
                });

                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "Stație de lucru" });
                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "Laptop", IncreaseOrDecreaseFixed = 10});

                service.Options.Add(opt);

                //optiune dropdown
                opt = (new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Dropdown,
                    Text = "Ce sistem de operare aveți",
                    Description = "Precizați sistemul de operare",
                });

                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "Windows" });
                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "OS X" });
                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "Linux", IncreaseOrDecreaseFixed = 30 });
                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "BSD", IncreaseOrDecreaseFixed = 25 });
                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "Chrome OS" });

                service.Options.Add(opt);

                //optiune text
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Text,
                    Text = "Altele",
                    Description = "Spuneți-ne în câteva cuvinte care e problema",
                });

                //in final il adaugam la lista
                Services.Add(service);

                //al doilea serviciu

                service = new WelpService()
                {
                    Title = "Optimizare",
                    Description = "Nimic nu este mai enervant decât un calculator care merge încet. Chiar și calculatoarele mai noi adună în timp fișiere inutile și aplicații nefolosite.",
                    Category = category,
                    IncludedPrestations = String.Join(Environment.NewLine,
                      "Creșterea performanței",
                      "Curățarea sistemului",
                      "Defragmentarea discurilor"),
                    Price = 40,
                    OnlineDiscount = 10,
                    CanBePerformedOnline = true
                };

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Navigația merge greu",
                    CanBePerformedOnline = true,
                    Description = "Când accesați Internetul, paginile se încarcă greu",
                });

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Durează mult până pornește",
                    CanBePerformedOnline = true,
                    Description = "Așteptați mai mult timp decât ar trebui atunci când porniți calculatorul",
                });

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Durează mult până se oprește",
                    CanBePerformedOnline = true,
                    Description = "Așteptați mai mult timp decât ar trebui atunci când opriți calculatorul",
                });

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Reacționează greu",
                    CanBePerformedOnline = false,
                    Description = "Calculatorul răspunde greu la comenzile de la tastatură sau mouse",
                });

                //optiune checkbox
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Checkbox,
                    Text = "Copierea fișierelor durează mult",
                    CanBePerformedOnline = false,
                    Description = "Atunci când copiați fișiere de pe un dispozitiv, durează mai mult decât ar trebui",
                });


                //optiune dropdown
                opt = (new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Dropdown,
                    Text = "Ce calculator aveți",
                    Description = "Precizați tipul de calculator",
                });

                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "Stație de lucru" });
                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "Laptop", IncreaseOrDecreaseFixed = 10 });

                service.Options.Add(opt);

                //optiune dropdown
                opt = (new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Dropdown,
                    Text = "Ce sistem de operare aveți",
                    Description = "Precizați sistemul de operare",
                });

                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "Windows" });
                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "OS X" });
                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "Linux", IncreaseOrDecreaseFixed = 30 });
                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "BSD", IncreaseOrDecreaseFixed = 25 });
                opt.DropDownItems.Add(new WelpServiceOptionDropItem() { Text = "Chrome OS" });

                service.Options.Add(opt);

                //optiune text
                service.Options.Add(new WelpServiceOption()
                {
                    Type = WelpServiceOptionType.Text,
                    Text = "Altele",
                    Description = "Spuneți-ne în câteva cuvinte care e problema",
                });

                //in final il adaugam la lista
                Services.Add(service);

            }
        }
    }
}
