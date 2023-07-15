using Domain.Shared.Entities;

namespace Domain.File.Models
{
    public class File : Entity
    {
        public string Name { get; private set; }
        public string Path { get; private set; }

        public File(
            string name,
            string path
        )
        {
            this.Name = name;
            this.Path = path;
        }
        public void Update(
            string name,
            string path
        )
        {
            this.Name = name;
            this.Path = path;
        }
    }
}