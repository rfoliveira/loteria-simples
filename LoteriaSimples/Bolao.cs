namespace LoteriaSimples
{
    public class Bolao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public List<Pessoa> Pessoas { get; set; } = default!;
        public List<Aposta> Apostas { get; set; } = default!;
    }
}
