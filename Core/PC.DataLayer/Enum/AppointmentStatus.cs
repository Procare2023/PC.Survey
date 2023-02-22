using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DataLayer.Enum
{
    public enum AppointmentStatus
    {
        Open = 0,
        Closed = 1,
        Cancelled = 2,
        CheckedIn = 3,
        CheckedOut = 4,
        Confirmed = 10,
        UNKNOWN = 99999,
    }
}
