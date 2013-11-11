using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPersistibleObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        void Clone(IPersistibleObject obj);
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ICatalogObject : IPersistibleObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        int GetUniqueIdentifier();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetDescription();
    }
}
