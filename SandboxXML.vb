Imports System.Xml


''' <summary>
''' Sandbox.sbcの読み書き
''' </summary>
Public Class SandboxXML

  ''' <summary>
  ''' 読み込みすみか？
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property IsLoaded As Boolean
    Get
      Return Not IsNothing(Me.XmlSandbox)
    End Get
  End Property

  ''' <summary>
  ''' Sandbox.sbc XMLデータ
  ''' </summary>
  Private XmlSandbox As XmlDocument = Nothing

  ''' <summary>
  ''' 読み込んだファイル名
  ''' </summary>
  Private XmlFilename As String = ""


  ''' <summary>
  ''' New
  ''' </summary>
  Public Sub New()
    'NOP
  End Sub

  ''' <summary>
  ''' Finalize
  ''' </summary>
  Protected Overrides Sub Finalize()
    'NOP
    MyBase.Finalize()
  End Sub

  ''' <summary>
  ''' 読み込み
  ''' </summary>
  Public Sub Open(filename As String)

    Try
      Me.XmlSandbox = New XmlDocument()
      Me.XmlFilename = filename
      Me.XmlSandbox.Load(filename)
    Catch ex As Exception
      Me.XmlSandbox = Nothing
      Me.XmlFilename = ""
      Throw
    End Try

  End Sub

  ''' <summary>
  ''' 保存
  ''' </summary>
  Public Sub Save()
    If IsNothing(Me.XmlSandbox) OrElse Me.XmlFilename.Equals("") Then
      '読み込んでいない場合は何もしない
      Return
    End If

    'bak作成
    My.Computer.FileSystem.CopyFile(Me.XmlFilename, System.IO.Path.GetFileNameWithoutExtension(Me.XmlFilename) & ".bak", True)

    '上書き保存
#If DEBUG Then
    Me.XmlSandbox.Save(Me.XmlFilename & ".test")
#Else
    Me.XmlSandbox.Save(Me.XmlFilename)
#End If

  End Sub


  ''' <summary>
  ''' SessionNameを返す
  ''' </summary>
  ''' <returns></returns>
  Public Function GetSessionName() As String
    Dim sessionName As String = ""

    If IsNothing(Me.XmlSandbox) OrElse Me.XmlFilename.Equals("") Then
      '読み込んでいない場合は何もしない
      Return sessionName
    End If

    Dim sessionNameList As Xml.XmlNodeList = Me.XmlSandbox.SelectNodes("/MyObjectBuilder_Checkpoint/SessionName")
    For Each sessionNameText As Xml.XmlNode In sessionNameList
      sessionName = sessionNameText.InnerText
      Exit For
    Next

    Return sessionName
  End Function

  ''' <summary>
  ''' MOD ID一覧を返す
  ''' </summary>
  ''' <returns></returns>
  Public Function GetModIDList() As List(Of String)
    Dim modIDList As New List(Of String)

    If IsNothing(Me.XmlSandbox) OrElse Me.XmlFilename.Equals("") Then
      '読み込んでいない場合は何もしない
      Return modIDList
    End If


    Dim modsList As Xml.XmlNodeList = Me.XmlSandbox.SelectNodes("/MyObjectBuilder_Checkpoint/Mods")
    For Each mods As Xml.XmlNode In modsList
      Dim modItemList As Xml.XmlNodeList = mods.SelectNodes("./ModItem")
      For Each modItem As Xml.XmlNode In modItemList
        Dim publishedFileIdList As Xml.XmlNodeList = modItem.SelectNodes("./PublishedFileId")
        For Each publishedFileId As Xml.XmlNode In publishedFileIdList
          modIDList.Add(publishedFileId.InnerText)
        Next
      Next
    Next


    Return modIDList
  End Function


  ''' <summary>
  ''' MODIDリストを差し替え
  ''' </summary>
  ''' <param name="modIDList"></param>
  Public Sub SetModIDList(modIDList As List(Of String))
    If IsNothing(Me.XmlSandbox) OrElse Me.XmlFilename.Equals("") Then
      '読み込んでいない場合は何もしない
      Return
    End If


    '<ModItem>
    '  <Name>440438786.sbm</Name>
    '  <PublishedFileId>440438786</PublishedFileId>
    '</ModItem>


    Dim nodeListMods As Xml.XmlNodeList = Me.XmlSandbox.SelectNodes("/MyObjectBuilder_Checkpoint/Mods")
    Dim elmMods As XmlElement

    If nodeListMods.Count >= 1 Then
      'すでに存在するので一旦消去
      elmMods = nodeListMods.Item(0)
      elmMods.RemoveAll()
    Else
      '存在しない

      '新しいデータを作成
      elmMods = Me.XmlSandbox.CreateElement("Mods")

      Dim root As Xml.XmlNodeList = Me.XmlSandbox.SelectNodes("/MyObjectBuilder_Checkpoint")
      root.Item(0).AppendChild(elmMods)

    End If


    For Each id As String In modIDList
      Dim elmModItem As XmlElement = Me.XmlSandbox.CreateElement("ModItem")
      elmMods.AppendChild(elmModItem)

      Dim elmName As XmlElement = Me.XmlSandbox.CreateElement("Name")
      elmModItem.AppendChild(elmName)

      Dim nodeName As XmlNode = Me.XmlSandbox.CreateNode(XmlNodeType.Text, "", "")
      nodeName.Value = id & ".sbm"
      elmName.AppendChild(nodeName)

      Dim elmPublishedFileId As XmlElement = Me.XmlSandbox.CreateElement("PublishedFileId")
      elmModItem.AppendChild(elmPublishedFileId)

      Dim nodePublishedFileId As XmlNode = Me.XmlSandbox.CreateNode(XmlNodeType.Text, "", "")
      nodePublishedFileId.Value = id
      elmPublishedFileId.AppendChild(nodePublishedFileId)
    Next

  End Sub




End Class
