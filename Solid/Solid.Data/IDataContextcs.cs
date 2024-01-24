using Solid.Core.Entities;

namespace Solid.Data
{
    public interface IDataContextcs
    {
        public List<Guide> GuideList { get; set; }
        public List<Student> StudentList { get; set; }
        public List<Training> TrainingList { get; set; }

    }
}
