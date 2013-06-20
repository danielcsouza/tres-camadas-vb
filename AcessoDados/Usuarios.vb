Imports System.Data
Imports System.Data.SqlClient


Namespace AcessoDados
    Public Class Usuarios
        'Declaração de variaveis 
        Public retorno As Boolean
        Private DadosUsuario As DataTable

        Public Function EditarUsuario(ByVal CodigoUsuario As Integer, ByVal Nome As String, ByVal Login As String, ByVal Senha As String) As Boolean
            retorno = False
            Try
                Using con As New SqlConnection(AcessoBanco.StringConexao)
                    Dim sql As New SqlCommand()
                    sql.CommandText = "UPDATE USUARIOS SET usu_nome=@nome,usu_login=@login,usu_senha=@senha " &
                     "WHERE (usu_codigo = @codigo)"

                    sql.Parameters.AddWithValue("@nome", Nome)
                    sql.Parameters.AddWithValue("@login", Login)
                    sql.Parameters.AddWithValue("@senha", Senha)
                    sql.Parameters.AddWithValue("@codigo", CodigoUsuario)

                    con.Open()
                    sql.Connection = con
                    sql.ExecuteNonQuery()

                    retorno = True


                End Using

            Catch ex As SqlException
                Throw New Exception("Erro ao executar código sql" + ex.Message)
            End Try

            Return retorno

        End Function
        ''' <summary>
        ''' Método para listar usuário pelo código
        ''' </summary>
        ''' <param name="codigo"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ListarUsuario(ByVal codigo As Integer) As DataTable
            Try
                Using con As New SqlConnection(AcessoDados.AcessoBanco.StringConexao)
                    Dim sql As New SqlDataAdapter("SELECT * FROM USUARIOS WHERE (usu_codigo=@usu_codigo)", con)
                    sql.SelectCommand.Parameters.AddWithValue("@usu_codigo", codigo)
                    sql.SelectCommand.CommandType = CommandType.Text

                    con.Open()

                    DadosUsuario = New DataTable

                    sql.Fill(DadosUsuario)

                    con.Close()

                End Using
            Catch ex As SqlException
                Throw New Exception("Erro ao executar sql" + ex.Message)
            End Try
            Return DadosUsuario
        End Function
        ''' <summary>
        ''' Método de para acessar o sistema através do login
        ''' </summary>
        ''' <param name="Login"></param>
        ''' <param name="Senha"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function AcessarSistema(ByVal Login As String, ByVal Senha As String) As DataTable
            Try
                Using con As New SqlConnection(AcessoBanco.StringConexao)
                    Dim sql As New SqlDataAdapter("SELECT * FROM USUARIOS WHERE (usu_login = @usuario) AND (usu_senha = @senha)", con)
                    sql.SelectCommand.CommandType = CommandType.Text
                    sql.SelectCommand.Parameters.AddWithValue("@usuario", Login)
                    sql.SelectCommand.Parameters.AddWithValue("@senha", Senha)

                    con.Open()

                    DadosUsuario = New DataTable

                    sql.Fill(DadosUsuario)

                    con.Close()

                End Using
            Catch ex As SqlException
                Throw New Exception("Erro ao executar sql" + ex.Message)
            End Try

            Return DadosUsuario

        End Function
        ''' <summary>
        ''' Método para add Usuario
        ''' </summary>
        ''' <param name="Nome">Nome do usuario</param>
        ''' <param name="Login">Login do usuario</param>
        ''' <param name="Senha">Senha do usuario</param>
        ''' <returns>Retorna boolenano se gravou corretamente</returns>
        ''' <remarks></remarks>
        Public Function AdicionarUsuario(ByVal Nome As String, ByVal Login As String, ByVal Senha As String) As Boolean
            Try
                Using con As New SqlConnection(AcessoBanco.StringConexao)
                    Dim sql As New SqlCommand()
                    sql.CommandText = "INSERT INTO USUARIOS (usu_nome, usu_login, usu_senha) VALUES (@nome,@login,@senha)"
                    sql.Parameters.AddWithValue("@nome", Nome)
                    sql.Parameters.AddWithValue("@login", Login)
                    sql.Parameters.AddWithValue("@senha", Senha)

                    sql.Connection = con

                    con.Open()

                    sql.ExecuteNonQuery()

                    con.Close()

                    retorno = True

                End Using

            Catch ex As SqlException
                Throw New Exception("Erro ao executar sql" + ex.Message)
            End Try

            Return retorno

        End Function
        ''' <summary>
        ''' Método para listar todos os usuários
        ''' </summary>
        ''' <returns>Retorna um Datatable com os dados</returns>
        ''' <remarks></remarks>
        ''' 
        Public Function ListarTodosUsuarios() As DataTable
            Try
                Using con As New SqlConnection(AcessoBanco.StringConexao)
                    Dim sql = New SqlDataAdapter("SELECT * FROM USUARIOS", con)
                    sql.SelectCommand.CommandType = CommandType.Text

                    con.Open()

                    DadosUsuario = New DataTable

                    sql.Fill(DadosUsuario)

                    con.Close()

                End Using

            Catch ex As Exception
                Throw New Exception("Erro ao executar sql" + ex.Message)
            End Try

            Return DadosUsuario

        End Function

        ''' <summary>
        ''' Método para Exclusão de usuário
        ''' </summary>
        ''' <param name="CodigoUsuario">Código</param>
        ''' <returns> Retorna booleano se exclui ou não</returns>
        ''' <remarks></remarks>
        Public Function ExcluirUsuario(ByVal CodigoUsuario As Integer) As Boolean
            Try
                Using con As New SqlConnection(AcessoBanco.StringConexao)
                    Dim query As New SqlCommand()
                    query.CommandText = "DELETE FROM USUARIOS WHERE (usu_codigo = @codigo)"
                    query.CommandType = CommandType.Text
                    query.Parameters.AddWithValue("@codigo", CodigoUsuario)

                    con.Open()
                    query.Connection = con

                    query.ExecuteNonQuery()

                    con.Close()

                    retorno = True

                End Using
            Catch ex As SqlException
                Throw New Exception("Erro ao executar sql" + ex.Message)
            End Try

            Return retorno

        End Function

    End Class
End Namespace