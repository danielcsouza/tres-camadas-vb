Imports RegrasNegocios
Public Class AdicionarUsuario
    Inherits System.Web.UI.Page
    Private sucesso As Boolean

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs)
        If Not (String.IsNullOrEmpty(txtLogin.Text) And Not (String.IsNullOrEmpty(txtNome.Text) And
        Not (String.IsNullOrEmpty(txtSenha.Text)))) Then

            Dim usuario As New RegrasNegocios.RegrasNegocios.Usuarios()
            sucesso = usuario.AdicionarUsuario(txtNome.Text.ToString(), txtLogin.Text.ToString(), txtSenha.Text.ToString())

            If sucesso Then
                ClientScript.RegisterStartupScript(Me.GetType(), "Mensagem", "mensagem('Usuário cadastrado com sucesso!', " &
                          "'success');", True)
            Else
                ClientScript.RegisterStartupScript(Me.GetType(), "Mensagem", "mensagem('Erro ao cadastrar usuario ', " &
                          "'error');", True)
            End If

        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "Mensagem", "mensagem('Não deixe campos vazios!', " &
            "'error');", True)

        End If


    End Sub

   

End Class