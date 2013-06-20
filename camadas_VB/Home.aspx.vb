Public Class Home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If String.IsNullOrEmpty(Session("CodUsuario")) Then
            Response.Redirect("index.aspx")
        Else
            lblTexto.Text = "Olá <b>" + Session("NomeUsuario").ToString() + "</b>, seja bem vindo!"
        End If

    End Sub

End Class