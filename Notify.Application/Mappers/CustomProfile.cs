using AutoMapper;
using Notify.Contracts.Shared;
using Notify.Domain.Customers;
using Notify.Domain.Notifications;
using Notify.Domain.Orders;

namespace Notify.Application.Mappers;

internal class CustomProfile : Profile
{
    public CustomProfile()
    {
        CreateMap<OrderProductData, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<ProductDto, OrderProductData>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

        CreateMap<OrderDto, Order>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));

        CreateMap<OrderProduct, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        CreateMap<Customer, CustomerDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        CreateMap<Notification, NotificationDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
            .ForMember(dest => dest.Recipient, opt => opt.MapFrom(src => src.Recipient))
            .ForMember(dest => dest.SendTimeUTC, opt => opt.MapFrom(src => src.SendTimeUTC))
            .ForMember(dest => dest.NotificationType, opt => opt.MapFrom(src => src.NotificationType))
            .ForMember(dest => dest.NotificationStatus, opt => opt.MapFrom(src => src.NotificationStatus));

        CreateMap<NotificationDto, Notification>()
            .ForMember(dest => dest.NotificationType, opt => opt.MapFrom(src => src.NotificationType))
            .ForMember(dest => dest.NotificationStatus, opt => opt.MapFrom(src => src.NotificationStatus));

        CreateMap<Domain.Notifications.NotificationType, Contracts.Shared.NotificationType>().ReverseMap();
        CreateMap<Domain.Notifications.NotificationStatus, Contracts.Shared.NotificationStatus>().ReverseMap();
    }
}