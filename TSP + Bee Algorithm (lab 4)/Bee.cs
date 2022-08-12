using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПА_Лаб._4
{
    public class Bee
    {
        public BeeStatus Status { get; set; }
        public int Value { get; set; }
        public int NumberOfVisit { get; set; }
        private List<int> _traversalOrder;

        public Bee(List<int> traversalOrder, BeeStatus status, int value, int numberOfVisit)
        {
            _traversalOrder = traversalOrder;
            Status = status;
            Value = value;
            NumberOfVisit = numberOfVisit;
        }

        public List<int> LocationOfFlowerPatch
        {
            get => new List<int>(_traversalOrder);
            set => _traversalOrder = new List<int>(value);
        }

        public enum BeeStatus
        {
            Active,
            Inactive,
            Scout
        }
    }
}
