Imports System
Imports System.Net

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello One!")

        Dim sw = Stopwatch.StartNew()
        NewMethodAsync().Wait()

        sw.Stop()

        Console.WriteLine($"Hello Three! {sw.ElapsedMilliseconds()}")

        sw = Stopwatch.StartNew()
        Console.WriteLine(DoStuff1())
        Console.WriteLine(DoStuff2())
        Console.WriteLine(DoStuff3())
        Console.WriteLine(DoStuff4())
        Console.WriteLine(DoStuff5())
        sw.Stop()
        Console.WriteLine($"Hello Four! {sw.ElapsedMilliseconds()}")
    End Sub

    Private Async Function NewMethodAsync() As Task(Of String())
        Dim Processar = New List(Of Task(Of String))

        Processar.Add(Task.Run(Function() DoStuff1()))
        Processar.Add(Task.Run(Function() DoStuff2()))
        Processar.Add(Task.Run(Function() DoStuff3()))
        Processar.Add(Task.Run(Function() DoStuff4()))
        Processar.Add(Task.Run(Function() DoStuff5()))

        Console.WriteLine("Hello Two!")

        Dim resultados = Await Task.WhenAll(Processar)

        For Each resultado In resultados
            Console.WriteLine(resultado)
        Next
    End Function

    Private Function DoStuff1() As String
        Dim a As Integer
        Dim c As New WebClient()
        Dim s As String = ""
        For i = 0 To 10
            a += 1
            s = c.DownloadString("http://sapo.pt")
        Next
        a -= 10
        Return "DoStuff1 " & a.ToString() & s.Substring(0, 10)
    End Function

    Private Function DoStuff2() As String
        Return "DoStuff2"
    End Function

    Private Function DoStuff3() As String
        Dim a As Integer
        For i = 0 To 10
            a += 1
            Dim c As New WebClient()
            c.DownloadString("https://www.youtube.com/")
        Next
        a -= 10
        Return Nothing
    End Function

    Private Function DoStuff4() As String
        Dim a As Integer
        Dim c As New WebClient()
        Dim s As String = ""
        For i = 0 To 10
            a += 1
            s = c.DownloadString("https://www.publico.pt/")
        Next
        a -= 10
        Return "DoStuff4 " & a.ToString() & s.Substring(0, 10)
    End Function

    Private Function DoStuff5() As String
        Dim a As Integer
        Dim c As New WebClient()
        Dim s As String = ""
        For i = 0 To 1
            a += 1
            s = c.DownloadString("https://www.dn.pt/")
        Next
        a -= 10
        Return "DoStuff5 " & a.ToString() & s.Substring(0, 10)
    End Function
End Module
