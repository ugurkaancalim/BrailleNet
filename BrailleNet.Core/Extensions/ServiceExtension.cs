﻿using BrailleNet.Core.Implementations.Importers;
using BrailleNet.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BrailleNet.Core.Implementations.Translators;
using BrailleNet.Core.Implementations.Converters;
using BrailleNet.Core.Environment.Implementations;
using BrailleNet.Core.Environment.Interfaces;

namespace BrailleNet.Core.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterBrailleNetServices(this IServiceCollection services)
        {
            services.AddScoped<ILanguageImporter, LanguageImporter>();
            services.AddScoped<ITextConverter, TextToBrailleConverter>();
            services.AddScoped<ITextTranslator, TextTransator>();

           

            // Register the IFileManager service with the wwwroot path
            services.AddSingleton<IFileService, FileService>();

        }
    }
}
