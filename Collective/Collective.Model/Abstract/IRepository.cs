
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public interface IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        Artist Update(Artist dataObject);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        User Update(User dataObject);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void GetAll(Action<IQueryable<Artist>> contextCallback);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void GetAll(Action<IQueryable<Item>> contextCallback);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void GetAll(Action<IQueryable<Tag>> contextCallback);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void GetAll(Action<IQueryable<Frame>> contextCallback);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void GetAll(Action<IQueryable<Size>> contextCallback);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        void GetAll(Action<IQueryable<User>> contextCallback);
    }

    public interface IRepository<T> where T : IPersistibleObject
    {
        IQueryable<T> GetAll(Context context);
        T Update(Context context, T dataObject);
    }
}