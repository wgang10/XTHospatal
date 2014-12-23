using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
//下载于51aspx.com
public class AliPay
{
    public static string GetMD5(string s, string _input_charset)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(s));
        StringBuilder sb = new StringBuilder(32);
        for (int i = 0; i < t.Length; i++)
        {
            sb.Append(t[i].ToString("x").PadLeft(2, '0'));
        }
        return sb.ToString();
    }

    public static string[] BubbleSort(string[] r)
    {
        int i, j;
        string temp;

        bool exchange;

        for (i = 0; i < r.Length; i++)
        {
            exchange = false;

            for (j = r.Length - 2; j >= i; j--)
            {
                if (String.CompareOrdinal(r[j + 1], r[j]) < 0)
                {
                    temp = r[j + 1];
                    r[j + 1] = r[j];
                    r[j] = temp;

                    exchange = true;
                }
            }

            if (!exchange)
            {
                break;
            }
        }
        return r;
    }

    public string CreatUrl(
        string gateway,
        string service,
        string partner,
        string sign_type,
        string out_trade_no,
        string subject,
        string body,
        string payment_type,
        string total_fee,
        string show_url,
        string seller_email,
        string key,
        string return_url,
        string _input_charset,
        string notify_url
        )
    {
        int i;

        string[] Oristr = {
                              "service=" + service,
                              "partner=" + partner,
                              "subject=" + subject,
                              "body=" + body,
                              "out_trade_no=" + out_trade_no,
                              "price=" + total_fee,
                              "show_url=" + show_url,
                              "payment_type=" + payment_type,
                              "seller_email=" + seller_email,
                              "notify_url=" + notify_url,
                              "_input_charset=" + _input_charset,
                              "return_url=" + return_url,
                              "discount=-0.01",
                              "quantity=1",
                              "logistics_type=EXPRESS",
                              "logistics_fee=0",
                              "logistics_payment=BUYER_PAY",
                              "logistics_type_1=POST",
                              "logistics_fee_1=0",
                              "logistics_payment_1=BUYER_PAY"
                          };

        string[] Sortedstr = BubbleSort(Oristr);

        StringBuilder prestr = new StringBuilder();

        for (i = 0; i < Sortedstr.Length; i++)
        {
            if (i == Sortedstr.Length - 1)
            {
                prestr.Append(Sortedstr[i]);
            }
            else
            {
                prestr.Append(Sortedstr[i] + "&");
            }
        }

        prestr.Append(key);

        string sign = GetMD5(prestr.ToString(), _input_charset);

        char[] delimiterChars = {'='};
        StringBuilder parameter = new StringBuilder();
        parameter.Append(gateway);
        for (i = 0; i < Sortedstr.Length; i++)
        {
            parameter.Append(Sortedstr[i].Split(delimiterChars)[0] + "=" +
                             HttpUtility.UrlEncode(Sortedstr[i].Split(delimiterChars)[1]) + "&");
        }

        parameter.Append("sign=" + sign + "&sign_type=" + sign_type);

        return parameter.ToString();
    }
}