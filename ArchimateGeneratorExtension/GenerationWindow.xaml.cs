using EnvDTE;
using FichierGenerator;
using JR.Utils.GUI.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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
        List<string> list_type = new List<string>();
        List<string> list_group = new List<string>();
        List<string> list_view = new List<string>();
        private bool handleSelection = true;
        private bool select_all = false;
        string input_path;
        string output_path;
        string name_space;
        string[] _groups;
        string[] _views;
        string[] _types;
        string[] _elements;
        string[] _projects;
        FileGenerator fileGenerator;
        IEnumerable<Project> projects;
        Dictionary<string, Project> dict_name_project = new Dictionary<string, Project>();
        string current_solution_path;
        string current_solution_name;
        Solution solution;

        public GenerationWindow(string path_in, Dictionary<string, string> dict_implementation, string path_out, string name_space, IEnumerable<Project> projects, string current_solution_path, string current_solution_name, Solution solution)
        {
            this.solution = solution; 
            input_path = path_in;
            output_path = path_out;
            this.name_space = name_space;
            this.current_solution_path = current_solution_path;
            this.current_solution_name = current_solution_name;
            using (new WaitCursor())
            {
                // very long task
                fileGenerator = new FileGenerator(path_in, dict_implementation, current_solution_name, current_solution_path);
            }
            
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
            _projects = fileGenerator.GetProjects(solution);

            ElementType.Items.Add("Select All");
            foreach (var i in _types)
                ElementType.Items.Add(i);

            Group.Items.Add("Select All");
            foreach (var i in _groups)
                Group.Items.Add(i);

            View.Items.Add("Select All");
            foreach (var i in _views)
                View.Items.Add(i);

            Project.Items.Add("Select All");
            foreach (var i in _projects)
                Project.Items.Add(i);


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
            
            string[] types = list_type.ToArray();
            string str_types = String.Join(",", types.Select(i => i.ToString()).ToArray());
            
            string[] groups = list_group.ToArray();
            string str_groups = String.Join(",", groups.Select(i => i.ToString()).ToArray());
            
            string[] views = list_view.ToArray();
            string str_views = String.Join(",", views.Select(i => i.ToString()).ToArray());

            List<string> list_element = new List<string>();
            foreach (var i in Element.SelectedItems)
            {
                if (!i.ToString().Equals("Select All"))
                    list_element.Add(Regex.Replace(i.ToString(), @" ?\(.*?\)", string.Empty));
            }
            string[] elements = list_element.ToArray();
            string str_elements = String.Join(",", elements.Select(i => i.ToString()).ToArray());

            //List<string> list_project = new List<string>();
            //Dictionary<string, Project> dict_path_project = new Dictionary<string, Project>();
            //foreach (var i in Project.SelectedItems)
            //{
            //    var fullName = dict_name_project[i.ToString()].FullName;
            //    var project_path = fullName.Replace(fullName.Substring(fullName.LastIndexOf("\\") + 1), "");
            //    list_project.Add(project_path);
            //    dict_path_project.Add(project_path, dict_name_project[i.ToString()]);
            //}
            //string[] selectedProjects = list_project.ToArray();
            //string str_selectedProjects = String.Join(",", selectedProjects.Select(i => i.ToString()).ToArray());

            UserSettings.Default.ElementType = str_types;
            UserSettings.Default.Groups = str_groups;
            UserSettings.Default.Views = str_views;
            UserSettings.Default.Elements = str_elements;
            //UserSettings.Default.Projects_paths = str_selectedProjects;
            UserSettings.Default.Name_space = NameSpace.Text;
            UserSettings.Default.Save();

            //if (selectedProjects.Count()>0)
            //{
            //    foreach (var path in selectedProjects)
            //    {
            //        try
            //        {
            //            List<string> list_file_name = GetFilesNotInProject(dict_path_project[path]);
            //            foreach(var i in list_file_name)
            //            {
            //                ProjectItem item = dict_path_project[path].ProjectItems.Item(i);
            //                String filename = item.get_FileNames(0);
            //                item.Remove(); // remove the item from project
            //                System.IO.File.Delete(filename); //delete the file
            //            }

            //        }
            //        catch{ }
            //        fileGenerator.Generate(path, types, groups, views, elements, NameSpace.Text);
            //        IncludeNewFiles(dict_path_project[path]);
            //    }
            //}
            //else
            //{
            using (new WaitCursor())
            {
                // very long task
                fileGenerator.Generate(output_path, types, groups, views, elements, NameSpace.Text, solution);
            }
            
            //}

            FlexibleMessageBox.Show(string.Join("\n", fileGenerator.Log["errors"]), "Errors");
            FlexibleMessageBox.Show(string.Join("\n", fileGenerator.Log["warnings"]), "Warnings");
            Close();
            
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

        private void ItemSelectionChanged(ItemSelectionChangedEventArgs e, MyCheckComboBox box)
        {
            var item = e.Item;
            if (item.Equals("Select All"))
            {
                select_all = true;
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
                select_all = false;
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

            list_type.Clear();
            foreach (var i in ElementType.SelectedItems)
            {
                if (!i.ToString().Equals("Select All"))
                    list_type.Add(i.ToString());
            }

            if (select_all)
            {
                _elements = fileGenerator.getAllElements();
                Element.Items.Clear();
                foreach (var i in _elements)
                    Element.Items.Add(i + " (" + GetElementTypeByName(i) + ")");
            }
            else
            {
                UpdateGroups();
                UpdateViews();
                UpdateElements();
            }
        }

        private void UpdateElements()
        {
            _elements = fileGenerator.getElements(list_type.ToArray(), list_group.ToArray(), list_view.ToArray());
            List<string> list = _elements.ToList();
            list.Sort();
            _elements = list.ToArray();
            Element.Items.Clear();
            Element.Items.Add("Select All");
            foreach (var i in _elements)
                Element.Items.Add(i + "("+ GetElementTypeByName(i) + ")");
        }

        private string GetElementTypeByName(string name)
        {
            return fileGenerator.Dict_element.First(x => x.Value.Name_.Equals(name)).Value.Type_;
        }

        private void UpdateGroups()
        {
            _groups = fileGenerator.getGroups(list_type.ToArray());
            List<string> list = _groups.ToList();
            list.Sort();
            _groups = list.ToArray();
            Group.Items.Clear();
            Group.Items.Add("Select All");
            foreach (var i in _groups)
                Group.Items.Add(i);
        }
        private void UpdateViews()
        {
            _views = fileGenerator.getViews(list_type.ToArray());
            List<string> list = _views.ToList();
            list.Sort();
            _views = list.ToArray();
            View.Items.Clear();
            View.Items.Add("Select All");
            foreach (var i in _views)
                View.Items.Add(i);
        }

        private void Group_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            if (handleSelection)
            {
                handleSelection = false;
                ItemSelectionChanged(e, Group);
            }
            handleSelection = true;

            list_group.Clear();
            foreach (var i in Group.SelectedItems)
            {
                if (!i.ToString().Equals("Select All"))
                    list_group.Add(i.ToString());
            }

            if (select_all)
            {
                _elements = fileGenerator.getAllElements();
                Element.Items.Clear();
                foreach (var i in _elements)
                    Element.Items.Add(i + "(" + GetElementTypeByName(i) + ")");
            }
            else
                UpdateElements();
        }

        private void View_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            if (handleSelection)
            {
                handleSelection = false;
                ItemSelectionChanged(e, View);
            }
            handleSelection = true;

            list_view.Clear();
            foreach (var i in View.SelectedItems)
            {
                if (!i.ToString().Equals("Select All"))
                    list_view.Add(i.ToString());
            }

            if (select_all)
            {
                _elements = fileGenerator.getAllElements();
                Element.Items.Clear();
                foreach (var i in _elements)
                    Element.Items.Add(i + "(" + GetElementTypeByName(i) + ")");
            }
            else
                UpdateElements();
        }

        private void ElementSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Element.Items.Clear();
            if (Element.Text.Length > 0)
            {
                List<string> mylist = new List<string>();
                List<string> elements = new List<string>(_elements);
                mylist = elements.FindAll(delegate (string s) { return s.ToLower().Contains(ElementSearch.Text.Trim().ToLower()); });
                mylist.Sort();
                foreach (var i in mylist)
                    Element.Items.Add(i);
                //View.ItemsSource = mylist.ToArray();
                Element.IsDropDownOpen = true;
            }
            else
            {
                //View.ItemsSource = fileGenerator.getAllGroup();
                Element.Items.Add("Select All");
                foreach (var i in _elements)
                    Element.Items.Add(i);
            }
        }

        private void Element_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            if (handleSelection)
            {
                handleSelection = false;
                ItemSelectionChanged(e, Element);
            }
            handleSelection = true;
        }

        public static void IncludeNewFiles(Project project)
        {
            List<string> newfiles;

            newfiles = GetFilesNotInProject(project);

            foreach (var file in newfiles)
                project.ProjectItems.AddFromFile(file);
        }

        public static List<string> GetAllProjectFiles(ProjectItems projectItems, string extension)
        {
            List<string> returnValue = new List<string>();

            foreach (ProjectItem projectItem in projectItems)
            {
                for (short i = 1; i <= projectItems.Count; i++)
                {
                    string fileName = projectItem.FileNames[i];
                    if (Path.GetExtension(fileName).ToLower() == extension)
                        returnValue.Add(fileName);
                }
                returnValue.AddRange(GetAllProjectFiles(projectItem.ProjectItems, extension));
            }

            return returnValue;
        }

        public static List<string> GetFilesNotInProject(Project project)
        {
            List<string> returnValue = new List<string>();
            string startPath = Path.GetDirectoryName(project.FullName);
            List<string> projectFiles = GetAllProjectFiles(project.ProjectItems, ".cs");

            foreach (var file in Directory.GetFiles(startPath, "*.cs", SearchOption.AllDirectories))
                if (!projectFiles.Contains(file)) returnValue.Add(file);

            return returnValue;
        }

        private void ProjectSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            Project.Items.Clear();
            if (Project.Text.Length > 0)
            {
                List<string> mylist = new List<string>();
                List<string> projects = new List<string>(_projects);
                mylist = projects.FindAll(delegate (string s) { return s.ToLower().Contains(ProjectSearch.Text.Trim().ToLower()); });
                mylist.Sort();
                foreach (var i in mylist)
                    Project.Items.Add(i);
                //View.ItemsSource = mylist.ToArray();
                Project.IsDropDownOpen = true;
            }
            else
            {
                //View.ItemsSource = fileGenerator.getAllGroup();
                Project.Items.Add("Select All");
                foreach (var i in _projects)
                    Project.Items.Add(i);
            }
        }

        private void Project_ItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            if (handleSelection)
            {
                handleSelection = false;
                ItemSelectionChanged(e, Project);
            }
            handleSelection = true;
        }

        private void Generate_Projects_Click(object sender, RoutedEventArgs e)
        {
            List<string> list_project = new List<string>();
            foreach (var i in Project.SelectedItems)
            {
                if (!i.ToString().Equals("Select All"))
                    list_project.Add(i.ToString());
            }
            using (new WaitCursor())
            {
                foreach (var i in list_project)
                    fileGenerator.GenerateProject(solution, i);
            }
            fileGenerator.AddProjectReferences(solution);
        }
    }
}