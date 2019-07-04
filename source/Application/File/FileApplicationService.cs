using DotNetCore.Objects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetCoreArchitecture.Application
{
    public sealed class FileApplicationService : IFileApplicationService
    {
        public async Task<IEnumerable<FileBinary>> AddAsync(string directory, IEnumerable<FileBinary> files)
        {
            foreach (var file in files)
            {
                await file.SaveAsync(directory);
            }

            return files;
        }

        public async Task<FileBinary> SelectAsync(string directory, Guid id)
        {
            return await FileBinary.ReadAsync(directory, id);
        }
    }
}
