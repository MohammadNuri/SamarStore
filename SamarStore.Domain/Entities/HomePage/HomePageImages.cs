using SamarStore.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SamarStore.Domain.Entities.HomePage
{
    public class HomePageImages : BaseEntity
    {
        public string Src { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public ImageLocation ImageLocation { get; set; }
    }

    public enum ImageLocation
    {
        L1 = 0, // عکس اول سمت چپ
        L2 = 1, // عکس دوم سمت چپ
        R1 = 3, // عکس زیر اسلایدر
        CenterWideImage = 4, // عکس وسط دراز
        G1 = 5, // عکس دسته بندی 1
        G2 = 6, // عکس دسته بندی 2
        
    }
}
