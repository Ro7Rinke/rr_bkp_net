using System;
using System.Collections.Generic;
using System.IO;

namespace rr_bkp_net
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            int total = 0;
            int totalCopied = 0;

            Config config = new Config(false);


            foreach(string path in config.FoldersToBackup)
            {
                string rootPath = Path.GetDirectoryName(path);
                var dir = new DirectoryInfo($@"{rootPath}\{path}");

                List<string> pathsToCopy = new List<string>();

                try
                {
                    var files = new FileSystemEnumerable(dir, string.Empty, SearchOption.AllDirectories);

                    foreach (var file in files)
                    {
                        if (file.Attributes != FileAttributes.Directory)
                        {
                            total++;

                            FileInfo pathBkp = new FileInfo(file.FullName.Replace(rootPath, config.RootPathBackup));

                            if (!pathBkp.Exists || pathBkp.LastWriteTime < file.LastWriteTime)
                            {
                                pathsToCopy.Add(file.FullName);
                            }
                        }
                    }

                    foreach (string pathToCopy in pathsToCopy)
                    {
                        string pathToCopyBkp = pathToCopy.Replace(rootPath, config.RootPathBackup);
                        string directoryBkp = Path.GetDirectoryName(pathToCopyBkp);

                        if (!Directory.Exists(directoryBkp))
                        {
                            Directory.CreateDirectory(directoryBkp);
                        }

                        File.Copy(pathToCopy, pathToCopyBkp, true);
                        totalCopied++;
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            TimeSpan timeElapsed = DateTime.Now - start;
            Console.WriteLine($"Total: {total}");
            Console.WriteLine($"To Copy: {totalCopied}");
            Console.WriteLine($"Time Elapsed: {timeElapsed.TotalSeconds}");
        }


    }
}
