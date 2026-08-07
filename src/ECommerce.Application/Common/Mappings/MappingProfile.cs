using AutoMapper;
using ECommerce.Application.Cart.DTOs;
using ECommerce.Application.Categories.DTOs;
using ECommerce.Application.Common.DTOs;
using ECommerce.Application.Orders.DTOs;
using ECommerce.Application.Products.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.ValueObjects;
using DomainCart = ECommerce.Domain.Entities.Cart;

namespace ECommerce.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Address, AddressDto>();

        CreateMap<Category, CategoryDto>();

        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Amount))
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Price.Currency))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name));

        CreateMap<CartItem, CartItemDto>()
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice.Amount))
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.UnitPrice.Currency))
            .ForMember(dest => dest.LineTotal, opt => opt.MapFrom(src => src.LineTotal.Amount));

        CreateMap<DomainCart, CartDto>()
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Items.Sum(i => i.LineTotal.Amount)))
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src =>
                src.Items.Count > 0 ? src.Items.First().UnitPrice.Currency : "USD"));

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice.Amount))
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.UnitPrice.Currency))
            .ForMember(dest => dest.LineTotal, opt => opt.MapFrom(src => src.LineTotal.Amount));

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount.Amount))
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.TotalAmount.Currency));
    }
}