using System.ComponentModel.DataAnnotations;

namespace TestMonopoly
{
    public abstract class StorageItem
    {
        public int ID { get; set; }
        private float volume;
        private float width;
        private float height;
        private float depth;
        private float weight;


        public float Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение объема не может быть меньше нуля");
                }
                else
                {
                    volume = value;
                }
            }
        }
        public float Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение ширины не может быть меньше нуля");
                }
                else
                {
                    width = value;
                }
            }
        }
        public float Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение высоты не может быть меньше нуля");
                }
                else
                {
                    height = value;
                }
            }
        }
        public float Depth
        {
            get
            {
                return depth;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение глубины не может быть меньше нуля");
                }
                else
                {
                    depth = value;
                }
            }
        }
        public float Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Значение веса не может быть меньше нуля");
                }
                else
                {
                    weight = value;
                }
            }
        }
        protected abstract void CalculateVolume();
    }
}
