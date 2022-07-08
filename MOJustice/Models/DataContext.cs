using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MOE.Models
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            //AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

      

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Page> Pages { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PageCategory> PagesCategories { get; set; }

        public DbSet<CategoryTypes> Category_Types { get; set; }

        public DbSet<Files> Files { get; set; }
        public DbSet<FilesList> FilesList { get; set; }

        public DbSet<FilesType> FileType { get; set; }

        public DbSet<HtmlTemplate> HtmlTemplates { get; set; }

        public DbSet<HtmlTemplatesType> HtmlTemplatesTypes { get; set; }

        public DbSet<AdminLog> AdminLogs { get; set; }

        public DbSet<AdminLogFor> AdminLogFor { get; set; }

        //public DbSet<AdminLogAction> AdminLogAction { get; set; }

        public DbSet<MenuLocation> MenuLocations { get; set; }

       

        public DbSet<Settings> Settings { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<TagRel> TagsRel { get; set; }


    }
}
