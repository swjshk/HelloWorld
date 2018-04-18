Imports System.IO
Imports Newtonsoft

Module Module1

    Sub Main()
        'Console.WriteLine("hello world!")
        Dim a As List(Of String) = findfiles("C:\FO")
        For Each file_name In a
            Console.WriteLine(file_name)
        Next


        Dim b As Person_Info = New Person_Info
        b.Name = "Max"
        b.age = "30"

        Dim json_string As String = Json.JsonConvert.SerializeObject(b)

        Console.WriteLine(json_string)
        File.WriteAllText("c:\FO\Test.txt", json_string)
        Console.Write("press any key")
        Console.ReadKey(True)

    End Sub

    Public Function findfiles(path As String)

        'path = path.Substring(0, path.Length - 22)
        Dim di As DirectoryInfo = New DirectoryInfo(path)
        Dim di_json As String = Json.JsonConvert.SerializeObject(di)
        File.WriteAllText("c:\FO\Test_di.txt", di_json)
        Dim files As New List(Of String)
        For Each fi In di.GetFiles()
            Dim filename As String = fi.Name.ToString
            Dim fi_json As String = Json.JsonConvert.SerializeObject(fi)
            Console.WriteLine(fi_json)
            files.Add(filename)
        Next

        Return files
    End Function

    Public Class Person_Info
        Public Name As String
        Public age As String
    End Class

End Module

