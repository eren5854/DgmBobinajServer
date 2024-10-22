using AutoMapper;
using DgmBobinajServer.DTOs.Comment;
using DgmBobinajServer.DTOs.DescriptionModelDto;
using DgmBobinajServer.DTOs.Galery;
using DgmBobinajServer.DTOs.Layout;
using DgmBobinajServer.DTOs.Link;
using DgmBobinajServer.DTOs.MiniService;
using DgmBobinajServer.Models;

namespace DgmBobinajServer.Mapping;

public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLayoutDto, Layout>();
        CreateMap<UpdateLayoutDto, Layout>();

        CreateMap<CreateLinkDto, Link>();
        CreateMap<UpdateLinkDto, Link>();

        CreateMap<CreateMiniServiceDto, MiniService>();
        CreateMap<UpdateMiniServiceDto, MiniService>();

        CreateMap<CreateDescriptionModelDto, DescriptionModel>();
        CreateMap<UpdateDescriptionModelDto, DescriptionModel>();

        CreateMap<CreateGaleryDto, Galery>();
        CreateMap<UpdateGaleryDto, Galery>();

        CreateMap<CreateCommentDto, Comment>();
        CreateMap<UpdateCommentDto, Comment>();
    }
}
