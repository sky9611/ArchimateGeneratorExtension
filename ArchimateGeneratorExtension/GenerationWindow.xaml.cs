using EnvDTE;
using FichierGenerator;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Primitives;

namespace ArchimateGeneratorExtension
{
    public class MyCheckComboBox : CheckComboBox
    {
        protected override void UpdateText()
        {
            // Do not display the “Select All” in the TextBox.
            var selectedItemsList = this.SelectedItems.Cast<object>().Select(x => this.GetItemDisplayValue(x)).Where(x => !x.Equals("Select All"));

            var newValue = String.Join(this.Delimiter, selectedItemsList);
            if (String.IsNullOrEmpty(this.Text) || !this.Text.Equals(newValue))
            {
                this.SetCurrentValue(CheckComboBox.TextProperty, newValue);
            }
        }
    }
    /// <summary>
    /// Interaction logic for GenerationWindow.xaml
    /// </summary>
    public partial class GenerationWindow
    {
        string input_path;
        string output_path;
        string name_space;
        FileGenerator fileGenerator;
        IEnumerable<Project> projects;
        Dictionary<string, Project> dict_name_project = new Dictionary<string, Project>();

        public GenerationWindow(string path_in, string path_out, string name_space, IEnumerable<Project> projects)
        {
            input_path = path_in;
            output_path = path_out;
            this.name_space = name_space;
            
            fileGenerator = new FileGenerator(path_in);
            this.projects = projects;
            InitializeComponent();

            NameSpace.Text = name_space;
            List<string> types = fileGenerator.getAllType().ToList();
            types.Insert(0, "Select all");
            ElementType.ItemsSource = types;

            List<string> groups = fileGenerator.getAllGroup().ToList();
            groups.Insert(0, "Select all");
            Group.ItemsSource = groups;

            List<string> views = fileGenerator.getAllView().ToList();
            views.Insert(0, "Select all");
            View.ItemsSource = views;

            List<string> list_project_name = new List<string>(); 
            foreach(var p in projects)
            {
                list_project_name.Add(p.Name);
                dict_name_project.Add(p.Name, p);
            }
            Project.ItemsSource = list_project_name;
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
            if (output_path == null || output_path.Equals(""))
                path_out = input_path.Replace(input_path.Substring(input_path.LastIndexOf("\\") + 1), "") + "FileGenerated.cs";
            else
                path_out = output_path + "\\FileGenerated.cs";

            List<string> list_type = new List<string>();
            foreach (var i in ElementType.SelectedItems)
            {
                if(!i.ToString().Equals("Select All"))
                    list_type.Add(i.ToString());
            }
            string[] types = list_type.ToArray();
            string str_types = String.Join(",", types.Select(i => i.ToString()).ToArray());

            List<string> list_group = new List<string>();
            foreach (var i in Group.SelectedItems)
            {
                if (!i.ToString().Equals("Select All"))
                    list_group.Add(i.ToString());
            }
            string[] groups = list_group.ToArray();
            string str_groups = String.Join(",", groups.Select(i => i.ToString()).ToArray());

            List<string> list_view = new List<string>();
            foreach (var i in View.SelectedItems)
            {
                if (!i.ToString().Equals("Select All"))
                    list_view.Add(i.ToString());
            }
            string[] views = list_view.ToArray();
            string str_views = String.Join(",", views.Select(i => i.ToString()).ToArray());

            List<string> list_project = new List<string>();
            Dictionary<string, Project> dict_path_project = new Dictionary<string, Project>();
            foreach (var i in Project.SelectedItems)
            {
                var fullName = dict_name_project[i.ToString()].FullName;
                var project_path = fullName.Replace(fullName.Substring(fullName.LastIndexOf("\\") + 1), "");
                list_project.Add(project_path);
                dict_path_project.Add(project_path, dict_name_project[i.ToString()]);
            }
            string[] selectedProjects = list_project.ToArray();
            string str_selectedProjects = String.Join(",", selectedProjects.Select(i => i.ToString()).ToArray());

            UserSettings.Default.ElementType = str_types;
            UserSettings.Default.Groups = str_groups;
            UserSettings.Default.Views = str_views;
            UserSettings.Default.Projects_paths = str_selectedProjects;
            UserSettings.Default.Name_space = NameSpace.Text;
            UserSettings.Default.Save();

            if (selectedProjects.Count()>0)
                foreach(var path in selectedProjects)
                {
                    fileGenerator.Generate(path + "FileGenerated.cs", types, groups, views, NameSpace.Text);
                    dict_path_project[path].ProjectItems.AddFromFile(path + "FileGenerated.cs");
                    //dict_path_project[path].
                }
            else
                fileGenerator.Generate(output_path, types, groups, views, NameSpace.Text);
        }

        private void GroupSearch_KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (GroupSearch.Text.Length > 0)
            {
                List<string> mylist = new List<string>();
                List<string> groups = new List<string>(fileGenerator.getAllGroup());
                mylist = groups.FindAll(delegate (string s) { return s.ToLower().Contains(GroupSearch.Text.Trim().ToLower()); });
                foreach(var i in mylist)
                {

                }
                Group.ItemsSource = mylist.ToArray();
                Group.IsDropDownOpen = true;
            }
            else
            {
                Group.ItemsSource = fileGenerator.getAllGroup();
            }
        }

        private void ViewSearch_KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (ViewSearch.Text.Length > 0)
            {
                List<string> mylist = new List<string>();
                List<string> views = new List<string>(fileGenerator.getAllView());
                mylist = views.FindAll(delegate (string s) { return s.ToLower().Contains(ViewSearch.Text.Trim().ToLower()); });
                View.ItemsSource = mylist.ToArray();
                View.IsDropDownOpen = true;
            }
            else
            {
                View.ItemsSource = fileGenerator.getAllGroup();
            }
        }

        private void NameSpace_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ItemSelectionChanged(ItemSelectionChangedEventArgs e, MyCheckComboBox box)
        {
            var item = e.Item;
            if (item.Equals("Select All"))
            {
                // Select All
                if (e.IsSelected)
                {
                    foreach (var data in box.Items)
                    {
                        var selectorItem = box.ItemContainerGenerator.ContainerFromItem(data) as SelectorItem;
                        if ((selectorItem != null) && !selectorItem.IsSelected)
                        {
                            box.SelectedItems.Add(data);
                        }
                    }
                }
                else
                {
                    for (int i = box.SelectedItems.Count - 1; i >= 0; i--)
                        box.SelectedItems.RemoveAt(i);
                }
            }
            else
            {
                // UnSelect an item => make sure the “Select All” option is not selected.
                if (!e.IsSelected)
                {
                    Group.SelectedItems.Remove("Select All");
                }
            }
        }

        private void ElementType_ItemSelectionChanged(object sender, Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e)
        {
            ItemSelectionChanged(e, ElementType); 
        }

        private void Group_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            ItemSelectionChanged(e, Group);
        }

        private void View_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            ItemSelectionChanged(e, View);
        }
    }
}