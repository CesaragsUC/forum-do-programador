using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Queries
{
    public class AreaQuery : IAreaQuery
    {

        private readonly IAreaRepository _areaRepository;

        public AreaQuery(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }
        public async Task<AreaDTO> GetById(Guid id)
        {
            var area = await _areaRepository.GetById(id);
            if (area == null) return null;

            var areaModel = new AreaDTO
            {
                Id = area.Id,
                Name = area.Name,

            };

            return areaModel;
        }

        public async Task<IEnumerable<AreaDTO>> GetAll()
        {
            var areas = await _areaRepository.GetAll();
            if (areas == null) return null;

            var areaModel = new List<AreaDTO>();

            foreach (var item in areas)
            {
                areaModel.Add(new AreaDTO
                {

                    Id = item.Id,
                    Name = item.Name
                }); 

            }

            return areaModel;
        }
    }
}
