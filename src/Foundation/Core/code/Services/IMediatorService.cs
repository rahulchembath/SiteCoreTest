using System.ComponentModel.DataAnnotations;
using Claro.Foundation.Core.Models;

namespace Claro.Foundation.Core.Services
{
    public interface IMediatorService
    {
        MediatorResponse<T> GetMediatorResponse<T>(string code, T viewModel = default(T),
            ValidationResult validationResult = null, object parameters = null, string message = null);
    }
}