using EnvDTE;
using FichierGenerator;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.IO;
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
        // variable to avoid recalling selectchanged event 
        private bool handleSelection = true;
        string input_path;
        string output_path;
        string name_space;
        string[] _groups;
        string[] _views;
        string[] _types;
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

            //List<string> types = fileGenerator.getAllType().ToList();
            //types.Insert(0, "Select all");
            //ElementType.ItemsSource = types;

            //List<string> groups = fileGenerator.getAllGroup().ToList();
            //groups.Insert(0, "Select all");
            //Group.ItemsSource = groups;

            //List<string> views = fileGenerator.getAllView().ToList();
            //views.Insert(0, "Select all");
            //View.ItemsSource = views;

            _types = fileGenerator.getAllType();
            _groups = fileGenerator.getAllGroup();
            _views = fileGenerator.getAllView();

            ElementType.Items.Add("Select All");
            foreach (var i in _types)
                ElementType.Items.Add(i);

            Group.Items.Add("Select All");
            foreach (var i in _groups)
                Group.Items.Add(i);

            View.Items.Add("Select All");
            foreach (var i in _views)
                View.Items.Add(i);

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
            {
                foreach (var path in selectedProjects)
                {
                    try
                    {
                        ProjectItem item = dict_path_project[path].ProjectItems.Item("FileGenerated.cs");
                        String filename = item.get_FileNames(0);
                        item.Remove(); // remove the item from project
                        System.IO.File.Delete(filename); //delete the file
                    }
                    catch{ }
                    //dict_path_project[path].ProjectItems.
                    //File.Delete(path + "FileGenerated.cs");
                    //System.Threading.Thread.Sleep(500);
                    fileGenerator.Generate(path + "FileGenerated.cs", types, groups, views, NameSpace.Text);
                    dict_path_project[path].ProjectItems.AddFromFile(path + "FileGenerated.cs");
                    //dict_path_project[path].Save(path);
                    //dict_path_project[path].DTE.ExecuteCommand("dict_path_project[path].UnloadProject", "");
                    //System.Threading.Thread.Sleep(500);
                    //dict_path_project[path].DTE.ExecuteCommand("dict_path_project[path].ReloadProject", "");
                }
            }
            else
            {
                fileGenerator.Generate(output_path, types, groups, views, NameSpace.Text);

            }

            MessageBoxResult result = System.Windows.MessageBox.Show("File generated", "Confirmation");
            this.Close();
            
        }

        private void GroupSearch_KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Group.Items.Clear();
            if (GroupSearch.Text.Length > 0)
            {
                List<string> mylist = new List<string>();
                List<string> groups = new List<string>(_groups);
                mylist = groups.FindAll(delegate (string s) { return s.ToLower().Contains(GroupSearch.Text.Trim().ToLower()); });
                foreach(var i in mylist)
                    Group.Items.Add(i);
                //Group.ItemsSource = mylist.ToArray();
                Group.IsDropDownOpen = true;
            }
            else
            {
                //Group.ItemsSource = fileGenerator.getAllGroup();
                Group.Items.Add("Select All");
                foreach (var i in _groups)
                    Group.Items.Add(i);
            }
        }

        private void ViewSearch_KeyUp_1(object sender, System.Windows.Input.KeyEventArgs e)
        {
            View.Items.Clear();
            if (ViewSearch.Text.Length > 0)
            {
                List<string> mylist = new List<string>();
                List<string> views = new List<string>(_views);
                mylist = views.FindAll(delegate (string s) { return s.ToLower().Contains(ViewSearch.Text.Trim().ToLower()); });
                foreach (var i in mylist)
                    View.Items.Add(i);
                //View.ItemsSource = mylist.ToArray();
                View.IsDropDownOpen = true;
            }
            else
            {
                //View.ItemsSource = fileGenerator.getAllGroup();
                View.Items.Add("Select All");
                foreach (var i in _views)
                    View.Items.Add(i);
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
                    box.SelectedItems.Remove("Select All");
                }
            }
        }

        private void ElementType_ItemSelectionChanged(object sender, Xceed.Wpf.Toolkit.Primitives.ItemSelectionChangedEventArgs e)
        {
            if(handleSelection)
            {
                handleSelection = false;
                ItemSelectionChanged(e, ElementType);
            }
            handleSelection = true;
        }

        private void Group_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            if (handleSelection)
            {
                handleSelection = false;
                ItemSelectionChanged(e, Group);
            }
            handleSelection = true;
        }

        private void View_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            if (handleSelection)
            {
                handleSelection = false;
                ItemSelectionChanged(e, View);
            }
            handleSelection = true;
        }
    }
}