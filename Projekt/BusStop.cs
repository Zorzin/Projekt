namespace Projekt
{
    internal class BusStop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public BusStop(int id, string name, int area)
        {
            Id = id;
            Name = name;
            Area = area;
        }
    }
}