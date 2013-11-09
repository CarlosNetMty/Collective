using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public partial class Repository : IRepository
    {
        #region Constants
        public const string CACHE_KEY_GETALL_ARTISTS = "appGetAllArtist";
        public const string CACHE_KEY_GETALL_FRAMES = "appGetAllFrame";
        public const string CACHE_KEY_GETALL_SIZES = "appGetAllSize";
        public const string CACHE_KEY_GETALL_TAGS = "appGetAllTag";
        public const string CACHE_KEY_GETALL_USERS = "appGetAllUser";
        public const string CACHE_KEY_GETALL_SETTINGS = "appGetAllSettings";
        #endregion

        #region Fields
        ObjectCache CurrentCache;
        #endregion

        #region Constructors
        public Repository(ObjectCache currentCache) 
        {
            //Context = new Model.Context();
            CurrentCache = currentCache; 
        }
        public Repository() : this(MemoryCache.Default) { }
        #endregion

        #region Methods
        void RunOrExecute<T>(string cacheKey, Func<Context, IQueryable<T>> contextCallback, Action<IQueryable<T>> callback) where T : IPersistibleObject 
        {
            //if (CurrentCache.Contains(cacheKey))
            //    callback.Invoke(CurrentCache.Get(cacheKey) as IQueryable<T>);
            //else
                CurrentCache.Store<T>(cacheKey, contextCallback, callback);
        }
        T RunOrExecute<T>(Func<Context, T, T> contextCallback, T dataObject) where T : IPersistibleObject
        {
            return Extensions.Store<T>(contextCallback, dataObject);
        }
        #endregion
    }
}
