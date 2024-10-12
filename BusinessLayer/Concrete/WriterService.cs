using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Repositories;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterService : Service<Writer>, IWriterService
    {
        private readonly UserManager<AppUser> _userManager; 
        private readonly ICommentRepository commentRepository;
        private readonly IWriterRepository writerRepository;
        private readonly IMapper mapper;
        public WriterService(IGenericRepository<Writer> repository, IUnitOfWork unitOfWork, IWriterRepository writerRepository, IMapper mapper, ICommentRepository commentRepository, UserManager<AppUser> userManager) : base(repository, unitOfWork)
        {
            this.writerRepository = writerRepository;
            this.mapper = mapper;
            this.commentRepository = commentRepository;
            _userManager = userManager;
        }

        public async Task<List<BlogDto>> GetBlogsByWriterId(int id)
        {
           var blogs = await writerRepository.GetBlogsByWriterId(id);
            var blogsDto=mapper.Map<List<BlogDto>>(blogs);
            return blogsDto;
        }

        //public async Task<Writer> GetUserByUserMail(string mail)
        //{
        //    var writer = await writerRepository.GetCurrentUserByUserMail(mail);
        //    return writer;
        //}

        public async Task<Writer> GetCurrentUserByUsername(string username)
        {
            var values = await _userManager.FindByNameAsync(username);

            return await writerRepository.GetCurrentUserByUserMail(values.Email);
        }

        public async Task<List<CommentDto>> GetLastCommentsByWriterId(int id)
        {
            var blogs = await writerRepository.GetBlogsByWriterId(id);

            // Blog ID'lerini listeye dönüştür
            var blogIds = blogs.Select(b => b.Id).ToList();

            // Blog ID'lerine göre yorumları al ve en son 5 yorumu getir
            var comments = commentRepository.GetCommentsByBlogIds(blogIds).OrderByDescending(c => c.CreatedTime)
                .Take(10)
                .ToList();

            var commentDtos = mapper.Map<List<CommentDto>>(comments);

            return commentDtos;
        }
    }
}
