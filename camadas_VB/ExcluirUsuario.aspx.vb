Imports RegrasNegocios
Public Class ExcluirUsuario
    Inherits System.Web.UI.Page
    Private CodigoUsuario As Integer
    Private retorno As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not String.IsNullOrEmpty(Request.QueryString("cod").ToString()) Then
                CodigoUsuario = CInt(Request.QueryString("cod").ToString())

                Dim ObjUsuario As New RegrasNegocios.RegrasNegocios.Usuarios()
                retorno = ObjUsuario.ExcluirUsuario(CodigoUsuario)

                If retorno Then
                    Response.Redirect("index.aspx")
                Else

                    ClientScript.RegisterStartupScript(Me.GetType(), "Mensagem", "mensagem('Erro ao excluir este usuário!', " &
                                          "'error');", True)
                End If

            End If

        End If

    End Sub

End Class