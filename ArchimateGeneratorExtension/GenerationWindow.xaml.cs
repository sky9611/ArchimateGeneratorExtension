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

namespace ArchimateGeneratorExtension
{
    /// <summary>
    /// Interaction logic for GenerationWindow.xaml
    /// </summary>
    public partial class GenerationWindow
    {
        string input_path;
        string output_path;
        public GenerationWindow(string path_in, string path_out)
        {
            input_path = path_in;
            output_path = path_out;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Domain_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            string path_out;
            if (output_path.Equals("") || output_path == null)
                path_out = input_path.Replace(input_path.Substring(input_path.LastIndexOf("\\") + 1), "") + "FileGenerated.cs";
            else
                path_out = output_path + "\\FileGenerated.cs";

            FichierGenerator.Program.Generate(input_path, path_out);
        }
    }
}
