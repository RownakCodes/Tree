Module Module1

    Const null As Integer = -1

    Public Structure TreeNode
        Dim data As String
        Dim leftPointer, rightPointer As Integer
    End Structure

    Public Structure Tree
        Dim rootPointer, flp As Integer
        Dim tree() As TreeNode

        Sub init(ByVal size As Integer)
            size = size - 1
            ReDim tree(size)

            flp = 0
            rootPointer = null

            For index = 0 To size - 1
                tree(index).data = ""
                tree(index).leftPointer = index + 1
                tree(index).rightPointer = null
            Next

            tree(size).data = ""
            tree(size).leftPointer = null
            tree(size).rightPointer = null

        End Sub

        Sub insertData(ByVal AddData As Integer)

            If flp = null Then
                Console.WriteLine("No more space")
                Return
            End If

            Dim tmp As Integer = flp


            tree(flp).data = AddData
            flp = tree(tmp).leftPointer
            tree(tmp).leftPointer = null
            tree(tmp).rightPointer = null

            If rootPointer = null Then
                rootPointer = tmp
                Return
            End If

            Dim PreviousPointer, ForwardPointer As Integer
            ForwardPointer = rootPoinster
            PreviousPointer = null
            Dim isRight As Boolean = True

            While ForwardPointer <> null
                PreviousPointer = ForwardPointer

                If tree(ForwardPointer).data > AddData Then
                    ForwardPointer = tree(ForwardPointer).leftPointer
                    isRight = False
                ElseIf tree(ForwardPointer).data < AddData Then
                    ForwardPointer = tree(ForwardPointer).rightPointer
                    isRight = True
                ElseIf tree(ForwardPointer).data = AddData Then
                    Console.WriteLine("Invalid, you entered the same number!")
                    Return
                End If
            End While

            If isRight = True Then
                Console.WriteLine("Success")
                tree(PreviousPointer).rightPointer = tmp
            Else
                Console.WriteLine("Success")
                tree(PreviousPointer).leftPointer = tmp
            End If
        End Sub

        Sub printTree(ByVal currPointer As Integer)
            If currPointer = null Then
                Return
            End If

            printTree(tree(currPointer).rightPointer)
            Console.Write(tree(currPointer).data & "   ")
            printTree(tree(currPointer).leftPointer)
        End Sub

    End Structure

    Sub Main()
        Dim xmas As Tree
        xmas.init(10)
        Console.WriteLine("                                   Trees by Sharfaraz!")
        For x = 0 To 8
            Console.WriteLine("Enter no. {0} value out of 9", x)
            xmas.insertData(Console.ReadLine)
            Console.Clear()
        Next
        xmas.printTree(xmas.rootPointer)
    End Sub
End Module
