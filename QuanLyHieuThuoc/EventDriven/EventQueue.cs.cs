using QuanLyHieuThuoc.EventDriven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuanLyHieuThuoc.EventDriven
{
    public class EventQueue
    {
        private readonly Queue<Tuple<string, object>> _events = new Queue<Tuple<string, object>>();
        private readonly object _lockObj = new object();
        private Thread _processingThread;
        private bool _isRunning = false;

        public void Enqueue(string channelName, object eventData)
        {
            lock (_lockObj)
            {
                _events.Enqueue(new Tuple<string, object>(channelName, eventData));
                Monitor.Pulse(_lockObj);
            }
        }

        public void StartProcessing(EventMediator mediator)
        {
            if (_isRunning) return;

            _isRunning = true;
            _processingThread = new Thread(() =>
            {
                while (_isRunning)
                {
                    Tuple<string, object> eventItem = null;

                    lock (_lockObj)
                    {
                        while (_events.Count == 0 && _isRunning)
                        {
                            Monitor.Wait(_lockObj);
                        }

                        if (!_isRunning) break;

                        eventItem = _events.Dequeue();
                    }

                    if (eventItem != null)
                    {
                        mediator.Handle(eventItem.Item1, eventItem.Item2);
                    }
                }
            });

            _processingThread.IsBackground = true;
            _processingThread.Start();
        }

        public void StopProcessing()
        {
            lock (_lockObj)
            {
                _isRunning = false;
                Monitor.PulseAll(_lockObj);
            }

            if (_processingThread != null && _processingThread.IsAlive)
            {
                _processingThread.Join(1000);
            }
        }
    }
}
