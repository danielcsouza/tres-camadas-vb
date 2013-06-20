Imports System.Data
Imports RegrasNegocios

Public Class EditarUsuario
    Inherits System.Web.UI.Page
    Private retorno As Boolean
    Private CodigoUsuario As Integer
    'Private DadosUsuario As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Not String.IsNullOrEmpty(Request.QueryString("cod").ToString()) Then
                CodigoUsuario = CInt(Request.QueryString("cod").ToString())

                Dim DadosUsuario = New DataTable

                Dim objUsuario As New RegrasNegocios.RegrasNegocios.Usuarios()
                DadosUsuario = objUsuario.ListarUsuario(CodigoUsuario)

                If DadosUsuario.Rows.Count > 0 Then
                    For Each campo As DataRow In DadosUsuario.Rows
                        txtNome.Text = campo("usu_nome")
                        txtLogin.Text = campo("usu_login")
                        ' nao passo senha, pois o preenchimento da senha é obrigatória
                        hdtxtCodUsuario.Value = campo("usu_codigo")
                    Next
                End If

            End If
        End If


    End Sub

    Protected Sub btnEnviar_Click(sender As Object, e As EventArgs)
        If Not (String.IsNullOrEmpty(txtLogin.Text) And Not (String.IsNullOrEmpty(txtNome.Text) And
        Not (String.IsNullOrEmpty(txtSenha.Text)))) Then

            Dim objUsuario As New RegrasNegocios.RegrasNegocios.Usuarios()
            retorno = objUsuario.EditarUsuario(CInt(hdtxtCodUsuario.Value), txtNome.Text.ToString(),
                                               txtLogin.Text.ToString(), txtSenha.Text.ToString())
            If retorno Then
                ClientScript.RegisterStartupScript(Me.GetType(), "Mensagem", "mensagem('Usuário alterado com sucesso!', " &
                        "'success');", True)
            Else
                ClientScript.RegisterStartupScript(Me.GetType(), "Mensagem", "mensagem('Erro ao alterar dados do usuario ', " &
                                        "'error');", True)
            End If

        Else
            ClientScript.RegisterStartupScript(Me.GetType(), "Mensagem", "mensagem('Não deixe campos vazios!', " &
           "'error');", True)

        End If

    End Sub
End Class