using Microsoft.AspNetCore.Http;
using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stx.Shared.Models.DTO.HRM
{
    public class FileUploadDto
    {
        public string FileName { get; set; }
        public int FileBaseRecID { get; set; }
        public object FileObject { get; set; }

    }
}
