using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using WorkRun.Core;

namespace WorkRun.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadFile();
        }

        private static void ReadFile()
        {
            string json = File.ReadAllText("Tourism_1.json");
            var root = JsonDocument.Parse(json).RootElement;
            var result = JsonSerializer.Deserialize<List<BynmModel>>(root.GetProperty("indirimliFaaliyetCinsleri").ToString(), RunHelper.GetJsonSettings());
        }
    }
}
