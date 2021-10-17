using System;
using System.Collections.Generic;
using System.Text;

namespace ReceitasDoMundo.Classes
{
	public class Receita : EntidadeBase
	{		
		private Origem Origem { get; set; }
		private string Nome { get; set; }
		private int Ano { get; set; }
		private string Ingredientes { get; set; }
		public string ModoPreparo { get; set; }
		private bool Excluido { get; set; }

        public Receita(int id, Origem origem, string nome, int ano, string ingredientes, string modoPreparo)
        {
			Id = id;
            Origem = origem;
            Nome = nome;
            Ano = ano;
            Ingredientes = ingredientes;
            ModoPreparo = modoPreparo;
            Excluido = false;
        }
		public string retornaTitulo()
		{
			return this.Nome;
		}

		public int retornaId()
		{
			return this.Id;
		}
		public bool retornaExcluido()
		{
			return this.Excluido;
		}
		public void Excluir()
		{
			Excluido = true;
		}

		public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1

			string retorno = "";
			retorno += "	--------------------\n";
			retorno += "	País: " + Origem + Environment.NewLine;
			retorno += "	Nome: " + Nome + Environment.NewLine;
			retorno += "	Ano que a receita foi criada: " + Ano + Environment.NewLine;
			retorno += "	Ingredientes: " + Ingredientes + Environment.NewLine;
			retorno += "	Modo de preparo: " + ModoPreparo + Environment.NewLine;
			retorno += "	Excluido: " + Excluido;
			retorno += "\n	--------------------";
			return retorno;
		}
	}
}
