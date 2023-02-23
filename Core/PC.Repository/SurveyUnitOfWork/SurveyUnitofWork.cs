using PC.DataLayer.DbContexts;
using PC.DataLayer.Model.Survey;
using PC.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Repository.SurveyUnitOfWork
{
    public class SurveyUnitofWork : ISurveyUnitofWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<GeneralSurveyReport> GeneralSurveyReport { get; private set; }
        public SurveyUnitofWork(ApplicationDbContext context)
        {
            _context = context;

            GeneralSurveyReport = new BaseRepository<GeneralSurveyReport>(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
