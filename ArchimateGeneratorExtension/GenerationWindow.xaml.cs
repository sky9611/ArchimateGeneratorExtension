using FichierGenerator;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ArchimateGeneratorExtension
{
    /// <summary>
    /// Interaction logic for GenerationWindow.xaml
    /// </summary>
    public partial class GenerationWindow
    {
        string input_path;
        string output_path;
        FileGenerator fileGenerator;
        GenerateCommandPackage generateCommandPackage;

        public GenerationWindow(string path_in, ref GenerateCommandPackage generateCommandPackage)
        {
            input_path = path_in;
            output_path = generateCommandPackage.Output_path_;
            fileGenerator = new FileGenerator(path_in);
            this.generateCommandPackage = generateCommandPackage;
            InitializeComponent();
            ElementType.ItemsSource = fileGenerator.getAllType();
            Group.ItemsSource = fileGenerator.getAllGroup();
            View.ItemsSource = fileGenerator.getAllView();
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

            List<string> list_type = new List<string>();
            foreach(var i in ElementType.SelectedItems)
            {
                list_type.Add(i.ToString());
            }
            string[] types = list_type.ToArray();
            string str_types = String.Join(",", types.Select(i => i.ToString()).ToArray());

            List<string> list_group = new List<string>();
            foreach (var i in Group.SelectedItems)
            {
                list_type.Add(i.ToString());
            }
            string[] groups = list_group.ToArray();
            string str_groups = String.Join(",", groups.Select(i => i.ToString()).ToArray());

            List<string> list_view = new List<string>();
            foreach (var i in View.SelectedItems)
            {
                list_type.Add(i.ToString());
            }
            string[] views = list_view.ToArray();
            string str_views = String.Join(",", views.Select(i => i.ToString()).ToArray());

            //generateCommandPackage.Element_type_ = str_types;
            //generateCommandPackage.Groups_ = str_groups;
            //generateCommandPackage.Views_ = str_views;
            fileGenerator.Generate(path_out, types, groups, views);
        }
    }
}
