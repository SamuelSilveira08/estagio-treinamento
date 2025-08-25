using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public enum NivelPerigo
    {
        NENHUM = 1,
        BAIXO = 2,
        MEDIO = 3,
        ALTO = 4,
        EXTREMO = 5,
        FUJA = 6
    }

    public enum Raridade
    {
        COMUM = 1,
        INCOMUM = 2,
        RARO = 3,
        LENDÁRIO = 4,
        ICÔNICO = 5
    }

    public enum Tipo
    {
        HUMANO = 1,
        MORTO_VIVO = 2,
        SELVAGEM = 3,
        GIGANTE = 4,
        ABERRAÇÃO = 5,
        INSETO = 6,
        CONSTRUTO = 7
    }
}
