﻿namespace ProjetoBancoConsole
{
    public enum TipoCliente
    {
        Comum = 0,
        Super = 1,
        Premium = 2
    }

    public class Cliente
    {
        private static int _proximoIdCliente = 1;
        private int _id;
        private string _cpf;
        private string _nome;
        private DateTime _dataDeNascimento;
        private TipoCliente _tipo;
        private Conta _conta;

        public int Id { get { return _id; } set { _id = value; } }
        public string Cpf { get { return _cpf; } set { _cpf = value; } }
        public string Nome { get { return _nome; } set { _nome = value; } }
        public DateTime DataDeNascimento { get { return _dataDeNascimento; } set { _dataDeNascimento = value; } }
        public TipoCliente Tipo { get { return _tipo; } set { _tipo = value; } }
        public Conta Conta { get { return _conta; } set { _conta = value; } }

        public Cliente(string cpf, string nome, DateTime dataDeNascimento)
        {
            Id = _proximoIdCliente++;
            Cpf = cpf;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
        }

        public Cliente()
        {
            
        }


        public bool ValidarCpf()
        {
            
            Cpf = Cpf.Replace(" ", "");

            if (Cpf.Length != 11 || !Cpf.All(char.IsDigit))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public TipoCliente TiparCliente()
        {
            if (Conta.Saldo == 15000.00m)
            {
                return TipoCliente.Super;
            }
            else if (Conta.Saldo >= 5.000m || Conta.Saldo <= 14999.00m)
            {
                return TipoCliente.Premium;
            }
            else
            {
                return TipoCliente.Comum;
            }
        }

        public void ConsultarSaldo()
        {
            Console.Write("Digite o número da conta: ");
            string numC = Console.ReadLine();
            if (numC == Conta.Numero)
            {
                Console.WriteLine(@$"DADOS DO CLIENTE:
Nome: {Nome}
Tipo: {Tipo}");
                Console.WriteLine(@$"DADOS DA CONTA:
Número: {Conta.Numero}
Saldo: {Conta.Saldo}
Tipo: {Conta.TipoConta}");
            }
        }

    }
}
