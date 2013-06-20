Imports RegrasNegocios
Public Class Login
    Inherits System.Web.UI.Page
    Private sucesso As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs)
        If Not (String.IsNullOrEmpty(txtLogin.Text) And Not (String.IsNullOrEmpty(txtSenha.Text))) Then

            Dim objUsuario As New RegrasNegocios.RegrasNegocios.Usuarios()
            sucesso = objUsuario.AcessarSistema(txtLogin.Text.ToString(), txtSenha.Text.ToString())

            Select Case sucesso
                Case "sucesso"
                    Response.Redirect("Home.aspx")
                Case "erro"
                    ClientScript.RegisterStartupScript(Me.GetType(), "Mensagem", "mensagem('Usuario e /ou senha incorretos','error');", True)
                Case "vazio"
                    ClientScript.RegisterStartupScript(Me.GetType(), "Mensagem", "mensagem('Não deixe campos vazios','error');", True)
            End Select

        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "Mensagem", "mensagem('Não deixe campos vazios!', " &
            "'error');", True)

        End If

    End Sub
End Class