using EntityLayer.Concrete;

namespace DemoProject.Models
{
    public class AddThumbnail
    {
        public string BlogTitle { get; set; }
        public IFormFile? BlogThumbnailImage { get; set; }
        public IFormFile? BlogImage { get; set; }
        public string BlogContent { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryId { get; set; }
        public int? WriterID { get; set; }
    }
}
