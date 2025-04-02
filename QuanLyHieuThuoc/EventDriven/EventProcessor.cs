using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven
{
    public abstract class EventProcessor
    {
        public abstract void ProcessEvent(object eventData);
    }
}
