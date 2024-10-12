namespace DemoProject.Utilities
{
    public static class ImageHelper
    {
        public static string SaveImage(IFormFile image, string folderPath)
        {
            if (image == null) return null;

            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), folderPath, newImageName);

            using (var stream = new FileStream(location, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            return newImageName;
        }
    }

}
