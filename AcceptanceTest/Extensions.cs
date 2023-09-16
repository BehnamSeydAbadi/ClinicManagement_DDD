using Newtonsoft.Json;
using Presentation.Common;

namespace AcceptanceTest;

internal static class Extensions
{
    internal static TResult To<TResult>(this HttpResponseMessage? response)
    {
        var apiOutput = response.ToOutput();
        return JsonConvert.DeserializeObject<TResult>(apiOutput.Data.ToString())!;
    }

    internal static Output ToOutput(this HttpResponseMessage? response)
    {
        var task = response.Content.ReadAsStringAsync();
        task.Wait();
        var jsonContent = task.Result;

        return JsonConvert.DeserializeObject<Output>(jsonContent)!;
    }
}
