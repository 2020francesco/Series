using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    ListarSeries();
                    break;
                    case "2":
                    Inserirserie();
                    break;
                    case "3":
                    AtualizarSerie();
                    break;
                    case "4":
                    ExcluirSerie();
                    break;
                    case "5":
                    VisualizarSerie();
                    break;
                    case "C":
                    Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos servicos.");
            Console.ReadLine();
            
        }

       


        private static void ListarSeries()
        {
            Console.WriteLine("Listar series");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada.");
                return;
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: . {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }



        private static void Inserirserie()
        {
            Console.WriteLine("Inserir nova serie");

            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore.3.1
            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore.3.1
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opcoes acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie:");
            string entradatitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descricao da Serie:");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradatitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

         private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore.3.1
            //https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore.3.1
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o genero entre as opcoes acima:");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o titulo da serie:");
            string entradatitulo = Console.ReadLine();

            Console.Write("Digite o Ano de Inicio da Serie:");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descricao da Serie:");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradatitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Series a seu dispor!!!");
            Console.WriteLine("Informe a opcão desejada:");

            Console.WriteLine("1- Listar series");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;

        }
    }
}
