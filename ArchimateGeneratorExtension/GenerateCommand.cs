using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;
using EnvDTE;
using FichierGenerator;
using System.Linq;
using System.Collections.Generic;
using Tools;

namespace ArchimateGeneratorExtension
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class GenerateCommand
    {
        string current_solution_name;
        string current_solution_path;

        Dictionary<string, string> dict_implementation = new Dictionary<string, string>();

        private static readonly string[] all_file_types = { "xml" };
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;
        public const int CommandId2 = 0x0101;
        public const int CommandId3 = 0x0102;

        //FileGenerator fileGenerator;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("8f7ede4d-9591-48df-8aee-506dc67fdba0");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly AsyncPackage package;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        /// <param name="commandService">Command service to add command to, not null.</param>
        private GenerateCommand(AsyncPackage package, OleMenuCommandService commandService)
        {

            this.package = package ?? throw new ArgumentNullException(nameof(package));
            commandService = commandService ?? throw new ArgumentNullException(nameof(commandService));

            var menuCommandID = new CommandID(CommandSet, CommandId);
            var menuItem = new MenuCommand(this.GenerateAll, menuCommandID);
            commandService.AddCommand(menuItem);

            var menuCommandID2 = new CommandID(CommandSet, CommandId2);
            var menuItem2 = new MenuCommand(this.Generate2, menuCommandID2);
            commandService.AddCommand(menuItem2);

            var menuCommandID3 = new CommandID(CommandSet, CommandId3);
            var menuItem3 = new MenuCommand(this.Generate3, menuCommandID3);
            commandService.AddCommand(menuItem3);

            GenerateCommandPackage generateCommandPackage = package as GenerateCommandPackage;
            dict_implementation.Add(ElementConstants.BusinessObject, generateCommandPackage.BusinessObjectImplementation);
            dict_implementation.Add(ElementConstants.Contract, generateCommandPackage.Contract_implementation_);
            dict_implementation.Add(ElementConstants.ApplicationEvent, generateCommandPackage.ApplicationEvent_implementation_);
            dict_implementation.Add(ElementConstants.ApplicationComponent, generateCommandPackage.ApplicationComponent_implementation_);
            dict_implementation.Add(ElementConstants.DataObject, generateCommandPackage.DataObject_implementation_);
            dict_implementation.Add(ElementConstants.ApplicationProcess, generateCommandPackage.ApplicationProcess_implementation_);
            dict_implementation.Add(ElementConstants.ApplicationService, generateCommandPackage.ApplicationService_implementation_);
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static GenerateCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private Microsoft.VisualStudio.Shell.IAsyncServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static async Task InitializeAsync(AsyncPackage package)
        {
            // Verify the current thread is the UI thread - the call to AddCommand in GenerateCommand's constructor requires
            // the UI thread.
            ThreadHelper.ThrowIfNotOnUIThread();

            OleMenuCommandService commandService = await package.GetServiceAsync((typeof(IMenuCommandService))) as OleMenuCommandService;
            Instance = new GenerateCommand(package, commandService);
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void GenerateAll(object sender, EventArgs e)
        {

            EnvDTE80.DTE2 current_DTE2 = GetDTE2();
            current_solution_path = System.IO.Path.GetDirectoryName(current_DTE2.Solution.FullName);
            current_solution_name = current_DTE2.Solution.FileName;
            string path_in = GetSourceFilePath();
            ThreadHelper.ThrowIfNotOnUIThread();
            //string message = string.Format(CultureInfo.CurrentCulture, "inside {0}.menuitemcallback()", GetType().FullName);
            string message;
            if (isCorrectFileType(path_in))
                message = "File generated";
            else
                message = "error: File type not correct";
            string title = "ArchimateGenerateExtension";

            string path_out;
            FileGenerator fileGenerator = new FileGenerator(path_in, dict_implementation, current_solution_name, current_solution_path);
            GenerateCommandPackage generateCommandPackage = package as GenerateCommandPackage;
            if (generateCommandPackage.Output_path_.Equals("") || generateCommandPackage.Output_path_ == null)
                path_out = path_in.Replace(path_in.Substring(path_in.LastIndexOf("\\") + 1), "") + "FileGenerated.cs";
            else
                path_out = generateCommandPackage.Output_path_ + "\\FileGenerated.cs";

            fileGenerator.Generate(path_out, fileGenerator.getAllType(), fileGenerator.getAllGroup(), fileGenerator.getAllView(), fileGenerator.getAllElements(), "Maidis.Vnext.");

            // show a message box to prove we were here
            VsShellUtilities.ShowMessageBox(
                this.package,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
        }

        private void Generate2(object sender, EventArgs e)
        {

            EnvDTE80.DTE2 current_DTE2 = GetDTE2();
            current_solution_path = System.IO.Path.GetDirectoryName(current_DTE2.Solution.FullName);
            current_solution_name = current_DTE2.Solution.FileName;
            ThreadHelper.ThrowIfNotOnUIThread();
            string path_in = GetSourceFilePath();
            //string message = string.Format(CultureInfo.CurrentCulture, "inside {0}.menuitemcallback()", GetType().FullName);
            string message;
            if (isCorrectFileType(path_in))
            {
                ShowGenerationWindow();
            }
            else
            {
                message = "error: File type not correct";
                string title = "ArchimateGenerateExtension";

                // show a message box to prove we were here
                VsShellUtilities.ShowMessageBox(
                    this.package,
                    message,
                    title,
                    OLEMSGICON.OLEMSGICON_INFO,
                    OLEMSGBUTTON.OLEMSGBUTTON_OK,
                    OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);
                
            }
                
        }

        private void Generate3(object sender, EventArgs e)
        {
            string path_in = GetSourceFilePath();
            ThreadHelper.ThrowIfNotOnUIThread();
            //string message = string.Format(CultureInfo.CurrentCulture, "inside {0}.menuitemcallback()", GetType().FullName);
            string message;
            if (isCorrectFileType(path_in))
                message = "File generated with the former setting";
            else
                message = "error: File type not correct";
            string title = "ArchimateGenerateExtension";

            // show a message box to prove we were here
            VsShellUtilities.ShowMessageBox(
                this.package,
                message,
                title,
                OLEMSGICON.OLEMSGICON_INFO,
                OLEMSGBUTTON.OLEMSGBUTTON_OK,
                OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST);

            string path_out;
            FileGenerator fileGenerator = new FileGenerator(path_in, dict_implementation, current_solution_name, current_solution_path);
            GenerateCommandPackage generateCommandPackage = package as GenerateCommandPackage;
            if (generateCommandPackage.Output_path_.Equals("") || generateCommandPackage.Output_path_ == null)
                path_out = path_in.Replace(path_in.Substring(path_in.LastIndexOf("\\") + 1), "") + "FileGenerated.cs";
            else
                path_out = generateCommandPackage.Output_path_ + "\\FileGenerated.cs";

            string str_types = UserSettings.Default.ElementType;
            string str_groups = UserSettings.Default.Groups;
            string str_views = UserSettings.Default.Views;
            string str_elements = UserSettings.Default.Elements;
            //string str_projects_paths = UserSettings.Default.Projects_paths;
            string name_space = UserSettings.Default.Name_space;

            string[] element_types = str_types.Length>0 ? str_types.Split(',').ToList().ToArray() : null;
            string[] groups = str_groups.Length>0 ? str_groups.Split(',').ToList().ToArray() : null;
            string[] views = str_views.Length>0 ? str_views.Split(',').ToList().ToArray() : null;
            string[] elements = str_elements.Length > 0 ? str_elements.Split(',').ToList().ToArray() : null;
            //string[] projects_paths = str_projects_paths.Length > 0 ? str_projects_paths.Split(',').ToList().ToArray() : null;

            var projects = GetProjects();
            Dictionary<string, Project> dict_path_project = new Dictionary<string, Project>();
            foreach(var p in projects)
            {
                var fullName = p.FullName;
                var project_path = fullName.Replace(fullName.Substring(fullName.LastIndexOf("\\") + 1), "");
                dict_path_project.Add(project_path, p);
            }

            //if (str_projects_paths.Length==0)
            //{
            fileGenerator.Generate(path_out, element_types, groups, views, elements, name_space);
            //}
            //else
            //{
            //    foreach(var path in projects_paths)
            //    {
            //        fileGenerator.Generate(path + "FileGenerated.cs", element_types, groups, views, elements, name_space);
            //        dict_path_project[path].ProjectItems.AddFromFile(path + "FileGenerated.cs");
            //    }
            //}
        }


        private static EnvDTE80.DTE2 GetDTE2()
        {
            return Package.GetGlobalService(typeof(DTE)) as EnvDTE80.DTE2;
        }

        private static DTE GetDTE()
        {
            return Package.GetGlobalService(typeof(DTE)) as DTE;
        }

        private string GetSourceFilePath()
        {
            EnvDTE80.DTE2 _applicationObject = GetDTE2();
            UIHierarchy uih = _applicationObject.ToolWindows.SolutionExplorer;
            Array selectedItems = (Array)uih.SelectedItems;
            if (null != selectedItems)
            {
                foreach (UIHierarchyItem selItem in selectedItems)
                {
                    ProjectItem prjItem = selItem.Object as ProjectItem;
                    string filePath = prjItem.Properties.Item("FullPath").Value.ToString();
                    //System.Windows.Forms.MessageBox.Show(selItem.Name + filePath);
                    return filePath;
                }
            }
            return string.Empty;
        }

        private void ShowGenerationWindow()
        {
            GenerateCommandPackage generateCommandPackage = package as GenerateCommandPackage;
            var generationControl = new GenerationWindow(GetSourceFilePath(), dict_implementation, generateCommandPackage.Output_path_ + "\\FileGenerated.cs", generateCommandPackage.Name_space_, GetProjects(), current_solution_path, current_solution_name, GetDTE().Solution);
            generationControl.ShowModal();
        }

        private bool isCorrectFileType(string file_name)
        {
            string file_type = file_name.Substring(file_name.LastIndexOf('.')+1);
            return all_file_types.Contains(file_type);
        }

        private IEnumerable<Project> GetProjects()
        {
            EnvDTE80.DTE2 _applicationObject = GetDTE2();
            return _applicationObject.Solution.Projects.Cast<Project>();
        }
    }
}