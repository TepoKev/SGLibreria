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
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;

namespace SGLibreria.Pages
{
    public class SeguridadModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostCrearBackupAsync()
        {
            StreamWriter escribir;
            StreamReader leer;
            try
            {
                /*
                string file = @"C:\Users\Ernesto\Desktop";
                Process proceso = new Process();
                proceso.StartInfo.FileName = "cmd.exe";
                proceso.StartInfo.UseShellExecute = false;
                proceso.StartInfo.WorkingDirectory = @"C:\xampp\mysql\bin";
                proceso.StartInfo.RedirectStandardInput = true;
                proceso.StartInfo.RedirectStandardOutput = true;
                proceso.Start();

                escribir = proceso.StandardInput;
                leer = proceso.StandardOutput;
                escribir.WriteLine("mysqldump -u root libreria > "+file+"");
                proceso.WaitForExit();
                proceso.Close();
                */
                string commandText = $@"BACKUP DATABASE [libreria] TO DISK = N'C:\Users\Ernesto\Desktop\backup.sql' WITH NOFORMAT, INIT, NAME = N'libreria-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

                SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = "localhost",
                    InitialCatalog = "master",
                    IntegratedSecurity = true
                };
                using (SqlConnection connection = new SqlConnection(connectionStringBuilder.ConnectionString))
                {
                    connection.Open();
                    connection.InfoMessage += Connection_InfoMessage;
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = commandText;
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                    }
                }
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