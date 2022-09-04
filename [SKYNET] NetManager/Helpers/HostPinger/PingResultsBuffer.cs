using NetUtils;
using System.Collections.Generic;
namespace NetUtils
{
    public class PingResultsBuffer
    {
        private class Entry
        {
            public bool _received;

            public int _count;

            public Entry(bool received, int count)
            {
                _received = received;
                _count = count;
            }
        }

        private List<Entry> _buffer = new List<Entry>();

        private object _syncObject = new object();

        public static readonly int DEFAULT_BUFFER_SIZE = 100;

        private int _bufferSize = DEFAULT_BUFFER_SIZE;

        private int _currentSize;

        private int _lostCount;

        private int _receivedCount;

        public int BufferSize
        {
            get
            {
                lock (_syncObject)
                {
                    return _bufferSize;
                }
            }
            set
            {
                lock (_syncObject)
                {
                    if (value < 0)
                    {
                        value = 0;
                    }
                    if (value > _bufferSize)
                    {
                        _bufferSize = value;
                    }
                    else
                    {
                        int num = _currentSize - value;
                        while (num > 0)
                        {
                            Entry entry = _buffer[0];
                            if (entry._count <= num)
                            {
                                _buffer.RemoveAt(0);
                                DecCount(entry._received, entry._count);
                                num -= entry._count;
                            }
                            else
                            {
                                entry._count -= num;
                                DecCount(entry._received, num);
                                num = 0;
                            }
                        }
                        if (_currentSize > value)
                        {
                            _currentSize = value;
                        }
                        _bufferSize = value;
                    }
                }
            }
        }

        public int CurrentSize
        {
            get
            {
                lock (_syncObject)
                {
                    return _currentSize;
                }
            }
        }

        public int LostCount
        {
            get
            {
                lock (_syncObject)
                {
                    return _lostCount;
                }
            }
        }

        public float LostCountPercent
        {
            get
            {
                lock (_syncObject)
                {
                    return (float)_lostCount / (float)_currentSize * 100f;
                }
            }
        }

        public int ReceivedCount
        {
            get
            {
                lock (_syncObject)
                {
                    return _receivedCount;
                }
            }
        }

        public float ReceivedCountPercent
        {
            get
            {
                lock (_syncObject)
                {
                    return (float)_receivedCount / (float)_currentSize * 100f;
                }
            }
        }

        public PingResultsBuffer(int size)
        {
            _bufferSize = size;
        }

        public PingResultsBuffer()
        {
        }

        private void IncCount(bool received)
        {
            if (received)
            {
                _receivedCount++;
            }
            else
            {
                _lostCount++;
            }
        }

        private void DecCount(bool received, int count)
        {
            if (received)
            {
                _receivedCount -= count;
            }
            else
            {
                _lostCount -= count;
            }
        }

        public void AddPingResult(bool received)
        {
            if (_bufferSize >= 1)
            {
                lock (_syncObject)
                {
                    if (_currentSize >= _bufferSize)
                    {
                        Entry entry = _buffer[0];
                        entry._count--;
                        DecCount(entry._received, 1);
                        if (entry._count == 0)
                        {
                            _buffer.RemoveAt(0);
                        }
                        goto IL_00a9;
                    }
                    if (_currentSize != 0)
                    {
                        _currentSize++;
                        goto IL_00a9;
                    }
                    _buffer.Add(new Entry(received, 1));
                    IncCount(received);
                    _currentSize++;
                    goto end_IL_000c;
                    IL_00a9:
                    Entry entry2 = _buffer[_buffer.Count - 1];
                    if (entry2._received == received)
                    {
                        entry2._count++;
                    }
                    else
                    {
                        _buffer.Add(new Entry(received, 1));
                    }
                    IncCount(received);
                    end_IL_000c:;
                }
            }
        }

        public void Clear()
        {
            lock (_syncObject)
            {
                _currentSize = 0;
                _lostCount = 0;
                _receivedCount = 0;
                _buffer.Clear();
            }
        }
    }
}