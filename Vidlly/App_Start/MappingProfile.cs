using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidlly.Dtos;
using Vidlly.Models;

namespace Vidlly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(c=>c.Id, opt=>opt.Ignore());
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c=>c.id, opt=>opt.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
        }
    }
}