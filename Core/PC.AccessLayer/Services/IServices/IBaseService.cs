using PC.AccessLayer.Models;

namespace PC.AccessLayer.Services.IServices
{
    public interface IBaseService
    {
        public ResponseDto responseModel { get; set; }
        public Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
