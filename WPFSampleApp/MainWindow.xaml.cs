using AutoUpdaterDotNET;
using System;
using System.Configuration;
using System.Reflection;
using System.Windows;
using Upgrades.Models;
using Upgrades.Services;

namespace WPFSampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            textblockVersionNumber.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            IProjectRepository projectRepository = GetProjectsRepository();
            var latestProjectOnServer = projectRepository.GetLatestProjectInfoById(Convert.ToInt64(ConfigurationManager.AppSettings["projectId"]));
            if (latestProjectOnServer.LatestAssemblyVersionNumber != assemblyVersion)
            {
                AutoUpdater.Start(latestProjectOnServer.AutoUpdaterXMLPath);
            }
            else
            {
                MessageBox.Show("This project is up to date!");
            }
        }

        private IProjectRepository GetProjectsRepository()
        {
           return new ProjectRepository(
                new Options()
                {
                    APICredentials = new APICredentials()
                    {
                        Username = ConfigurationManager.AppSettings["upgradeUsername"],
                        Password = ConfigurationManager.AppSettings["upgradePassword"]
                    },
                    AuthBaseUrl = ConfigurationManager.AppSettings["authBaseUrl"],
                    ProjectBaseUrl = ConfigurationManager.AppSettings["projectsBaseUrl"]
                }
            );
        }
    }
}
