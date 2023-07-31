using AutoMapper;
using SplitSpendingWeb.Dtos;
using SplitSpendingWeb.Model;

namespace SplitSpendingWeb.Profiles;

public class SpendingProfile : Profile {
    public SpendingProfile()
    {
        CreateMap<Spending, SpendingReadDto>();
    }
}