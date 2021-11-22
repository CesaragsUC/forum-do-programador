﻿using Forum.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Application.Queries.Interfaces
{
    public interface ICommentQuery
    {
        Task<CommentsDTO> GetById(Guid id);
        Task<IEnumerable<CommentsDTO>> GetAll();

        Task<IEnumerable<CommentsDTO>> GetByTopicId(Guid topicId, Guid loggedUserId);
    }
}
