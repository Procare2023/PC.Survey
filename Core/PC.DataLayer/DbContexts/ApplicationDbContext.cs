using Microsoft.EntityFrameworkCore;
using PC.DataLayer.Model.Survey;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DataLayer.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<GeneralSurveyReport> GeneralSurveyReport { get; set; }
    }
}
