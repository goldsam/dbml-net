namespace Dbml.Model
{
    public class Token
    {
        public TokenPosition Start { get; }
        public TokenPosition End { get; }

        public Token(TokenPosition start, TokenPosition end)
        {
            Start = start;
            End = end;
        }
    }
}
