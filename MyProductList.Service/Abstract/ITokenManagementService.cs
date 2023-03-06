using MyProductList.Dto.Models;

namespace MyProductList.Service.Abstract
{
    public interface ITokenManagementService
    {
        Task<TokenResponse> GenerateTokensAsync(TokenRequest loginResource, DateTime now, string userAgent);
    }
}
