using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenesisChallenge.Repository;
using Unity;

namespace GenesisChallenge
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICustomerRepository, CustomerRepository>();

            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainWindow>());
        }

        static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show($"CurrentDomain_UnhandledException: {e.ExceptionObject}");
        }

        static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show($"Application_ThreadException: {e.Exception.Message}");
        }
    }
}
