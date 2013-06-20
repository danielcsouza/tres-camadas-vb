Imports RegrasNegocios

Public Class index
    Inherits System.Web.UI.Page
    Private ListagemUsuarios As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim ListagemUsuarios = New DataTable

            Dim usuario As New RegrasNegocios.RegrasNegocios.Usuarios()
            ListagemUsuarios = usuario.ListarTodosUsuarios()

            If (ListagemUsuarios.Rows.Count > 0) Then

                rptLista.DataSource = ListagemUsuarios
                rptLista.DataBind()

            Else
                lblNothing.Text = "Não há usuários cadastrados"
                lblNothing.Visible = True

            End If

        End If
    End Sub

End Class