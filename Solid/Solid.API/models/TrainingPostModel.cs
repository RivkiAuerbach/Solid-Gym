using Solid.Core.Entities;

namespace Solid.API.models
{
    public class TrainingPostModel
    {
        public string Title { get; set; }

        public int Day { get; set; }
        public double Hour { get; set; }
        public int GuideId { get; set; }
        public Guide Guide { get; set; }
    }
}
