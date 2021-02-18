using System;

namespace bank
{
    public class Conta
    {
        // Atributos
        private TipoConta TipoConta {get; set; }

        public double Saldo {get; set;}

        private double Credito {get; set; }

        private string Nome {get; set;}

        // Contrutor... Metodo que será chamado no momento que será instanciada
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome){
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            
        }

        public bool Sacar(double valorSaque){
            // Validaçao de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            return true;
        }
        public void Depositar(double valorDeposito){
            this.Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }
        public void Transferir(double valorDaTranferencia, Conta contaDestino){
             if (this.Sacar (valorDaTranferencia)){
                contaDestino.Depositar(valorDaTranferencia);
            }
            this.Saldo -= valorDaTranferencia;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
        }
        
        // sobrescreve os dados que estao na classe mae
        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta: " + this.TipoConta + " | ";
            retorno += "Nome: " + this.Nome + " | ";
            retorno += "Saldo: " + this.Saldo + " | ";
            retorno += "Crédito: " + this.Credito;
            return retorno;
        }
    }
}