using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionApp
{
    public class Helper
    {
        public static string registrToken;
        public static string pid;
        public static bool isFirstItrationOfQuestEveryDay = false;
        //Костыльная дата, нужна для метода который проверяет есть ли 10 часов и если есть то надо показать вопрос
        //Опять таки не самая лучшая реализация, а если день совпадет с этой датой? То все пиздец? Решить этот момент
        public static DateTime tenHourDate = new DateTime(2015, 7, 20);

    }
}
