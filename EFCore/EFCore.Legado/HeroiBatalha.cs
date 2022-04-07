using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore.Legado
{
    public partial class HeroiBatalha
    {
        public int HeroiId { get; set; }
        public int BatalhaId { get; set; }

        public virtual Batalha Batalha { get; set; }
        public virtual Heroi Heroi { get; set; }
    }
}
