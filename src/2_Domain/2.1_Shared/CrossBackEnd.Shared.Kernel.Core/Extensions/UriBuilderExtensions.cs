
using System;
using System.IO;

namespace CrossBackEnd.Shared.Kernel.Core.Extensions
{
    public static class UriBuilderExtensions
    {
        public static void AppendToPath(this UriBuilder builder, string pathToAdd)
        {
            builder.Path = Path.Combine(builder.Path, pathToAdd);
        }
    }
}