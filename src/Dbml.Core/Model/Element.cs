namespace Dbml.Model
{
    /// <summary>
    /// Based class implemented by all DBML model components.
    /// </summary>
    public abstract class Element
    {
        /// <summary>
        /// Location of this token in the DMBL source. 
        /// </summary>
        /// <remarks>
        /// This property is typically only set when the model was created
        /// from parsing of a DBML source file.
        /// </remarks>
        public Token? Token { get; set; }
    }
}