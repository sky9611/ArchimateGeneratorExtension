using FichierGenerator;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tools;

namespace ArchimateGeneratorExtension
{
    /// <summary>
    /// Interaction logic for SolutionGenerationWindow.xaml
    /// </summary>
    public partial class SolutionGenerationWindow
    {
        FileGenerator fileGenerator;
        string[] solutions;

        public SolutionGenerationWindow(string path_out)
        {
            InitializeComponent();
            SolutionPath.Text = path_out;
        }

        private void SolutionName_ItemSelectionChanged(object sender, Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e)
        {

        }

        private void SolutionSearch_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> list_selected_solution = new List<string>();
            foreach (var i in SolutionName.SelectedItems)
            {
                // Display wait cursor
                using (new WaitCursor())
                {
                    fileGenerator.GenerateSolution(@SolutionPath.Text, i.ToString());
                }

                // Copy the XML to the solution folder
                File.Copy(@XMLPath.Text, Path.Combine(Path.Combine(Path.Combine(@SolutionPath.Text, StringHelper.UpperString(i.ToString())), StringHelper.UpperString(i.ToString())), Path.GetFileName(@XMLPath.Text)));
            }
        }

        private void XMLPath_LostFocus(object sender, RoutedEventArgs e)
        {
            // Display wait cursor
            using (new WaitCursor())
            {
                if (XMLPath.Text.Length > 0)
                {
                    fileGenerator = new FileGenerator(@XMLPath.Text, new Dictionary<string, string>(), "", "", null);

                    solutions = fileGenerator.getAllSolutions();

                    int n = solutions.Length;

                    foreach (var i in solutions)
                        SolutionName.Items.Add(i);
                }
                    
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog browse = new System.Windows.Forms.OpenFileDialog();
            browse.ShowDialog();
            XMLPath.Text = browse.FileName;
            XMLPath.Focus();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog browse = new System.Windows.Forms.FolderBrowserDialog();
            browse.ShowDialog();
            SolutionPath.Text = browse.SelectedPath;
            XMLPath.Focus();
        }
    }
}
