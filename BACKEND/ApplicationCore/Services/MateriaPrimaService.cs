using ApplicationCore.Interface.IRepositories;
using ApplicationCore.Interface.IServices;
using AutoMapper;
using Domain.Core;
using Domain.DTO.Request.Item;
using Domain.DTO.Request.MateriaPrima;
using Domain.DTO.Response.MateriaPrima;
using Domain.Entities;

namespace ApplicationCore.Services
{
    public class MateriaPrimaService : IMateriaPrimaService
    {
        private readonly IMateriaPrimaRepository _materiaPrimaRepository;
        private readonly IMapper _mapper;
        public MateriaPrimaService(
           IMateriaPrimaRepository materiaPrimaRepository
           , IMapper mapper)
        {
            this._materiaPrimaRepository = materiaPrimaRepository;
            this._mapper = mapper;
        }

        public async Task<HttpResponseResult<List<MateriaPrimaListarResponse>>> Listar()
        {
            var result = await this._materiaPrimaRepository.Listar();
            var responsemapper = _mapper.Map<IEnumerable<MateriaPrimaListarResponse>>(result);
            var response = new HttpResponseResult<List<MateriaPrimaListarResponse>>() { Data = responsemapper.ToList<MateriaPrimaListarResponse>() };
            return response;
        }


        public async Task<HttpResponseResult<int>> Eliminar(int IdMateriaPrima)
        {
            var param = new MateriaPrimaEliminarRequest { IdMateriaPrima = IdMateriaPrima };
            var parammapper = _mapper.Map<MateriaPrimaEntity>(param);
            var responsemapper = await _materiaPrimaRepository.Eliminar(parammapper);
            var response = new HttpResponseResult<int>() { Data = responsemapper };
            return response;
        }
    }
}
