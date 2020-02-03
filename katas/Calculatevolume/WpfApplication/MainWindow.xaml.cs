using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
/*Autor: Rajesh Murali*/

namespace WpfApplication
{
    /// <summary>
    /// How Interactions takes place on  MainWindow.xaml
    /// </summary>
    /// 
    public enum VolumeUnit { CubicFeet, CubicMeter, Barrel };

    public partial class MainWindow : Window
    {
        private const double Meter2Feet = 3.28084;
        private const long cellArea = 200 * 200;
        private const double baseDelta = 100 * Meter2Feet;
        private const double fluidContact = 3000 * Meter2Feet;
        private List<long> lVolTops = new List<long>();
        private List<string> lVolTops2 = new List<string>();
        private List<long> lVolTops3 = new List<long>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Log Files|*.log|Textfiles|*.txt|All Files|*.*";
            ofd.DefaultExt = ".txt";
            Nullable<bool> dialogOK = ofd.ShowDialog();

            if (dialogOK == true)
            {
                string sFilenames = "";
                foreach (string sFilename in ofd.FileNames)
                {
                    sFilenames += ";" + sFilename;
                }
                sFilenames = sFilenames.Substring(1);
                textBox.Text = sFilenames;
                parseVoldata(sFilenames);
                button1.IsEnabled = true;
            }

        }
        private void parseVoldata(string Filenames)
        {
            
            using (var sr = File.OpenText(Filenames))
                {
                    int i;
                    long data = 0;
                    string line;
                    const int lineRet = 16;
                    int counter = 0;
                    StringBuilder sVolTops = new StringBuilder();
                    for (i = 1; ((line = sr.ReadLine()) != null);)
                    {
                        try
                        {
                            lVolTops2 = line.Split(' ').ToList();
                            counter = counter + 1;
                        }
                        catch (ArgumentNullException e)
                        {
                            MessageBox.Show(e.Message);
                            return;
                        }
                        catch (FormatException e)
                        {
                            MessageBox.Show(e.Message);
                            return;
                        }
                        catch (OverflowException e)
                        {
                            MessageBox.Show(e.Message);
                            return;
                        }
                        if (counter > 0)
                        {
                            if (counter == 1)
                            {
                                lVolTops = lVolTops2.ConvertAll(long.Parse);
                            }
                            else
                            {
                                lVolTops3 = lVolTops2.ConvertAll(long.Parse);
                                lVolTops.AddRange(lVolTops3);
                            }
                        }
                        else
                        {
                            string postfix;

                            switch (i)
                            {
                                case 1:
                                    postfix = "st";
                                    break;
                                case 2:
                                    postfix = "nd";
                                    break;
                                case 3:
                                    postfix = "rd";
                                    break;
                                default:
                                    postfix = "th";
                                    break;
                            }

                            string fmt = string.Format("The {0}{1} line in file {2} is {3}\r\n\r\n" +
                                                       "Horizon top data cannot be less than zero!",
                                                       i, postfix, sr, data);
                            MessageBox.Show(fmt);
                            return;
                        }

                        sVolTops.Append(string.Format("{0,5}", line));
                        sVolTops.Append(i++ % lineRet != 0 ? " " : "\r\n");
                    }
                }

        }          
        private void buttoncalculate_click(object sender, RoutedEventArgs e)
        {
            VolumeUnit vu = new VolumeUnit();
            
            if (radioButton.IsChecked == true)
            {
                vu = VolumeUnit.CubicFeet;
            }
            else if (radioButton1.IsChecked == true)
            {
                vu = VolumeUnit.CubicMeter;
            }
            else
            {
                vu = VolumeUnit.Barrel;
            }

            ParameterRechnen cp = new ParameterRechnen(cellArea, baseDelta, fluidContact, vu);
            VolumeRechnen cv = new VolumeRechnen(lVolTops, ref cp);
            textBox1.Text = cv.ReVolume().ToString();
        }
        private void buttonclose_click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Close();
        }
      }
    }


