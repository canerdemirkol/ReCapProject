using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _cache;
        public MemoryCacheManager() : this(ServiceTool.ServiceProvider.GetService<IMemoryCache>())
        {
        }
        public MemoryCacheManager(IMemoryCache cache)
        {
            _cache = cache;
        }
        public void Add(string key, object value, int duration)
        {
            _cache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _cache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _cache.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _cache.TryGetValue(key, out _);//out degerini kullanmayacaksan
        }

        public void Remove(string key)
        {
            _cache.Remove(key);
        }
        //çalışma anında bellekten silme
        public void RemoveByPattern(string pattern)
        {
            //Microsoft MemoryCache leri bellekte EntriesCollection türündeki listeye atıyor
            //belektedi MemoryCache  türnde olan EntriesCollection ı bul
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_cache) as dynamic;//defination ı MemoryCache olanlari bul
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)//herbir cache elemanını gez
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }
            //radıgım parametreyi Regex kuralına cevir
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);//casesentetive olmayacak, compileedilmis olcak, singleline olcak
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();  //cachedi yukarda verilen degere uyanlari bul (parametre olarak verilen kural)


            ///bulunan cachleri bul sil
            foreach (var key in keysToRemove)
            {
                _cache.Remove(key);
            }
        }
    }
}
