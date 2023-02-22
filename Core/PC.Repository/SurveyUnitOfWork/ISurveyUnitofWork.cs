using PC.DataLayer.Model.Survey;
using PC.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.Repository.SurveyUnitOfWork
{
    public interface ISurveyUnitofWork : IDisposable
    {
        IBaseRepository<GeneralSurveyReport> GeneralSurveyReport { get; }

        int Complete();
    }
}
