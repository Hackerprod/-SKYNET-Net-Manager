using NetUtils;
using System;
using System.Net;

namespace NetUtils
{
    internal class AsyncHostNameResolver
    {
        private delegate IPHostEntry GetHostEntryDelegate(string addr);

        private class AsyncStateUni
        {
            public GetHostEntryDelegate _resolveMethod;

            public AsyncStateUni(GetHostEntryDelegate resolveMethod)
            {
                _resolveMethod = resolveMethod;
            }
        }

        public delegate void StoreHostNameDelegate(string hostName);

        private class AsyncStateForName : AsyncStateUni
        {
            public StoreHostNameDelegate _storeResultMethod;

            public AsyncStateForName(GetHostEntryDelegate resolveMethod, StoreHostNameDelegate storeResultMethod)
                : base(resolveMethod)
            {
                _storeResultMethod = storeResultMethod;
            }
        }

        public delegate void StoreHostIPDelegate(IPAddress[] addreses);

        private class AsyncStateForIP : AsyncStateUni
        {
            public StoreHostIPDelegate _storeResultMethod;

            public AsyncStateForIP(GetHostEntryDelegate resolveMethod, StoreHostIPDelegate storeResultMethod)
                : base(resolveMethod)
            {
                _storeResultMethod = storeResultMethod;
            }
        }

        private IPHostEntry GetHostEntry(string addr)
        {
            try
            {
                return Dns.GetHostEntry(addr);
            }
            catch
            {
                return null;
            }
        }

        public void ResolveHostName(IPAddress address, StoreHostNameDelegate callback)
        {
            AsyncStateForName asyncStateForName = new AsyncStateForName(GetHostEntry, callback);
            asyncStateForName._resolveMethod.BeginInvoke(address.ToString(), HostNameResolved, asyncStateForName);
        }

        private void HostNameResolved(IAsyncResult result)
        {
            try
            {
                AsyncStateForName asyncStateForName = (AsyncStateForName)result.AsyncState;
                IPHostEntry iPHostEntry = asyncStateForName._resolveMethod.EndInvoke(result);
                if (iPHostEntry != null)
                {
                    asyncStateForName._storeResultMethod(iPHostEntry.HostName);
                }
            }
            catch
            {
            }
        }

        public void ResolveHostIP(string name, StoreHostIPDelegate callback)
        {
            AsyncStateForIP asyncStateForIP = new AsyncStateForIP(GetHostEntry, callback);
            asyncStateForIP._resolveMethod.BeginInvoke(name, HostIPResolved, asyncStateForIP);
        }

        private void HostIPResolved(IAsyncResult result)
        {
            try
            {
                AsyncStateForIP asyncStateForIP = (AsyncStateForIP)result.AsyncState;
                IPHostEntry iPHostEntry = asyncStateForIP._resolveMethod.EndInvoke(result);
                if (iPHostEntry != null)
                {
                    asyncStateForIP._storeResultMethod(iPHostEntry.AddressList);
                }
            }
            catch
            {
            }
        }
    }
}