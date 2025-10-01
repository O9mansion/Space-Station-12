namespace Content.Server.NameSpaces
{
    public class Component
    {
        public string Name { get; set; }
        public List<(string SubValueName, object Value)> Values { get; set; } = new List<(string, object)>();
    }
    
    public class Entity
    {
        public int Id { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public short Zindex { get; set; } // Zindex to say what sould rener over it. from -255 to 255
        public string Type { get; set; }
        public string Name { get; set; }
        public List<Component> Components { get; set; } = new List<Component>(); // Can be anything, settings gor a object or just saying like its on fire or something        
    }
}