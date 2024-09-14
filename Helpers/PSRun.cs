using Microsoft.AspNetCore.SignalR;
using SignalRChat.Hubs;
using System.Diagnostics;

namespace SignalRChat.Helpers
{
    public class PSRun
    {
        private readonly IHubContext<ChatHub> _hubcontext;
        public string someVar { get; set; } = "i am some variable and I will store your output";
        public PSRun(IHubContext<ChatHub> hubcontext)
        {
            _hubcontext = hubcontext;
        }

        public void StartPS()
        {

            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "powershell.exe";
            //process.StartInfo.Arguments = "start-vm -Name terminal";
            process.StartInfo.Arguments = "write-host test";
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.RedirectStandardOutput = true;

            _ = Task.Run(() =>
            {
                _hubcontext.Clients.All.SendAsync("ReceiveMessage", "STARTED METHOD", "");
                process.Start();
                StreamReader reader = process.StandardOutput;
                string output = reader.ReadToEnd();
                someVar = output;
                _hubcontext.Clients.All.SendAsync("ReceiveMessage", "FINISHED", someVar);

            });
        }

        public string StartPSArg(string vm)
        {
 
            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                Task.CurrentId, obj,
                Thread.CurrentThread.ManagedThreadId);
            };

            Task<string> task1 = Task<string>.Factory.StartNew(() =>
            {
                Process process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = $"{vm}";
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.Start();
                return process.StandardOutput.ReadToEnd();
            });


            //Task tsk1 = new Task(action, "TASK1!");
            //tsk1.Start();
            _hubcontext.Clients.All.SendAsync("ReceiveMessage", "FINISHED-args", task1.Result);
            return task1.Result;
        }

        public Task StartPSArg_old(string vm)
        {
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = $"{vm}";
            process.StartInfo.CreateNoWindow = false;
            process.StartInfo.RedirectStandardOutput = true;

            var result = Task.Run(() =>
            {
                _hubcontext.Clients.All.SendAsync("ReceiveMessage", "STARTED METHOD", "");
                process.Start();
                StreamReader reader = process.StandardOutput;
                string output = reader.ReadToEnd();
                someVar = output;
                _hubcontext.Clients.All.SendAsync("ReceiveMessage", "FINISHED-args", someVar);

            });
            return result;
        }
    }
}
