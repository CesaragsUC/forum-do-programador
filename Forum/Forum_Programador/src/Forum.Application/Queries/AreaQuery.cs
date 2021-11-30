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
        private readonly ITopicRepository _topicRepository;

        public AreaQuery(IAreaRepository areaRepository,
            ITopicRepository topicRepository)
        {
            _areaRepository = areaRepository;
            _topicRepository = topicRepository;
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
                var sectionList = new List<SectionDTO>();

                foreach (var sc in item.Sections)
                {
                    var topics = await _topicRepository.GetBySectionId(sc.Id);
                    var coments = topics.Select(x => x.Coments).ToList();

                    var areaDTO = new AreaDTO
                    {
                        Id = sc.Areas.Id,
                        Name = sc.Areas.Name
                    };

                    var sectionDTO = new SectionDTO
                    {
                        Id = sc.Id,
                        Name = sc.Name,
                        IsActive = sc.IsActive,
                        AreaId = sc.AreaId,
                        Area = areaDTO,
                        TotalPosts = coments.Any() ? coments[0].Count() : 0, //all sumed comments for each topic
                        TotalTopics = topics.Count() //all sumed topics for this section


                    };

                    sectionList.Add(sectionDTO);
                }

                areaModel.Add(new AreaDTO
                {

                    Id = item.Id,
                    Name = item.Name,
                    Sections = sectionList

                });


            }

            return areaModel;
        }
    }
}
