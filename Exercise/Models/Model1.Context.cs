namespace Exercise.Models
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class Model1Container : DbContext
    {
        public Model1Container()
            : base("name=Model1Container")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<Person> People { get; set; }
    }
}
