using System;
namespace Star_3_Figure
{
    [Serializable]
    public class Rectangle : Figure
    {
        private double width;
        private double height;
        public string Width { get => width.ToString(); set => width = Convert_Double(value); }

        public string Height { get => height.ToString(); set => height = Convert_Double(value); }

        public Rectangle() : base() => Width = Height = "10";
        
        public Rectangle(string name, DateTime create_date, double W, double H) : base(name, create_date)
        {
            Width = W.ToString();
            Height = H.ToString();
            Area = (width * height).ToString();
        }
        
        public override string ToString() => string.Join("", base.ToString(), "\nWirth: ", Width, " sm", "\nHeight: ", Height, " sm");

        public override void Display() => Console.WriteLine(this);

        public override void SetNewInfo(bool brand_new = true)
        {
            if (brand_new == true)
                base.SetNewInfo();
            try
            {
                Console.Write("Enter properties of a rectangle:\nWidth: ");
                Width = Convert_Double(Console.ReadLine()).ToString();
                Console.Write("Height: ");
                Height = Convert_Double(Console.ReadLine()).ToString();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Area = (width * height).ToString();
        }

        public override string GetShape() => "rectangle";
        
        public static Rectangle ConvertToRectangle(Figure figure)
        {
            Rectangle r = new()
            {
                Name = figure.Name,
                Create_date = figure.Create_date
            };
            return r;
        }

    }
}
