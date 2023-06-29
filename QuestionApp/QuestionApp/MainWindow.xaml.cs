using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuestionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("Kyt (1).ico");
            ni.Text = "KYT";
            ni.Visible = true;
            var currentDir = Directory.GetCurrentDirectory();
            if (File.Exists($"{currentDir}\\FirstLaunchWas.txt"))
            {

            }
            else
            {
                try
                {
                    RegistryKey rk = Registry.CurrentUser.OpenSubKey
                            ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    rk.SetValue("Kyt", System.Environment.ProcessPath);
                    File.Create($"{currentDir}\\FirstLaunchWas.txt");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.ToString());
                }
                
            }

            //Хранение pid в текстовом документе = идиотское решение, Переделать на хранение в настройках.
            //Также важно понимать что в данный момент при удалении программы, папка хранящая pid не удаляется, не удивляемся а ручками удаляем(для теста)
            //Опять таки нахуй снести такой подход

            if (Directory.Exists($"{currentDir}\\QuestData"))
            {
                if (File.Exists($"{currentDir}\\QuestData\\pid.txt"))
                {
                    using (StreamReader reader = new StreamReader($"{currentDir}\\QuestData\\pid.txt"))
                    {
                        string text = reader.ReadToEnd();
                        if (text.Length < 5)
                        {

                        }
                        else
                        {
                            Helper.pid = text;
                            Helper.pid = Helper.pid[..^2];
                            QuestionWindow questionWindow = new QuestionWindow();
                            questionWindow.Show();
                            this.Close();
                        }

                    }
                }
                else
                {
                    File.Create($"{currentDir}\\QuestData\\pid.txt");
                }
            }
            else
            {
                Directory.CreateDirectory($"{currentDir}\\QuestData");
                File.Create($"{currentDir}\\QuestData\\pid.txt");
            }
            this.ShowInTaskbar = false;
        }
        public async Task Registr()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sit00.xyz/v0_1/registration");
            request.Headers.Add("x-api-key", "F3Ka1KrPGi5wgfnzVufgC2k9o17nVcgl8hpchQHZ");
            var content1 = new StringContent($"{{\n  \"token\": \"{registrTokenTxt.Text}\"\n}}", Encoding.UTF8, "application/json");
            request.Content = content1;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string G = await response.Content.ReadAsStringAsync();
            if (G.Contains("error"))
            {
                errorTxt.Visibility = Visibility.Visible;
            }
            else
            {
                Rootobject person = JsonSerializer.Deserialize<Rootobject>(G);
                Helper.pid = person.pid;
                Helper.registrToken = registrTokenTxt.Text;
                await Confirnm();
            }
            int b = 3;

        }
        //Метод свою задачу выполнил, можно удалять
        public async Task Test()
        {
            await Task.Delay(10000);
            this.Focus();
            this.Activate();
            Test();
        }
        public async Task Confirnm()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sit00.xyz/v0_1/confirmation");
            request.Headers.Add("x-api-key", "F3Ka1KrPGi5wgfnzVufgC2k9o17nVcgl8hpchQHZ");
            //var content = new StringContent($"{{\n\"pid:\" \"{Helper.pid}\", \n \"token\": \"{Helper.registrToken}\"\n}}", Encoding.UTF8, "application/json");
            var content = new StringContent($"{{\n  \"pid\": \"{Helper.pid}\",\n  \"token\": \"{Helper.registrToken}\"\n}}", Encoding.UTF8, "application/json");
            //string content = ($"{{\n\"pid:\" \"{Helper.pid}\", \n \"token\": \"{Helper.registrToken}\"\n}}");
            //var content = new StringContent("{\n  \"pid\": \"23a49875-759b-4a61-8f0e-1e63edb7fd4a\",\n  \"token\": \"Nsddu1cu-Uj\"\n}", Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string b2 = await response.Content.ReadAsStringAsync();
            Rootobject1 confirmMes = JsonSerializer.Deserialize<Rootobject1>(b2);
            if(confirmMes.confirmed == true)
            {
                using (StreamWriter writer = new StreamWriter($"{Directory.GetCurrentDirectory()}\\QuestData\\pid.txt", false))
                {
                    await writer.WriteLineAsync(confirmMes.pid);
                }
                await Task.Delay(5000);
                QuestionWindow questionWindow = new QuestionWindow();
                questionWindow.Show();
                this.Close();
            }
            else
            {
                errorTxt.Visibility = Visibility.Visible;
            }
            int b5 = 3;
        }
        public class Rootobject
        {
            public string pid { get; set; }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            errorTxt.Visibility = Visibility.Hidden;
            await Registr();
        }

        public class Rootobject1
        {
            public string pid { get; set; }
            public bool confirmed { get; set; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Позиционирование окна
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }
    }
}
