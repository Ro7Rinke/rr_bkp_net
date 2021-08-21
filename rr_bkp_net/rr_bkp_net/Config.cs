using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace rr_bkp_net
{
    public class Config
    {
        public string RootPathBackup { get; set; }

        public List<string> FoldersToBackup { get; set; }

        public List<string> IgnoreFolderPaths { get; set; }

        public List<string> IgnoreFilePaths { get; set; }

        public Config() { }

        public Config(bool isTest)
        {
            if (isTest)
            {
                this.RootPathBackup = @"C:\Users\Ro7Rinke\Documents\work\rr_bkp_net\bkp";
                this.FoldersToBackup = new List<string>();
                this.FoldersToBackup.Add(@"C:\Users\Ro7Rinke\Documents\work\rr_bkp_net\a");
                this.IgnoreFolderPaths = new List<string>();
                this.IgnoreFilePaths = new List<string>();
            }
            else
            {
                try
                {
                    string data = File.ReadAllText(@"C:\Users\Ro7Rinke\Documents\work\rr_bkp_net\rr_bkp_net\rr_bkp_net\Config.json");
                    Config config = JsonSerializer.Deserialize<Config>(data);

                    this.RootPathBackup = config.RootPathBackup;
                    this.FoldersToBackup = config.FoldersToBackup;
                    this.IgnoreFolderPaths = config.IgnoreFolderPaths;
                    this.IgnoreFilePaths = config.IgnoreFilePaths;
                }
                catch(Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
