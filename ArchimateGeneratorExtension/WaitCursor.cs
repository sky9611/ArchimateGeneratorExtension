using System;
using System.Windows.Forms;
using System.Windows.Input;

public class WaitCursor : IDisposable
{
    private System.Windows.Input.Cursor _previousCursor;

    public WaitCursor()
    {
        _previousCursor = Mouse.OverrideCursor;

        Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
    }

    #region IDisposable Members

    public void Dispose()
    {
        Mouse.OverrideCursor = _previousCursor;
    }

    #endregion
}