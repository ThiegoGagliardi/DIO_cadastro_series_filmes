using System.Collections.Generic;
using DIO.series.Interfaces;

namespace DIO.series
{
    public class FilmesRepositorio: IRepositorio<Filme>
    {

        private List<Filme> listaFilme = new List<Filme>();

        public void atualizar(int id, Filme entidade)
        {
            listaFilme[id] = entidade;
        }

        public void exclui(int id)
        {
            listaFilme[id].Excluir();
        }

        public void insere(Filme entidade)
        {
           listaFilme.Add(entidade);
        }

        public List<Filme> lista()
        {
            return listaFilme;            
        }

        public int proximoID()
        {
            return listaFilme.Count;
        }

        public Filme retronoPorId(int id)
        {
            return  listaFilme[id];
        }        
    }
}