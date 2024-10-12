using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract.Repositories;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.ViewComponents
{
    public class MostLikedBlogs:ViewComponent
    {
        private readonly IBlogService blogService;
        private readonly IBlogRaytingService blogRaytingService;
        private readonly IMapper mapper;
        public MostLikedBlogs(IBlogService blogService, IBlogRaytingService blogRaytingService, IMapper mapper)
        {
            this.blogService = blogService;
            this.blogRaytingService = blogRaytingService;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int writerId)
        {
            var blogRaytings = await blogRaytingService.GetBlogRaytingsByWriterId(writerId);

            var top4BlogRaytings = blogRaytings.Where(br => br.BlogRaytingCount >= 1).OrderByDescending(br => (br.BlogTotalScore/br.BlogRaytingCount)).Take(4).ToList();



            var blogIds = top4BlogRaytings.Select(br => br.BlogID).ToList();
            var blogs = await blogService.GetAllAsync();
            var topBlogs = blogs.Where(b => blogIds.Contains(b.Id)).ToList();

            var blogsDto=mapper.Map<List<BlogDto>>(topBlogs);
            return View(blogsDto);
        }
    }
}
