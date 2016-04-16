using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EasyTransaction
{
    /// <summary>
    /// 文件操作库
    /// </summary>
    class FileLib
    {
         /// <summary>
         /// 将文件内容按行全部读取
         /// </summary>
         /// <param name="fileName">文件名</param>
         /// <returns>行内容，如果文件不存在则返回null</returns>
        public static IList<string> ScanEnterFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;
            if ( !File.Exists(fileName))
                return null;
            //翻译为大文件，初始容量大一些
            var list = new List<string>(1000);
            using (StreamReader sr = File.OpenText(fileName))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(sr.ReadLine());
                } 
                sr.Close();
            }
            return list;
        }
    }
}
