
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public interface IRepository
    {
        #region Update
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        Item Update(Item dataObject);
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
        /// <param name="dataObject"></param>
        /// <returns></returns>
        Size Update(Size dataObject);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        Frame Update(Frame dataObject);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataObject"></param>
        /// <returns></returns>
        Tag Update(Tag dataObject);
        #endregion
        #region GetAll
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
        #endregion
    }

    public interface IRepository<T> where T : IPersistibleObject
    {
        /// <summary>
        /// Gets a single element
        /// </summary>
        T Get(Context context, int id);
        /// <summary>
        /// Gets all elements
        /// </summary>
        IQueryable<T> GetAll(Context context);
        /// <summary>
        /// Updates a single element
        /// </summary>
        T Update(Context context, T dataObject);
    }
}