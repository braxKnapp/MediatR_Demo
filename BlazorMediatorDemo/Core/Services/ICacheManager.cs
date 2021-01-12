namespace BlazorMediatorDemo.Core.Services
{
    public interface ICacheManager
    {
        int IncrementClickCount();
        int GetClickCount();
    }
}