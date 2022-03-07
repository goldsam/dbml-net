namespace Dbml.Model
{
    public struct TokenPosition
    {
        public int Column { get; }
        
        public int Line { get; }

        public int Offset { get; }
    }
}
