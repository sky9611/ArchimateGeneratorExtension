using FichierGenerator;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
                fileGenerator.GenerateSolution(@SolutionPath.Text, i.ToString());

        }

        private void XMLPath_LostFocus(object sender, RoutedEventArgs e)
        {
            if (XMLPath.Text.Length>0)
                fileGenerator = new FileGenerator(XMLPath.Text, new Dictionary<string, string>(), "", "");

            solutions = fileGenerator.getAllSolutions();
            foreach (var i in solutions)
                SolutionName.Items.Add(i);
        }
    }
}
