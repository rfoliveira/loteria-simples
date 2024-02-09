namespace LoteriaSimples
{
    public class Aposta
    {
        private readonly List<int> _numeros = new List<int>();
        private const string SEPARADOR_RESULTADO = "-";
        private readonly int id;
        private readonly int qtdNumeros;
        private readonly int nroMaximo;

        public string Resultado => string.Join(SEPARADOR_RESULTADO, _numeros.OrderBy(x => x).ToArray());
        public int[] NumerosSorteados => _numeros.ToArray();

        public Aposta(int id, int qtdNumeros, int nroMaximo)
        {
            this.id = id;
            this.qtdNumeros = qtdNumeros;
            this.nroMaximo = nroMaximo;
        }

        public Aposta Gerar(int[] numerosSorteados)
        {
            var rnd = new Random();

            while (_numeros.Count != qtdNumeros)
            {
                var numero = rnd.Next(1, nroMaximo);

                if (!numerosSorteados.Contains(numero) && !_numeros.Any(num => num == numero))
                    _numeros.Add(numero);
            }

            return this;
        }        
    }
}