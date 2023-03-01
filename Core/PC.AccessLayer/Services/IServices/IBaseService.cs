using PC.AccessLayer.Models;

namespace PC.AccessLayer.Services.IServices
{
    public interface IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public T SendAsync<T>(ApiRequest apiRequest);
    }
}
