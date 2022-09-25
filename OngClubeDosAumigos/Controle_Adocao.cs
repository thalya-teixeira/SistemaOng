using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngClubeDosAumigos
{
    internal class Controle_Adocao
    {
        public int Num_Chip { get; set; }
        public string CPF { get; set; }
        public DateTime Date { get; set; }

        public Controle_Adocao(int num_Chip, string cPF, DateTime date)
        {
            Num_Chip = num_Chip;
            CPF = cPF;
            Date = date;
        }

        public Controle_Adocao()
        {

        }
    }
}
