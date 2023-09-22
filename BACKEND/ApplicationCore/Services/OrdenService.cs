using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;

namespace ApplicationCore.Services
{
    public class OrdenService: IOrdenService
    {
        private readonly IOrdenRepository _itemRepository;
        private readonly IMapper _mapper;
        public OrdenService(
            IOrdenRepository itemRepository
           , IMapper mapper)
        {
            this._itemRepository = itemRepository;
            this._mapper = mapper;
        }




    }
}
