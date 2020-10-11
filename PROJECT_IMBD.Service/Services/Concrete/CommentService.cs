using PROJECT_IMBD.Service.Services.Abstraction;
using PROJECT_IMDB.DAL.Context;
using PROJECT_IMDB.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJECT_IMBD.Service.Services.Concrete
{
    public class CommentService:BaseService<Comment>,ICommentService
    {
        public CommentService(ProjectContext context):base(context)
        {

        }
    }
}
