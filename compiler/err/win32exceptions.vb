Imports System.IO
Imports System.Text.RegularExpressions

Public Class win32exceptions
    Private errcode As String
    Public Sub New(errtext As String)
        If errtext.Contains("error code=") Then
            If Regex.IsMatch(errtext, "0x[0-9]{8}") Then
                errcode = Regex.Match(errtext, "0x[0-9]{8}").Value
                Console.WriteLine("Searching the database to provide error explanation ...")
            End If
        End If
    End Sub

    Public Sub get_description()
        If File.Exists(conrex.APPDIR & "/" & "iniopt/win32exceptions.yoda") AndAlso errcode <> conrex.NULL Then
            Dim gwin32err As String = File.ReadAllText(conrex.APPDIR & "/" & "iniopt/win32exceptions.yoda")
            Dim yodaf As New YODA.YODA_Format
            Dim ydata As YODA.YODA_Format.YODAMapFormat = yodaf.ReadYODA_Map(gwin32err)
            Dim win32errmap As New mapstoredata
            win32errmap.import_collection(ydata.keys, ydata.values)
            Dim hresult As mapstoredata.dataresult = win32errmap.find(errcode)
            If hresult.issuccessful Then
                Console.Write(vbCr & "Win32Exception [description]: native code ({0}) = {1}", errcode, hresult.result)
            Else
                Console.Write(vbCr & "There is no explanation for this error.")
            End If
        Else
            Console.Write(conrex.APPDIR & "/" & "iniopt/win32exceptions.yoda" & " , Source file not found.")
            Return
        End If
    End Sub
End Class
