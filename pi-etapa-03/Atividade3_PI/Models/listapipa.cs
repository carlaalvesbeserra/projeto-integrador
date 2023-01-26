using System.Collections.Generic;

namespace Atividade3_PI.Models
{
    public class listapipa
    {
         private static List<pipas> Lista = new List<pipas>();

        public static void Incluir(pipas pipas)
        {
            Lista.Add(pipas);
        }
        public static List<pipas> Listar()
        {
            return Lista;
        }
    }
}