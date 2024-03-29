using System.ComponentModel.Design;

namespace ProjetoBancoConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
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
                        Cliente novoCliente = new Cliente();
                        Console.WriteLine(@"CADASTRO DE CONTA
Para realizar o seu cadastro informe abaixo os seus seguintes dados: ");
                        //CPF

                        do
                        {
                            Console.Write("CPF: ");
                            novoCliente.Cpf = Console.ReadLine();
                            bool cpfValido = novoCliente.ValidarCpf();

                            if(!cpfValido)
                            {
                                Console.WriteLine("O número de CPF deve conter 11 dígitos, sem caracteres especiais.");

                            }
                        } 
                        while (!novoCliente.ValidarCpf());

                        //NOME
                        Console.Write("Nome completo: ");
                        novoCliente.Nome = Console.ReadLine();
                        string sobrenome = novoCliente.Nome.Split(' ').Last();

                        //TIPO CONTA
                        Console.Write("Tipo da conta (0 - CORRENTE / 1 - POUPANÇA): ");
                        int tipo = int.Parse(Console.ReadLine());
                        if (tipo == 0)
                        {
                            novoCliente.Conta = new ContaCorrente(TipoConta.Corrente);
                            
                        }
                        else if (tipo == 1)
                        {
                            novoCliente.Conta = new ContaPoupanca(TipoConta.Poupanca);
                            
                            
                        }
                        while (tipo !=0 && tipo != 1)
                        {
                            Console.WriteLine("Valor inválido, digite novamente.");
                            tipo = int.Parse(Console.ReadLine());
                        }

                        //TIPO CLIENTE
                        novoCliente.TiparCliente();

                        novoCliente.Conta.GerarNumeroDaConta();

                        clientes.Add(novoCliente);

                        Console.WriteLine($@"Conta cadastrada com sucesso.
Sr.(a) {sobrenome}, o Banco Console agradece a preferência.

Número da conta: {novoCliente.Conta.Numero}");                        
                        break;
                    case "2":
                        Console.Write("Digite o número da conta de origem: ");
                        string numContaOrigem = Console.ReadLine();

                        Console.Write("Digite o número da conta de destino: ");
                        string numContaDestino = Console.ReadLine();

                        Console.Write("Digite a quantia a ser transferida: ");
                        decimal quantia = decimal.Parse(Console.ReadLine());

                        //Retorna o primeiro elemento de uma lista que preencha condições específicas.
                        //Busca na lista de clientes pelo cliente que possui o número de conta fornecido (numContaOrigem) e atribui esse cliente à variável clienteOrigem.
                        Cliente clienteOrigem = clientes.FirstOrDefault(c => c.Conta.Numero == numContaOrigem);

                        if (clienteOrigem != null)
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

                        Cliente clienteDestino = clientes.FirstOrDefault(c => c.Conta.Numero == numContaDestino);
                        if (clienteDestino != null)
                        {
                            clienteDestino.Conta.Depositar(quantia);
                        }
                        else
                        {
                            Console.WriteLine("Conta de origem ou destino não encontrada.");
                        }
                        break;
                    case "4":
                        Console.Write("Digite o número da conta: ");
                        string numConta = Console.ReadLine();

                        Cliente clienteConsulta = clientes.FirstOrDefault(c => c.Conta.Numero == numConta);

                        if (clienteConsulta != null)
                        {
                            clienteConsulta.ConsultarSaldo();
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Sistema finalizado.");
                        return;
                    default:
                        Console.WriteLine("Erro! Digite uma opção válida.");
                        break;


                }            
            }
        }

        
    }
}
