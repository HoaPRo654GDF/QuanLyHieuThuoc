using QuanLyHieuThuoc.EventDriven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven
{
    public abstract class EventChannel
    {
        public virtual void DispatchEvent(object eventData, EventProcessor processor)
        {
            processor.ProcessEvent(eventData);
        }
    }
}
