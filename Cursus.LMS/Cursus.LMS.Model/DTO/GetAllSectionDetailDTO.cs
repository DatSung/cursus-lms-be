using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursus.LMS.Model.DTO
{
    public class GetAllSectionDetailDTO
    {
        public Guid Id { get; set; }
        public Guid? courseSectionDetail {  get; set; }
        public string name { get; set; }
        public string? videoUrl { get; set; }
        public string? slideUrl { get; set; }
        public string? docsUrl { get; set; }
        public int? type { get; set; }
        public int? currentStatus { get; set; }
    }
}
