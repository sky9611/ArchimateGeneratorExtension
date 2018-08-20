using Microsoft.VisualStudio.PlatformUI;

namespace ArchimateGeneratorExtension
{
    public class BaseDialogWindow : DialogWindow
    {
        public BaseDialogWindow()
        {
            this.HasMaximizeButton = true;
            this.HasMinimizeButton = true;
        }

    }
}
