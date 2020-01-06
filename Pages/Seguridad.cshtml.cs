using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace SGLibreria.Pages {
    public class SeguridadModel : PageModel {
        public void OnGet () {

        }

        public async Task<IActionResult> OnPostCrearBackup () {

            string path;
            path = "C:\\MySqlBackup" + ".sql";
            StreamWriter file = new StreamWriter (path);

            ProcessStartInfo psi = new ProcessStartInfo ();
            psi.FileName = "C:\\xampp\\mysql\\bin\\mysqldump.exe";
            psi.RedirectStandardInput = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = "--user=root --password= --database=libreria < C:\\MySqlBackup.sql";
            psi.UseShellExecute = false;

            Process process = Process.Start (psi);
            string output;
            output = process.StandardOutput.ReadToEnd ();
            file.WriteLine (output);
            process.WaitForExit ();
            file.Close ();
            process.Close ();
            //MessageBox.Show ("Back Up Successfully!", "Saved", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            return Page ();
        }
    }
}