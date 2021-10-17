using ReceitasDoMundo.Classes;
using System;

namespace ReceitasDoMundo
{
    class Program
    {
		static ReceitaRepositorio repositorio = new ReceitaRepositorio();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarReceita();
						break;
					case "2":
						InserirReceita();
						break;
					case "3":
						AtualizarReceita();
						break;
					case "4":
						ExcluirReceita();
						break;
					case "5":
						VisualizarReceita();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("	<<<< Obrigado por utilizar nossos serviços. >>>>");
			Console.ReadLine();
		}

		private static void ListarReceita()
		{
			Console.WriteLine("	<<<< Listar Receita >>>>");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("  Você ainda não cadastou nenhuma receita...\n" + "  digite a opção << 2 >> e cadastre uma nova.");
				return;
			}

			foreach (var serie in lista)
			{
				var excluido = serie.retornaExcluido();

				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}
		private static void InserirReceita()
		{
			Console.WriteLine("	<<<< Inserir nova receita >>>>\n");

			foreach (int i in Enum.GetValues(typeof(Origem)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Origem), i));
			}

			Console.Write("	Digite o país de origem da receita, dentre as opção acima: ");
			int entradaOrigem = int.Parse(Console.ReadLine());
			while (entradaOrigem <= 0 || entradaOrigem > 13)
			{
				Console.WriteLine("\n	<<<< Não existe essa opção cadastrada! >>>>\n");
				Console.Write("	Digite o país de origem da receita, dentre as opção acima: ");
				entradaOrigem = int.Parse(Console.ReadLine());
			}
			Console.Write("	Digite o Nome da receita: ");
			string entradaNome = Console.ReadLine();

			Console.Write("	Digite o Ano que a receita foi criada: ");
			int entradaAno = int.Parse(Console.ReadLine());
			int ano = DateTime.Now.Year;
			while (entradaAno <= 0 || entradaAno > ano)
			{
				Console.WriteLine("\n	<<<< Você precisa digitar um ano válido >>>>");
				Console.Write("\n	Digite novamente o ano que a receita foi criada: ");
				entradaAno = int.Parse(Console.ReadLine());
			}
            Console.Write("	Digite os ingredientes da receita: ");
			string entradaIngredientes = Console.ReadLine();

			Console.Write("	Digite o modo de preparo: ");
			string entradaModoPreparo = Console.ReadLine();

			Console.WriteLine("\n	<<<< Receita cadastrada com sucesso >>>>");

			Receita novaReceita = new Receita(id: repositorio.ProximoId(),
										origem: (Origem)entradaOrigem,
										nome: entradaNome,
										ano: entradaAno,
										ingredientes: entradaIngredientes,
										modoPreparo: entradaModoPreparo);

			repositorio.Insere(novaReceita);
		}
		private static void AtualizarReceita()
		{
			Console.Write("	Digite o id da receita que deseja atualizar: ");
			int indiceReceita = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Origem)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Origem), i));
			}

			Console.Write("	Digite o país de origem da receita, dentre as opção acima: ");
			int entradaOrigem = int.Parse(Console.ReadLine());
			while (entradaOrigem <= 0 || entradaOrigem > 13)
			{
				Console.WriteLine("\n	<<<< Não existe essa opção cadastrada! >>>>\n");
				Console.Write("	Digite o país de origem da receita, dentre as opção acima: ");
				entradaOrigem = int.Parse(Console.ReadLine());
			}
			Console.Write("	Digite o Nome da receita: ");
			string entradaNome = Console.ReadLine();

			Console.Write("	Digite o Ano que a receita foi criada: ");
			int entradaAno = int.Parse(Console.ReadLine());
			int ano = DateTime.Now.Year;
			while (entradaAno <= 0 || entradaAno > ano)
			{
				Console.WriteLine("\n	<<<< Você precisa digitar um ano válido >>>>");
				Console.Write("\n	Digite novamente o ano que a receita foi criada: ");
				entradaAno = int.Parse(Console.ReadLine());
			}
			Console.Write("	Digite os ingredientes da receita: ");
			string entradaIngredientes = Console.ReadLine();

			Console.Write("	Digite o modo de preparo: ");
			string entradaModoPreparo = Console.ReadLine();

			Console.WriteLine("\n	<<<< Receita atualizada com sucesso!! >>>>");

			Receita atualizaReceita = new Receita(id: repositorio.ProximoId(),
										origem: (Origem)entradaOrigem,
										nome: entradaNome,
										ano: entradaAno,
										ingredientes: entradaIngredientes,
										modoPreparo: entradaModoPreparo);
			repositorio.Atualiza(indiceReceita, atualizaReceita);
		}
		private static void ExcluirReceita()
		{
			Console.Write("	Digite o id da receita: ");
			int indiceReceita = int.Parse(Console.ReadLine());
			Console.WriteLine("\n	<<<< Receita excluida com sucesso >>>>");
			repositorio.Exclui(indiceReceita);
		}
		private static void VisualizarReceita()
		{
			Console.Write("	Digite o id da receita: ");
			int indiceReceita = int.Parse(Console.ReadLine());

			var receita = repositorio.RetornaPorId(indiceReceita);

			Console.WriteLine(receita);
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("================================================");
			Console.WriteLine("	RECEITAS DO MUNDO!!!");
			Console.WriteLine("================================================");


			Console.WriteLine("	1- Listar receita");
			Console.WriteLine("	2- Inserir nova receita");
			Console.WriteLine("	3- Atualizar receita");
			Console.WriteLine("	4- Excluir receita");
			Console.WriteLine("	5- Visualizar receita");
			Console.WriteLine("	C- Limpar Tela");
			Console.WriteLine("	X- Sair");

			Console.Write("	Informe a opção desejada: ");

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
	}
}
