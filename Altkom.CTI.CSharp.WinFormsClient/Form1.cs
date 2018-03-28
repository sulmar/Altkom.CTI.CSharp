using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Altkom.CTI.CSharp.WinFormsClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

      

        private async void bDownload_Click(object sender, EventArgs e)
        {
            tResult.Text = await DownloadAsync(tURL.Text);


            //Thread thread = new Thread(Download();
            //thread.Start();

            //Task.Run<string>(() => Download(tURL.Text))
            //    .ContinueWith(task => tResult.Text = task.Result);

            //  tResult.Text = Task.Run<string>(() => Download(tURL.Text)).Result;

            // Download();
        }

        private string Download(string url)
        {
            using (var client = new WebClient())
            {
                var result = client.DownloadString(url);

                return result;
            }
        }

        private async Task<string> DownloadAsync(string url)
        {
            using (var client = new WebClient())
            {
                await Task.Delay(TimeSpan.FromSeconds(5));

                var result = await client.DownloadStringTaskAsync(url);

                return result;
            }
        }


        private void Callback()
        {

        }
   

        private async void bCalculate_Click(object sender, EventArgs e)
        {
            await CalculateAsync();

            //Task task = new Task(() => Calculate());
            //task.Start();

            //Task.Run(() => Calculate());

            // Asynchronicznie za pomocą Thread
            //Thread thread = new Thread(Calculate);
            //thread.Start();

            // Synchroniczne

           // Calculate();
        }

        private void Calculate()
        {
            Console.WriteLine("Calculating...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine("Calculated.");
        }

        private Task CalculateAsync()
        {
            return Task.Run(() => Calculate());
        }

    }
}
