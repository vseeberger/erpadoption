﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Site
{
    /// <summary>
    /// Summary description for _Upload
    /// </summary>
    public class _Upload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string sDestino = "";
                if (context.Request.QueryString["fotos"] != null) sDestino = "Fotos";
                else if (context.Request.QueryString["exames"] != null) sDestino = "Exames";
                if (!String.IsNullOrEmpty(sDestino))
                {
                    string pathrefer = context.Request.UrlReferrer.ToString();
                    string Serverpath = HttpContext.Current.Server.MapPath("Arquivos") + "/" + sDestino + "/";

                    var postedFile = context.Request.Files[0];

                    string file;

                    //For IE to get file name
                    if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                    {
                        string[] files = postedFile.FileName.Split(new char[] { '\\' });
                        file = files[files.Length - 1];
                    }
                    else
                    {
                        file = postedFile.FileName;
                    }


                    if (!Directory.Exists(Serverpath))
                        Directory.CreateDirectory(Serverpath);

                    string fileDirectory = Serverpath;
                    if (context.Request.QueryString["fileName"] != null)
                    {
                        file = context.Request.QueryString["fileName"];
                        if (File.Exists(fileDirectory + "\\" + file))
                        {
                            File.Delete(fileDirectory + "\\" + file);
                        }
                    }

                    string ext = Path.GetExtension(fileDirectory + "\\" + file);
                    file = Guid.NewGuid() + ext;

                    fileDirectory = Serverpath + "\\" + file;

                    postedFile.SaveAs(fileDirectory);

                    context.Response.AddHeader("Vary", "Accept");
                    try
                    {
                        if (context.Request["HTTP_ACCEPT"].Contains("application/json"))
                            context.Response.ContentType = "application/json";
                        else
                            context.Response.ContentType = "text/plain";
                    }
                    catch
                    {
                        context.Response.ContentType = "text/plain";
                    }

                    context.Response.Write("Success");
                }
            }
            catch (Exception exp)
            {
                context.Response.Write(exp.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}