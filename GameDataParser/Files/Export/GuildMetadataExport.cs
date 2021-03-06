﻿using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using GameDataParser.Crypto.Common;
using GameDataParser.Parsers;
using Maple2Storage.Types.Metadata;

namespace GameDataParser.Files.Export
{
    public static class GuildMetadataExport
    {
        public static void Export(List<PackFileEntry> files, MemoryMappedFile memFile)
        {
            if (Hash.CheckHash("ms2-guild-metadata"))
            {
                Console.WriteLine("\rSkipping guild metadata!");
                return;
            }

            // Parse and save some item data from xml file
            GuildMetadata GuildMetadata = GuildParser.Parse(memFile, files);
            GuildParser.Write(GuildMetadata);
            Hash.WriteHash("ms2-guild-metadata");
        }
    }
}
