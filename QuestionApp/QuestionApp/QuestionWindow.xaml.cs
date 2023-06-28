using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuestionApp
{
    /// <summary>
    /// Логика взаимодействия для QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        string questId;
        public List<QuestionClass> dlyaProverkis = new List<QuestionClass>();
        public QuestionWindow()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            WindowFocucEveryHour();
            //DlyaProverki dlyaProverki = new DlyaProverki()
            //{
            //    nado = "asdadd"
            //};
            //DlyaProverki dlyaProverki1 = new DlyaProverki()
            //{
            //    nado = "AHAHAH"
            //};
            //dlyaProverkis.Add(dlyaProverki);
            //dlyaProverkis.Add(dlyaProverki1);
            //questLst.ItemsSource = dlyaProverkis.ToList();


        }
        //Метод сбрасывает ответ на вопрос
        public async Task Reset()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sit00.xyz/v0_1/reset");
            request.Headers.Add("x-api-key", "F3Ka1KrPGi5wgfnzVufgC2k9o17nVcgl8hpchQHZ");
            var content = new StringContent($"{{\n  \"pid\": \"{Helper.pid}\"\n}}", Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string b = await response.Content.ReadAsStringAsync();
            int b43 = 2;
        }
        //Метод чисто для теста, для проверки на наличие нового вопроса каждую минуту
        public async Task TestGetQuestEveryMin()
        {
            await Task.Delay(60000);
            await GetQuest();
        }
        //Метод для получения вопроса
        public async Task GetQuest()
        {
            //await Reset();
            this.Focus();
            this.Activate();
            questLst.Visibility = Visibility.Visible;
            this.Visibility = Visibility.Visible;
            dlyaProverkis.Clear();
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.sit00.xyz/v0_1/question");
            request.Headers.Add("x-api-key", "F3Ka1KrPGi5wgfnzVufgC2k9o17nVcgl8hpchQHZ");
            request.Headers.Add("x-api-pid", Helper.pid);
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string b = await response.Content.ReadAsStringAsync();
            if(b == "{}")
            {
                questLst.Visibility = Visibility.Collapsed;
                questTxt.Text = "No questions for now. We'll let you know.";
                await Task.Delay(2000);
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                Rootobject person = JsonSerializer.Deserialize<Rootobject>(b);
                //TextBlock textBlock = new TextBlock();
                QuestionClass questionClass1 = new QuestionClass();
                questionClass1.Question = person._0._5;
                QuestionClass questionClass2 = new QuestionClass();
                questionClass2.Question = person._0._4;
                QuestionClass questionClass3 = new QuestionClass();
                questionClass3.Question = person._0._3;
                QuestionClass questionClass4 = new QuestionClass();
                questionClass4.Question = person._0._2;
                QuestionClass questionClass5 = new QuestionClass();
                questionClass5.Question = person._0._1;
                dlyaProverkis.Add(questionClass1);
                dlyaProverkis.Add(questionClass2);
                dlyaProverkis.Add(questionClass3);
                dlyaProverkis.Add(questionClass4);
                dlyaProverkis.Add(questionClass5);
                questTxt.Text = person._0.text;
                questLst.ItemsSource = dlyaProverkis.ToList();
                questId = Convert.ToString(person.qid);

            }
            
        }
        public async Task Answer(string answrId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sit00.xyz/v0_1/answer");
            request.Headers.Add("x-api-key", "F3Ka1KrPGi5wgfnzVufgC2k9o17nVcgl8hpchQHZ");
            var content = new StringContent($"{{\n  \"aid\": {answrId},\n  \"pid\": \"{Helper.pid}\",\n  \"qid\": {questId}\n}}", null, "application/json");
            //var content = new StringContent($"{{\n  \"aid\": 5,\n  \"pid\": \"b738e6b4-6c60-43e0-8101-d4a565bd1560\",\n  \"qid\": 3\n}}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string b = await response.Content.ReadAsStringAsync();
            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Post, "https://api.sit00.xyz/v0_1/answer");
            //request.Headers.Add("x-api-key", "F3Ka1KrPGi5wgfnzVufgC2k9o17nVcgl8hpchQHZ");
            //var content = new StringContent("{\n  \"aid\": 5,\n  \"pid\": \"b738e6b4-6c60-43e0-8101-d4a565bd1560\",\n  \"qid\": 3\n}", null, "application/json");
            //request.Content = content;
            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //string b = await response.Content.ReadAsStringAsync();
            questTxt.Text = "Got it. Thank you!";
            questLst.Visibility = Visibility.Collapsed;
            await Task.Delay(2000);
            this.Visibility = Visibility.Hidden;
            int b4 = 3;
                       
        }
        public async Task QuestEveryDay()
        {
            await Task.Delay(120000);
            var currentDate = DateTime.Now;
            if(currentDate.Hour == 10)
            {
                if(Helper.tenHourDate.Day == currentDate.Day)
                {
                    Helper.tenHourDate = currentDate;
                    await Task.Delay(10800000);
                }
                else
                {
                    Helper.tenHourDate = currentDate;
                    this.Focus();
                    this.Activate();
                    this.Visibility = Visibility.Visible;
                    questLst.Visibility = Visibility.Visible;
                    await GetQuest();
                }
                  
            }
            else
            {
                await QuestEveryDay();
            }
        }
        public class Rootobject
        {
            [JsonPropertyName("0")]
            public _0 _0 { get; set; }
            [JsonPropertyName("qid")]
            public int qid { get; set; }
        }
        public async Task WindowFocucEveryHour()
        {
            //3600000 here instead 60000
            await Task.Delay(60000);
            if(questTxt.Text.Contains("Got it") || questTxt.Text.Contains("No questions"))
            {

            }
            else
            {
                this.Focus();
                this.Activate();
                await WindowFocucEveryHour();
            }
           

        }
        public class _0
        {
            [JsonPropertyName("1")]
            public string _1 { get; set; }
            [JsonPropertyName("2")]
            public string _2 { get; set; }
            [JsonPropertyName("3")]
            public string _3 { get; set; }
            [JsonPropertyName("4")]
            public string _4 { get; set; }
            [JsonPropertyName("5")]
            public string _5 { get; set; }
            [JsonPropertyName("text")]
            public string text { get; set; }
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //await Reset();
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
            await GetQuest();
            QuestEveryDay();
            TestGetQuestEveryMin();
        }

        private async void questLst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string answerId = "0";
            if(questLst.SelectedIndex == 0)
            {
                answerId = "5";
            }
            else if(questLst.SelectedIndex == 1)
            {
                answerId = "4";
            }
            else if (questLst.SelectedIndex == 2)
            {
                answerId = "3";
            }
            else if (questLst.SelectedIndex == 3)
            {
                answerId = "2";
            }
            else if (questLst.SelectedIndex == 4)
            {
                answerId = "1";
            }
            await Answer(answerId);
        }
    }
}
