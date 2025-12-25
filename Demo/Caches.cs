using Demo.Domains.Business;
using Server.Core.Caching;
using System;
using System.Collections.Generic;

namespace Demo
{
    public static class Caches
    {
        /// <summary>
        /// 缓存命名空间
        /// </summary>
        private const string Space = Constants.CacheNamespace;

        private static readonly Lazy<ICacheProvider> LazyMemory = new Lazy<ICacheProvider>(() =>
        {
            var provider = HttpRuntimeCacheProviderSlim.Instance;
            return provider;
        });

        /// <summary>
        /// 使用本地内存的缓存。
        /// </summary>
        private static ICacheProvider Memory => LazyMemory.Value;

        /// <summary>
        /// 具体某个业务的缓存，通过自行拼装key的方式进行管理和划分。
        /// </summary>
        public static class Business
        {
            public static readonly CacheOperation<IList<BusinessOne>> BusinessList
                = new CacheOperation<IList<BusinessOne>>(
                    Space, "s:business1:list", Memory, CacheExpiration.FromTimeSpan(TimeSpan.FromHours(1)));

            public static readonly CacheOperation<int, BusinessOne> BusinessOne
                = new CacheOperation<int, BusinessOne>(
                    Space, "s:business2:object", Memory, CacheExpiration.FromTimeSpan(TimeSpan.FromHours(1)));
        }
    }
}
