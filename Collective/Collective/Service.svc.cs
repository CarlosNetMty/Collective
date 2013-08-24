using Collective.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DTO = Collective.DataTransferObjects;

namespace Collective
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<DTO.Item> GetItems()
        {
            IList<DTO.Item> data = Enumerable.Empty<DTO.Item>().ToList();
            new Repository(MemoryCache.Default).GetAll((IQueryable<Item> response) => {
                
                data = (from item in response 
                        select new DTO.Item{
                            ItemID = item.ItemId,
                            Description = item.Description,
                            ArtistID = item.Artist.ArtistId,
                            ArtistName = item.Artist.Name
                        }).ToList();
            });

            return data as List<DTO.Item>;
        }

        public List<DTO.Artist> GetArtists()
        {
            IList<DTO.Artist> data = Enumerable.Empty<DTO.Artist>().ToList();
            new Repository(MemoryCache.Default).GetAll((IQueryable<Artist> response) =>
            {

                data = (from item in response
                        select new DTO.Artist
                        {
                            ArtistId = item.ArtistId,
                            Name = item.Name,
                            PhotoUrl = item.PhotoUrl
                        }).ToList();
            });

            return data as List<DTO.Artist>;
        }

        public List<DTO.Tag> GetTags() 
        {
            IList<DTO.Tag> data = Enumerable.Empty<DTO.Tag>().ToList();
            new Repository(MemoryCache.Default).GetAll((IQueryable<Tag> response) =>
            {

                data = (from item in response
                        select new DTO.Tag
                        {
                            TagId = item.TagId,
                            Name = item.Name
                        }).ToList();
            });

            return data as List<DTO.Tag>;
        }
    }
}
