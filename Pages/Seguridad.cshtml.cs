using System.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using SGLibreria.Utils;

namespace SGLibreria.Pages
{
    public class SeguridadModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostCrearBackupAsync()
        {
            try
            {
                StreamWriter escribir;
                //output file, with absolute path
                //and current datetime
                string file =
                Entorno.backupOutputDir
                + Entorno.prefix
                + DateTime.Now.ToString("yyyy-MM-ddTHH-mm-sszzz") + ".sql";
                Console.WriteLine(file);
                Process proceso = new Process();
                //shell will be open with, and to it, will be send command
                proceso.StartInfo.FileName = "cmd.exe";
                proceso.StartInfo.UseShellExecute = false;
                //path to database manager (mysql)
                proceso.StartInfo.WorkingDirectory = Entorno.DBMSPath;
                proceso.StartInfo.RedirectStandardInput = true;
                proceso.StartInfo.RedirectStandardOutput = true;
                proceso.Start();

                //send to stdin mysqldump command to backup
                escribir = proceso.StandardInput;
                escribir.WriteLine($"mysqldump -u {Entorno.username} {Entorno.dbName} > " + file + "");
                //close the stdin
                escribir.Close();
                //wait 
                proceso.WaitForExit();

                int status = proceso.ExitCode;
                proceso.Close();
                //status == 0, means to program finish Okay

            }
            catch (Exception e)
            {
                Console.Write("" + e.Message);
            }

            return Page();
        }

        private static void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}