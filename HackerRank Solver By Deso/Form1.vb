Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Threading

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim xstart As Thread = New Thread(AddressOf get_data) : xstart.Start()
    End Sub
    Function get_ans(str As String)
        Try
            Label1.Text = "Status: Geting Answer..."
            Label1.ForeColor = Color.Yellow
            Dim reg As String = Regex.Match(str, "<code class=""language-python"">([^<]*)</code>").Groups(1).Value
            Dim ans = reg.Replace("&lt;", "<").Replace("&gt;", ">")
            TextBox2.Text = ans
            Label1.Text = "Status: This is the answer"
            Label1.ForeColor = Color.Lime
        Catch ex As Exception
            Label1.Text = "Status: Error In Getting ans."
            Label1.ForeColor = Color.Red
        End Try
    End Function
    Sub get_data()
        Try
            Label1.Text = "Status: Geting Data..."
            Label1.ForeColor = Color.Yellow
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create("https://www.thepoorcoder.com/hackerrank-" + TextBox1.Text.Replace(" ", "-") + "-solution/"), HttpWebRequest)
            httpWebRequest.Proxy = Nothing
            httpWebRequest.Method = "GET"
            httpWebRequest.Headers.Add("Cookie", "__cfduid=d1b1f8190e97795255ee82588af04367a1601746428; ezepvv=0; lp_200442=https://www.thepoorcoder.com/hackerrank-arrays-introduction-solution/; ezCMPCCS=true; __utma=189523054.621902181.1601746483.1601746483.1601746483.1; __utmz=189523054.1601746483.1.1.utmcsr=hackerrank.com|utmccn=(referral)|utmcmd=referral|utmcct=/; __utmc=189523054; ezds=ffid%3D1%2Cw%3D1536%2Ch%3D864; _ga=GA1.2.621902181.1601746483; _gid=GA1.2.1089439417.1601746484; id5id.1st=%7B%22ID5ID%22%3A%22ID5-ZHMOcgv3hHfLghBCQRA-nBO4fGzrNuDGaWeLB1r1cw%22%2C%22ID5ID_CREATED_AT%22%3A%222020-08-03T20%3A11%3A08Z%22%2C%22ID5_CONSENT%22%3Atrue%2C%22CASCADE_NEEDED%22%3Atrue%2C%22ID5ID_LOOKUP%22%3Atrue%2C%223PIDS%22%3A%5B%5D%7D; id5id.1st_last=Sat%2C%2003%20Oct%202020%2017%3A34%3A56%20GMT; ezosuigeneris=0adefbdc409fe3a680edf5e713a55815; __gads=ID=5e5f299d97279789:T=1601746455:S=ALNI_MaMb8alTKbpLdliJuy34z8Woz37iA; ezouspvh=120; ezux_ifep_200442=true; __qca=P0-713029707-1601746527238; ezoadgid_200442=-1; ezoref_200442=thepoorcoder.com; ezoab_200442=mod54; ezovid_200442=1957530272; ezovuuid_200442=dd38fe1c-ef7c-472c-7d93-2d8e80e9c595; ezohw=w%3D1536%2Ch%3D731; __utmt_e=1; __utmt_f=1; cto_bidid=hITaB19KYzcyc0JkYkZZc3BEWWd2Tkc5c0xYTWpya2xSWW5uRGZwTTZoZFY2N0ladTFxZTNrVVNTUTlxYThqVFB6dkR0UGtiVTl3V05CNW9LMktFZWxZQXk4ZyUzRCUzRA; cto_bundle=lyfAT19FcnRRJTJCb1ZZZzVKJTJGc2I1SnI2dENIREVnSTdlRXFYSm8xNWFBb0o4b1FqQjd1V3MxTnpwMElQVHVFZUhwMHF0RWgzbWlqSjZvM3ZjVHJFR3NKeUdsJTJCd1Z3U0NRV2V2NHRqaXZEUDBtWjVPSEFncWkzR3VaU3BpVHFUQVJwJTJCVCUyRnA; ezosuigenerisc=f6243fcb406936cc8083d783bac3cf7c; active_template::200442=pub_site.1601752941; ezopvc_200442=25; ezovuuidtime_200442=1601752942; _gat_gtag_UA_132753903_12=1; ezux_lpl_200442=1601753010662|787d7b7e-8c16-4286-66e6-385ae5f7e8c6|false; ezouspva=4; ezouspvv=118; __utmb=189523054.250.8.1601753027794; ezux_et_200442=667; ezux_tos_200442=5409")
            httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.122 Safari/537.36"
            httpWebRequest.KeepAlive = True
            Dim httpWebResponse As HttpWebResponse = CType(httpWebRequest.GetResponse(), HttpWebResponse)
            Dim streamReader As StreamReader = New StreamReader(httpWebResponse.GetResponseStream())
            Dim input As String = streamReader.ReadToEnd()
            Label1.Text = "Status: Data Scraped"
            Label1.ForeColor = Color.Lime
            get_ans(input)
        Catch ex As Exception
            Label1.Text = "Status: Error In Getting Data" & vbCrLf & "(Check name of the challenge)."
            Label1.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub TextBox2_DoubleClick(sender As Object, e As EventArgs) Handles TextBox2.DoubleClick

    End Sub

    Private Sub TestThemeEditorForm1_Click(sender As Object, e As EventArgs) Handles TestThemeEditorForm1.Click

    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        End
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try

            Using webClient As WebClient = New WebClient()
                AddHandler webClient.DownloadStringCompleted, Sub(_sender As Object, _e As DownloadStringCompletedEventArgs)
                                                                  If _e.[Error] IsNot Nothing Then
                                                                      MessageBox.Show("Error: No internet connection")
                                                                  Else
                                                                      MessageBox.Show(_e.Result)
                                                                  End If

                                                              End Sub
                webClient.DownloadStringAsync(New Uri("https://pastebin.com/raw/aCA5PCq9"))
            End Using
        Catch ex As Exception : End Try
    End Sub
End Class
