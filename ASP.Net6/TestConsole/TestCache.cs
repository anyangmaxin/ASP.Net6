using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace TestConsole
{
    public class TestCache
    {
        MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions());

        public bool SetCache(string key,string value)
        {            
            memoryCache.Set(key, value); 
            return true;
        }

        public object GetCache(string key)
        {
            return memoryCache.Get(key);
        }

     
    }
}
