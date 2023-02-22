using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DataLayer.Model.Survey
{
    public class GeneralSurveyModel
    {
        public string Name { get; set; }
        public string Link { get; set; }

        public GeneralSurveyModel() { }

        public GeneralSurveyModel(string name, string link)
        {
            try
            {
                this.Name = name;
                this.Link = link;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
