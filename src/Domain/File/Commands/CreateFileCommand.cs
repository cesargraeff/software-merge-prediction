using MediatR;

using Domain.Shared.Commands;

namespace Domain.File.Commands
{
    public class CreateFileCommand : Command<Unit>
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}