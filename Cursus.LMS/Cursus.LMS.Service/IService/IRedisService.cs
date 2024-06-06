namespace Cursus.LMS.Service.IService;

public interface IRedisService
{
    Task<bool> Store(string key, string value);
    Task<string> Retrieve(string key);
    Task<bool> Delete(string key);
}