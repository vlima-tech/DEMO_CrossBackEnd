
using System;
using System.IO;

namespace CrossBackEnd.Shared.Kernel.Core.Extensions
{
    internal static class UriBuilderExtensions
    {
        internal static void AppendToPath(this UriBuilder builder, string pathToAdd)
        {
            builder.Path = Path.Combine(builder.Path, pathToAdd);
        }
    }
}