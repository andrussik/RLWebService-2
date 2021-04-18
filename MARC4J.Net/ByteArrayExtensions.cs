using System.Linq;

namespace MARC4J.Net
{
    public static class ByteArrayExtensions
    {
        public static string ConvertToString(this byte[] bytes)
        {
            return new string(bytes.Select(a => (char)a).ToArray());
        }
    }
}
