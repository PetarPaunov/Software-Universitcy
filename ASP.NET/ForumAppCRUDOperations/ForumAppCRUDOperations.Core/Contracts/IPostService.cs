using ForumAppCRUDOperations.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ForumAppCRUDOperations.Core.Contracts
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetAllPosts();

        Task AddPost(AddPostViewModel model);
    }
}
