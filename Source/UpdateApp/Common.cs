using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace UpdateApp
{
    public class Common
    {
        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="fileName"></param>
        public static void UnZipFile(string fileName,string folder)   //解压缩
        {
            //string[] un_tmp = p.Split(new char[]{'*'});
            //int i2=0;  //防止名称冲突的参数
            //for(int j=0;j<un_tmp.Length;j++)
            //{
                    //if(un_tmp[j]!="")
                    //{
                        //string un_time=System.DateTime.Now.ToShortDateString()+"-"+System.DateTime.Now.Hour.ToString()+"-"+System.DateTime.Now.Minute.ToString()+"-"+(System.DateTime.Now.Second+i2).ToString();
                        if (!Directory.Exists(folder))
                        {
                            Directory.CreateDirectory(folder);     //创建解压的文件夹
                        }
                        ZipInputStream f = new ZipInputStream(File.OpenRead(fileName)); //读取压缩文件，并用此文件流新建 “ZipInputStream”对象

                        A: ZipEntry zp = f.GetNextEntry();    //获取解压文件流中的项目。 另注（我的理解）：在压缩包里每个文件都以“ZipEntry”形式存在，其中包括存放文件的目录信息。如果空目录被压缩，该目录下将出现一个名称为空、大小为 0 、“Crc”属性为 00000000 的“文件”。此文件只是个标记，不会被解压。

                        while(zp!=null)
                        {
                            string un_tmp2;
                            if (zp.IsDirectory)
                            {
                                if (!Directory.Exists(folder+"/"+zp.Name))
                                {
                                    Directory.CreateDirectory(folder + "/" + zp.Name); 
                                }
                            }
                            if(zp.Name.IndexOf(@"/")>=0) //获取文件的目录信息
                            {
                                int tmp1 = zp.Name.LastIndexOf("/");
                                un_tmp2 = zp.Name.Substring(0,tmp1);
                                un_tmp2 = folder + "/" + un_tmp2;
                                if (!Directory.Exists(un_tmp2))
                                {
                                    Directory.CreateDirectory(un_tmp2); //必须先创建目录，否则解压失败 --- （A） 关系到下面的步骤（B）
                                }
                            }
                            if(!zp.IsDirectory&&zp.Crc!=00000000L) //此“ZipEntry”不是“标记文件”
                            {
                                int i =2048;
                                byte[] b = new byte[i];  //每次缓冲 2048 字节
                                FileStream s = File.Create(folder + "/" + zp.Name); //（B)-新建文件流
                                while(true) //持续读取字节，直到一个“ZipEntry”字节读完
                                {
                                    i = f.Read(b,0,b.Length); //读取“ZipEntry”中的字节
                                    if(i>0)
                                    {
                                        s.Write(b,0,i); //将字节写入新建的文件流
                                    }
                                    else
                                    {
                                        break; //读取的字节为 0 ，跳出循环
                                    }
                                }
                                s.Close();
                            }
                            goto A; //进入下一个“ZipEntry”
                        }
                        f.Close();
                        //i2++;
                    //}
                //}
        }

        /// <summary>
        /// 计算文件的MD5校验
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("error:" + ex.Message);
            }
        }

        public static string globalAppVNo = string.Empty;

        public static string globalAppMD5No = string.Empty;

        /// <summary>
        /// 从配置文件中获取配置项
        /// </summary>
        /// <returns></returns>
        public static string GetConfigFormIni()
        {
            string filePath = Application.StartupPath + "\\WebURL.ini";
            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            string s = string.Empty;
            s = sr.ReadLine();
            sr.Close();
            if (s.EndsWith(@"/"))
            {
                s = s.Substring(0, s.Length - 1);
            }
            return s;
        }
    }
}
