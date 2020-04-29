using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public static class Enum
    {
        public static class Retas
        {
            public const int DDA = 0;
            public const int BRESENHAM = 1;
        }

        public static class CIRCUNFERENCIAS
        {
            public const int BRESENHAM = 2;
        }

        public static class TRANSFORMACOES
        {
            public const int TRANSLADAR = 3;
            public const int ROTACIONAR = 4;
            public const int ESCALA_AUMENTAR = 5;
            public const int REFLETIRX = 6;
            public const int REFLETIRY = 7;
            public const int REFLETIRXY = 8;
            public const int ESCALA_DIMINUIR = 9;
            public const double CONSTANTE_MAIOR = 1.1;
            public const double CONSTANTE_MENOR = 0.9;
        }

        public static class RECORTE
        {
            public const int COHEN = 10;
            public const int LIANG = 11;
        }
    }
}
