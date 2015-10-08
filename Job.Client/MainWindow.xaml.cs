using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Job.Crawler.CrawlerAction;
using Job.DAL;
using Job.DAL.Repositories;
using Job.DAL.UnitOfWork;
using Job.Model.Entities;

namespace Job.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var job51 = new Job51();
            //var liePin = new LiePin();
            //var zhaoPin = new ZhaoPin();
            //var laGou = new LaGou();
            //List<JobInfo> crawlerJob = job51.CrawlerJob("无锡", ".net", "1");
            //List<JobInfo> jobInfos = liePin.CrawlerJob("无锡", ".net", "1");
            //List<JobInfo> infos = zhaoPin.CrawlerJob("无锡", ".net", "1");
            //List<JobInfo> list = laGou.CrawlerJob("无锡", ".net", "1");
            //var unitOfWork = new UnitOfWork<DbContextBase>();
            //unitOfWork.JobInfoRepository.AddRange(crawlerJob);
            //unitOfWork.JobInfoRepository.AddRange(jobInfos);
            //unitOfWork.JobInfoRepository.AddRange(infos);
            //unitOfWork.JobInfoRepository.AddRange(list);
            //unitOfWork.Commit();
        }


    }
}
