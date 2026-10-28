using System.Text.Json;
using System.Text.Json.Serialization;

namespace buscador_cep
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(" Buscador de Endereço via CEP ");
            Console.WriteLine("------------------------------\n");

            Console.Write("Digite um CEP (apenas números, exemplo: 86010000): ");

            string? cep = Console.ReadLine();

            // verifica se está vazio, se tem 8 caracteres e se contém APENAS números
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8 || !cep.All(char.IsDigit))
            {
                Console.WriteLine("CEP inválido! O CEP deve conter exatamente 8 dígitos numéricos (sem letras ou traço)");
                return;
            }

            using HttpClient client = new HttpClient();
            string url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                Console.WriteLine("\nConsultando a API do ViaCEP. Aguarde um momento...");
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();

                    Endereco? endereco = JsonSerializer.Deserialize<Endereco>(jsonString);

                    if (endereco != null && !endereco.Erro)
                    {
                        Console.WriteLine("\n--- ENDEREÇO ENCONTRADO ---");
                        Console.WriteLine($"Logradouro: {endereco.Logradouro}");
                        Console.WriteLine($"Bairro: {endereco.Bairro}");
                        Console.WriteLine($"Cidade: {endereco.Localidade}");
                        Console.WriteLine($"Estado: {endereco.Uf}");
                        Console.WriteLine($"DDD: {endereco.Ddd}");
                        Console.WriteLine("---------------------------");
                    }
                    else
                    {
                        Console.WriteLine("\n[AVISO]: CEP não encontrado na base de dados nacional.");
                    }

                }
                else
                {
                    Console.WriteLine($"\n[ERRO]: Erro na requisição. Código HTTP: {response.StatusCode}");
                }
   
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\n[ERRO]: Falha ao conectar com o serviço: {ex.Message}");
            }
        }


    }

    public class Endereco
    {
        [JsonPropertyName("cep")] 
        public string? Cep { get; set; }

        [JsonPropertyName("logradouro")]
        public string? Logradouro { get; set; }

        [JsonPropertyName("bairro")]
        public string? Bairro { get; set; }

        [JsonPropertyName("localidade")]
        public string? Localidade { get; set; }

        [JsonPropertyName("uf")]
        public string? Uf { get; set; }

        [JsonPropertyName("ddd")]
        public string? Ddd { get; set; }

        [JsonPropertyName("erro")]
        public bool Erro { get; set; }
    }
}