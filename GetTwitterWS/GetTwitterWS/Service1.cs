using GetTwitterLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetTwitterWS
{
    public partial class Service1 : ServiceBase
    {
        private string arquivoErro = @"c:\LogTcc\erroTcc.txt";
        private string arquivoConexaoFechada = @"c:\LogTcc\conexaoFechada.txt";
        private string arquivoSuceso = @"c:\LogTcc\sucessoTcc.txt";
        Timer timer1;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer(new TimerCallback(GetTwitter), null, 0, 300000);
        }

        protected override void OnStop()
        {
            if (!File.Exists(arquivoConexaoFechada))
                File.Create(arquivoConexaoFechada).Close();
            using (StreamWriter vWriter = new StreamWriter(arquivoConexaoFechada, true))
            {
                vWriter.WriteLine("\n\n******************************\n");
                vWriter.WriteLine("Conexão fechada: " + DateTime.Now.ToString());
                vWriter.Flush();
                vWriter.Close();
            }
        }

        private void GetTwitter(object sender)
        {
            try
            {
                using (var getTwitter = new GetTwitter())
                {
                    getTwitter.GetCandidatos();

                    if (!File.Exists(arquivoSuceso))
                        File.Create(arquivoSuceso).Close();
                    using (StreamWriter vWriter = new StreamWriter(arquivoSuceso, true))
                    {
                        vWriter.WriteLine("\n\n******************************\n");
                        vWriter.WriteLine("Serviço executado com sucesso: " + DateTime.Now.ToString());
                        vWriter.Flush();
                        vWriter.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                if (!File.Exists(arquivoErro))
                    File.Create(arquivoErro).Close();

                using (StreamWriter vWriter = new StreamWriter(arquivoErro, true))
                {
                    vWriter.WriteLine("\n\n******************************\n");
                    vWriter.WriteLine("Erro no serviço: " + DateTime.Now.ToString());
                    vWriter.WriteLine("\n\nMensagem: " + ex.Message);
                    vWriter.Flush();
                    vWriter.Close();
                }
                
                
            }
        }

    }
}
