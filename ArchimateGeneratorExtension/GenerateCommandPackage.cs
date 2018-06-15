using Microsoft.VisualStudio.Shell;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using System.ComponentModel;
using Task = System.Threading.Tasks.Task;
using System.Windows.Forms;

namespace ArchimateGeneratorExtension
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GenerateCommandPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideOptionPage(typeof(OptionPageGrid),
    "Archimate Generator Extension", "Custom page", 0, 0, true)]
    //[ProvideOptionPage(typeof(OptionPageCustom),
    //"Archimate Generator Extension", "Custom page", 0, 0, true)]
    public sealed class GenerateCommandPackage : AsyncPackage
    {
        /// <summary>
        /// GenerateCommandPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "beff8231-12a7-444b-9760-21a914bc02b0";

        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateCommand"/> class.
        /// </summary>
        public GenerateCommandPackage()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.
        }

        public string Output_path_
        {
            get
            {
                OptionPageGrid page = (OptionPageGrid)GetDialogPage(typeof(OptionPageGrid));
                return page.Output_path_;
            }
        }

        public string Element_type_
        {
            get
            {
                OptionPageGrid page = (OptionPageGrid)GetDialogPage(typeof(OptionPageGrid));
                return page.Element_type_;
            }
            set
            {
                OptionPageGrid page = (OptionPageGrid)GetDialogPage(typeof(OptionPageGrid));
                page.Element_type_ = value;
            }
        }
        public string Groups_
        {
            get
            {
                OptionPageGrid page = (OptionPageGrid)GetDialogPage(typeof(OptionPageGrid));
                return page.Groups_;
            }
            set
            {
                OptionPageGrid page = (OptionPageGrid)GetDialogPage(typeof(OptionPageGrid));
                page.Groups_ = value;
            }
        }
        public string Views_
        {
            get
            {
                OptionPageGrid page = (OptionPageGrid)GetDialogPage(typeof(OptionPageGrid));
                return page.Views_;
            }
            set
            {
                OptionPageGrid page = (OptionPageGrid)GetDialogPage(typeof(OptionPageGrid));
                page.Views_ = value;
            }
        }
        //#region Package Members

        ///// <summary>
        ///// Initialization of the package; this method is called right after the package is sited, so this is the place
        ///// where you can put all the initialization code that rely on services provided by VisualStudio.
        ///// </summary>
        ///// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        ///// <param name="progress">A provider for progress updates.</param>
        ///// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        //protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        //{
        //    // When initialized asynchronously, the current thread may be a background thread at this point.
        //    // Do any initialization that requires the UI thread after switching to the UI thread.
        //    await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        //    await GenerateCommand.InitializeAsync(this);
        //}

        //#endregion
    }

    public class OptionPageGrid : DialogPage
    {
        private string output_path_ = "";
        private string element_type_ = "";
        private string groups_ = "";
        private string views_ = "";

        [Category("Archimate Generator Extension")]
        [DisplayName("Output path")]
        [Description("The path of generated files")]
        public string Output_path_
        {
            get { return output_path_; }
            set { output_path_ = value; }
        }

        [Category("Archimate Generator Extension")]
        [DisplayName("Element types")]
        [Description("The selected types of element")]
        public string Element_type_ { get => element_type_; set => element_type_ = value; }

        [Category("Archimate Generator Extension")]
        [DisplayName("Groups")]
        [Description("The selected groups")]
        public string Groups_ { get => groups_; set => groups_ = value; }

        [Category("Archimate Generator Extension")]
        [DisplayName("Views")]
        [Description("The selected views")]
        public string Views_ { get => views_; set => views_ = value; }

    }

    //[Guid("00000000-0000-0000-0000-000000000000")]
    //public class OptionPageCustom : DialogPage
    //{
    //    private string output_path_ = "";

    //    public string Output_path_
    //    {
    //        get { return output_path_; }
    //        set { output_path_ = value; }
    //    }
    //    protected override IWin32Window Window
    //    {
    //        get
    //        {
    //            MyUserControl page = new MyUserControl();
    //            page.optionsPage = this;
    //            return page;
    //        }
    //    }
    //}
}
