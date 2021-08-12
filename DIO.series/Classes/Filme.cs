namespace DIO.series
{
    using System;

    public class Filme : EntidadeBase
    {
    private Genero genero { get; set; }
    private string titulo { get; set; }
    private string descricao { get; set; }
    private int ano { get; set; }
    private int duracao { get; set; }
    public Situacao situacao { get; private set; }

    public Filme(int id, Genero genero, string titulo, string descricao, int ano, int duracao)
    {
        this.id = id;
        this.genero = genero;
        this.titulo = titulo;
        this.descricao = descricao;
        this.ano = ano;
        this.duracao = duracao;
        this.situacao = Situacao.Concluida;
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
        retorno += "Duração: " + this.duracao + Environment.NewLine;
        
        return retorno;
    }        
        
    }
}