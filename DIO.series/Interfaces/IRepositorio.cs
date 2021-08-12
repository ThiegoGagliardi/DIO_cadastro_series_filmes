using System.Collections.Generic;

namespace DIO.series.Interfaces
{
    public interface IRepositorio<T>
    {
       List<T>  lista();

       T retronoPorId(int id);

       void insere(T entidade);

       void exclui(int id);

       void atualizar (int id, T entidade);

       int proximoID();

    }
}