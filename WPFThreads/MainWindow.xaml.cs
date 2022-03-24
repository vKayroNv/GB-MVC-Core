using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
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

namespace WPFThreads
{
    public partial class MainWindow : Window
    {
        private Thread _fibonacciThread;

        private static volatile bool _isWorking = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_fibonacciThread != null && _fibonacciThread.IsAlive)
            {
                _isWorking = false;

                if (!_fibonacciThread.Join(5000))
                {
                    _fibonacciThread.Interrupt();
                }
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (_fibonacciThread == null || !_fibonacciThread.IsAlive)
            {
                StartButton.Content = "Стоп";

                fieldFibonacci.Text = string.Empty;

                _isWorking = true;

                _fibonacciThread = new(() =>
                {
                    var timerText = Dispatcher.Invoke(() => TimerText.Text);
                    Fibonacci(int.Parse(timerText));
                });

                _fibonacciThread.Start();
            }
            else
            {
                StartButton.Content = "Запуск";

                _isWorking = false;
            }
        }

        private void Fibonacci(int timer)
        {
            try
            {
                BigInteger a = 0, b = 1;
                Dispatcher.Invoke(() => fieldFibonacci.Text += $"{a} ");
                Thread.Sleep(timer * 1000);
                Dispatcher.Invoke(() => fieldFibonacci.Text += $"{b} ");
                Thread.Sleep(timer * 1000);

                while (_isWorking)
                {
                    BigInteger c = a + b;
                    a = b;
                    b = c;

                    Dispatcher.Invoke(() => fieldFibonacci.Text += $"{c} ");

                    Thread.Sleep(timer * 1000);
                }
            }
            catch (ThreadInterruptedException)
            {
                Console.WriteLine("Поток был прерван");
            }
        }
    }
}
