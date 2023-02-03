using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jamlu
{
    class Nemico : Character
    {
        public int Livello;
        public Nemico(int armatura, int danno, int agilita, int resistenza, int vita, int livello)
        {
            this.Armatura = armatura;
            this.Danno = danno;
            this.Agilita = agilita;
            this.Resistenza = resistenza;
            this.Vita = vita;
            this.Livello = livello;
        }
        public Nemico()
        {

        }
    }
}
