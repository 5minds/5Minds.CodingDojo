using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BerlinClock
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i_hours;
        int i_minutes;

        List<TextBlock> hours5 = new List<TextBlock>();
        List<TextBlock> hours = new List<TextBlock>();
        List<TextBlock> minutes5 = new List<TextBlock>();
        List<TextBlock> minutes = new List<TextBlock>();

        int listIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            BuildLists();
            ShowTime();
        }


        private void BuildLists()
        {
            hours5.Add(tb_5Hours1);
            hours5.Add(tb_5Hours2);
            hours5.Add(tb_5Hours3);
            hours5.Add(tb_5Hours4);

            hours.Add(tb_Hours1); 
            hours.Add(tb_Hours2);
            hours.Add(tb_Hours3);
            hours.Add(tb_Hours4);

            minutes5.Add(tb_5Minutes1);
            minutes5.Add(tb_5Minutes2);
            minutes5.Add(tb_5Minutes3);
            minutes5.Add(tb_5Minutes4);
            minutes5.Add(tb_5Minutes5);
            minutes5.Add(tb_5Minutes6);
            minutes5.Add(tb_5Minutes7);
            minutes5.Add(tb_5Minutes8);
            minutes5.Add(tb_5Minutes9);
            minutes5.Add(tb_5Minutes10);
            minutes5.Add(tb_5Minutes11);

            minutes.Add(tb_Minutes1);
            minutes.Add(tb_Minutes2);
            minutes.Add(tb_Minutes3);
            minutes.Add(tb_Minutes4);
        }

        private void ShowTime()
        {
            DateTime time = DateTime.Now;

            i_hours = time.Hour;
            i_minutes = time.Minute;

            if(time.Second % 2 == 0)
            {
                tb_Second.Background = Brushes.Yellow;
            }
            else
            {
                tb_Second.Background = Brushes.White;
            }

            listIndex = 0;
            while(i_hours >= 5)
            {
                hours5[listIndex].Background = Brushes.Red;
                listIndex++;
                i_hours -= 5;
            }
            for (int i = 0; i < i_hours; i++)
            {
                hours[i].Background = Brushes.Red;
            }

            listIndex = 0;
            while(i_minutes >= 5)
            {
                if(listIndex == 2 || listIndex == 5 || listIndex == 8)
                {
                    minutes5[listIndex].Background = Brushes.Red;
                    listIndex++;
                    i_minutes -= 5;
                }
                else
                {
                    minutes5[listIndex].Background = Brushes.Yellow;
                    listIndex++;
                    i_minutes -= 5;
                }
            }
            for (int i = 0; i < i_minutes; i++)
            {
                minutes[i].Background = Brushes.Yellow;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowTime();
        }

    }
}
