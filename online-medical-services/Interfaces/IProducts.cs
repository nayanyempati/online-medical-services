using online_medical_services.Models;

namespace online_medical_services.Interfaces
{
    public interface IProducts
    {
        Task<ResponseMessage> AddProduct(AddProductModel product);
    }
}
