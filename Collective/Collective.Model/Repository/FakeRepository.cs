using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collective.Model
{
    public class FakeRepository : IRepository
    {

        #region Interface Implementation
        public void GetAll(Action<IQueryable<Artist>> contextCallback)
        {
            contextCallback.Invoke(GetDataFromArtists());
        }

        public void GetAll(Action<IQueryable<Item>> contextCallback)
        {
            throw new NotImplementedException();
        }

        public void GetAll(Action<IQueryable<Tag>> contextCallback)
        {
            contextCallback.Invoke(GetDataFromTags());
        }

        public void GetAll(Action<IQueryable<Frame>> contextCallback)
        {
            contextCallback.Invoke(GetDataFromFrames());
        }

        public void GetAll(Action<IQueryable<Size>> contextCallback)
        {
            contextCallback.Invoke(GetDataFromSizes());
        }

        public void GetAll(Action<IQueryable<User>> contextCallback)
        {
            contextCallback.Invoke(GetDataFromUsers());
        }
        #endregion

        #region Fake Data 

        IQueryable<User> GetDataFromUsers() 
        {

            List<User> dataCollection = new List<User>() 
            { 
                new User { UserID=1, Name="Carlos Martinez", Password="password", Email="carlos@neux.com", IsActive=true, IsAdministrator=false },
                new User { UserID=2, Name="Federico Gonzalez", Password="password", Email="fede@neux.com", IsActive=true, IsAdministrator=false },
            };
            return dataCollection.AsQueryable();
        }

        IQueryable<Size> GetDataFromSizes()
        {

            List<Size> dataCollection = new List<Size>() 
            { 
                new Size { SizeId=1, Description="Small" },
                new Size { SizeId=2, Description="Medium" },
                new Size { SizeId=3, Description="Big" },
               
            };
            return dataCollection.AsQueryable();
        }

        IQueryable<Frame> GetDataFromFrames()
        {

            List<Frame> dataCollection = new List<Frame>() 
            { 
                new Frame { FrameId=1, Description="Classic" },
                new Frame { FrameId=2, Description="Contemporary" },
                new Frame { FrameId=3, Description="Modern" },
               
            };
            return dataCollection.AsQueryable();
        }

        IQueryable<Tag> GetDataFromTags()
        {

            List<Tag> dataCollection = new List<Tag>() 
            { 
                new Tag { TagId=1, Name="Classic" },
                new Tag { TagId=2, Name="Contemporary" },
                new Tag { TagId=3, Name="Modern" },
               
            };
            return dataCollection.AsQueryable();
        }

        IQueryable<Item> GetDataFromItems() 
        {
            IQueryable<Artist> allArtists = GetDataFromArtists();
            IQueryable<Frame> allFrames = GetDataFromFrames();
            IQueryable<Size> allSizes = GetDataFromSizes();
            IQueryable<Tag> allTags = GetDataFromTags();

            List<Item> dataCollection = new List<Item>() 
            { 
                new Item 
                { 
                    ItemId=1, 
                    Artist=allArtists.First(),
                    AvailableFrames=allFrames.Take(2).ToList(),
                    AvailableSizes=allSizes.Take(2).ToList(),
                    Code="TMX 2040M",
                    Description="Nature",
                    PhotoUrl="",
                    Price=(decimal)12345.67,
                    PublishingDate=DateTime.Now.AddMonths(-15),
                    Tags=allTags.Take(2).ToList(),
                    UseAsBackground=true                        
                },
                new Item 
                { 
                    ItemId=2, 
                    Artist=allArtists.Last(),
                    AvailableFrames=allFrames.Skip(1).ToList(),
                    AvailableSizes=allSizes.Skip(1).ToList(),
                    Code="TMX 1030U",
                    Description="Landscape",
                    PhotoUrl="",
                    Price=(decimal)12345.67,
                    PublishingDate=DateTime.Now.AddMonths(-16),
                    Tags=allTags.Skip(1).ToList(),
                    UseAsBackground=true                        
                }
            };
            return dataCollection.AsQueryable();
        }

        IQueryable<Artist> GetDataFromArtists()
        {

            List<Artist> dataCollection = new List<Artist>() 
            { 
                new Artist { ArtistId=1, Name="Carlos Martinez" },
                new Artist { ArtistId=2, Name="Federico Gonzalez" },
            };
            return dataCollection.AsQueryable();
        }        
        #endregion

        #region Utils



        #endregion 

        #region Actions 

        public User Update(User dataObject)
        {
            throw new NotImplementedException();
        }
        public Artist Update(Artist dataObject)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
