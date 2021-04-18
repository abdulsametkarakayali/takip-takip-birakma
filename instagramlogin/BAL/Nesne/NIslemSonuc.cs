using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace instagramlogin.BAL.Nesne
{
    public class NIslemSonuc<T>
    {
        public bool Basarilimi { get; set; }
        public T Veri { get; set; }
        public string Mesaj { get; set; }
        public NHata HataBilgi { get; set; }
    }
}
