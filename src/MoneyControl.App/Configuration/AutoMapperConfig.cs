using AutoMapper;
using MoneyControl.App.DTOs;
using MoneyControl.Business.Models;

namespace MoneyControl.App.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
        }
    }
}
