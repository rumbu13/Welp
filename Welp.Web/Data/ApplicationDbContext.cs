using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Welp.Web.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Welp.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        public ApplicationDbContext() : base() { }

        public DbSet<TagLine> TagLines { get; set; }
        public DbSet<WelpService> Services { get; set; }
        public DbSet<WelpServiceCategory> Categories { get; set; }
        public DbSet<WelpServiceOption> Options { get; set; }
        public DbSet<WelpServiceOptionDropItem> DropItems { get; set; }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Locality> Localities { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStateHistory> OrderStates { get; set; }

        public DbSet<ClientInvoice> ClientInvoices { get; set; }
        public DbSet<ClientInvoiceItem> ClientInvoiceItems { get; set; }
        public DbSet<ClientInvoiceStateHistory> ClientInvoiceStates { get; set; }

        public DbSet<WelperInvoice> WelperInvoices { get; set; }
        public DbSet<WelperInvoiceItem> WelperInvoiceItems { get; set; }
        public DbSet<WelperInvoiceStateHistory> WelperInvoiceStates{ get; set; }


        public DbSet<FAQCategory> FAQCategories { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<ClientInvoice>()
                .HasOne<Locality>(ci => ci.ProviderLocality)
                .WithMany(l => l.ClientInvoices)
                .HasForeignKey(l => l.ProviderLocalityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<WelperInvoice>()
                .HasOne<InvoiceData>(wi => wi.InvoiceData)
                .WithMany()
                .HasForeignKey(wi => wi.InvoiceDataId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<OrderItem>()
                .HasOne<Profile>(oi => oi.Welper)
                .WithMany()
                .HasForeignKey(oi => oi.WelperProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Locality>()
            //    .HasOne<County>(l => l.County)
            //    .WithMany(c => c.Localities)
            //    .HasForeignKey(l => l.CountyId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<WelpService>()
            //    .HasOne<WelpServiceCategory>(s => s.Category)
            //    .WithMany(c => c.Services)
            //    .HasForeignKey(c => c.WelpServiceCategoryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<WelpService>()
            //    .HasMany<WelpServiceOption>(s => s.Options)
            //    .WithOne(o => o.Service)
            //    .HasForeignKey(o => o.WelpServiceId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<WelpServiceOption>()
            //    .HasMany<WelpServiceOptionDropItem>(o => o.DropDownItems)
            //    .WithOne(d => d.Option)
            //    .HasForeignKey(d => d.WelpServiceOptionId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Profile>()
            //    .HasMany<Address>(p => p.Addresses)
            //    .WithOne(a => a.Profile)
            //    .HasForeignKey(a => a.ProfileId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Profile>()
            //    .HasMany<InvoiceData>(p => p.InvoiceDatas)
            //    .WithOne(a => a.Profile)
            //    .HasForeignKey(a => a.ProfileId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Address>()
            //    .HasOne<Locality>(a => a.Locality)
            //    .WithMany(l => l.Addresses)
            //    .HasForeignKey(a => a.LocalityId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<FAQ>()
            //    .HasOne<FAQCategory>(f => f.Category)
            //    .WithMany(c => c.FAQs)
            //    .HasForeignKey(f => f.CategoryId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Order>()
            //    .HasOne<Profile>(o => o.Client)
            //    .WithMany(c => c.Orders)
            //    .HasForeignKey(o => o.ClientProfileId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<Order>()
            //    .HasMany<OrderItem>(o => o.Items)
            //    .WithOne(i => i.Order)
            //    .HasForeignKey(i => i.OrderId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<OrderItem>()
            //    .HasMany<OrderStateHistory>(o => o.History)
            //    .WithOne(h => h.OrderItem)
            //    .HasForeignKey(h => h.OrderItemId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<OrderItem>()
            //    .HasOne<Profile>(o => o.Welper)
            //    .WithMany(p => p.Jobs)
            //    .HasForeignKey(o => o.WelperProfileId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<ClientInvoice>()
            //    .HasMany<ClientInvoiceItem>(i => i.InvoiceItems)
            //    .WithOne(i => i.Invoice)
            //    .HasForeignKey(i => i.InvoiceId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<ClientInvoice>()
            //    .HasMany<ClientInvoiceStateHistory>(i => i.History)
            //    .WithOne(h => h.Invoice)
            //    .HasForeignKey(h => h.InvoiceId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<ClientInvoice>()
            //    .HasOne<Profile>(i => i.Client)
            //    .WithMany(p => p.ClientInvoices)
            //    .HasForeignKey(i => i.ClientId)
            //    .OnDelete(DeleteBehavior.Restrict);

            ////builder.Entity<ClientInvoice>()
            ////    .HasOne<ClientInvoice>(i => i.ReverseInvoice)
            ////    .WithOne(i => i.ReverseInvoice)
            ////    .HasForeignKey<ClientInvoice>(i => i.ReverseInvoiceId)                
            ////    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<ClientInvoice>()
            //    .HasOne<InvoiceData>(i => i.InvoiceData)
            //    .WithMany(i => i.ClientInvoices)
            //    .HasForeignKey(i => i.InvoiceDataId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<ClientInvoice>()
            //    .HasOne<Locality>(i => i.ProviderLocality)
            //    .WithMany(l => l.ClientInvoices)
            //    .HasForeignKey(i => i.ProviderLocalityId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<ClientInvoiceItem>()
            //    .HasOne<OrderItem>(i => i.OrderItem)
            //    .WithOne(o => o.ClientInvoiceItem)
            //    .HasForeignKey<OrderItem>(o => o.ClientInvoiceItemId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<OrderItem>()
            //    .HasOne<ClientInvoiceItem>(o => o.ClientInvoiceItem)
            //    .WithOne(i => i.OrderItem)
            //    .HasForeignKey<ClientInvoiceItem>(i => i.OrderItemId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<WelperInvoice>()
            //   .HasMany<WelperInvoiceItem>(i => i.InvoiceItems)
            //   .WithOne(i => i.Invoice)
            //   .HasForeignKey(i => i.InvoiceId)
            //   .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<WelperInvoice>()
            //    .HasMany<WelperInvoiceStateHistory>(i => i.History)
            //    .WithOne(h => h.Invoice)
            //    .HasForeignKey(h => h.InvoiceId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<WelperInvoice>()
            //    .HasOne<Profile>(i => i.Welper)
            //    .WithMany(p => p.WelperInvoices)
            //    .HasForeignKey(i => i.WelperId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<WelperInvoice>()
            //    .HasOne<WelperInvoice>(i => i.ReverseInvoice)
            //    .WithOne(i => i.ReverseInvoice)
            //    .HasForeignKey<WelperInvoice>(i => i.ReverseInvoiceId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<WelperInvoice>()
            //    .HasOne<InvoiceData>(i => i.InvoiceData)
            //    .WithMany(i => i.WelperInvoices)
            //    .HasForeignKey(i => i.InvoiceDataId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<WelperInvoice>()
            //    .HasOne<Locality>(i => i.ClientLocality)
            //    .WithMany(l => l.WelperInvoices)
            //    .HasForeignKey(i => i.ClientLocalityId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<WelperInvoiceItem>()
            //    .HasOne<OrderItem>(i => i.OrderItem)
            //    .WithOne(o => o.WelperInvoiceItem)
            //    .HasForeignKey<OrderItem>(o => o.WelperInvoiceItemId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<OrderItem>()
            //    .HasOne<WelperInvoiceItem>(o => o.WelperInvoiceItem)
            //    .WithOne(i => i.OrderItem)
            //    .HasForeignKey<WelperInvoiceItem>(i => i.OrderItemId)
            //    .OnDelete(DeleteBehavior.Restrict);

        }

        public void SeedAll()
        {
            
            SeedTagLines();
            SeedCategories();
            SeedProfiles().Wait();
            SaveChanges();
            SeedFAQCategories();
            SaveChanges();
            SeedFAQs();
            SaveChanges();
            SeedServices();
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
                    Text = "Un text",
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

                service.Options = new List<WelpServiceOption>();
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

                opt.DropDownItems = new List<WelpServiceOptionDropItem>();

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

                opt.DropDownItems = new List<WelpServiceOptionDropItem>();

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
                    Text = "Un text",
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

                service.Options = new List<WelpServiceOption>();

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

                opt.DropDownItems = new List<WelpServiceOptionDropItem>();

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

                opt.DropDownItems = new List<WelpServiceOptionDropItem>();

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


        public void SeedFAQCategories()
        {
            if (!FAQCategories.Any())
            {
                FAQCategories.AddRange(
                    new FAQCategory { Text = "Cont", Icon = "glyphicon glyphicon-user" },
                    new FAQCategory { Text = "Plăți", Icon = "glyphicon glyphicon-credit-card" },
                    new FAQCategory { Text = "Asistență", Icon = "glyphicon glyphicon-question-sign" },
                    new FAQCategory { Text = "Servicii", Icon = "glyphicon glyphicon-shopping-cart" }
                    );
            }
        }


        public void SeedFAQs()
        {
            if (!FAQs.Any())
            {
                var category = FAQCategories.FirstOrDefault(f => f.Text == "Cont");
                FAQs.Add(new FAQ()
                {
                    Category = category,
                    Question = "Cum îmi actualizez datele din cont?",
                    Answer = "Apăsați pe numele dvs. în colțul din dreapta sus.",
                    Type = FAQType.Both,
                });

                FAQs.Add(new FAQ()
                {
                    Category = category,
                    Question = "Cum îmi schimb parola?",
                    Answer = "Apăsați pe numele dvs. în colțul din dreapta sus."
                });

                FAQs.Add(new FAQ()
                {
                    Category = category,
                    Question = "Contul meu a fost suspendat. De ce?",
                    Answer = "Motivul este precizat atunci când vă autentificați. Contactați-ne pentru mai multe detalii."
                });

                FAQs.Add(new FAQ()
                {
                    Category = category,
                    Question = "Cum îmi șterg contul?",
                    Answer = "Nu ne-am gândit la asta pâna acum."
                });

                category = FAQCategories.FirstOrDefault(f => f.Text == "Plăți");

                FAQs.Add(new FAQ()
                {
                    Category = category,
                    Question = "De ce suma din extrasul de cont nu corespunde cu serviciul contractat?",
                    Answer = "Nu știm. Vorbiți la bancă."
                });

                FAQs.Add(new FAQ()
                {
                    Category = category,
                    Question = "Pot obține ceva gratis de la voi?",
                    Answer = "Depinde."
                });
            }
        }
    }
}
