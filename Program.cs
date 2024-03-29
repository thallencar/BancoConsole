using System.ComponentModel.Design;

namespace ProjetoBancoConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();
            List<Cliente> novoCliente = new List<Cliente>();
            List<Cliente> clientes = new List<Cliente>();

            ContaPoupanca cp = new ContaPoupanca();
            ContaCorrente cc = new ContaCorrente();

            while (true)
            {
                Console.Write(@"----- $ BANCO CONSOLE $ -----

1. Cadastrar nova Conta
2. Transferir Dinheiro
3. Depositar Dinheiro
4. Consultar Saldo

5. Sair

-> ");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.WriteLine(@"CADASTRO DE CONTA
Para realizar o seu cadastro informe abaixo os seus seguintes dados: ");
                        //CPF

                        do
                        {
                            Console.Write("CPF: ");
                            cliente.Cpf = Console.ReadLine();
                            bool cpfValido = cliente.ValidarCpf();

                            if(!cpfValido)
                            {
                                Console.WriteLine("O número de CPF deve conter 11 dígitos, sem caracteres especiais.");

                            }
                        } 
                        while (!cliente.ValidarCpf());

                        //NOME
                        Console.Write("Nome completo: ");
                        cliente.Nome = Console.ReadLine();
                        string sobrenome = cliente.Nome.Split(' ').Last();

                        //TIPO CONTA
                        Console.Write("Tipo da conta (0 - CORRENTE / 1 - POUPANÇA): ");
                        int tipo = int.Parse(Console.ReadLine());
                        if (tipo == 0)
                        {
                            cliente.Conta = new ContaCorrente(TipoConta.Corrente);
                            
                        }
                        else if (tipo == 1)
                        {
                            cliente.Conta = new ContaPoupanca(TipoConta.Poupanca);
                            
                            
                        }
                        while (tipo !=0 && tipo != 1)
                        {
                            Console.WriteLine("Valor inválido, digite novamente.");
                            tipo = int.Parse(Console.ReadLine());
                        }

                        //TIPO CLIENTE
                        cliente.TiparCliente();

                        cliente.Conta.GerarNumeroDaConta();

                        novoCliente.Add(cliente);

                        Console.WriteLine($@"Conta cadastrada com sucesso.
Sr.(a) {sobrenome}, o Banco Console agradece a preferência.

Número da conta: {cliente.Conta.Numero}");                        
                        break;
                    case "2":
                        Console.Write("Digite o número da conta de origem: ");
                        string numContaOrigem = Console.ReadLine();

                        Console.Write("Digite o número da conta de destino: ");
                        string numContaDestino = Console.ReadLine();

                        Console.Write("Digite a quantia a ser transferida: ");
                        decimal quantia = decimal.Parse(Console.ReadLine());

                        Cliente clienteOrigem = clientes.FirstOrDefault(c => c.Conta.Numero == numContaOrigem);
                        Cliente clienteDestino = clientes.FirstOrDefault(c => c.Conta.Numero == numContaDestino);

                        if (clienteOrigem != null && clienteDestino != null)
                        {
                            clienteOrigem.Conta.Transferir(quantia);
                        }
                        else
                        {
                            Console.WriteLine("Conta de origem ou destino não encontrada.");
                        }
                        break;
                    case "3":
                        Console.Write("Digite o número da conta de origem: ");
                        numContaOrigem = Console.ReadLine();

                        Console.Write("Digite o número da conta de destino: ");
                        numContaDestino = Console.ReadLine();

                        Console.Write("Digite a quantia a ser depositada: ");
                        quantia = decimal.Parse(Console.ReadLine());

                        clienteOrigem = clientes.FirstOrDefault(c => c.Conta.Numero == numContaOrigem);
                        clienteDestino = clientes.FirstOrDefault(c => c.Conta.Numero == numContaDestino);

                        if (clienteOrigem != null && clienteDestino != null)
                        {
                            clienteOrigem.Conta.Depositar(quantia);
                        }
                        else
                        {
                            Console.WriteLine("Conta de origem ou destino não encontrada.");
                        }
                        break;
                    case "4":
                        cliente.ConsultarSaldo();
                        break;
                    case "5":
                        Console.WriteLine("Sistema finalizado.");
                        break;
                    default:
                        Console.WriteLine("Erro! Digite uma opção válida.");
                        break;

                }
            }
        }

        
    }
}
