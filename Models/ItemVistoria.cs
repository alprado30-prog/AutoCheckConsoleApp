namespace AutoCheckConsoleApp.Models
{
    public class ItemVistoria
    {
        public string Descricao { get; set; }
        public string Status { get; set; } // "Bom", "Regular", "Ruim"

        public ItemVistoria(string descricao, string status = "Ruim")
        {
            Descricao = descricao;
            Status = status;
        }
    }
}