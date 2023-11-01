using System;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 00;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            if (placa.Length != 7)
            {
                Console.WriteLine("Placa Inválida");
            }
            else
            {
                bool valida = ValidarPlaca(placa);
                if (valida)
                {
                    if (VerficaPlacaEstaCadastrada(placa))
                    {
                        Console.WriteLine("Não foi possível cadastrar, placa já cadastrada no sistema.");
                    }
                    else
                    {
                        Console.WriteLine("Cadastro Realizado com Sucesso");
                        veiculos.Add(placa);
                    }
                }
                else
                {
                    Console.WriteLine("Placa Inválida");
                }
            }
        }

        public static bool ValidarPlaca(string placa)
        {
            // Padrão da placa no formato "AAA1234" ou "AAA1A34"
            string pattern = @"^[A-Z]{3}\d{4}$|^[A-Z]{3}\d[A-Z]\d{2}$";
            RegexOptions options = RegexOptions.IgnoreCase;
            bool isValid = Regex.IsMatch(placa, pattern, options);
            return isValid;
        }
        public bool VerficaPlacaEstaCadastrada(string placa)
        {
            HashSet<string> placasCadastradas = new HashSet<string>();
            foreach (string veiculo in veiculos)
            {
                placasCadastradas.Add(veiculo);
            }

            string placaParaVerificar = placa;
            if (placasCadastradas.Contains(placaParaVerificar))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void RemoverVeiculo()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Digite a placa do veículo para remover:");
                string placa = Console.ReadLine().ToUpper();

                if (placa.Length != 7)
                {
                    Console.WriteLine("Placa inválida");
                }
                else
                {
                    bool valida = ValidarPlaca(placa);
                    if (valida)
                    {
                        if (VerficaPlacaEstaCadastrada(placa))
                        {
                            int horas;
                            Console.WriteLine("Quantas horas o veículo ficou estacionado?");
                            while (!int.TryParse(Console.ReadLine(), out horas))
                            {
                                Console.WriteLine("Entrada inválida. Certifique-se de digitar um número inteiro.");
                            }
                            decimal valorTotal = (precoInicial + (precoPorHora * horas));
                            Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal.ToString("N2")}");
                            veiculos.Remove(placa);
                        }
                        else
                        {
                            Console.WriteLine("Veículo não cadastrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Placa Inválida");
                    }

                }

            }
            else
            {
                Console.WriteLine("Não existem veículos cadastrados.");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
