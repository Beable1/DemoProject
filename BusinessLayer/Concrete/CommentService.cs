using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentService : Service<Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        

        public CommentService(IGenericRepository<Comment> repository, IUnitOfWork unitOfWork, ICommentRepository commentRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            
        }

        public IEnumerable<CommentDto> GetComments()
        {
            var comments =_commentRepository.GetAll();
            var commentsDto=_mapper.Map<IEnumerable<CommentDto>>(comments);
            return commentsDto;
        }

        
    }
}
