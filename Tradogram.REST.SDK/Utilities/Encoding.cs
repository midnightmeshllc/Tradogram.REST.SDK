using Microsoft.Extensions.Configuration;

namespace Tradogram.REST.SDK.Utilities
{
    public class Encoding()
    {
        /// <summary>
        /// Converts the given organization token to a Base64 encoded string for use in the Authorization header of API requests.
        /// </summary>
        /// <param name="orgToken"></param>
        /// <returns></returns>
        public string Base64EncodeKey(string orgToken)
        {

            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(orgToken));
        }
    }
}
