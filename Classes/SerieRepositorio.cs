namespace DIO.series
{

using System.Collections.Generic;
using DIO.series.Interfaces;

    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void atualizar(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void insere(Serie entidade)
        {
           listaSerie.Add(entidade);
        }

        public List<Serie> lista()
        {
            return listaSerie;            
        }

        public int proximoID()
        {
            return listaSerie.Count;
        }

        public Serie retronoPorId(int id)
        {
            return  listaSerie[id];
        }
    }
}