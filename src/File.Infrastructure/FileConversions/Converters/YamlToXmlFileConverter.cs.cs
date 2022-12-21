﻿using File.Infrastructure.Abstractions;
using LunarLabs.Parser.XML;
using LunarLabs.Parser.YAML;

namespace File.Infrastructure.FileConversions.Converters
{
    internal class YamlToXmlFileConverter : IFileConverter
    {
        public Task<string> Convert(string fileContent, CancellationToken cancellationToken)
        {
            var root = YAMLReader.ReadFromString(fileContent);
            cancellationToken.ThrowIfCancellationRequested();
            var jsonContent = XMLWriter.WriteToString(root);
            return Task.FromResult(jsonContent);
        }
    }
}
