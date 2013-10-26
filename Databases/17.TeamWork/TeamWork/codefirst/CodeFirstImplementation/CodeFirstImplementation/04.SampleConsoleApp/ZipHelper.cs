using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ionic.Zip;
using System.IO;

namespace _04.SampleConsoleApp
{
    public class ZipHelper
    {
        public static void ExtractEntriesFromZip(string zipPath, string extractPath, string startDate = null)
        {
            ZipFile archive = ZipFile.Read(zipPath);
            using (archive)
            {
                if (startDate == null)
                {
                    startDate = "";
                }

                var selection =
                    from e in archive.Entries
                    where e.FileName.CompareTo(startDate) >= 0
                    select e;

                if (!Directory.Exists(extractPath))
                {
                    Directory.CreateDirectory(extractPath);
                }

                foreach (var entry in selection)
                {
                    entry.Extract(extractPath, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
}
