using ReceitasDoMundo.Classes;
using ReceitasDoMundo.Interfaces;
using System.Collections.Generic;

namespace ReceitasDoMundo
{
	public class ReceitaRepositorio : IRepositorio<Receita>
	{
		private List<Receita> listaReceita = new List<Receita>();
		public void Atualiza(int id, Receita objeto)
		{
			listaReceita[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaReceita[id].Excluir();
		}

		public void Insere(Receita objeto)
		{
			listaReceita.Add(objeto);
		}

		public List<Receita> Lista()
		{
			return listaReceita;
		}

		public int ProximoId()
		{
			return listaReceita.Count;
		}

		public Receita RetornaPorId(int id)
		{
			return listaReceita[id];
		}
	}
}