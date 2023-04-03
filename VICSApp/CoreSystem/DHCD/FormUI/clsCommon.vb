
Public Class clsCommon

    Public Function num2Text(ByVal str1 As String) As String
        Dim str As String
        Dim i As Integer
        Dim tg As String
        Dim j As Integer
        Dim sval As Integer
        Dim sSo As String
        Dim sNum2Text As String
        Dim k As Integer
        Dim l As Integer
        str = str1
        i = len(str)
        k = i \ 3
        l = 0
        Do While l <= k
            If l < k Then
                tg = mid(str, i - (l + 1) * 3 + 1, 3)
            Else
                tg = Microsoft.VisualBasic.Left(str, i - l * 3)
            End If
            sSo = ""
            For j = 1 To len(tg)
                sval = val(mid(tg, len(tg) - j + 1, 1))
                Select Case sval
                    Case 0
                        Select Case j
                            Case 3
                                If val(tg) > 0 Then
                                    sSo = "không trăm " & sso
                                End If
                            Case 2
                                If val(mid(tg, 3, 1)) > 0 Then
                                    sSo = "linh " & sso
                                End If
                            Case 1

                        End Select
                    Case 1
                        Select Case j
                            Case 3
                                sSo = "một trăm " & sso
                            Case 2
                                sSo = "mười " & sso
                            Case 1
                                If len(tg) > 1 And val(mid(tg, 2, 1)) > 1 Then
                                    sSo = "mốt" & sso
                                Else
                                    sSo = "một" & sso
                                End If
                        End Select
                    Case 2
                        Select Case j
                            Case 3
                                sSo = "hai trăm " & sso
                            Case 2
                                sSo = "hai mươi " & sso
                            Case 1
                                sSo = "hai" & sso
                        End Select
                    Case 3
                        Select Case j
                            Case 3
                                sSo = "ba trăm " & sso
                            Case 2
                                sSo = "ba mươi " & sso
                            Case 1
                                sSo = "ba" & sso
                        End Select
                    Case 4
                        Select Case j
                            Case 3
                                sSo = "bốn trăm " & sso
                            Case 2
                                sSo = "bốn mươi " & sso
                            Case 1
                                sSo = "bốn" & sso
                        End Select
                    Case 5
                        Select Case j
                            Case 3
                                sSo = "năm trăm " & sso
                            Case 2
                                sSo = "năm mươi " & sso
                            Case 1
                                If len(tg) > 1 And val(mid(tg, 2, 1)) >= 1 Then
                                    sSo = "lăm " & sso
                                Else
                                    sSo = "năm " & sso
                                End If
                        End Select
                    Case 6
                        Select Case j
                            Case 3
                                sSo = "sáu trăm " & sso
                            Case 2
                                sSo = "sáu mươi " & sso
                            Case 1
                                sSo = "sáu" & sso
                        End Select
                    Case 7
                        Select Case j
                            Case 3
                                sSo = "bảy trăm " & sso
                            Case 2
                                sSo = "bảy mươi " & sso
                            Case 1
                                sSo = "bảy" & sso
                        End Select
                    Case 8
                        Select Case j
                            Case 3
                                sSo = "tám trăm " & sso
                            Case 2
                                sSo = "tám mươi " & sso
                            Case 1
                                sSo = "tám" & sso
                        End Select
                    Case 9
                        Select Case j
                            Case 3
                                sSo = "chín trăm " & sso
                            Case 2
                                sSo = "chín mươi " & sso
                            Case 1
                                sSo = "chín" & sso
                        End Select
                End Select
            Next
            Select Case l
                Case 1, 4
                    If sso <> "" Then
                        snum2text = sso & " nghìn" & " " & snum2text
                    End If
                Case 2, 5
                    If sso <> "" Then
                        snum2text = sso & " triệu" & " " & snum2text
                    End If
                Case 3, 6
                    If sso <> "" Then
                        snum2text = sso & " tỷ" & " " & snum2text
                    End If
                Case Else
                    snum2text = sso
            End Select
            l = l + 1
        Loop
        num2Text = snum2text
    End Function

End Class
