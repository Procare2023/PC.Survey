using PC.DataLayer.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC.DataLayer.Model
{
    public class MyBase
    {
        public DateTime CreateStamp { get; set; }

        public DateTime UpdateStamp { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public RecordStatus RecordStatus { get; set; }
    }
}
