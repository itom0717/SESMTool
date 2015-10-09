Public Class MainForm

  ''' <summary>
  ''' Sandboxファイル名
  ''' </summary>
  Private Const SandboxFIleName As String = "Sandbox.sbc"

  ''' <summary>
  ''' basePath
  ''' </summary>
  Private Const SavesPath As String = "SpaceEngineers\Saves"

  ''' <summary>
  ''' Sandbox XMLデータ
  ''' </summary>
  Private SandboxXML As New SandboxXML



  ''' <summary>
  ''' 現在のMOD一覧タイトル
  ''' </summary>
  Private ModListTitleLabelText As String = ""

  ''' <summary>
  ''' 置換するMOD一覧タイトル
  ''' </summary>
  Private NewModListTitleLabelText As String = ""


  ''' <summary>
  ''' Load
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
    Me.Text = My.Application.Info.Title
    Me.ModIDListBox.Items.Clear()
    Me.NewModIDListBox.Items.Clear()

    Me.ModListTitleLabelText = Me.ModIDLabel.Text
    Me.NewModListTitleLabelText = Me.NewModIDLabel.Text

    Me.ModIDLabel.Text = String.Format(Me.ModListTitleLabelText, 0)
    Me.NewModIDLabel.Text = String.Format(Me.NewModListTitleLabelText, 0)

    Me.SessionNameTextBox.Text = ""
  End Sub

  ''' <summary>
  ''' 閉じるボタン
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
    Me.Close()
  End Sub

  ''' <summary>
  ''' ファイルを開くダイアログを表示
  ''' </summary>
  ''' <returns>キャンセルの場合は""を返す</returns>
  Private Function ShowOpenDialog(defaultFilename As String,
                                  defaultlDirectory As String,
                                  filter As String,
                                  title As String) As String

    Dim openFilename As String = ""

    'OpenFileDialogクラスのインスタンスを作成
    Dim openFileDialog As New OpenFileDialog()
    With openFileDialog

      'はじめのファイル名を指定する
      .FileName = defaultFilename

      'はじめに表示されるフォルダを指定する
      '指定しない（空の文字列）の時は、現在のディレクトリが表示される
      .InitialDirectory = defaultlDirectory

      '[ファイルの種類]に表示される選択肢を指定する
      '指定しないとすべてのファイルが表示される
      '.Filter = "HTMLファイル(*.html;*.htm)|*.html;*.htm|すべてのファイル(*.*)|*.*"
      .Filter = filter

      '[ファイルの種類]ではじめに
      '「すべてのファイル」が選択されているようにする
      .FilterIndex = 1

      'タイトルを設定する
      .Title = title

      'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
      .RestoreDirectory = True

      '存在しないファイルの名前が指定されたとき警告を表示する
      'デフォルトでTrueなので指定する必要はない
      .CheckFileExists = True

      '存在しないパスが指定されたとき警告を表示する
      'デフォルトでTrueなので指定する必要はない
      .CheckPathExists = True


      'ダイアログを表示する
      If .ShowDialog() = DialogResult.OK Then
        'OKボタンがクリックされたとき
        openFilename = .FileName
      End If
    End With

    Return openFilename
  End Function


  ''' <summary>
  ''' Saveフォルダを返す
  ''' </summary>
  ''' <returns></returns>
  Private Function GetSaveDirectory() As String
    Dim applicationDataPath As String = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Dim savePath As String = My.Computer.FileSystem.CombinePath(applicationDataPath, SavesPath)

    If My.Computer.FileSystem.DirectoryExists(savePath) Then
      Return savePath
    Else
      Return applicationDataPath
    End If

  End Function

  ''' <summary>
  ''' SaveデータからModID一覧取得
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub GetModButton_Click(sender As Object, e As EventArgs) Handles GetModButton.Click
    Dim filename As String = Me.ShowOpenDialog(SandboxFIleName, Me.GetSaveDirectory(), SandboxFIleName & "|" & SandboxFIleName, "")
    If filename.Equals("") Then
      Return
    End If

    'データ読み込み
    Me.SandboxXML.Open(filename)

    'MODID一覧取得
    Dim modIDList As List(Of String) = Me.SandboxXML.GetModIDList

    Me.SessionNameTextBox.Text = Me.SandboxXML.GetSessionName
    Me.ToolTip.SetToolTip(Me.SessionNameTextBox, filename)

    'リストボックスに追加
    Me.ModIDListBox.Items.Clear()
    For Each modID As String In modIDList
      Me.ModIDListBox.Items.Add(modID)
    Next

    Me.ModIDLabel.Text = String.Format(Me.ModListTitleLabelText, modIDList.Count)

  End Sub

  ''' <summary>
  ''' SaveデータのModを書き換え
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub SetModButton_Click(sender As Object, e As EventArgs) Handles SetModButton.Click
    If Not Me.SandboxXML.IsLoaded Then
      Return
    End If

    Dim modIDList As New List(Of String)
    For i As Integer = 0 To Me.ModIDListBox.Items.Count - 1
      modIDList.Add(Me.ModIDListBox.Items(i).ToString)
    Next

    Dim newModIDList As New List(Of String)
    For i As Integer = 0 To Me.NewModIDListBox.Items.Count - 1
      newModIDList.Add(Me.NewModIDListBox.Items(i).ToString)
    Next

    '比較
    Dim isChange As Boolean = False
    Do
      If modIDList.Count = newModIDList.Count Then
        For i As Integer = 0 To modIDList.Count - 1
          If Not modIDList(i).Equals(newModIDList(i)) Then
            isChange = True
            Exit Do
          End If
        Next
      Else
        isChange = True
      End If
    Loop While False
    If Not isChange Then
      MessageBox.Show("変更されていないため、保存はしません。")
      Return
    End If



    If MessageBox.Show("上書き保存しますか？", "", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
      Return
    End If

    'XNKを書き換え
    Me.SandboxXML.SetModIDList(newModIDList)

    '保存
    Me.SandboxXML.Save()

    MessageBox.Show("データを保存しました。")

  End Sub


  ''' <summary>
  ''' ModIDリストを読み込み
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub LoadModButton_Click(sender As Object, e As EventArgs) Handles LoadModButton.Click
    If Not Me.SandboxXML.IsLoaded Then
      Return
    End If

    Dim filename As String = Me.ShowOpenDialog("", System.Environment.GetFolderPath(Environment.SpecialFolder.Personal), "テキストファイル(*.txt)|*.txt", "")
    If filename.Equals("") Then
      Return
    End If

    Dim modIDList As New List(Of String)

    Using sr As New System.IO.StreamReader(filename, System.Text.Encoding.UTF8)
      While sr.Peek() > -1
        Dim id As String = sr.ReadLine()
        If Not System.Text.RegularExpressions.Regex.IsMatch(id, "^\d{9}$") Then
          Continue While
        End If
        modIDList.Add(id)
      End While
      sr.Close()
    End Using


    'リストボックスに追加
    Me.NewModIDListBox.Items.Clear()
    For Each modID As String In modIDList
      Me.NewModIDListBox.Items.Add(modID)
    Next

    Me.NewModIDLabel.Text = String.Format(Me.NewModListTitleLabelText, modIDList.Count)

  End Sub

  ''' <summary>
  ''' ModIDリストを保存
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub SaveModButton_Click(sender As Object, e As EventArgs) Handles SaveModButton.Click
    If Not Me.SandboxXML.IsLoaded Then
      Return
    End If

    If Me.ModIDListBox.Items.Count = 0 Then
      MessageBox.Show("１件もMODがありません。")
      Return
    End If


    Dim saveFilename As String = ""


    'SaveFileDialogクラスのインスタンスを作成
    Dim saveFileDialog As New SaveFileDialog()
    With saveFileDialog
      'はじめのファイル名を指定する
      .FileName = Me.SandboxXML.GetSessionName & "_MOD_LIST.txt"

      'はじめに表示されるフォルダを指定する
      .InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal)

      '[ファイルの種類]に表示される選択肢を指定する
      .Filter = "テキストファイル(*.txt)|*.txt"

      '[ファイルの種類]でじめに
      '「すべてのファイル」が選択されているようにする
      .FilterIndex = 1

      'タイトルを設定する
      .Title = ""

      'ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
      .RestoreDirectory = True

      '既に存在するファイル名を指定したとき警告する
      'デフォルトでTrueなので指定する必要はない
      .OverwritePrompt = True

      '存在しないパスが指定されたとき警告を表示する
      'デフォルトでTrueなので指定する必要はない
      .CheckPathExists = True

      'ダイアログを表示する
      If .ShowDialog() = DialogResult.OK Then
        'OKボタンがクリックされたとき
        '選択されたファイル名を表示する
        saveFilename = .FileName
      End If
    End With

    If saveFilename.Equals("") Then
      Return
    End If




    '保存
    Using sw As New System.IO.StreamWriter(saveFilename, False, System.Text.Encoding.UTF8)
      For i As Integer = 0 To Me.ModIDListBox.Items.Count - 1
        sw.WriteLine(Me.ModIDListBox.Items(i).ToString)
      Next
      sw.Close()
    End Using


    MessageBox.Show("保存しました。")

  End Sub
End Class
