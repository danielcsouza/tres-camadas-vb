Imports System.Data
Imports AcessoDados

Namespace RegrasNegocios
    Public Class Usuarios
        Inherits Page
        Private retorno As Boolean
        Private resultado As String
        Public DadosUsuario As DataTable
        ''' <summary>
        ''' Método para edição de dados de um determinado usuario
        ''' </summary>
        ''' <param name="CodigoUsuario">Código de usuario</param>
        ''' <param name="Nome"></param>
        ''' <param name="Login"></param>
        ''' <param name="Senha"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function EditarUsuario(CodigoUsuario As Integer, Nome As String, Login As String, Senha As String) As Boolean
            If Not (String.IsNullOrEmpty(Nome)) And Not (String.IsNullOrEmpty(Login)) And Not (String.IsNullOrEmpty(Senha)) Then

                Dim user As New AcessoDados.AcessoDados.Usuarios()
                retorno = user.EditarUsuario(CodigoUsuario, Nome, Login, Senha)

            End If
            Return retorno

        End Function
        ''' <summary>
        ''' Método de login no sistema
        ''' </summary>
        ''' <param name="Login"></param>
        ''' <param name="Senha"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AcessarSistema(Login As String, Senha As String) As String
            If Not (String.IsNullOrEmpty(Login)) And Not (String.IsNullOrEmpty(Senha)) Then

                DadosUsuario = New DataTable

                Dim sucesso As New AcessoDados.AcessoDados.Usuarios()

                DadosUsuario = sucesso.AcessarSistema(Login, Senha)

                If (DadosUsuario.Rows.Count > 0) Then

                    For Each campo As DataRow In DadosUsuario.Rows

                        Session("CodUsuario") = campo("usu_codigo")
                        Session("NomeUsuario") = campo("usu_nome")

                        resultado = "sucesso"
                    Next
                Else
                    resultado = "nao_encontrou"
                End If

            Else
                resultado = "vazio"
            End If

            Return resultado
        End Function
        ''' <summary>
        ''' Método para inserção do usuario
        ''' </summary>
        ''' <param name="Nome"></param>
        ''' <param name="Login"></param>
        ''' <param name="Senha"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AdicionarUsuario(Nome As String, Login As String, Senha As String) As Boolean
            If Not (String.IsNullOrEmpty(Nome)) And Not (String.IsNullOrEmpty(Login)) And Not (String.IsNullOrEmpty(Senha)) Then
                Dim usuario As New AcessoDados.AcessoDados.Usuarios()
                retorno = usuario.AdicionarUsuario(Nome, Login, Senha)

            End If

            Return retorno

        End Function
        ''' <summary>
        ''' Método que lista dados de um determinado usuario
        ''' </summary>
        ''' <param name="CodigoUsuario">Código de usuario</param>
        ''' <returns>Retorna um DataTable com os dados do usuario</returns>
        ''' <remarks></remarks>

        Public Function ListarUsuario(ByVal CodigoUsuario As Integer) As DataTable
            If (CodigoUsuario > 0) Then
                Dim usuario As New AcessoDados.AcessoDados.Usuarios()
                DadosUsuario = usuario.ListarUsuario(CodigoUsuario)

            End If

            Return DadosUsuario

        End Function
        ''' <summary>
        ''' Método que exclui os dados de um usuario
        ''' </summary>
        ''' <param name="CodigoUsuario"></param>
        ''' <returns>Retorna booleano se apagou ou nao</returns>
        ''' <remarks></remarks>
        Public Function ExcluirUsuario(CodigoUsuario As Integer) As Boolean
            If (CodigoUsuario > 0) Then
                Dim usuario As New AcessoDados.AcessoDados.Usuarios()
                retorno = usuario.ExcluirUsuario(CodigoUsuario)

            End If

            Return retorno

        End Function
        ''' <summary>
        ''' Método que retorna todos os usuarios cadastrados
        ''' </summary>
        ''' <returns>Retorna um DataTable com os dados do usuario passado</returns>
        ''' <remarks></remarks>
        Public Function ListarTodosUsuarios() As DataTable

            Dim usuario As New AcessoDados.AcessoDados.Usuarios()
            DadosUsuario = usuario.ListarTodosUsuarios()

            Return DadosUsuario

        End Function
    End Class
End Namespace
