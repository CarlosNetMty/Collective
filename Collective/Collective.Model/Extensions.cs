﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Collective.Model
{
    public static class Extensions
    {
        #region Resources
        public static string GetResource(this Resources resource)
        {
            return GetResource((int)resource);
        }
        public static string GetResource(int resource) 
        {
            using (Context db = new Context())
            {
                Resource element = db
                    .Resources
                    .Where(item => item.ResourceId == resource)
                    .FirstOrDefault();

                if (element != null && element.ResourceId > 0)
                    return element.Value;
            }

            return string.Empty;
        }
        #endregion
        #region General
        public static T Get<T>(this IRepository repository, Context context, int id) where T : IPersistibleObject 
        {
            return ((IRepository<T>)repository).Get(context, id);
        }

        public static void Load<T>(this List<T> destination, IRepository repository, Context context, List<T> source) where T : ICatalogObject
        {
            IList<int> sourceItems = source.Select(item => item.GetUniqueIdentifier()).ToList();
            IList<int> destinationItems = destination.Select(item => item.GetUniqueIdentifier()).ToList();
            
            sourceItems
                .Where(obj => !destinationItems.Contains(obj))
                .ToList()
                .ForEach((item) => 
                {
                    T newElement = repository.Get<T>(context, item);
                    //repository.Attach((dynamic)newElement);

                    destination.Add(newElement);
                });

            destinationItems
                .Where(obj => !sourceItems.Contains(obj))
                .ToList()
                .ForEach((item) =>
                {
                    T removedElement = destination
                        .Where(subItem => item == subItem.GetUniqueIdentifier())
                        .SingleOrDefault();

                    //repository.Attach((dynamic)removedElement);
                    destination.Remove(removedElement);
                });            
            
        }
        public static bool HasValue(this int currentValue) 
        {
            return currentValue > 0;
        }
        #endregion
    }

    public enum Resources
    {
        AboutUS = 1,
        TermsAndConditions = 2
    }
}
