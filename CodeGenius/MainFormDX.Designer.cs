namespace CodeGenius
{
    partial class MainFormDX
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormDX));
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barMenu = new DevExpress.XtraBars.Bar();
            this.siFile = new DevExpress.XtraBars.BarSubItem();
            this.siView = new DevExpress.XtraBars.BarSubItem();
            this.biDBExplorer = new DevExpress.XtraBars.BarButtonItem();
            this.biTemplateManager = new DevExpress.XtraBars.BarButtonItem();
            this.siTools = new DevExpress.XtraBars.BarSubItem();
            this.biEncryption = new DevExpress.XtraBars.BarButtonItem();
            this.biGenerateDBDocument = new DevExpress.XtraBars.BarButtonItem();
            this.biStringBuilderTool = new DevExpress.XtraBars.BarButtonItem();
            this.biEncodeConvert = new DevExpress.XtraBars.BarButtonItem();
            this.biBatchCodeGenerator = new DevExpress.XtraBars.BarButtonItem();
            this.biTableProperty = new DevExpress.XtraBars.BarButtonItem();
            this.siHelp = new DevExpress.XtraBars.BarSubItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockTemplateManager = new DevExpress.XtraBars.Docking.DockPanel();
            this.controlContainer1 = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucTemplateManager1 = new CodeGenius.UserControls.ucTemplateManager();
            this.dockDBExplorer = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.ucDBExplorer1 = new CodeGenius.UserControls.ucDBExplorer();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barbtnMainForm = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barbtnAbout = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barbtnExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem7 = new DevExpress.XtraBars.BarSubItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyPopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockTemplateManager.SuspendLayout();
            this.controlContainer1.SuspendLayout();
            this.dockDBExplorer.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.notifyPopupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // documentManager1
            // 
            this.documentManager1.MdiParent = this;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // tabbedView1
            // 
            this.tabbedView1.PopupMenuShowing += new DevExpress.XtraBars.Docking2010.Views.PopupMenuShowingEventHandler(this.tabbedView1_PopupMenuShowing);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.barMenu,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockManager = this.dockManager1;
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.siFile,
            this.siView,
            this.barbtnMainForm,
            this.barbtnAbout,
            this.barbtnExit,
            this.siTools,
            this.barSubItem5,
            this.barSubItem6,
            this.barSubItem7,
            this.biDBExplorer,
            this.biEncryption,
            this.biGenerateDBDocument,
            this.biStringBuilderTool,
            this.siHelp,
            this.biTemplateManager,
            this.biBatchCodeGenerator,
            this.biTableProperty,
            this.biEncodeConvert});
            this.barManager1.MainMenu = this.barMenu;
            this.barManager1.MaxItemId = 20;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Tools";
            this.bar1.Visible = false;
            // 
            // barMenu
            // 
            this.barMenu.BarName = "Main menu";
            this.barMenu.DockCol = 0;
            this.barMenu.DockRow = 0;
            this.barMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.siFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.siView),
            new DevExpress.XtraBars.LinkPersistInfo(this.siTools),
            new DevExpress.XtraBars.LinkPersistInfo(this.siHelp)});
            this.barMenu.OptionsBar.AllowQuickCustomization = false;
            this.barMenu.OptionsBar.DrawBorder = false;
            this.barMenu.OptionsBar.DrawSizeGrip = true;
            this.barMenu.OptionsBar.MultiLine = true;
            this.barMenu.OptionsBar.UseWholeRow = true;
            this.barMenu.Text = "Main menu";
            // 
            // siFile
            // 
            this.siFile.Caption = "文件(&F)";
            this.siFile.Id = 0;
            this.siFile.Name = "siFile";
            // 
            // siView
            // 
            this.siView.Caption = "视图(&V)";
            this.siView.Id = 1;
            this.siView.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biDBExplorer),
            new DevExpress.XtraBars.LinkPersistInfo(this.biTemplateManager)});
            this.siView.Name = "siView";
            // 
            // biDBExplorer
            // 
            this.biDBExplorer.Caption = "资源管理器";
            this.biDBExplorer.Id = 10;
            this.biDBExplorer.Name = "biDBExplorer";
            this.biDBExplorer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biDBExplorer_ItemClick);
            // 
            // biTemplateManager
            // 
            this.biTemplateManager.Caption = "模板管理器";
            this.biTemplateManager.Id = 15;
            this.biTemplateManager.Name = "biTemplateManager";
            this.biTemplateManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biTemplateManager_ItemClick);
            // 
            // siTools
            // 
            this.siTools.Caption = "工具(&T)";
            this.siTools.Id = 5;
            this.siTools.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.biEncryption),
            new DevExpress.XtraBars.LinkPersistInfo(this.biGenerateDBDocument),
            new DevExpress.XtraBars.LinkPersistInfo(this.biStringBuilderTool),
            new DevExpress.XtraBars.LinkPersistInfo(this.biEncodeConvert),
            new DevExpress.XtraBars.LinkPersistInfo(this.biBatchCodeGenerator, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.biTableProperty)});
            this.siTools.Name = "siTools";
            // 
            // biEncryption
            // 
            this.biEncryption.Caption = "加密/解密";
            this.biEncryption.Id = 11;
            this.biEncryption.ImageIndex = 0;
            this.biEncryption.Name = "biEncryption";
            this.biEncryption.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biEncryption_ItemClick);
            // 
            // biGenerateDBDocument
            // 
            this.biGenerateDBDocument.Caption = "生成数据字典";
            this.biGenerateDBDocument.Id = 12;
            this.biGenerateDBDocument.ImageIndex = 2;
            this.biGenerateDBDocument.Name = "biGenerateDBDocument";
            this.biGenerateDBDocument.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biGenerateDBDocument_ItemClick);
            // 
            // biStringBuilderTool
            // 
            this.biStringBuilderTool.Caption = "StringBuilder工具";
            this.biStringBuilderTool.Id = 13;
            this.biStringBuilderTool.ImageIndex = 1;
            this.biStringBuilderTool.Name = "biStringBuilderTool";
            this.biStringBuilderTool.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biStringBuilderTool_ItemClick);
            // 
            // biEncodeConvert
            // 
            this.biEncodeConvert.Caption = "文件编码转化";
            this.biEncodeConvert.Id = 19;
            this.biEncodeConvert.Name = "biEncodeConvert";
            this.biEncodeConvert.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biEncodeConvert_ItemClick);
            // 
            // biBatchCodeGenerator
            // 
            this.biBatchCodeGenerator.Caption = "代码批量生成器";
            this.biBatchCodeGenerator.Id = 17;
            this.biBatchCodeGenerator.Name = "biBatchCodeGenerator";
            this.biBatchCodeGenerator.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biBatchCodeGenerator_ItemClick);
            // 
            // biTableProperty
            // 
            this.biTableProperty.Caption = "表属性";
            this.biTableProperty.Id = 18;
            this.biTableProperty.Name = "biTableProperty";
            this.biTableProperty.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biTableProperty_ItemClick);
            // 
            // siHelp
            // 
            this.siHelp.Caption = "帮助(&H)";
            this.siHelp.Id = 14;
            this.siHelp.Name = "siHelp";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(681, 53);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 559);
            this.barDockControlBottom.Size = new System.Drawing.Size(681, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 53);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 506);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(681, 53);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 506);
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.HiddenPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockTemplateManager});
            this.dockManager1.MenuManager = this.barManager1;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockDBExplorer});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl"});
            // 
            // dockTemplateManager
            // 
            this.dockTemplateManager.Controls.Add(this.controlContainer1);
            this.dockTemplateManager.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockTemplateManager.ID = new System.Guid("2bef4e13-097d-4743-9b22-878b90e71a2e");
            this.dockTemplateManager.Location = new System.Drawing.Point(481, 52);
            this.dockTemplateManager.Name = "dockTemplateManager";
            this.dockTemplateManager.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockTemplateManager.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockTemplateManager.SavedIndex = 1;
            this.dockTemplateManager.Size = new System.Drawing.Size(200, 507);
            this.dockTemplateManager.Text = "模板管理器";
            this.dockTemplateManager.Visibility = DevExpress.XtraBars.Docking.DockVisibility.Hidden;
            // 
            // controlContainer1
            // 
            this.controlContainer1.Controls.Add(this.ucTemplateManager1);
            this.controlContainer1.Location = new System.Drawing.Point(4, 23);
            this.controlContainer1.Name = "controlContainer1";
            this.controlContainer1.Size = new System.Drawing.Size(192, 480);
            this.controlContainer1.TabIndex = 0;
            // 
            // ucTemplateManager1
            // 
            this.ucTemplateManager1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTemplateManager1.Location = new System.Drawing.Point(0, 0);
            this.ucTemplateManager1.Name = "ucTemplateManager1";
            this.ucTemplateManager1.Size = new System.Drawing.Size(192, 480);
            this.ucTemplateManager1.TabIndex = 0;
            // 
            // dockDBExplorer
            // 
            this.dockDBExplorer.Controls.Add(this.dockPanel1_Container);
            this.dockDBExplorer.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockDBExplorer.ID = new System.Guid("dd236fff-c44a-4201-8695-61edca7bdafb");
            this.dockDBExplorer.Location = new System.Drawing.Point(0, 53);
            this.dockDBExplorer.Name = "dockDBExplorer";
            this.dockDBExplorer.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockDBExplorer.Size = new System.Drawing.Size(200, 506);
            this.dockDBExplorer.Text = "资源管理器";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.ucDBExplorer1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(192, 479);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // ucDBExplorer1
            // 
            this.ucDBExplorer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDBExplorer1.Location = new System.Drawing.Point(0, 0);
            this.ucDBExplorer1.Name = "ucDBExplorer1";
            this.ucDBExplorer1.Size = new System.Drawing.Size(192, 479);
            this.ucDBExplorer1.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Locker.ico");
            this.imageList1.Images.SetKeyName(1, "String_16.ico");
            this.imageList1.Images.SetKeyName(2, "Word_Large.ico");
            // 
            // barbtnMainForm
            // 
            this.barbtnMainForm.Caption = "显示/隐藏主窗体(&S)";
            this.barbtnMainForm.Glyph = global::CodeGenius.Properties.Resources.Window_16;
            this.barbtnMainForm.Id = 2;
            this.barbtnMainForm.Name = "barbtnMainForm";
            this.barbtnMainForm.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnMainForm_ItemClick);
            // 
            // barbtnAbout
            // 
            this.barbtnAbout.Caption = "关于(&A)";
            this.barbtnAbout.Glyph = global::CodeGenius.Properties.Resources.Info_16;
            this.barbtnAbout.Id = 3;
            this.barbtnAbout.Name = "barbtnAbout";
            this.barbtnAbout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnAbout_ItemClick);
            // 
            // barbtnExit
            // 
            this.barbtnExit.Caption = "退出(&E)";
            this.barbtnExit.Glyph = global::CodeGenius.Properties.Resources.Exit_16;
            this.barbtnExit.Id = 4;
            this.barbtnExit.Name = "barbtnExit";
            this.barbtnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnExit_ItemClick);
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "加密\\解密";
            this.barSubItem5.Id = 7;
            this.barSubItem5.Name = "barSubItem5";
            // 
            // barSubItem6
            // 
            this.barSubItem6.Caption = "生成数据字典";
            this.barSubItem6.Id = 8;
            this.barSubItem6.Name = "barSubItem6";
            // 
            // barSubItem7
            // 
            this.barSubItem7.Caption = "StringBuilder工具";
            this.barSubItem7.Id = 9;
            this.barSubItem7.Name = "barSubItem7";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "程序已最小化";
            this.notifyIcon1.BalloonTipTitle = "CodeGenius";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CodeGenius";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp);
            // 
            // notifyPopupMenu
            // 
            this.notifyPopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnMainForm),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnAbout),
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnExit)});
            this.notifyPopupMenu.Manager = this.barManager1;
            this.notifyPopupMenu.Name = "notifyPopupMenu";
            // 
            // MainFormDX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 582);
            this.Controls.Add(this.dockDBExplorer);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainFormDX";
            this.Text = "CodeGenius";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainFormDX_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockTemplateManager.ResumeLayout(false);
            this.controlContainer1.ResumeLayout(false);
            this.dockDBExplorer.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.notifyPopupMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar barMenu;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem siFile;
        private DevExpress.XtraBars.BarSubItem siView;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private DevExpress.XtraBars.PopupMenu notifyPopupMenu;
        private DevExpress.XtraBars.BarLargeButtonItem barbtnMainForm;
        private DevExpress.XtraBars.BarLargeButtonItem barbtnAbout;
        private DevExpress.XtraBars.BarLargeButtonItem barbtnExit;
        private DevExpress.XtraBars.BarSubItem siTools;
        private DevExpress.XtraBars.BarSubItem barSubItem5;
        private DevExpress.XtraBars.BarSubItem barSubItem6;
        private DevExpress.XtraBars.BarSubItem barSubItem7;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockDBExplorer;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private UserControls.ucDBExplorer ucDBExplorer1;
        private DevExpress.XtraBars.BarButtonItem biDBExplorer;
        private DevExpress.XtraBars.BarButtonItem biEncryption;
        private DevExpress.XtraBars.BarButtonItem biGenerateDBDocument;
        private DevExpress.XtraBars.BarButtonItem biStringBuilderTool;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarSubItem siHelp;
        private DevExpress.XtraBars.BarButtonItem biTemplateManager;
        private DevExpress.XtraBars.Docking.DockPanel dockTemplateManager;
        private DevExpress.XtraBars.Docking.ControlContainer controlContainer1;
        private UserControls.ucTemplateManager ucTemplateManager1;
        private DevExpress.XtraBars.BarButtonItem biBatchCodeGenerator;
        private DevExpress.XtraBars.BarButtonItem biTableProperty;
        private DevExpress.XtraBars.BarButtonItem biEncodeConvert;
    }
}