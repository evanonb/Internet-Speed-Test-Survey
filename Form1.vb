Public Class Form1
    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        Dim strSpeed As String
        Dim decSpeed As Decimal
        Dim decSum As Decimal
        Dim decAverage As Decimal = 0D

        Dim strIBoxMsg As String = "Enter the number of Mbps of your home Internet speed user #"
        Dim strIBoxTitle As String = "Internet Speed"
        Dim strNotNumericErrMsg As String = "Error - Enter the speed of your home Internet connection"
        Dim strNegErrMsg As String = "Error - Enter a valid speed"

        Dim intMaxEntries As Integer = 10
        Dim intEntries As Integer = 1

        strSpeed = InputBox(strIBoxMsg & intEntries, strIBoxTitle)

        Do Until intEntries > intMaxEntries Or strSpeed = ""
            If IsNumeric(strSpeed) Then
                decSpeed = Convert.ToDecimal(strSpeed)
                If decSpeed > 0 Then
                    lstSpeed.Items.Add(decSpeed)
                    decSum += decSpeed
                    intEntries += 1
                    strIBoxMsg = strIBoxMsg
                Else
                    strIBoxMsg = strNegErrMsg
                End If
            Else
                strIBoxMsg = strNotNumericErrMsg
            End If

            If intEntries <= intMaxEntries Then
                strSpeed = InputBox(strIBoxMsg & intEntries, strIBoxTitle)
            End If
        Loop

        If intEntries > 1 Then
            decAverage = decSum / (intEntries - 1)
            lblOutput.Text = "Average Internet Speed: " & decAverage.ToString("F2") & " Mbps"
        Else
            lblOutput.Text = "No speed values entered"
        End If

        btnCalc.Enabled = False

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lstSpeed.Items.Clear()
        lblOutput.Text = ""
        btnClear.Enabled = True
        btnCalc.Enabled = True
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class
