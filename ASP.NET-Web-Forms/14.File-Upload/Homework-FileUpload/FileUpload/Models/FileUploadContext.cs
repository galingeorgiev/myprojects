using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FileUpload.Models
{
    public class FileUploadContext : DbContext
    {
        public FileUploadContext()
            : base("UploadFilesDb")
        {

        }

        public DbSet<File> Files { get; set; }
    }
}