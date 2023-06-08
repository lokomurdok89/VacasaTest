using API.Application.Core;

namespace API.Utils
{
    public class Utils : IUtils
    {
        private readonly ILogger<Utils> _logger;
        readonly Combinations _comb;


        public Utils(ILogger<Utils> logger)
        {
            _logger = logger;
            _comb = new Combinations();
        }

        public string GetRandomAnswer(string q)
        {
            return RandomResponse.GenerateRandomResponse(q);
        }

        public bool ValidateSumFormat(string q)
        {
            return SimplePlus.ValidateSumFormat(q);
        }

        public string GenerateSimplePlus(string q)
        {
            return SimplePlus.GenerateSimplePlus(q);
        }
        public string CountNumberOfWords(string q)
        {
            return NumberWord.CountNumberOfWords(q);
        }

        public bool ValidateCountNumberOfWords(string q)
        {
            return NumberWord.ValidateCountNumberOfWords(q);
        }

        public bool ValidateListFormatCombination(string q)
        {
            return Combinations.ValidateListFormatCombination(q);
        }

        public string GenerateOutputList(string q)
        {
            return _comb.GenerateOutputList(q);
        }  


#region displaying these in a 2-D grid
        public bool Validate2D(string q){

            return q.Contains("ABCDE");
        }
        public string VisualizeCharacters2D(string formato)
        {
           // q = q.Replace(" ","").Replace("ABCDE","");
                   int n = (int)Math.Sqrt(formato.Length);
            char[,] matriz = new char[n, n];

            int index = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matriz[i, j] = formato[index];
                    index++;
                }
            }

            List<char> orden = new();
            List<char> antes = new();
            List<char> despues = new();

            for (int i = 0; i < n; i++)
            {
                bool antesDeTodos = true;
                bool despuesDeTodos = true;

                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        if (matriz[j, i] == '<' || matriz[j, i] == '-')
                        {
                            antesDeTodos = false;
                        }
                        if (matriz[j, i] == '>' || matriz[j, i] == '-')
                        {
                            despuesDeTodos = false;
                        }
                    }
                }

                if (antesDeTodos)
                {
                    antes.Add((char)(i + 'A'));
                }
                else if (despuesDeTodos)
                {
                    despues.Add((char)(i + 'A'));
                }
            }

            for (int i = 0; i < antes.Count; i++)
            {
                orden.Add(antes[i]);
            }
            for (int i = despues.Count - 1; i >= 0; i--)
            {
                orden.Add(despues[i]);
            }

            return string.Join("", orden);
        }

        public static string ObtenerOrden(char[,] matriz)
        {
            int n = matriz.GetLength(0);
            List<char> orden = new();

            bool[] visitado = new bool[n];

            for (int i = 0; i < n; i++)
            {
                if (!visitado[i])
                {
                    VisitarNodo(i, matriz, visitado, orden);
                }
            }

            return string.Join("", orden);
        }
        static void VisitarNodo(int nodo, char[,] matriz, bool[] visitado, List<char> orden)
        {
            int n = matriz.GetLength(0);

            visitado[nodo] = true;

            for (int j = 0; j < n; j++)
            {
                if (matriz[nodo, j] == '<' && !visitado[j])
                {
                    VisitarNodo(j, matriz, visitado, orden);
                }
            }

            orden.Insert(0, (char)(nodo + 'A'));

            for (int j = 0; j < n; j++)
            {
                if (matriz[nodo, j] == '>' && !visitado[j])
                {
                    VisitarNodo(j, matriz, visitado, orden);
                }
            }
        }       
#endregion
    }
}