using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DataLayer.Enum
{
    public enum SurveyStatus
    {
        UNKNOWN = 99999,
        Unsent = 0,
        Sent = 10,
        Answered = 20,
    }
}
