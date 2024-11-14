using System.Text;
using System.Web;

namespace Crabank.Utilities;

public static class Notifications
{
    public static async Task SendAsync(string title, string message, params string[] emojis)
    {
        HttpClient client = new();
        client.DefaultRequestHeaders.Add("Title", HttpUtility.HtmlEncode(title));
        client.DefaultRequestHeaders.Add("Tags", string.Join(',', emojis));
        await client.PostAsync("https://ntfy.sh/kayoukoubeme", new StringContent(message, Encoding.UTF8));
    }
}