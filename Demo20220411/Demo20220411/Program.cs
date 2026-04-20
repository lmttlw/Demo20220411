using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo20220411
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine(GetDaXieMoney(1234567890.4054567));
            //安装了 Microsoft.VisualBasic.dll
            Console.WriteLine(Strings.StrConv("测试：不支持超过万亿级别的数字", VbStrConv.TraditionalChinese, 0));//简体转繁体
            Console.WriteLine(Strings.StrConv("測試：不支持超過萬億級別的數字", VbStrConv.SimplifiedChinese, 0));//繁体转简体
            Console.ReadKey();
        }
        /// <summary>
        /// 金额 阿拉伯数字转换为大写
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string GetDaXieMoney(double value)
        {
            string[] moneyUnit = { "分", "角", "元", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "億", "拾", "佰", "仟", "萬" };
            string result = "";         //←定义结果
            int unitPointer = 0;        //←定义单位位置
            //↓格式化金额字符串
            string valueStr = value.ToString("#0.00");
            //↓判断是否超出万亿的限制
            if (valueStr.Length > 16)
            {
                throw new Exception("不支持超過萬億級別的數字！");
            }
            //↓遍历字符串，获取金额大写
            for (int i = valueStr.Length - 1; i >= 0; i--)
            {
                //↓判断是否小数点
                if (valueStr[i] != '.')
                {
                    //↓后推方式增加内容
                    result = GetDaXie(valueStr[i]) + moneyUnit[unitPointer] + result;
                    //↓设置单位位置
                    unitPointer++;
                }
            }
            return result;
        }
        /// <summary>
        /// 获取大写信息
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static string GetDaXie(char c)
        {
            string result = "";
            switch (c)
            {
                case '0':
                    result = "零";
                    break;
                case '1':
                    result = "壹";
                    break;
                case '2':
                    result = "貳";
                    break;
                case '3':
                    result = "叁";
                    break;
                case '4':
                    result = "肆";
                    break;
                case '5':
                    result = "伍";
                    break;
                case '6':
                    result = "陸";
                    break;
                case '7':
                    result = "柒";
                    break;
                case '8':
                    result = "捌";
                    break;
                case '9':
                    result = "玖";
                    break;
            }
            return result;
        }
    }
}
