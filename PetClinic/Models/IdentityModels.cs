using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PetClinic.Models
{
    // В профиль пользователя можно добавить дополнительные данные, если указать больше свойств для класса ApplicationUser. Подробности см. на странице https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            userIdentity.AddClaim(new Claim("id", this.Id));
            userIdentity.AddClaim(new Claim("name", this.Name));
            userIdentity.AddClaim(new Claim("surname", this.Surname));
            userIdentity.AddClaim(new Claim("patronymic", this.Patronymic));
            //userIdentity.AddClaim(new Claim("position", this.Position.NamePosition));
            return userIdentity;
        }

    }
    public class Position
    {
        public int PositionId { get; set; }
        public string NamePosition { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //static ApplicationDbContext()
        //{
        //    Database.SetInitializer<ApplicationDbContext>(new PositionContextInit());
        //}
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Position> Positions { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
    class PositionContextInit : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Positions.Add(new Position { NamePosition = "Главный врач"});
            context.Positions.Add(new Position { NamePosition = "Мед сестра" });
            context.SaveChanges();
        }
    }
}