using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Application.Core
{
    public class Combinations
    {
        public Combinations()
        {
            
        }
        public static bool ValidateListFormatCombination(string q)
        {
            q = q.Trim();
            if (q.StartsWith("<") && q.EndsWith(">"))
            {
                string content = q[1..^1].Trim();
                string[] parts = content.Split(' ');

                foreach (string part in parts)
                {
                    if (!int.TryParse(part, out _))
                        return false;
                }

                return true;
            }

            return false;
        }
        public static List<int> ConvertToList(string q)
        {
            string content = q.Trim().Substring(1, q.Length - 2);
            string[] parts = content.Split(' ');
            List<int> numbers = new();

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    numbers.Add(number);
                }
            }
            return numbers;
        }

        public string GenerateOutputList(string q)
        {
            List<int> numbers = ConvertToList(q);
            List<List<int>> result = new();
            List<string[]> combinations = GenerateCombinations(numbers);
            combinations = DeleteListRepeat(combinations);	

            foreach (string[] combinacion in combinations)
            {
                var sorted = SortList(combinacion);
                var cantidad = PlusElement(sorted,numbers);			
                if(numbers.Sum() == cantidad.Sum()){
                    result.Add(cantidad);
                }
            }
            return(string.Join(" ",FindListWithSmallestDifference(result)));
        }


        private List<string[]> GenerateCombinations(List<int> lista)
        {
            List<string[]> combinaciones = new();
            GenerateCombinationRecursive(lista, new string[5], 0, 0, combinaciones);
            return combinaciones;
        }

        private void GenerateCombinationRecursive(List<int> lista, string[] combinacion, int index, int start, List<string[]> combinaciones)
        {
            
            if (index == combinacion.Length)
            {
                combinaciones.Add(combinacion);
                return;
            }

            for (int i = start; i < lista.Count; i++)
            {
                for (int j = i + 1; j < lista.Count; j++)
                {
                    if (!FindStringEnArray(lista[i].ToString(),combinacion,lista) &&  !FindStringEnArray(lista[j].ToString(),combinacion,lista))
                    {	
                        string[] nuevaCombinacion = (string[])combinacion.Clone();
                        nuevaCombinacion[index] = lista[i].ToString() + "+" +lista[j].ToString();
                        GenerateCombinationRecursive(lista, nuevaCombinacion, index + 1, i + 1, combinaciones);
                    }
                }
            }
        }
		
		private static bool FindStringEnArray(string textoBuscado, string[] array,List<int> lista)
		{
			if (array == null || array.Length == 0)
			{
				return false;
			}
			
			int cantMaxRepeat = lista.FindAll(x => x.Equals(Int32.Parse(textoBuscado))).Count;			
			int cant = 0;
			foreach (string elemento in array)
			{
				if (!string.IsNullOrEmpty(elemento))
				{
					string[] numeros = elemento.Split('+');
                    _ = int.TryParse(numeros[0], out int numero1);
                    _ = int.TryParse(numeros[1], out int numero2);
                    _ = int.TryParse(textoBuscado, out int numero3);
					if(numero1.Equals(numero3)||numero2.Equals(numero3))cant++;
					//return true;
				}
			}
			//Console.WriteLine(cant.ToString(),cantMaxRepeat.ToString() );
			if(cant >= cantMaxRepeat) return true;
			return false;
		}

		private static List<int> PlusElement(string[] array, List<int> elemen)
		{
			List<int> result = new();
			foreach (string elemento in array)
			{
				string[] numeros = elemento.Split('+');
                if (numeros.Length == 2 && int.TryParse(numeros[0], out int numero1) && int.TryParse(numeros[1], out int numero2))
                {
                    if ((numero1 % 2 == 0 && numero2 % 2 != 0) || (numero2 % 2 == 0 && numero1 % 2 != 0))
                    {                        
                        result.Add(numero1 + numero2);                        
                    }
                }
            }			
			return result;
		}
		
		private static List<string[]> DeleteListRepeat(List<string[]> listOfList)
		{
			List<string[]> listWithOutRepeat = new();
			foreach (string[] listaActual in listOfList)
			{
				bool isRepeat = false;
				foreach (string[] listaExistente in listWithOutRepeat)
				{
					if (IfLisIquals(listaActual, listaExistente))
					{
						isRepeat = true;
						break;
					}
				}
				if (!isRepeat)
				{
					listWithOutRepeat.Add(listaActual);
				}
			}

			return listWithOutRepeat;
		}
		
		private static bool IfLisIquals(string[] lista1, string[] lista2)
		{
			if (lista1.Length != lista2.Length)
				return false;

			for (int i = 0; i < lista1.Length; i++)
			{
				if (lista1[i] != lista2[i])
					return false;
			}
			return true;
		}

        public static List<int> FindListWithSmallestDifference(List<List<int>> listOfLists)
		{
			List<int> smallestDifferenceList = null;
			int smallestDifference = int.MaxValue;

			foreach (List<int> list in listOfLists)
			{
				int min = list.Min();
				int max = list.Max();
				int difference = max - min;

				if (difference < smallestDifference)
				{
					smallestDifference = difference;
					smallestDifferenceList = list;
				}
			}

			return smallestDifferenceList;
		}
		
		public static string[] SortList(string[] list)
		{
			List<int> parNums = new();
			List<int> imparNums = new();

			foreach (string element in list)
			{
				string[] numbers = element.Split('+');

                if (int.TryParse(numbers[0], out int number1) && int.TryParse(numbers[1], out int number2))
                {
                    if (number1 % 2 == 0)
                    {
                        parNums.Add(number1);
                        imparNums.Add(number2);
                    }
                    else
                    {
                        imparNums.Add(number1);
                        parNums.Add(number2);
                    }
                }

            }

			if (parNums.Sum() > imparNums.Sum())
			{
				return list.OrderByDescending(expression =>
				{
					string[] parts = expression.Split('+');
					if(int.Parse(parts[0])%2==0) return int.Parse(parts[0]);
					return int.Parse(parts[1]);

				}).ToArray();
			}
			else
			{
				return list.OrderBy(expression =>
				{
					string[] parts = expression.Split('+');
					if(int.Parse(parts[0])%2!=0) return int.Parse(parts[0]);
					return int.Parse(parts[1]);

				}).ToArray();
			}
		}
    }
}