Imports System.Windows.Forms

Module Program
    <STAThread()>
    Public Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Try
            Application.Run(New frmLogin())
        Catch ex As Exception
            MessageBox.Show("VDMS could not start: " & ex.Message, "Error")
        End Try
    End Sub
End Module
