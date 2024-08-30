using Microsoft.JSInterop;

namespace YumStore.Services.Extentions
{
    public static class IJsRunTimeExtention
    {
        public static async Task ToastrSuccess(this IJSRuntime js,string message)
        {
            await js.InvokeVoidAsync("ShowToaster","success",message);
        }
        public static async Task ToasterError(this IJSRuntime js, string message)
        {
            await js.InvokeVoidAsync("ShowToaster", "error", message);
        }
    }
}
