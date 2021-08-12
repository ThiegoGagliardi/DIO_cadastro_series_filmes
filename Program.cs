using System;
using System.Collections.Generic;

namespace DIO.series
{
    class Program
    {
        static SerieRepositorio repositorioSeries = new SerieRepositorio();
        static FilmesRepositorio repositorioFilmes = new FilmesRepositorio();

        static void Main(string[] args)
        {
            string op = "";

            do
            {
                op = obterOpcaoUsuario();

                switch(op)
                {
                    case "1": 
                        listarSeries();
                        break;

                    case "2":
                        inserirAtualizarSerie(atualiza : false);
                        break;

                    case "3":
                        inserirAtualizarSerie(atualiza: true);
                        break;
                    
                    case "4": 
                        excluirSerie();
                        break;
                    
                    case "5" :
                      visualizarSerie();
                      break;

                    case "6" :
                      listarSeriesExcluidas();
                      break;

                    case "7": 
                        listarFilmes();
                        break;

                    case "8":
                        inserirAtualizarFilme(atualiza : false);
                        break;

                    case "9":
                        inserirAtualizarFilme(atualiza: true);
                        break;
                    
                    case "10": 
                        excluirFilme();
                        break;
                    
                    case "11" :
                      visualizarFilme();
                      break;

                    case "12" :
                      listarFilmesExcluidos();
                      break;

                    case "C" :
                      Console.Clear();
                      break; 

                    case "X" :
                      Console.Clear();
                      break;                      

                    default:                   
                        throw new ArgumentOutOfRangeException();                     
                }

            } while (op != "X");
            
        }

        private static string obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Series");
            Console.WriteLine("Selecione a opção que deseja executar:");
            Console.WriteLine();

            Console.WriteLine("1-Listar Series");
            Console.WriteLine("2-Inserir Nova Serie");
            Console.WriteLine("3-Atualizar Serie");
            Console.WriteLine("4-Excluir Serie");
            Console.WriteLine("5-Visualizar Serie");
            Console.WriteLine("6-Listar Serie Excluidas");
            Console.WriteLine("7-Listar Filmes");
            Console.WriteLine("8-Inserir Novo Filme");
            Console.WriteLine("9-Atualizar Filme");
            Console.WriteLine("10-Excluir Filme");
            Console.WriteLine("11-Visualizar Filme");
            Console.WriteLine("12-Listar Filmes Excluidos");                           
            Console.WriteLine("C-Limpar");
            Console.WriteLine("X-Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void excluirSerie()
        {
            Console.WriteLine("Digite o Id da serie para exclusao");
            int idExclusao = int.Parse(Console.ReadLine());

            if (idExclusao >= repositorioSeries.proximoID()){
               Console.WriteLine("Digite um ID valido.");
               return;
            }

            repositorioSeries.exclui(idExclusao);                   
        }        
        private static void visualizarSerie()
        {
            Console.WriteLine("Digite o ID da serie para visualizar:");
            int id = int.Parse(Console.ReadLine());
            Serie serie = repositorioSeries.retronoPorId(id);

            if (id >= repositorioSeries.proximoID()){
               Console.WriteLine("Digite um ID valido.");
               return;
            }
            
            Console.WriteLine(serie);

        }

        private static void listarSeries()        
        {
            var lista = repositorioSeries.lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Lista de series vazia.");
                return;
            }

            foreach (var s in lista){
              if (s.situacao == Situacao.Excluida) 
              {
                  continue;
              }

              Console.WriteLine("#ID {0}: {1}", s.retornaID(), s.retornaTitulo());
            }
        }

        private static void listarSeriesExcluidas()        
        {
            var lista = repositorioSeries.lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Lista de series vazia.");
                return;
            }

            foreach (var s in lista){
                if (s.situacao == Situacao.Excluida) 
                {
                    Console.WriteLine("#ID {0}: {1}", s.retornaID(), s.retornaTitulo());
                }              
            }
        }        

        private static void inserirAtualizarSerie(bool atualiza)
        {
            int idProcesso = -1;

            if (atualiza) {
                Console.WriteLine("Digite o ID para atualizar a serie:");
                idProcesso = int.Parse(Console.ReadLine()); 

                if (idProcesso >= repositorioSeries.proximoID()){
                     Console.WriteLine("Digite um ID valido.");
                    return;
                 }

            } else {
                Console.WriteLine("Inserir uma nova serie:");
                idProcesso = repositorioSeries.proximoID();
            }

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

            Console.WriteLine("Digite o genero entre as opcoes acima:");
            int generoEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie:");
            string tituloEntrada = Console.ReadLine();

            Console.WriteLine("Digite o descriçao da serie:");
            string descricaoEntrada = Console.ReadLine();            

            Console.WriteLine("Digite o ano de inicio da serie:");
            int  anoEntrada = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Digite a quantidade de temporadas:");
            int  qtdeTempEntrada = int.Parse(Console.ReadLine()); 
			
            foreach (int j in Enum.GetValues(typeof(Situacao)))
			{  
                if  ((Situacao)j == Situacao.Excluida)
                {
                   continue;
                }

				Console.WriteLine("{0}-{1}", j, Enum.GetName(typeof(Situacao), j));
			}

            Console.WriteLine("Digite a situacao da serie conforme listagem acima:");
            int  sitEntrada = int.Parse(Console.ReadLine()); 
  
            var novaSerie = new Serie( id: idProcesso,
                                      genero:(Genero)generoEntrada,
                                      titulo:tituloEntrada,
                                      descricao:descricaoEntrada,
                                      ano:anoEntrada,
                                      qtd_temp:qtdeTempEntrada,
                                      sit:(Situacao)sitEntrada );

            if (atualiza) {  
                repositorioSeries.atualizar(idProcesso, novaSerie);   
            } else{
                repositorioSeries.insere(novaSerie);
            }
        }

        private static void excluirFilme()
        {
            Console.WriteLine("Digite o Id da filme para exclusao");
            int idExclusao = int.Parse(Console.ReadLine());

            if (idExclusao >= repositorioFilmes.proximoID()){
               Console.WriteLine("Digite um ID valido.");
               return;
            }

            repositorioFilmes.exclui(idExclusao);                   
        }
        
        private static void visualizarFilme()
        {
            Console.WriteLine("Digite o ID da Filme para visualizar:");
            int id = int.Parse(Console.ReadLine());
            Filme Filme = repositorioFilmes.retronoPorId(id);

            if (id >= repositorioFilmes.proximoID()){
               Console.WriteLine("Digite um ID valido.");
               return;
            }
            
            Console.WriteLine(Filme);

        }

        private static void listarFilmes()        
        {
            var lista = repositorioFilmes.lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Lista de filmes vazia.");
                return;
            }

            foreach (var f in lista){
              if (f.situacao == Situacao.Excluida) 
              {
                  continue;
              }

              Console.WriteLine("#ID {0}: {1}", f.retornaID(), f.retornaTitulo());
            }
        }

        private static void listarFilmesExcluidos()        
        {
            var lista = repositorioFilmes.lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Lista de filmes vazia.");
                return;
            }

            foreach (var f in lista){
                if (f.situacao == Situacao.Excluida) 
                {
                    Console.WriteLine("#ID {0}: {1}", f.retornaID(), f.retornaTitulo());
                }              
            }
        }        

        private static void inserirAtualizarFilme(bool atualiza)
        {
            int idProcesso = -1;

            if (atualiza) {
                Console.WriteLine("Digite o ID para atualizar a filme:");
                idProcesso = int.Parse(Console.ReadLine()); 

                if (idProcesso >= repositorioFilmes.proximoID()){
                     Console.WriteLine("Digite um ID valido.");
                    return;
                 }

            } else {
                Console.WriteLine("Inserir um novo filme:");
                idProcesso = repositorioFilmes.proximoID();
            }

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}

            Console.WriteLine("Digite o genero entre as opções acima:");
            int generoEntrada = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo do filme:");
            string tituloEntrada = Console.ReadLine();

            Console.WriteLine("Digite o descriçao do filme:");
            string descricaoEntrada = Console.ReadLine();            

            Console.WriteLine("Digite o ano de lançamento do filme:");
            int  anoEntrada = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Digite a duraçao do filme:");
            int  duracaoEntrada = int.Parse(Console.ReadLine()); 	

  
            var novoFilme = new Filme( id: idProcesso,
                                      genero:(Genero)generoEntrada,
                                      titulo:tituloEntrada,
                                      descricao:descricaoEntrada,
                                      ano:anoEntrada,
                                      duracao:duracaoEntrada);

            if (atualiza) {  
                repositorioFilmes.atualizar(idProcesso, novoFilme);   
            } else{
                repositorioFilmes.insere(novoFilme);
            }
        }
    }
    
}