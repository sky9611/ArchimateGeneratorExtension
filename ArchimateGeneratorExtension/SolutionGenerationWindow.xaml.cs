using FichierGenerator;
using JR.Utils.GUI.Forms;
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
            if (SolutionName.SelectedItems.Count > 0)
                Generate.IsEnabled = true;
            else
                Generate.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnvDTE.DTE dte = null;
            List<string> list_selected_solution = new List<string>();
            foreach (var i in SolutionName.SelectedItems)
            {
                // Display wait cursor
                using (new WaitCursor())
                {
                    dte = fileGenerator.GenerateSolution(@SolutionPath.Text, i.ToString());
                }
                string file_path = Path.GetFullPath(Path.Combine(Path.Combine(Path.Combine(@SolutionPath.Text, StringHelper.UpperString(i.ToString())), StringHelper.UpperString(i.ToString())), Path.GetFileName(@XMLPath.Text)));
                // Copy the XML to the solution folder
                File.Copy(@XMLPath.Text, file_path);
                // Add to project
                System.Threading.Thread.Sleep(1000);
                // Unexpectiong error: Error HRESULT E_FAIL has been returned from a call to a COM component
                EnvDTE.Project project = fileGenerator.GetProjectByName(dte.Solution, StringHelper.UpperString(i.ToString()));
                project.ProjectItems.AddFromFile(file_path);
                //project.ProjectItems.AddFromFile(@"D:\documents\INSA\maidis\vs\Projet\FichierGenerator\FichierGenerator\lib\MODELE_VNEXT.xml");
                
            }
            dte.Quit();
            FlexibleMessageBox.Show("Solution generated successfully", "Message");
            
            Close();
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

                    SolutionName.Items.Clear();
                    foreach (var i in solutions)
                        SolutionName.Items.Add(i);

                    if (SolutionName.Items.Count == 0)
                    {
                        Solution_TextBlock.Visibility = Visibility.Hidden;
                        SolutionName.Visibility = Visibility.Hidden;
                    }
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
