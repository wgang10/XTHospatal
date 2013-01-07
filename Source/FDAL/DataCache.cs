using System;
using System.Web;


namespace XTHospital.FDAL
{
    public sealed class DataCache
    {
        /// <summary>
        /// GetCache
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <returns></returns>
        public static object GetCache(string CacheKey)
        {

            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[CacheKey];
        }

        /// <summary>
        /// SetCache
        /// </summary>
        /// <param name="CacheKey"></param>
        /// <param name="objObject"></param>
        public static void SetCache(string CacheKey, object objObject)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(CacheKey, objObject);
        }

        /// <summary>
        /// ClearCache
        /// </summary>
        /// <param name="CacheKey"></param>
        public static void ClearCache(string CacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            if (objCache[CacheKey] != null)
            {
                objCache.Remove(CacheKey);
            }
        }
    }
}
