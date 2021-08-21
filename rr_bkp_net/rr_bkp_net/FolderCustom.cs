using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rr_bkp_net
{
    public class FolderCustom : FileSystemCustom
    {
        public List<FileCustom> Files { get; set; }

        public List<FolderCustom> Folders { get; set; }
    }
}
