using System.Dynamic;

namespace d00
{
    public class Starage
    {
        public int quintity { get; set; }
        public Starage(int quintity)
        {
            this.quintity = quintity;
        }

        public bool isEmpty() => quintity == 0; 
    }
}