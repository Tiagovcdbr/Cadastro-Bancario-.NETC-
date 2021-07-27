using System;
using System.Collections.Generic;

namespace APP.Bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "x")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InseirConta();
                        break;
                    case "3":
                        //Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        //Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                        default:
                        throw new ArgumentOutOfRangeException();                
                }
                OpcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nosso serviços");
        Console.ReadLine();
        }
        private static void Depositar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
		}
        private static void Sacar()
		{
			Console.Write("Digite o número da conta: ");
			int indiceConta = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser sacado: ");
			double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
		}

        private static void Transferir()
		{
			Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
		}

        private static void InseirConta()
        {
            Console.Write("Digite 1 para conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente; ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entraSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito; ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                    saldo: entraSaldo,
                    credito: entradaCredito,
                    nome: entradaNome);

            listContas.Add(novaConta);        

        }

        private static void ListarContas()
		{
			Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
		}

        private static string ObterOpcaoUsuario()
        
        {
            Console.WriteLine();
            Console.WriteLine("APP Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Contas");                  
            Console.WriteLine("2- Inserir Nova Conta");                  
            Console.WriteLine("3- Transferir");                  
            Console.WriteLine("4- Sacar");                  
            Console.WriteLine("5- Depositar");                  
            Console.WriteLine("C- Limpar");                  
            Console.WriteLine("X- Sair");                  
            Console.WriteLine(); 

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;                 
            
        }
    }
}
