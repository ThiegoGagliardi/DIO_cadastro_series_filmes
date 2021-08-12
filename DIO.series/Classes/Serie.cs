namespace DIO.series
{
using System;

 public class Serie : EntidadeBase
 {
    private Genero genero { get; set; }
    private string titulo { get; set; }
    private string descricao { get; set; }
    private int ano { get; set; }
    private int qtde_temporadas { get; set; }
    public Situacao situacao { get; private set; }

    public Serie(int id, Genero genero, string titulo, string descricao, int ano, int qtd_temp, Situacao sit)
    {
        this.id = id;
        this.genero = genero;
        this.titulo = titulo;
        this.descricao = descricao;
        this.ano = ano;
        this.qtde_temporadas = qtd_temp;
        this.situacao = sit;        
    }

    public int retornaID ()
    {
        return this.id;
    }

    public string retornaTitulo ()
    { 
        return this.titulo;
    }

    public void Excluir()
    {
        this.situacao = Situacao.Excluida;
    }

    public override string ToString()
    {
        string retorno = "";
        retorno += "Genero: " + this.genero + Environment.NewLine;
        retorno += "Título: " + this.titulo + Environment.NewLine;
        retorno += "Descrição: " + this.descricao + Environment.NewLine;
        retorno += "Ano: " + this.ano + Environment.NewLine;
        retorno += "Duracao: " + this.qtde_temporadas + Environment.NewLine;
        
        return retorno;
    }
 }

}