﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;
using System.IO;

namespace compactTool
{
    class ZipClass
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public  ZipClass()
        {
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="FilePath">需要压缩文件路径集合</param>
        /// <param name="FileName">压缩后文件名</param>
        /// <param name="SavePath">压缩后存放路径</param>
        /// <param name="PassWord">压缩密码，null为无密码</param>
        /// <returns>异常消息，成功返回null</returns>
        public string SetZipFile(string[] FilePath,string FileName,string SavePath,string PassWord)
        {
            try
            {
                ZipFile zipfile = new ZipFile(SavePath + "\\" + FileName + ".zip", Encoding.Default);
                if (PassWord != string.Empty)
                    zipfile.Password = PassWord;
                zipfile.AddFiles(FilePath);

                zipfile.Save();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }           
            return null;
        }

        /// <summary>
        /// 压缩文件夹
        /// </summary>
        /// <param name="FilePath">需要压缩文件夹路径</param>
        /// <param name="FileName">压缩后文件名</param>
        /// <param name="SavePath">压缩后存放路径</param>
        /// <param name="PassWord">压缩密码，null为无密码</param>
        /// <returns>异常消息，成功返回null</returns>
        public string SetZipFile(string FilePath, string FileName, string SavePath, string PassWord)
        {
            try
            {
                ZipFile zipfile = new ZipFile(SavePath + "\\" + FileName + ".zip", Encoding.Default);
                if (PassWord != string.Empty)
                    zipfile.Password = PassWord;
                zipfile.AddDirectory(FilePath);
                zipfile.Save();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return null;
        }

        /// <summary>
        /// 解压文件
        /// </summary>
        /// <param name="FilePath">zip文件路径</param>
        /// <param name="ReleasePath">解压路径</param>
        /// <param name="FileName">需要解压的文件名</param>
        /// <param name="PassWord">解压密码 null为无密码</param>
        /// <returns>异常消息，成功返回null</returns>
        public string ReleaseFile(string FilePath,string ReleasePath,string[] FileName,string PassWord)
        {
            try
            {
                ZipFile zipfile = ZipFile.Read(FilePath);
                if (PassWord != string.Empty)
                    zipfile.Password = PassWord;
                foreach(string filename in FileName)
                zipfile[filename].Extract(ReleasePath);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return null;
        }

        /// <summary>
        /// 解压全部文件
        /// </summary>
        /// <param name="FilePath">zip文件路径</param>
        /// <param name="ReleasePath">解压路径</param>
        /// <param name="PassWord">解压密码，null为无密码</param>
        /// <returns>异常消息，成功返回null</returns>
        public string ReleaseAllFile(string FilePath, string ReleasePath, string PassWord)
        {
            try
            {
                ZipFile zipfile = ZipFile.Read(FilePath);
                if (PassWord != string.Empty)
                    zipfile.Password = PassWord;
                foreach (ZipEntry zipentry in zipfile)
                    zipentry.Extract(ReleasePath);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return null;
        }

        /// <summary>
        /// 从zip文件中移除文件
        /// </summary>
        /// <param name="FilePath">zip文件路径</param>
        /// <param name="FileName">要移除的文件名集合</param>
        /// <returns>异常消息，成功返回null</returns>
        public string DelFile(string FilePath, string[] FileName)
        {
            try
            {
                ZipFile zipfile = ZipFile.Read(FilePath);
                foreach (string filename in FileName)
                    zipfile.RemoveEntry(filename);
                zipfile.Save();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return null;
        }

        /// <summary>
        /// 向zip文件内添加文件
        /// </summary>
        /// <param name="FilePath">zip文件路径</param>
        /// <param name="AddFilePath">要添加的文件路径集合</param>
        /// <returns></returns>
        public string AddFile(string FilePath, string[] AddFilePath)
        {
            try
            {
                ZipFile zipfile = ZipFile.Read(FilePath);
                zipfile.AddFiles(AddFilePath);
                zipfile.Save();
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return null;
        }
    }
}
