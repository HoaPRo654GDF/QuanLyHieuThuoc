using QuanLyHieuThuoc.EventDriven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven
{
    //public class EventMediator
    //{
    //    private readonly Dictionary<string, IEventChannel> _channels = new Dictionary<string, IEventChannel>();
    //    private readonly Dictionary<string, IEventProcessor> _processors = new Dictionary<string, IEventProcessor>();

    //    public void RegisterChannel(string channelName, IEventChannel channel)
    //    {
    //        _channels[channelName] = channel;
    //    }

    //    public void RegisterProcessor(string channelName, IEventProcessor processor)
    //    {
    //        _processors[channelName] = processor;
    //    }

    //    public void Handle(string channelName, object eventData)
    //    {
    //        if (_channels.ContainsKey(channelName) && _processors.ContainsKey(channelName))
    //        {
    //            _channels[channelName].DispatchEvent(eventData, _processors[channelName]);
    //        }
    //    }
    //}
    public class EventMediator
    {
        private readonly Dictionary<string, EventChannel> _channels = new Dictionary<string, EventChannel>();
        private readonly Dictionary<string, EventProcessor> _processors = new Dictionary<string, EventProcessor>();

        public void RegisterChannel(string channelName, EventChannel channel)
        {
            _channels[channelName] = channel;
        }

        public void RegisterProcessor(string channelName, EventProcessor processor)
        {
            _processors[channelName] = processor;
        }

        public void Handle(string channelName, object eventData)
        {
            if (_channels.ContainsKey(channelName) && _processors.ContainsKey(channelName))
            {
                _channels[channelName].DispatchEvent(eventData, _processors[channelName]);
            }
        }
    }
}
