using System;
using MARC4J.Net.Converter;
using MARC4J.Net.MARC;

namespace MARC4J.Net
{
    /// <summary>
    /// Implement this interface to provide a writer for <code>Record</code> objects.
    /// </summary>
    public interface IMarcWriter : IDisposable
    {
        /// <summary>
        /// Writes a single <code>Record</code> to the output stream.
        /// </summary>
        /// <param name="record"></param>
        void Write(IRecord record);

		/// <summary>
        /// Gets and Sets the character converter.
		/// </summary>
        CharConverter Converter { get; set; }
        
        /// <summary>
        /// Closes the writer.
        /// </summary>
        void Close();
    }
}