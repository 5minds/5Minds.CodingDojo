using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;

namespace AntGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int FIELD_SIZE = 32;

        private List<Rectangle> fieldRectangles;
        private Queue<string> steps;

        private int boardSize;

        private DispatcherTimer stepTimer;

        public MainWindow()
        {
            InitializeComponent();

            stepTimer = new DispatcherTimer();
            stepTimer.Tick += StepTimer_Tick;
        }

        private void DrawBoard(string stepLine)
        {
            var stepBoard = new List<string>(stepLine.Split(','));

            for (int i = 0; i < stepBoard.Count; i++)
            {
                var fieldColor = stepBoard[i];
                var antDir = "";

                if (stepBoard[i].Length == 2)
                {
                    antDir = stepBoard[i][0].ToString();
                    fieldColor = stepBoard[i][1].ToString();
                }

                if (!string.IsNullOrEmpty(antDir))
                {
                    Canvas.SetTop(imgAnt, Canvas.GetTop(fieldRectangles[i]));
                    Canvas.SetLeft(imgAnt, Canvas.GetLeft(fieldRectangles[i]));

                    switch (antDir)
                    {
                        case "n":
                            imgAnt.RenderTransform = new RotateTransform(0);
                            break;
                        case "o":
                            imgAnt.RenderTransform = new RotateTransform(90);
                            break;
                        case "s":
                            imgAnt.RenderTransform = new RotateTransform(180);
                            break;
                        case "w":
                            imgAnt.RenderTransform = new RotateTransform(270);
                            break;
                        default:
                            break;
                    }

                    imgAnt.Visibility = Visibility.Visible;
                }

                if (fieldColor == "w")
                {
                    fieldRectangles[i].Fill = Brushes.White;
                }
                else if (fieldColor == "s")
                {
                    fieldRectangles[i].Fill = Brushes.Black;
                }
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Please enter filename");
                return false;
            }

            if (!File.Exists(txtFileName.Text))
            {
                MessageBox.Show(string.Format("Can't read file {0}", txtFileName.Text));
                return false;
            }

            if (string.IsNullOrEmpty(txtStepDelay.Text))
            {
                MessageBox.Show("Please enter step delay");
                return false;
            }

            if (!double.TryParse(txtStepDelay.Text, out _))
            {
                MessageBox.Show("Please enter valid number for step delay");
                return false;
            }

            return true;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtFileName.Text = openFileDialog.FileName;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput()) return;

            steps = new Queue<string>(File.ReadAllLines(txtFileName.Text));

            stepTimer.Interval = TimeSpan.FromSeconds(double.Parse(txtStepDelay.Text));

            boardSize = (int)Math.Sqrt(steps.Peek().Split(',').Count());

            // If Canvas is already populated, clear the old rectangles
            if (fieldRectangles != null && fieldRectangles.Any())
            {
                foreach (var rect in fieldRectangles)
                {
                    canvasBoard.Children.Remove(rect);
                }

                fieldRectangles.Clear();
            }

            // Populate the Canvas with rectangles to represent the board fields
            fieldRectangles = new List<Rectangle>();

            for (int y = 0; y < boardSize; y++)
            {
                for (int x = 0; x < boardSize; x++)
                {
                    var rect = new Rectangle
                    {
                        Width = FIELD_SIZE,
                        Height = FIELD_SIZE,
                        Stroke = Brushes.Black,
                        StrokeThickness = 1,
                        Fill = Brushes.White
                    };

                    canvasBoard.Children.Add(rect);
                    fieldRectangles.Add(rect);
                    Canvas.SetTop(rect, FIELD_SIZE * y);
                    Canvas.SetLeft(rect, FIELD_SIZE * x);
                    Panel.SetZIndex(rect, 0);
                }
            }

            btnStart.IsEnabled = false;
            stepTimer.Start();
        }

        private void StepTimer_Tick(object sender, EventArgs e)
        {
            if (steps.Any())
            {
                DrawBoard(steps.Dequeue());
            }
            else
            {
                stepTimer.Stop();
                btnStart.IsEnabled = true;
            }
        }
    }
}
