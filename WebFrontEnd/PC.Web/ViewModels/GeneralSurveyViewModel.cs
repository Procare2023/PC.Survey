using PC.DataLayer.Model.Survey;
using PC.Web.Models;

namespace PC.Web.ViewModels
{
    public class GeneralSurveyViewModel
    {
        public GeneralSurveyViewModel()
        {
            SurveyList = new List<GeneralSurvey>();
        }
        public DateTime fromDate { get; set; }

        public DateTime ToDate { get; set; }

        public IEnumerable<GeneralSurvey> SurveyList { get; set; }
    }
}
