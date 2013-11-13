using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Collective.Model;
using Collective.Web.Models;

namespace Collective.Web
{
    public class MapperConfig
    {
        public static void RegisterMappings()
        {
            #region Response

            Mapper.CreateMap<Frame, Option>()
                .ForMember(dest => dest.Id, obj => obj.MapFrom(val => val.FrameId))
                .ForMember(dest => dest.Name, obj => obj.MapFrom(val => val.Description));

            Mapper.CreateMap<Size, Option>()
                .ForMember(dest => dest.Id, obj => obj.MapFrom(val => val.SizeId))
                .ForMember(dest => dest.Name, obj => obj.MapFrom(val => val.Description));

            Mapper.CreateMap<Tag, Option>()
                .ForMember(dest => dest.Id, obj => obj.MapFrom(val => val.TagId));

            Mapper.CreateMap<User, UserResponse>()
                .ForMember(dest => dest.IsLoggedIn, obj => obj.UseValue(true));

            Mapper.CreateMap<User, CredentialResponse>()
                .ForMember(dest => dest.Id, obj => obj.MapFrom(val => val.UserID))
                .ForMember(dest => dest.UserName, obj => obj.MapFrom(val => val.Name))
                .ForMember(dest => dest.Status, obj => obj.MapFrom(val => val.IsActive ? "Active" : "Inactive"));

            Mapper.CreateMap<Item, CoverResponse>()
                .ForMember(dest => dest.Id, obj => obj.MapFrom(val => val.ItemId))
                .ForMember(dest => dest.Name, obj => obj.MapFrom(val => val.English.Name))
                .ForMember(dest => dest.Artist, obj => obj.MapFrom(val => val.Artist.Name));
                
            Mapper.CreateMap<Item, SearchResponse>()
                .ForMember(dest => dest.Id, obj => obj.MapFrom(val => val.ItemId))
                .ForMember(dest => dest.Name, obj => obj.MapFrom(val => val.English.Name))
                .ForMember(dest => dest.Photo, obj => obj.MapFrom(val => val.PhotoUrl))
                .ForMember(dest => dest.Tags, obj => obj.MapFrom(val => val.Tags.Select(tag => tag.Name)))
                .ForMember(dest => dest.Sizes, obj => obj.MapFrom(val => val.AvailableSizes.Select(size => size.Description)))
                .ForMember(dest => dest.Artist, obj => obj.MapFrom(val => val.Artist.Name));

            #endregion

            #region Request

            Mapper.CreateMap<ProductRequest, Item>()
                .ForMember(dest => dest.Artist, obj => obj.MapFrom(val => new Artist(val.ArtistId)));
                
            #endregion

        }
    }
}