namespace WebApplication10.Models
{


    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ColorDb
    {
        public List<Color> GetColors()
        {
            return new List<Color>
            {
                new Color{Id =1, Name = "Red"},
                new Color{Id =2, Name = "Green"},
                new Color{Id =3, Name = "Yellow"},
                new Color{Id =4, Name = "Blue"},
                new Color{Id =5, Name = "Orange"},

            };
        }
    }
    public class SelectDemoPostViewModel
    {
        public string Color { get; set; }
    }
}
