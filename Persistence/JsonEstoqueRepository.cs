using System;
using InventorySystem.Models;
using System.Text.Json;

namespace InventorySystem.Persistence
{
    public class JsonEstoqueRepository
    {
        private const string _caminho = "Data/estoque.json";
        public static void JsonSerializer(GestaoEstoque estoque)
        {
            _garantirDiretorio();
            string json = System.Text.Json.JsonSerializer.Serialize(estoque.ItensEstoque);
            File.WriteAllText(_caminho, json);
        }

        public static List<Estoque>? JsonDeserialize()
        {
            _garantirDiretorio();
            string json = File.ReadAllText(_caminho);
            return System.Text.Json.JsonSerializer.Deserialize<List<Estoque>>(json);
        }

        private static void _garantirDiretorio()
        {
            if (!File.Exists("Data/estoque.json") || !Directory.Exists("Data/"))
            {
                Directory.CreateDirectory("Data/");
                File.WriteAllText("Data/estoque.json", "[]");
            }
        }
    }
}
