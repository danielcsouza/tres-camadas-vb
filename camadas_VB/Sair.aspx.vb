﻿Public Class Sair
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Abandon()
            Response.Redirect("index.aspx")
        End If
    End Sub

End Class