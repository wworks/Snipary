<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Snipery
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Snipery))
        Me.SnippetsLibrary = New System.Windows.Forms.TreeView()
        Me.SnippetType = New System.Windows.Forms.ImageList(Me.components)
        Me.SnippetContentEditor = New System.Windows.Forms.RichTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TagsCollectionContainer = New System.Windows.Forms.FlowLayoutPanel()
        Me.TagsContainer = New System.Windows.Forms.FlowLayoutPanel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.SaveSnippetButton = New System.Windows.Forms.Button()
        Me.SearchBox = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SearchResults = New System.Windows.Forms.TreeView()
        Me.LookInContentChk = New System.Windows.Forms.CheckBox()
        Me.LookInTagsChk = New System.Windows.Forms.CheckBox()
        Me.LookInNamesChck = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShortcutsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetSnippetsXmlPathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetTagsXmlPathToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportTagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportSnippetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportTagsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportSnipeptsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectXmlFile = New System.Windows.Forms.OpenFileDialog()
        Me.SaveXmlFile = New System.Windows.Forms.SaveFileDialog()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SnippetsLibrary
        '
        Me.SnippetsLibrary.ImageIndex = 0
        Me.SnippetsLibrary.ImageList = Me.SnippetType
        Me.SnippetsLibrary.LabelEdit = True
        Me.SnippetsLibrary.Location = New System.Drawing.Point(6, 19)
        Me.SnippetsLibrary.Name = "SnippetsLibrary"
        Me.SnippetsLibrary.SelectedImageIndex = 0
        Me.SnippetsLibrary.Size = New System.Drawing.Size(253, 632)
        Me.SnippetsLibrary.TabIndex = 0
        '
        'SnippetType
        '
        Me.SnippetType.ImageStream = CType(resources.GetObject("SnippetType.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.SnippetType.TransparentColor = System.Drawing.Color.Transparent
        Me.SnippetType.Images.SetKeyName(0, "Category.png")
        Me.SnippetType.Images.SetKeyName(1, "Snippet.png")
        '
        'SnippetContentEditor
        '
        Me.SnippetContentEditor.Location = New System.Drawing.Point(8, 19)
        Me.SnippetContentEditor.Name = "SnippetContentEditor"
        Me.SnippetContentEditor.Size = New System.Drawing.Size(554, 568)
        Me.SnippetContentEditor.TabIndex = 1
        Me.SnippetContentEditor.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TagsCollectionContainer)
        Me.GroupBox1.Location = New System.Drawing.Point(872, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(193, 252)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Attached Tags of Snippet:"
        '
        'TagsCollectionContainer
        '
        Me.TagsCollectionContainer.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TagsCollectionContainer.Location = New System.Drawing.Point(6, 31)
        Me.TagsCollectionContainer.Name = "TagsCollectionContainer"
        Me.TagsCollectionContainer.Padding = New System.Windows.Forms.Padding(2)
        Me.TagsCollectionContainer.Size = New System.Drawing.Size(179, 214)
        Me.TagsCollectionContainer.TabIndex = 3
        '
        'TagsContainer
        '
        Me.TagsContainer.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TagsContainer.Location = New System.Drawing.Point(6, 31)
        Me.TagsContainer.Name = "TagsContainer"
        Me.TagsContainer.Padding = New System.Windows.Forms.Padding(2)
        Me.TagsContainer.Size = New System.Drawing.Size(179, 363)
        Me.TagsContainer.TabIndex = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TagsContainer)
        Me.GroupBox2.Location = New System.Drawing.Point(872, 289)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(193, 401)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tag Library:"
        '
        'SaveSnippetButton
        '
        Me.SaveSnippetButton.Location = New System.Drawing.Point(8, 597)
        Me.SaveSnippetButton.Name = "SaveSnippetButton"
        Me.SaveSnippetButton.Size = New System.Drawing.Size(554, 46)
        Me.SaveSnippetButton.TabIndex = 2
        Me.SaveSnippetButton.Text = "Save Content (Ctrl+S)"
        Me.SaveSnippetButton.UseVisualStyleBackColor = True
        '
        'SearchBox
        '
        Me.SearchBox.Location = New System.Drawing.Point(6, 19)
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.Size = New System.Drawing.Size(252, 20)
        Me.SearchBox.TabIndex = 10
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.SearchButton)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.SearchResults)
        Me.GroupBox3.Controls.Add(Me.LookInContentChk)
        Me.GroupBox3.Controls.Add(Me.LookInTagsChk)
        Me.GroupBox3.Controls.Add(Me.LookInNamesChck)
        Me.GroupBox3.Controls.Add(Me.SearchBox)
        Me.GroupBox3.Location = New System.Drawing.Point(1090, 32)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(264, 658)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search Snippets:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 199)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Search Results:"
        '
        'SearchButton
        '
        Me.SearchButton.Location = New System.Drawing.Point(9, 140)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(249, 46)
        Me.SearchButton.TabIndex = 14
        Me.SearchButton.Text = "Search"
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Look in:"
        '
        'SearchResults
        '
        Me.SearchResults.LabelEdit = True
        Me.SearchResults.Location = New System.Drawing.Point(9, 224)
        Me.SearchResults.Name = "SearchResults"
        Me.SearchResults.Size = New System.Drawing.Size(249, 427)
        Me.SearchResults.TabIndex = 15
        '
        'LookInContentChk
        '
        Me.LookInContentChk.AutoSize = True
        Me.LookInContentChk.Checked = True
        Me.LookInContentChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LookInContentChk.Location = New System.Drawing.Point(21, 111)
        Me.LookInContentChk.Name = "LookInContentChk"
        Me.LookInContentChk.Size = New System.Drawing.Size(63, 17)
        Me.LookInContentChk.TabIndex = 13
        Me.LookInContentChk.Text = "Content"
        Me.LookInContentChk.UseVisualStyleBackColor = True
        '
        'LookInTagsChk
        '
        Me.LookInTagsChk.AutoSize = True
        Me.LookInTagsChk.Checked = True
        Me.LookInTagsChk.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LookInTagsChk.Location = New System.Drawing.Point(21, 88)
        Me.LookInTagsChk.Name = "LookInTagsChk"
        Me.LookInTagsChk.Size = New System.Drawing.Size(50, 17)
        Me.LookInTagsChk.TabIndex = 12
        Me.LookInTagsChk.Text = "Tags"
        Me.LookInTagsChk.UseVisualStyleBackColor = True
        '
        'LookInNamesChck
        '
        Me.LookInNamesChck.AutoSize = True
        Me.LookInNamesChck.Checked = True
        Me.LookInNamesChck.CheckState = System.Windows.Forms.CheckState.Checked
        Me.LookInNamesChck.Location = New System.Drawing.Point(21, 65)
        Me.LookInNamesChck.Name = "LookInNamesChck"
        Me.LookInNamesChck.Size = New System.Drawing.Size(59, 17)
        Me.LookInNamesChck.TabIndex = 11
        Me.LookInNamesChck.Text = "Names"
        Me.LookInNamesChck.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.SnippetsLibrary)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 32)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(267, 658)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Snippets:"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.SnippetContentEditor)
        Me.GroupBox5.Controls.Add(Me.SaveSnippetButton)
        Me.GroupBox5.Location = New System.Drawing.Point(290, 32)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(572, 658)
        Me.GroupBox5.TabIndex = 18
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Snippet Content:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ImportToolStripMenuItem, Me.SaveAsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1363, 24)
        Me.MenuStrip1.TabIndex = 19
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShortcutsToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.H), System.Windows.Forms.Keys)
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'ShortcutsToolStripMenuItem
        '
        Me.ShortcutsToolStripMenuItem.Name = "ShortcutsToolStripMenuItem"
        Me.ShortcutsToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.ShortcutsToolStripMenuItem.Text = "Shortcuts"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetSnippetsXmlPathToolStripMenuItem, Me.SetTagsXmlPathToolStripMenuItem})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'SetSnippetsXmlPathToolStripMenuItem
        '
        Me.SetSnippetsXmlPathToolStripMenuItem.Name = "SetSnippetsXmlPathToolStripMenuItem"
        Me.SetSnippetsXmlPathToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.SetSnippetsXmlPathToolStripMenuItem.Text = "Set startup Snippets Xml Path"
        '
        'SetTagsXmlPathToolStripMenuItem
        '
        Me.SetTagsXmlPathToolStripMenuItem.Name = "SetTagsXmlPathToolStripMenuItem"
        Me.SetTagsXmlPathToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.SetTagsXmlPathToolStripMenuItem.Text = "Set startup Tags Xml Path"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportTagsToolStripMenuItem, Me.ImportSnippetsToolStripMenuItem})
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ImportToolStripMenuItem.Text = "Import"
        '
        'ImportTagsToolStripMenuItem
        '
        Me.ImportTagsToolStripMenuItem.Name = "ImportTagsToolStripMenuItem"
        Me.ImportTagsToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ImportTagsToolStripMenuItem.Text = "Import tags"
        '
        'ImportSnippetsToolStripMenuItem
        '
        Me.ImportSnippetsToolStripMenuItem.Name = "ImportSnippetsToolStripMenuItem"
        Me.ImportSnippetsToolStripMenuItem.Size = New System.Drawing.Size(158, 22)
        Me.ImportSnippetsToolStripMenuItem.Text = "Import Snippets"
        '
        'SaveAsToolStripMenuItem
        '
        Me.SaveAsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportTagsToolStripMenuItem, Me.ExportSnipeptsToolStripMenuItem})
        Me.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        Me.SaveAsToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.SaveAsToolStripMenuItem.Text = "Export"
        '
        'ExportTagsToolStripMenuItem
        '
        Me.ExportTagsToolStripMenuItem.Name = "ExportTagsToolStripMenuItem"
        Me.ExportTagsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ExportTagsToolStripMenuItem.Text = "Export tags"
        '
        'ExportSnipeptsToolStripMenuItem
        '
        Me.ExportSnipeptsToolStripMenuItem.Name = "ExportSnipeptsToolStripMenuItem"
        Me.ExportSnipeptsToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ExportSnipeptsToolStripMenuItem.Text = "Export Snippets"
        '
        'SaveXmlFile
        '
        Me.SaveXmlFile.DefaultExt = "Xml"
        Me.SaveXmlFile.Filter = "Xml Files|*.xml"
        '
        'Snipery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1363, 700)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Snipery"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SnippetsLibrary As System.Windows.Forms.TreeView
    Friend WithEvents SnippetContentEditor As System.Windows.Forms.RichTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TagsContainer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents TagsCollectionContainer As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SaveSnippetButton As System.Windows.Forms.Button
    Friend WithEvents SearchBox As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LookInContentChk As System.Windows.Forms.CheckBox
    Friend WithEvents LookInTagsChk As System.Windows.Forms.CheckBox
    Friend WithEvents LookInNamesChck As System.Windows.Forms.CheckBox
    Friend WithEvents SearchResults As System.Windows.Forms.TreeView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetSnippetsXmlPathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetTagsXmlPathToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SelectXmlFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportTagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportSnippetsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveXmlFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ExportTagsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportSnipeptsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShortcutsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SnippetType As System.Windows.Forms.ImageList

End Class
