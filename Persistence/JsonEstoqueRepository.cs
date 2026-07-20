using System;
using InventorySystem.Models;
using System.Text.Json;

namespace InventorySystem.Persistence
{
    public class JsonEstoqueRepository
    {
        private const string _caminho = "data/biblioteca.json";
        public static void JsonSerializer(GestaoEstoque estoque)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(estoque.ItensEstoque);
            File.WriteAllText(_caminho, json);
        }

        public static List<Estoque>? JsonDeserialize()
        {
            string json = File.ReadAllText(_caminho);
            return System.Text.Json.JsonSerializer.Deserialize<List<Estoque>>(json);
        }
    }
}
