using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven.Channels
{
    public class SearchInvoiceChannel : EventChannel
    {
        public void DispatchEvent(object eventData, EventProcessor processor)
        {
            processor.ProcessEvent(eventData);
        }
    }
}
