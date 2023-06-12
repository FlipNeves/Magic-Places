using MagicPlaces_WEB.Models;

namespace MagicPlaces_WEB.Extensions
{
    static class APIResponseExtension
    {
        public static bool IsValid(this APIResponse response)
        {
            return (response != null && response.IsSuccess);
        }
    }
}
