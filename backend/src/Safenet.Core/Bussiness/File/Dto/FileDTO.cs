using System;
using System.Collections.Generic;
using System.Text;

namespace Safenet.Bussiness.File.Dto
{
    public class FileDTO
    {
        public long Id { get; set; }
        public virtual string Ten { get; set; }
        public virtual string URL { get; set; }
    }
}
