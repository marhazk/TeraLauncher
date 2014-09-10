using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;
using System.Text.RegularExpressions;
using System.Net;

//FileDB v2.1 writen by MarHazK (6 Feb 2014)
//FileDB v2.0 writen by MarHazK
class FileDB
{
    public List<String> DB = new List<String>();
    String file;
    FileStream filestream;
    DateTime CurrTime;
    public bool temporary = false;
    ~FileDB()
    {
        //filestream.Dispose();
        DisposeAll();
    }
    public FileDB()
    {
        CurrTime = DateTime.Now;
        temporary = true;
    }
    public FileDB(Uri _url)
    {
        CurrTime = DateTime.Now;
        string randnum = CurrTime.Year.ToString() + CurrTime.Month.ToString() + CurrTime.Day.ToString() + CurrTime.Hour.ToString() + CurrTime.Minute.ToString() + CurrTime.Second.ToString();
        string _file = "FILE" + randnum;
        DownloadFile(_file, _url.ToString());
        temporary = true;
    }
    public FileDB(string _file, string _url)
    {
        DownloadFile(_file, _url);
    }
    public FileDB(string _file)
    {
        Open(_file);
    }


    public int Total()
    {
        return DB.Count - 1;
    }
    public void DownloadFile(string _file, string _url)
    {
        TryToDelete(_file);
        WebClient client = new WebClient();
        try
        {
            client.DownloadFile(@"" + _url, _file);
        }
        catch
        {
        }
        client.Dispose();
        Open(_file);
    }
    public void Open(string _file)
    {
        this.file = _file;
        try
        {
            filestream = File.Open(this.file, FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader r = new StreamReader(filestream);
            string t;
            while ((t = r.ReadLine()) != null)
            {
                DB.Add(t);
            }
            filestream.Close();
        }
        catch { }
    }
    public String Read(int num)
    {
        String temp = "";
        int x = 0;
        foreach (String r in DB)
        {
            if (x == num)
            {
                temp = r;
                break;
            }
            x++;
        }
        return temp;
    }
    public String ReadLine(int num)
    {
        return (Read(num) + "\r\n");
    }
    public void Delete()
    {
        filestream.Dispose();
        TryToDelete(file);
    }
    public void Replace(String find, string replacewith)
    {
        List<String> FindLDB = new List<String>();
        FindLDB.Add(find);
        Replace(FindLDB, replacewith);
    }
    public void Replace(String[] FindDB, string replacewith)
    {
        List<String> FindLDB = new List<String>();
        foreach (String find in FindDB)
        {
            FindLDB.Add(find);
        }
        Replace(FindLDB, replacewith);
    }
    public void Replace(List<String> FindDB, string replacewith)
    {
        List<String> NewDB = new List<String>();
        foreach (String r in DB)
        {
            String newstr = r;
            foreach (String find in FindDB)
            {
                newstr = newstr.Replace(find, replacewith);
            }
            NewDB.Add(newstr);
        }
        this.DB = NewDB;
    }
    public static bool TryToDelete(string f)
    {
        try
        {
            // A.
            // Try to delete the file.
            if (f != null)
                File.Delete(f);
            return true;
        }
        catch (IOException)
        {
            // B.
            // We couldn't delete the file.
            return false;
        }
    }
    public void Update()
    {
        TryToDelete(file);
        StreamWriter wfile = new StreamWriter(file);
        foreach (String r in DB)
        {
            wfile.WriteLine(r);
        }
        wfile.Close();
    }

    public void DisposeAll()
    {
        try
        {
            try
            {
                TryToDelete(file);
            }
            catch { }
            filestream.Dispose();
        }
        catch { }
        if (temporary)
        {
            TryToDelete(file);
        }
    }
    public override string ToString()
    {
        return base.ToString();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // dispose managed resources
            DisposeAll();
        }
        // free native resources
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}