using SamarStore.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Domain.Entities.HomePage
{
    public class Slider : BaseEntity
    {
        public string Src { get; set; } = string.Empty;
        public string? Link { get; set; }
        public int ClickCount { get; set; }
    }
}
