using System.Globalization;
using System.Text.Json;

namespace SportsStore.WebUI.Infarstructure;
public static class SessionExtensions
{
    //phuong thuc mo rong de luu mot doi tuong vao session
    public static void SetJson(this ISession session , string key , object value)
    {
        session.SetString(key , JsonSerializer.Serialize(value));
    }

    //Phuong thuc mo rong de lay mot doi tuong tu session
    public static T? GetJson<T>(this ISession session , string key)
    {
        var sessionData = session.GetString(key);

        return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
    }
}