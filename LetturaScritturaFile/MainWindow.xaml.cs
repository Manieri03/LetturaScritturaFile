using System;
using System.Collections.Generic;
using System.IO;
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

namespace LetturaScritturaFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    ///</summary>
    public partial class MainWindow : Window
    {

        Random random = new Random();
        string file = @"stato.txt";
        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(file))
                using (System.IO.StreamReader reader = new System.IO.StreamReader(file))
                {
                    string line = reader.ReadLine();
                    txtn.Text = $"{line}";
                    int[] array = new int[int.Parse(line)];
                    while ((line = reader.ReadLine()) != null)
                    {
                        lblrisultato.Content += $"{line},";
                    }
                }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int n = int.Parse(txtn.Text);
            int[] array = new int[n];
            
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1,100);
            }

            lblrisultato.Content+= "[";

            for (int i = 0; i < array.Length; i++)
            {
                if (i <= array.Length-2)
                {
                    lblrisultato.Content += $" {array[i]}, ";
                }
                else
                {
                    lblrisultato.Content += $" {array[i]} ";
                }
                
            }
            lblrisultato.Content += "]";

            
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(array.Length);

            for(int i=0;i<array.Length;i++)
            {
                sw.WriteLine(array[i]);
            }
            sw.Flush();
            sw.Close();

        }
        
    }
}
