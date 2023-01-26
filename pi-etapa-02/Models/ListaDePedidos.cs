using System.Collections.Generic;
namespace mflanchesmvc.Models
{
    public class ListaDePedidos
    {
    private static List<CadastroDePedidos> Lista = new List<CadastroDePedidos>();

    public static void Incluir(CadastroDePedidos cadastro)
        {
    Lista.Add(cadastro);
        }
     public static List<CadastroDePedidos> Listar()
        {
    return Lista;
    }
}
}