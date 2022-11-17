namespace WaveBand.Web.Services.Abstractions
{
    public interface IJsonService
    {
        T GetJson<T>(string path);

        void SaveJson<T>(T obj, string path);
    }
}
