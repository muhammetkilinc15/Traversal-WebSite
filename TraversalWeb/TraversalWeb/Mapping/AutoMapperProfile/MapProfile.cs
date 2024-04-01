﻿using AutoMapper;
using DTOLayer.DTOs.AnnouncementDTOs;
using DTOLayer.DTOs.AppUserDTOs;
using DTOLayer.DTOs.CityDTOs;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concreate;

namespace TraversalWeb.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Eşleştirmeler buraya gelir
            CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();
            CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();
            CreateMap<AnnouncementUpdateDTO, Announcement>().ReverseMap();


            CreateMap<CityAddDTO, Destination>().ReverseMap();

            CreateMap<AppUserLoginDTOs, AppUser>().ReverseMap();

            CreateMap<AppUserRegisterDTOs, AppUser>().ReverseMap();

			CreateMap<SendMessageDTO, ContactUs>().ReverseMap();
		}
    }
}
