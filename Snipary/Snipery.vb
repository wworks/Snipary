Imports System.Xml
Imports System.IO

Public Class Snipery
    Private Tags As New List(Of String)
    Private CurrentNode As SnippetNode

    Const SNIPPETSFILEPATH = "\Snippets.xml" 'If filepath isn't set by user
    Const TAGSFILEPATH = "\Tags.xml"

 
#Region "Form Events"
    Private Sub Snipery_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If My.Settings.XmlFilePathSnippets = "" Then
            If File.Exists(Application.StartupPath & SNIPPETSFILEPATH) = True Then
                LoadSnippets(Application.StartupPath & SNIPPETSFILEPATH)
            End If
        Else
            If File.Exists(My.Settings.XmlFilePathSnippets) = True Then
                LoadSnippets(My.Settings.XmlFilePathSnippets)
            End If
        End If

        If My.Settings.XmlFilePathTags = "" Then
            If File.Exists(Application.StartupPath & TAGSFILEPATH) = True Then
                LoadTags(Application.StartupPath & TAGSFILEPATH)
            End If
        Else
            If File.Exists(My.Settings.XmlFilePathTags) = True Then
                LoadTags(My.Settings.XmlFilePathTags)
            End If
        End If

        My.Application.SaveMySettingsOnExit = True
        SnippetsLibrary.TopNode.ExpandAll()

        FillTagsCollectionContainer()

        SnippetsLibrary.Select()
    End Sub
    Private Sub Snipery_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.XmlFilePathSnippets = "" Then
            If File.Exists(Application.StartupPath & SNIPPETSFILEPATH) = False Then
                File.Create(Application.StartupPath & SNIPPETSFILEPATH)
            End If
            SaveSnippets(Application.StartupPath & SNIPPETSFILEPATH)
        Else
            If File.Exists(My.Settings.XmlFilePathSnippets) = False Then
                File.Create(My.Settings.XmlFilePathSnippets)
            End If

            SaveSnippets(My.Settings.XmlFilePathSnippets)
        End If


        If My.Settings.XmlFilePathTags = "" Then
            If File.Exists(Application.StartupPath & TAGSFILEPATH) = False Then
                File.Create(Application.StartupPath & TAGSFILEPATH)
            End If
            SaveTags(Application.StartupPath & TAGSFILEPATH)
        Else
            If File.Exists(My.Settings.XmlFilePathTags) = False Then
                File.Create(Application.StartupPath & TAGSFILEPATH)
            End If
            SaveTags(My.Settings.XmlFilePathTags)
        End If
    End Sub
#End Region

#Region "Xml Saving and Loading"
    Private Sub LoadSnippets(XmlFilePath As String)
        Dim XmlText = IO.File.ReadAllText(XmlFilePath)
        Dim readXML As XmlReader = XmlReader.Create(New StringReader(XmlText))
        Dim l As New XmlDocument
        l.LoadXml(XmlText)

        Dim parentnode As New SnippetNode


        For Each node As XmlNode In l.ChildNodes
            If node.NodeType = XmlNodeType.Element Then
                LoadSubItem(parentnode, node)
            End If


        Next
        If parentnode.Name = "" Then
            parentnode.Name = "Untitled Category"
            parentnode.Text = "Untitled Category"
            parentnode.IsCategory = True
        End If

        SnippetsLibrary.Nodes.Add(parentnode)

    End Sub

    Private Sub LoadSubItem(Snippet As SnippetNode, xmlnode As XmlNode)
        Select Case xmlnode.Name
            Case "Name"
                Snippet.Name = xmlnode.InnerText
                Snippet.Text = Snippet.Name
                Return
            Case "Tags"
                For Each node As XmlNode In xmlnode.ChildNodes
                    LoadSubItem(Snippet, node)
                Next
            Case "Tag"
                Snippet.Tags.Add(xmlnode.InnerText)
                Return

            Case "IsCategory"
                Snippet.IsCategory = CBool(xmlnode.InnerText)
                If Not Snippet.IsCategory Then
                    Snippet.ImageIndex = 1
                    Snippet.SelectedImageIndex = 1
                End If
                Return
            Case "Contents"
                Snippet.Contents = xmlnode.InnerText
                Return
            Case "SubItem"
                Dim NewSnippet As New SnippetNode

                For Each node As XmlNode In xmlnode.ChildNodes
                    LoadSubItem(NewSnippet, node)
                Next
                Snippet.Nodes.Add(NewSnippet)

            Case "Snippets"
                For Each node As XmlNode In xmlnode.ChildNodes
                    LoadSubItem(Snippet, node)
                Next


        End Select
        Snippet.ExpandAll()
    End Sub

    Private Sub SaveSnippets(XmlFIlePath As String)

        Dim writer As New XmlTextWriter(XmlFIlePath, System.Text.Encoding.UTF8)
        With writer
            .WriteStartDocument(True)
            .Formatting = Formatting.Indented
            .Indentation = 2
            .WriteStartElement("Snippets")


            WriteElement(TryCast(SnippetsLibrary.TopNode, SnippetNode), writer)

            .WriteEndElement()
            .WriteEndDocument()

        End With
        writer.Dispose()

    End Sub

    Private Sub WriteElement(Snippet As SnippetNode, xml As XmlTextWriter)

        With xml
            .WriteStartElement("Name")
            .WriteString(Snippet.Text)
            .WriteEndElement()

            .WriteStartElement("Tags")
            For Each Tag As String In Snippet.Tags
                .WriteStartElement("Tag")
                .WriteString(Tag)
                .WriteEndElement()
            Next
            .WriteEndElement()

            .WriteStartElement("IsCategory")
            .WriteString(Snippet.IsCategory)
            .WriteEndElement()


            .WriteStartElement("Contents")
            .WriteString(Snippet.Contents)
            .WriteEndElement()

            For Each SubNode As SnippetNode In Snippet.Nodes
                .WriteStartElement("SubItem")
                WriteElement(SubNode, xml)
                .WriteEndElement()
            Next

        End With

    End Sub


    Private Sub LoadTags(XmlFilePath As String)
        Dim XmlText = IO.File.ReadAllText(XmlFilePath)
        Dim readXML As XmlReader = XmlReader.Create(New StringReader(XmlText))

        While readXML.Read()
            Select Case readXML.NodeType
                Case XmlNodeType.Element
                    Select Case readXML.Name
                        Case "Tag"
                            Tags.Add(readXML.ReadElementContentAsString)
                    End Select

            End Select
        End While

    End Sub

    Private Sub SaveTags(XmlFIlePath As String)

        Dim writer As New XmlTextWriter(XmlFIlePath, System.Text.Encoding.UTF8)
        With writer
            .WriteStartDocument(True)
            .Formatting = Formatting.Indented
            .Indentation = 2
            .WriteStartElement("Tags")

            For Each Tag As String In Tags
                .WriteStartElement("Tag")
                .WriteString(Tag)
                .WriteEndElement()

            Next
            .WriteEndElement()
            .WriteEndDocument()

        End With
        writer.Dispose()

    End Sub

#End Region

#Region "Snippet Library"
    Private Sub SnippetsLibrary_Click(sender As Object, e As EventArgs) Handles SnippetsLibrary.Click, SnippetsLibrary.AfterSelect

        TagsContainer.Controls.Clear()
        SnippetContentEditor.Text = ""
        CurrentNode = TryCast(SnippetsLibrary.SelectedNode, SnippetNode)
        If IsNothing(CurrentNode) Then
            Return
        End If
        If CurrentNode.IsCategory Then

            Return
        Else

        End If

        FillTagsContainer()

        SnippetContentEditor.Text = CurrentNode.Contents

    End Sub

    Private Sub SnippetsLibrary_DoubleClick(sender As Object, e As EventArgs) Handles SnippetsLibrary.DoubleClick
        CurrentNode = TryCast(SnippetsLibrary.SelectedNode, SnippetNode)
        If IsNothing(CurrentNode) Then
            Return
        End If
    End Sub

    Private Sub SnippetsLibrary_KeyUp(sender As Object, e As KeyEventArgs) Handles SnippetsLibrary.KeyUp

        If e.Control And e.KeyCode = Keys.F Then
            SearchBox.Focus()
        End If


        If IsNothing(SnippetsLibrary.SelectedNode) Then
            Return
        End If


        Dim ParentNode = SnippetsLibrary.SelectedNode
        If e.Control And e.KeyCode = Keys.Enter Then
            Dim ParentNodeIndex = ParentNode.Index

            Dim CategoryName = InputBox("Enter the name of the new category:", "Enter name:")
            If CategoryName = "" Then
                CategoryName = "Untitled category"
            End If

            Dim NewCategory As New SnippetNode

            NewCategory.Name = CategoryName
            NewCategory.Text = CategoryName
            NewCategory.IsCategory = True

            If IsNothing(ParentNode.Parent) Then
                SnippetsLibrary.Nodes.Add(NewCategory)
            Else
                ParentNode.Parent.Nodes.Add(NewCategory)
            End If

        End If

        If e.Shift And e.KeyCode = Keys.Enter Then
            Dim CategoryName = InputBox("Enter the name of the new subcategory:", "Enter name:")

            If CategoryName = "" Then
                CategoryName = "Untitled category"
            End If


            Dim NewCategory As New SnippetNode

            NewCategory.Name = CategoryName
            NewCategory.Text = CategoryName
            NewCategory.IsCategory = True

            ParentNode.Nodes.Add(NewCategory)

        End If

        If e.Control And e.KeyCode = Keys.N Then

            Dim NewSnippetName = InputBox("Enter the name of the new snippet:", "Enter name")

            If NewSnippetName = "" Then
                NewSnippetName = "Untitled Snippet"
            End If

            Dim NewSnippet As New SnippetNode
            NewSnippet.ImageIndex = 1
            NewSnippet.SelectedImageIndex = 1
            NewSnippet.Name = NewSnippetName
            NewSnippet.Text = NewSnippetName

            If IsNothing(ParentNode.Parent) Then
                SnippetsLibrary.Nodes.Add(NewSnippet)
            Else
                ParentNode.Parent.Nodes.Add(NewSnippet)
            End If



        End If

        If e.Shift And e.KeyCode = Keys.N Then
            Dim NewSnippetName = InputBox("Enter the name of the new snippet:", "Enter name")

            If NewSnippetName = "" Then
                NewSnippetName = "Untitled Snippet"
            End If

            Dim NewSnippet As New SnippetNode
            NewSnippet.ImageIndex = 1
            NewSnippet.SelectedImageIndex = 1
            NewSnippet.Name = NewSnippetName
            NewSnippet.Text = NewSnippetName

            ParentNode.Nodes.Add(NewSnippet)


        End If

        If e.KeyCode = Keys.Delete Then
            If SnippetsLibrary.TopNode.Equals(ParentNode) = False Then
                SnippetsLibrary.Nodes.Remove(ParentNode)
            Else
                MsgBox("You can't delete the root node, rename instead")

            End If

        End If
        If e.KeyCode = Keys.Insert Then
            ParentNode.BeginEdit()
        End If



        SnippetsLibrary.TopNode.ExpandAll()
        CurrentNode = TryCast(SnippetsLibrary.SelectedNode, SnippetNode)
    End Sub


    
#End Region

#Region "TagManagement"

    Private Sub TagsChois_TagSelected(sender As Object, e As EventArgs)
        If IsNothing(CurrentNode) Then
            Return
        End If
        If CurrentNode.IsCategory Then
            Return
        End If

        CurrentNode.Tags.Add(sender.SelectedItem)
        FillTagsContainer()
    End Sub

    Private Sub TagsCollectionTag_DoubleClick(sender As Object, e As EventArgs)
        Tags.Remove(sender.text)
        FillTagsCollectionContainer()

        FillTagsContainer()
    End Sub

    Private Sub TagsCollectionAddTextboxSubmitted(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Tags.Add(sender.text)
            FillTagsCollectionContainer()
            FillTagsContainer()
        End If

        If e.Control And e.KeyCode = Keys.F Then
            SearchBox.Focus()
        End If

    End Sub

    Private Sub Tag_DoubleClick(sender As Object, e As EventArgs)
        If IsNothing(CurrentNode) Then
            Return
        End If
        If CurrentNode.IsCategory Then
            Return
        End If

        CurrentNode.Tags.Remove(sender.text)
        FillTagsContainer()

    End Sub

    Private Function GetNewTag(Text As String) As Label
        Dim Tag As New Label
        Tag.Text = Text
        Tag.Margin = New Windows.Forms.Padding(3)
        Tag.Width = 169
        Tag.BackColor = Color.FromArgb(240, 240, 240)
        Tag.TextAlign = ContentAlignment.MiddleCenter



        Return Tag
    End Function

    Private Sub FillTagsContainer()
        TagsContainer.Controls.Clear()
        If IsNothing(CurrentNode) Then
            Return
        End If
        If CurrentNode.IsCategory Then
            Return
        End If

        For Each SnippetTag As String In CurrentNode.Tags
            Dim Tag = GetNewTag(SnippetTag)
            Tag.TabIndex = 6
            AddHandler Tag.DoubleClick, AddressOf Tag_DoubleClick
            TagsContainer.Controls.Add(Tag)
        Next

        Dim TagsChoices As New ComboBox
        TagsChoices.Width = 169
        TagsChoices.Height = 20
        For Each Tag As String In Tags
            TagsChoices.Items.Add(Tag)
        Next

        AddHandler TagsChoices.SelectedIndexChanged, AddressOf TagsChois_TagSelected

        TagsContainer.Controls.Add(TagsChoices)

    End Sub

    Private Sub FillTagsCollectionContainer()

        TagsCollectionContainer.Controls.Clear()

        For Each SnippetTag As String In Tags
            Dim Tag = GetNewTag(SnippetTag)

            Tag.TabIndex = 4
            AddHandler Tag.DoubleClick, AddressOf TagsCollectionTag_DoubleClick
            TagsCollectionContainer.Controls.Add(Tag)
        Next
        Dim NewTag As New TextBox
        NewTag.Width = 169
        NewTag.Height = 20
        AddHandler NewTag.KeyUp, AddressOf TagsCollectionAddTextboxSubmitted

        TagsCollectionContainer.Controls.Add(NewTag)
        NewTag.Focus()

    End Sub

#End Region

#Region "ContentEditor"
    Private Sub SaveSnippetButton_Click(sender As Object, e As EventArgs) Handles SaveSnippetButton.Click
        CurrentNode = TryCast(SnippetsLibrary.SelectedNode, SnippetNode)
        If IsNothing(CurrentNode) Then
            Return
        End If
        If CurrentNode.IsCategory Then
            Return
        End If

        CurrentNode.Contents = SnippetContentEditor.Text

    End Sub

    Private Sub SaveSnippetShortcut_KeyUp(sender As Object, e As KeyEventArgs) Handles SnippetContentEditor.KeyUp
        If e.Control And e.KeyCode = Keys.F Then
            SearchBox.Focus()
        End If
        CurrentNode = TryCast(SnippetsLibrary.SelectedNode, SnippetNode)
        If IsNothing(CurrentNode) Then
            Return
        End If
        If CurrentNode.IsCategory Then
            Return
        End If
        If e.Control And e.KeyCode = Keys.S Then
            CurrentNode.Contents = SnippetContentEditor.Text
        End If


    End Sub
#End Region

#Region "Search"
    Private Sub Search(SearchString As String, LookInName As Boolean, LookInTags As Boolean, LookInContent As Boolean, Snippet As SnippetNode)
        '
        SearchString = SearchString.ToLower


        If LookInName Then
            If Snippet.Text.ToLower.Contains(SearchString) Or Snippet.Name.ToLower.Contains(SearchString) Then
                If LibraryContains(Snippet, Library:=SearchResults) = False Then

                    SearchResults.Nodes.Add(Snippet.Copy(True))
                End If

            End If
        End If
        If LookInTags Then
            For Each Tag As String In Snippet.Tags
                If Tag.ToLower.Contains(SearchString) Then
                    If LibraryContains(Snippet, Library:=SearchResults) = False Then
                        SearchResults.Nodes.Add(Snippet.Copy(True))
                    End If

                End If
            Next
        End If
        If LookInContent Then
            If Snippet.Contents.ToLower.Contains(SearchString) Then
                If LibraryContains(Snippet, Library:=SearchResults) = False Then
                    SearchResults.Nodes.Add(Snippet.Copy(True))
                End If
            End If
        End If

        For Each SubSnippet As SnippetNode In Snippet.Nodes
            Search(SearchString, LookInName, LookInTags, LookInContent, SubSnippet)
        Next




    End Sub

    Private Sub SearchResults_DoubleClick(sender As Object, e As EventArgs) Handles SearchResults.DoubleClick
        Dim SelectedSnippet As SnippetNode = SearchResults.SelectedNode
        If IsNothing(SelectedSnippet.LinkNode) = False Then
            SnippetsLibrary.Focus()
            SnippetsLibrary.SelectedNode = SelectedSnippet.LinkNode

        End If


    End Sub

    Private Sub SearchBox_KeyUp(sender As Object, e As KeyEventArgs) Handles SearchBox.KeyUp
        If e.KeyCode = Keys.Enter Then
            SearchResults.Nodes.Clear()
            For Each Snippet As SnippetNode In SnippetsLibrary.Nodes
                Search(SearchBox.Text, LookInNamesChck.Checked, LookInTagsChk.Checked, LookInContentChk.Checked, Snippet)
            Next
        End If
    End Sub

    Private Sub SearchButton_Click(sender As Object, e As EventArgs) Handles SearchButton.Click
        SearchResults.Nodes.Clear()
        For Each Snippet As SnippetNode In SnippetsLibrary.Nodes
            Search(SearchBox.Text, LookInNamesChck.Checked, LookInTagsChk.Checked, LookInContentChk.Checked, Snippet)
        Next

    End Sub

    Private Function LibraryContains(Snippet As SnippetNode, Optional parentNode As SnippetNode = Nothing, Optional Library As TreeView = Nothing) As Boolean
        If IsNothing(Library) = False And IsNothing(parentNode) Then
            For Each LibSnippet As SnippetNode In Library.Nodes
                If LibraryContains(LibSnippet, Snippet, Library) Then
                    Return True
                End If
            Next
            Return False
        End If


        Dim Match = True
        If parentNode.Name <> Snippet.Name Then
            Match = False
        End If
        If parentNode.Text <> Snippet.Text Then
            Match = False
        End If
        For Each Tag As String In parentNode.Tags
            If Snippet.Tags.Contains(Tag) = False Then
                Match = False
            End If
        Next
        If parentNode.Contents <> Snippet.Contents Then
            Match = False
        End If
        If parentNode.IsCategory <> Snippet.IsCategory Then
            Match = False
        End If

        If Match Then
            Return True
        End If

        For Each SubSnippet As SnippetNode In parentNode.Nodes
            If LibraryContains(SubSnippet, Snippet) Then
                Return True
            End If
        Next

        Return False

    End Function
#End Region

#Region "MenuBar"
    Private Sub SetSnippetsXmlPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetSnippetsXmlPathToolStripMenuItem.Click
        If My.Settings.XmlFilePathSnippets <> "" Then
            SelectXmlFile.InitialDirectory = My.Settings.XmlFilePathSnippets
        End If

        Dim Result = SelectXmlFile.ShowDialog()
        If Result = Windows.Forms.DialogResult.OK Then
            If SelectXmlFile.FileName <> "" And File.Exists(SelectXmlFile.FileName) Then
                My.Settings.XmlFilePathSnippets = SelectXmlFile.FileName
                Dim Reload = MsgBox("Do you want to reload the Snippets now?", MsgBoxStyle.YesNo)
                If Reload = MsgBoxResult.Yes Then
                    SnippetsLibrary.Nodes.Clear()
                    LoadSnippets(My.Settings.XmlFilePathSnippets)

                End If



            End If
        End If



    End Sub

    Private Sub SetTagsXmlPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetTagsXmlPathToolStripMenuItem.Click
        If My.Settings.XmlFilePathTags <> "" Then
            SelectXmlFile.InitialDirectory = My.Settings.XmlFilePathTags
        End If

        Dim Result = SelectXmlFile.ShowDialog()
        If Result = Windows.Forms.DialogResult.OK Then
            If SelectXmlFile.FileName <> "" And File.Exists(SelectXmlFile.FileName) Then
                My.Settings.XmlFilePathTags = SelectXmlFile.FileName
                Dim Reload = MsgBox("Do you want to reload the tags now?", MsgBoxStyle.YesNo)
                If Reload = MsgBoxResult.Yes Then
                    Tags.Clear()
                    LoadTags(My.Settings.XmlFilePathTags)
                    FillTagsCollectionContainer()
                End If


            End If
        End If

    End Sub

    Private Sub ImportSnippetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportSnippetsToolStripMenuItem.Click
        Dim Result = SelectXmlFile.ShowDialog()
        If Result = Windows.Forms.DialogResult.OK Then
            If SelectXmlFile.FileName <> "" And File.Exists(SelectXmlFile.FileName) Then
                Dim Import = MsgBox("Do you want to add the Snippets?", MsgBoxStyle.YesNo)
                If Import = MsgBoxResult.Yes Then

                    LoadSnippets(SelectXmlFile.FileName)

                End If



            End If
        End If


    End Sub

    Private Sub ImportTagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportTagsToolStripMenuItem.Click
        Dim Result = SelectXmlFile.ShowDialog()
        If Result = Windows.Forms.DialogResult.OK Then
            If SelectXmlFile.FileName <> "" And File.Exists(SelectXmlFile.FileName) Then
                Dim Import = MsgBox("Do you want to add the tags?", MsgBoxStyle.YesNo)
                If Import = MsgBoxResult.Yes Then
                    LoadTags(SelectXmlFile.FileName)
                    FillTagsCollectionContainer()
                End If


            End If
        End If
    End Sub

    Private Sub ExportTagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportTagsToolStripMenuItem.Click
        Dim Result = SaveXmlFile.ShowDialog()
        If Result = Windows.Forms.DialogResult.OK Then
            If SaveXmlFile.FileName <> "" Then
                Dim Save = MsgBox("Do you want to save the tags to : " & SaveXmlFile.FileName & "?", MsgBoxStyle.YesNo)
                If Save = MsgBoxResult.Yes Then
                    SaveTags(SaveXmlFile.FileName)

                End If
            End If
        End If
    End Sub

    Private Sub ExportSnipeptsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportSnipeptsToolStripMenuItem.Click
        Dim Result = SaveXmlFile.ShowDialog()
        If Result = Windows.Forms.DialogResult.OK Then
            If SaveXmlFile.FileName <> "" Then
                Dim Save = MsgBox("Do you want to save the Snippets to : " & SaveXmlFile.FileName & "?", MsgBoxStyle.YesNo)
                If Save = MsgBoxResult.Yes Then
                    SaveSnippets(SaveXmlFile.FileName)
                End If


            End If
        End If
    End Sub

    Private Sub ShortcutsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShortcutsToolStripMenuItem.Click
        MsgBox("Shortcuts:" & vbNewLine & "Create new Category: Ctrl + Enter" & vbNewLine & "Create New Subcategory: Shift + Enter" & vbNewLine & "Create new Snippet: Ctrl + N" & vbNewLine & "Create new sub Snippet: Shift + N" & vbNewLine & "Save Content: Ctrl + S" & vbNewLine & "Search: Ctrl + F")
    End Sub
#End Region

End Class

Public Class SnippetNode : Inherits TreeNode
    Public Tags As New List(Of String)
    Public Contents As String = ""
    Public IsCategory As Boolean = False

    Public LinkNode As SnippetNode
    Public Function Copy(IsSearchResult As Boolean) As SnippetNode
        Dim CopiedNode As New SnippetNode
        CopiedNode.Name = Me.Name
        CopiedNode.Text = Me.Text
        CopiedNode.Tags = Me.Tags
        CopiedNode.IsCategory = Me.IsCategory
        CopiedNode.Contents = Me.Contents
        If IsSearchResult Then
            CopiedNode.LinkNode = Me
        End If

        Return CopiedNode


    End Function
End Class