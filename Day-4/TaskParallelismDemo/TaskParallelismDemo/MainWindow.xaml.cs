using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskParallelismDemo
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            displayMessage("Work Started");
            var task = new Task<string>(doWork);
            
            
            var task2 = task.ContinueWith((pt) =>
                {
                    Debug.WriteLine("pt id = " + pt.Id );
                    displayMessage(pt.Result);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            task.Start();
            Debug.WriteLine("task id = " + task.Id);
            Debug.WriteLine("task2 id = " + task2.Id);
           
        }

        private string doWork()
        {
            for(var i=0;i<10000;i++)
                for(var j=0;j<1000;j++)
                    for(var k=0;k<300;k++){}
            Debug.WriteLine("Task is completed");
            return "Task completed at " + DateTime.Now.ToString();
            //displayMessage("Work Completed");
        }

        private void displayMessage(string msg)
        {
            lblMessage.Content = msg;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblMessage.Content = "";
        }
    }
}
