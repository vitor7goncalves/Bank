using System;
using System.Collections.Generic;

namespace bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListaConta();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            System.Console.WriteLine("Obrigado por usar nossos serviços.");
            System.Console.WriteLine();
        }

        private static void ListaConta()
        {
           System.Console.WriteLine("Listar contas");
           if(listContas.Count == 0){
               System.Console.WriteLine("Nenhuma conta cadastrada");
               return;
               //Ao inves de um else foi usado um return
           }

           for(int i= 0; i < listContas.Count; i++){
               Conta conta = listContas[i];
               Console.Write("#{0} - ",i );
               System.Console.WriteLine(conta);
           }
        }

        private static void InserirConta()
        {
            System.Console.WriteLine("Inserir nova conta");

            System.Console.WriteLine("Digite 1 para Conta Fisica ou 2 para conta Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
            saldo: entradaSaldo,
            credito: entradaCredito,
            nome: entradaNome);
            
            listContas.Add(novaConta);

        }
           private static void Transferir()
        {
            System.Console.WriteLine("Digite o número da conta de origem");
            int indiceContaOrirem = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o número da conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser transferido");
            double valorTranferencia = double.Parse(Console.ReadLine());
            
            listContas[indiceContaOrirem].Transferir(valorTranferencia, listContas[indiceContaDestino]);
        }
         private static void Sacar()
        {
            System.Console.WriteLine("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser sacado");
            double valorSaque = double.Parse(Console.ReadLine());
            
            listContas[indiceConta].Sacar(valorSaque);
        }

          private static void Depositar()
        {
            System.Console.WriteLine("Digite o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Digite o valor a ser depositado");
            double valorDeposito = double.Parse(Console.ReadLine());
            
            listContas[indiceConta].Depositar(valorDeposito);
        }
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Your Bank");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
