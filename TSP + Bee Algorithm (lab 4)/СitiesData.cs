using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПА_Лаб._4
{
    public class CitiesData
    {
        private readonly int[,] _weightMatrix;

        public CitiesData(int[,] weightMatrix)
        {
            _weightMatrix = weightMatrix;
        }

        public int[,] WeightMatrix => (int[,])_weightMatrix.Clone();
        public int Dimension => _weightMatrix.GetLength(0);
        public int GetWeight(int i, int j) => _weightMatrix[i, j];
    }
}
