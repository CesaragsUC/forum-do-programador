using Forum.Application.DTO;
using Forum.Application.Queries.Interfaces;
using Forum.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries
{
    public class SectionQuery : ISectionQuery
    {
        private readonly ISectionRepository _sectionRepository;
        private readonly IAreaQuery _areaQuery;

        public SectionQuery(ISectionRepository sectionRepository,
            IAreaQuery areaQuery)
        {
            _sectionRepository = sectionRepository;
            _areaQuery = areaQuery;
        }
        public async Task<SectionDTO> GetById(Guid id)
        {
            var section = await _sectionRepository.GetById(id);
            if (section == null) return null;

            var sectionModel = new SectionDTO
            {
                Id = section.Id,
                Name = section.Name,
                IsActive = section.IsActive,
                CreationDate = section.CreationDate
            };

            return sectionModel;
        }

        public async Task<IEnumerable<SectionDTO>> GetAll()
        {
            var sections = await _sectionRepository.GetAll();
            if (sections == null) return null;

            var sectionModel = new List<SectionDTO>();

            foreach (var item in sections)
            {
                var area = await _areaQuery.GetById(item.AreaId);
                sectionModel.Add(new SectionDTO
                {

                    Id = item.Id,
                    Name = item.Name,
                    IsActive = item.IsActive,
                    CreationDate = item.CreationDate,
                    AreaId = item.AreaId,
                    Area = area
                }); 

            }

            return sectionModel;
        }
    }
}
