using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
//using SignalRChat.Hubs;

namespace SignalRChat.Pages
{
    public class ChatHub // : Hub
    {
     /*   public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        */
    }
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        //private readonly IHubContext<ChatHub> _hubcontext;
        public string someVar { get; set; } = "i am some variable";

        public IndexModel(ILogger<IndexModel> logger)//, IHubContext<ChatHub> hubcontext)
        {
            _logger = logger;
            //_hubcontext = hubcontext;
        }

        public void OnGet()
        {
            /*
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = "systeminfo; get-vm; $psversiontable";
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.RedirectStandardOutput = true;

            _ = Task.Run(() =>
            {
                
                Thread.Sleep(2000);
                _hubcontext.Clients.All.SendAsync("ReceiveMessage", "STARTED METHOD", "");
                process.Start();
                StreamReader reader = process.StandardOutput;
                string output = reader.ReadToEnd();
                someVar = output;
                _hubcontext.Clients.All.SendAsync("ReceiveMessage", "FINISHED", "");//.ConfigureAwait(false);

            });*/
        }
    }
}