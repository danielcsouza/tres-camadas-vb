Imports System.Linq
Imports System.Text

Namespace AcessoDados

    Public Class AcessoBanco
        Public Shared ReadOnly Property StringConexao() As String
            Get
                Return "Data Source=.\sqlexpress;Initial Catalog=USUARIOS;User ID=user;Password=senha"

            End Get
        End Property
    End Class

End Namespace

