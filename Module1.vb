Imports System.Data.SqlClient
Imports System.Data.Sql

Module Module1

    Public con As New SqlConnection("Data Source=.;Initial Catalog=OfficeMMI;Integrated Security=True")
    Public da As SqlDataAdapter
    Public dr1 As DataRow
    Public dt As DataTable
    Public ds As New DataSet
    Public dr As SqlDataReader
    Public com As SqlCommand
    Public cb As SqlCommandBuilder

    '---------------------------------------------------
    Public cnx As New SqlConnection("Data Source=.;Initial Catalog=OfficeMMI;Integrated Security=True")
    Public ss As New DataSet
    Public dt2 As New DataTable
    Public dt3 As New DataTable
    Public dt4 As New DataTable
    Public dt5 As New DataTable
    Public dt6 As New DataTable
    Public dt7 As New DataTable
    Public dt8 As New DataTable
    Public dt9 As New DataTable
    Public dt10 As New DataTable
    Public i As Integer = 0
    Public bind As New BindingSource
    Public idd As Integer
    Public maa As String
    Public typee As String
End Module
