using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collective.Console.ServiceReference;

namespace Collective.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Starting..");
            ServiceClient serviceClient = new ServiceClient();
            /////   Testing    /////
            ItemTest(serviceClient);
            System.Console.Read();
        }

        #region Test Definition
        static void ItemTest(ServiceClient serviceClient) 
        {
            ServiceReference.Item[] items = serviceClient.GetItems();

            items.ToList().ForEach((obj) =>
            {
                System.Console.WriteLine("Artist ID: {0}, ItemID: {1}", obj.ArtistID, obj.ItemID);
            });
        }
        #endregion
    }
}
