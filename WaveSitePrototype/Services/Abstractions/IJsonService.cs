namespace WaveBand.Web.Services.Abstractions
{
    public interface IJsonService
    {
        T GetJson<T>(Type type, string path);

        void SaveJson<T>(T obj, string path);
    }
}
