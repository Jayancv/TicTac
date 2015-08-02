namespace Tic_Tac_Toe
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singlePlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGame = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hihgestScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.A1 = new System.Windows.Forms.Button();
            this.B1 = new System.Windows.Forms.Button();
            this.A3 = new System.Windows.Forms.Button();
            this.A2 = new System.Windows.Forms.Button();
            this.B3 = new System.Windows.Forms.Button();
            this.C3 = new System.Windows.Forms.Button();
            this.C2 = new System.Windows.Forms.Button();
            this.C1 = new System.Windows.Forms.Button();
            this.B2 = new System.Windows.Forms.Button();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.submit = new System.Windows.Forms.Button();
            this.btnCancelP2 = new System.Windows.Forms.Button();
            this.player2 = new System.Windows.Forms.TextBox();
            this.player1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtNetName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cancelP1 = new System.Windows.Forms.Button();
            this.submitP1 = new System.Windows.Forms.Button();
            this.singlePlayer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.test2 = new System.Windows.Forms.Label();
            this.boardS = new System.Windows.Forms.Label();
            this.boardM = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.p1Won = new System.Windows.Forms.Label();
            this.p1Def = new System.Windows.Forms.Label();
            this.p2Won = new System.Windows.Forms.Label();
            this.p2Def = new System.Windows.Forms.Label();
            this.highScore = new System.Windows.Forms.Panel();
            this.BtnScoureClose = new System.Windows.Forms.Button();
            this.labMulScore = new System.Windows.Forms.Label();
            this.labSinScore = new System.Windows.Forms.Label();
            this.labSinName = new System.Windows.Forms.Label();
            this.labMulName = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rServer = new System.Windows.Forms.RadioButton();
            this.rClient = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.highScore.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.newGame,
            this.helpToolStripMenuItem,
            this.scoreToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(472, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.newGameToolStripMenuItem.Text = "Select Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // modeToolStripMenuItem
            // 
            this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playersToolStripMenuItem,
            this.singlePlayerToolStripMenuItem});
            this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
            this.modeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modeToolStripMenuItem.Text = "Mode";
            this.modeToolStripMenuItem.Click += new System.EventHandler(this.modeToolStripMenuItem_Click);
            // 
            // playersToolStripMenuItem
            // 
            this.playersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.networkToolStripMenuItem,
            this.normalToolStripMenuItem});
            this.playersToolStripMenuItem.Name = "playersToolStripMenuItem";
            this.playersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.playersToolStripMenuItem.Text = "2-Players";
            this.playersToolStripMenuItem.Click += new System.EventHandler(this.multi);
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.networkToolStripMenuItem.Text = "Network";
            this.networkToolStripMenuItem.Click += new System.EventHandler(this.networkToolStripMenuItem_Click);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // singlePlayerToolStripMenuItem
            // 
            this.singlePlayerToolStripMenuItem.Name = "singlePlayerToolStripMenuItem";
            this.singlePlayerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.singlePlayerToolStripMenuItem.Text = "Single Player";
            this.singlePlayerToolStripMenuItem.Click += new System.EventHandler(this.single);
            // 
            // newGame
            // 
            this.newGame.Name = "newGame";
            this.newGame.Size = new System.Drawing.Size(77, 20);
            this.newGame.Text = "New Game";
            this.newGame.Click += new System.EventHandler(this.newGame_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // scoreToolStripMenuItem
            // 
            this.scoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hihgestScoreToolStripMenuItem});
            this.scoreToolStripMenuItem.Name = "scoreToolStripMenuItem";
            this.scoreToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.scoreToolStripMenuItem.Text = "Score";
            this.scoreToolStripMenuItem.Click += new System.EventHandler(this.scoreToolStripMenuItem_Click);
            // 
            // hihgestScoreToolStripMenuItem
            // 
            this.hihgestScoreToolStripMenuItem.Name = "hihgestScoreToolStripMenuItem";
            this.hihgestScoreToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.hihgestScoreToolStripMenuItem.Text = "Hihgest score";
            this.hihgestScoreToolStripMenuItem.Click += new System.EventHandler(this.hihgestScoreToolStripMenuItem_Click);
            // 
            // A1
            // 
            this.A1.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A1.Location = new System.Drawing.Point(23, 98);
            this.A1.Name = "A1";
            this.A1.Size = new System.Drawing.Size(80, 80);
            this.A1.TabIndex = 1;
            this.A1.UseVisualStyleBackColor = true;
            this.A1.Click += new System.EventHandler(this.btnClick);
            this.A1.MouseEnter += new System.EventHandler(this.mouse_Enter);
            this.A1.MouseLeave += new System.EventHandler(this.mouse_leave);
            // 
            // B1
            // 
            this.B1.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B1.Location = new System.Drawing.Point(23, 184);
            this.B1.Name = "B1";
            this.B1.Size = new System.Drawing.Size(80, 80);
            this.B1.TabIndex = 2;
            this.B1.UseVisualStyleBackColor = true;
            this.B1.Click += new System.EventHandler(this.btnClick);
            this.B1.MouseEnter += new System.EventHandler(this.mouse_Enter);
            this.B1.MouseLeave += new System.EventHandler(this.mouse_leave);
            // 
            // A3
            // 
            this.A3.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A3.Location = new System.Drawing.Point(195, 98);
            this.A3.Name = "A3";
            this.A3.Size = new System.Drawing.Size(80, 80);
            this.A3.TabIndex = 3;
            this.A3.UseVisualStyleBackColor = true;
            this.A3.Click += new System.EventHandler(this.btnClick);
            this.A3.MouseEnter += new System.EventHandler(this.mouse_Enter);
            this.A3.MouseLeave += new System.EventHandler(this.mouse_leave);
            // 
            // A2
            // 
            this.A2.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A2.Location = new System.Drawing.Point(109, 98);
            this.A2.Name = "A2";
            this.A2.Size = new System.Drawing.Size(80, 80);
            this.A2.TabIndex = 4;
            this.A2.UseVisualStyleBackColor = true;
            this.A2.Click += new System.EventHandler(this.btnClick);
            this.A2.MouseEnter += new System.EventHandler(this.mouse_Enter);
            this.A2.MouseLeave += new System.EventHandler(this.mouse_leave);
            // 
            // B3
            // 
            this.B3.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B3.Location = new System.Drawing.Point(195, 184);
            this.B3.Name = "B3";
            this.B3.Size = new System.Drawing.Size(80, 80);
            this.B3.TabIndex = 5;
            this.B3.UseVisualStyleBackColor = true;
            this.B3.Click += new System.EventHandler(this.btnClick);
            this.B3.MouseEnter += new System.EventHandler(this.mouse_Enter);
            this.B3.MouseLeave += new System.EventHandler(this.mouse_leave);
            // 
            // C3
            // 
            this.C3.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C3.Location = new System.Drawing.Point(195, 271);
            this.C3.Name = "C3";
            this.C3.Size = new System.Drawing.Size(80, 80);
            this.C3.TabIndex = 6;
            this.C3.UseVisualStyleBackColor = true;
            this.C3.Click += new System.EventHandler(this.btnClick);
            this.C3.MouseEnter += new System.EventHandler(this.mouse_Enter);
            this.C3.MouseLeave += new System.EventHandler(this.mouse_leave);
            // 
            // C2
            // 
            this.C2.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C2.Location = new System.Drawing.Point(109, 271);
            this.C2.Name = "C2";
            this.C2.Size = new System.Drawing.Size(80, 80);
            this.C2.TabIndex = 7;
            this.C2.UseVisualStyleBackColor = true;
            this.C2.Click += new System.EventHandler(this.btnClick);
            this.C2.MouseEnter += new System.EventHandler(this.mouse_Enter);
            this.C2.MouseLeave += new System.EventHandler(this.mouse_leave);
            // 
            // C1
            // 
            this.C1.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.C1.Location = new System.Drawing.Point(23, 271);
            this.C1.Name = "C1";
            this.C1.Size = new System.Drawing.Size(80, 80);
            this.C1.TabIndex = 8;
            this.C1.UseVisualStyleBackColor = true;
            this.C1.Click += new System.EventHandler(this.btnClick);
            this.C1.MouseEnter += new System.EventHandler(this.mouse_Enter);
            this.C1.MouseLeave += new System.EventHandler(this.mouse_leave);
            // 
            // B2
            // 
            this.B2.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B2.Location = new System.Drawing.Point(109, 184);
            this.B2.Name = "B2";
            this.B2.Size = new System.Drawing.Size(80, 80);
            this.B2.TabIndex = 9;
            this.B2.UseVisualStyleBackColor = true;
            this.B2.Click += new System.EventHandler(this.btnClick);
            this.B2.MouseEnter += new System.EventHandler(this.mouse_Enter);
            this.B2.MouseLeave += new System.EventHandler(this.mouse_leave);
            // 
            // fontDialog1
            // 
            this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.submit);
            this.panel1.Controls.Add(this.btnCancelP2);
            this.panel1.Controls.Add(this.player2);
            this.panel1.Controls.Add(this.player1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(32, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 162);
            this.panel1.TabIndex = 10;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(122, 18);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(8, 8);
            this.panel3.TabIndex = 7;
            // 
            // submit
            // 
            this.submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.Location = new System.Drawing.Point(48, 116);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 5;
            this.submit.Text = "Save";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.save_Click);
            // 
            // btnCancelP2
            // 
            this.btnCancelP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelP2.Location = new System.Drawing.Point(168, 116);
            this.btnCancelP2.Name = "btnCancelP2";
            this.btnCancelP2.Size = new System.Drawing.Size(75, 23);
            this.btnCancelP2.TabIndex = 6;
            this.btnCancelP2.Text = "Cancel";
            this.btnCancelP2.UseVisualStyleBackColor = true;
            this.btnCancelP2.Click += new System.EventHandler(this.btnCancelP2_Click);
            // 
            // player2
            // 
            this.player2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2.Location = new System.Drawing.Point(155, 69);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(132, 24);
            this.player2.TabIndex = 4;
            // 
            // player1
            // 
            this.player1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1.Location = new System.Drawing.Point(3, 69);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(132, 24);
            this.player1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(190, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Player 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Two Players";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.TxtNetName);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(31, 162);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(284, 158);
            this.panel4.TabIndex = 8;
            this.panel4.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(139, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // TxtNetName
            // 
            this.TxtNetName.Location = new System.Drawing.Point(75, 50);
            this.TxtNetName.Name = "TxtNetName";
            this.TxtNetName.Size = new System.Drawing.Size(100, 20);
            this.TxtNetName.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Location = new System.Drawing.Point(75, 20);
            this.label6.MaximumSize = new System.Drawing.Size(10000, 1000);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Two Player - Network";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cancelP1);
            this.panel2.Controls.Add(this.submitP1);
            this.panel2.Controls.Add(this.singlePlayer);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(32, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 162);
            this.panel2.TabIndex = 6;
            this.panel2.Visible = false;
            // 
            // cancelP1
            // 
            this.cancelP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelP1.Location = new System.Drawing.Point(190, 118);
            this.cancelP1.Name = "cancelP1";
            this.cancelP1.Size = new System.Drawing.Size(75, 23);
            this.cancelP1.TabIndex = 4;
            this.cancelP1.Text = "Cancel";
            this.cancelP1.UseVisualStyleBackColor = true;
            this.cancelP1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // submitP1
            // 
            this.submitP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitP1.Location = new System.Drawing.Point(23, 119);
            this.submitP1.Name = "submitP1";
            this.submitP1.Size = new System.Drawing.Size(75, 23);
            this.submitP1.TabIndex = 3;
            this.submitP1.Text = "Submit";
            this.submitP1.UseVisualStyleBackColor = true;
            this.submitP1.Click += new System.EventHandler(this.submitP1_Click);
            // 
            // singlePlayer
            // 
            this.singlePlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.singlePlayer.Location = new System.Drawing.Point(64, 79);
            this.singlePlayer.Name = "singlePlayer";
            this.singlePlayer.Size = new System.Drawing.Size(157, 24);
            this.singlePlayer.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(100, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 18);
            this.label5.TabIndex = 1;
            this.label5.Text = "Player Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Single Player";
            // 
            // test2
            // 
            this.test2.AutoSize = true;
            this.test2.Location = new System.Drawing.Point(343, 109);
            this.test2.Name = "test2";
            this.test2.Size = new System.Drawing.Size(0, 13);
            this.test2.TabIndex = 12;
            // 
            // boardS
            // 
            this.boardS.AutoSize = true;
            this.boardS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardS.Location = new System.Drawing.Point(317, 122);
            this.boardS.Name = "boardS";
            this.boardS.Size = new System.Drawing.Size(35, 16);
            this.boardS.TabIndex = 13;
            this.boardS.Text = "You";
            this.boardS.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.boardS.Click += new System.EventHandler(this.boardS_Click);
            // 
            // boardM
            // 
            this.boardM.AutoSize = true;
            this.boardM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardM.Location = new System.Drawing.Point(294, 245);
            this.boardM.Name = "boardM";
            this.boardM.Size = new System.Drawing.Size(74, 16);
            this.boardM.TabIndex = 14;
            this.boardM.Text = "Computer";
            this.boardM.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(383, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Won";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(364, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Defeated";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(383, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Won";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(364, 274);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Defeated";
            // 
            // p1Won
            // 
            this.p1Won.AutoSize = true;
            this.p1Won.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Won.Location = new System.Drawing.Point(445, 108);
            this.p1Won.Name = "p1Won";
            this.p1Won.Size = new System.Drawing.Size(47, 15);
            this.p1Won.TabIndex = 19;
            this.p1Won.Text = "0           ";
            // 
            // p1Def
            // 
            this.p1Def.AutoSize = true;
            this.p1Def.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Def.Location = new System.Drawing.Point(445, 162);
            this.p1Def.Name = "p1Def";
            this.p1Def.Size = new System.Drawing.Size(44, 15);
            this.p1Def.TabIndex = 20;
            this.p1Def.Text = "0          ";
            // 
            // p2Won
            // 
            this.p2Won.AutoSize = true;
            this.p2Won.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Won.Location = new System.Drawing.Point(445, 223);
            this.p2Won.Name = "p2Won";
            this.p2Won.Size = new System.Drawing.Size(41, 15);
            this.p2Won.TabIndex = 21;
            this.p2Won.Text = "0         ";
            // 
            // p2Def
            // 
            this.p2Def.AutoSize = true;
            this.p2Def.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Def.Location = new System.Drawing.Point(445, 274);
            this.p2Def.Name = "p2Def";
            this.p2Def.Size = new System.Drawing.Size(47, 15);
            this.p2Def.TabIndex = 22;
            this.p2Def.Text = "0           ";
            // 
            // highScore
            // 
            this.highScore.BackColor = System.Drawing.Color.LightGray;
            this.highScore.Controls.Add(this.BtnScoureClose);
            this.highScore.Controls.Add(this.labMulScore);
            this.highScore.Controls.Add(this.labSinScore);
            this.highScore.Controls.Add(this.labSinName);
            this.highScore.Controls.Add(this.labMulName);
            this.highScore.Controls.Add(this.label14);
            this.highScore.Controls.Add(this.label13);
            this.highScore.Controls.Add(this.label12);
            this.highScore.Location = new System.Drawing.Point(140, 109);
            this.highScore.Name = "highScore";
            this.highScore.Size = new System.Drawing.Size(228, 238);
            this.highScore.TabIndex = 23;
            this.highScore.Visible = false;
            this.highScore.Paint += new System.Windows.Forms.PaintEventHandler(this.highScore_Paint);
            // 
            // BtnScoureClose
            // 
            this.BtnScoureClose.BackColor = System.Drawing.Color.Gainsboro;
            this.BtnScoureClose.Location = new System.Drawing.Point(77, 196);
            this.BtnScoureClose.Name = "BtnScoureClose";
            this.BtnScoureClose.Size = new System.Drawing.Size(75, 23);
            this.BtnScoureClose.TabIndex = 8;
            this.BtnScoureClose.Text = "Close";
            this.BtnScoureClose.UseVisualStyleBackColor = false;
            this.BtnScoureClose.Click += new System.EventHandler(this.BtnScoureClose_Click);
            // 
            // labMulScore
            // 
            this.labMulScore.AutoSize = true;
            this.labMulScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMulScore.Location = new System.Drawing.Point(140, 141);
            this.labMulScore.Name = "labMulScore";
            this.labMulScore.Size = new System.Drawing.Size(50, 16);
            this.labMulScore.TabIndex = 7;
            this.labMulScore.Text = "              ";
            // 
            // labSinScore
            // 
            this.labSinScore.AutoSize = true;
            this.labSinScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSinScore.Location = new System.Drawing.Point(39, 150);
            this.labSinScore.Name = "labSinScore";
            this.labSinScore.Size = new System.Drawing.Size(44, 16);
            this.labSinScore.TabIndex = 6;
            this.labSinScore.Text = "            ";
            // 
            // labSinName
            // 
            this.labSinName.AutoSize = true;
            this.labSinName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labSinName.Location = new System.Drawing.Point(39, 118);
            this.labSinName.Name = "labSinName";
            this.labSinName.Size = new System.Drawing.Size(47, 16);
            this.labSinName.TabIndex = 5;
            this.labSinName.Text = "             ";
            // 
            // labMulName
            // 
            this.labMulName.AutoSize = true;
            this.labMulName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMulName.Location = new System.Drawing.Point(140, 114);
            this.labMulName.Name = "labMulName";
            this.labMulName.Size = new System.Drawing.Size(35, 16);
            this.labMulName.TabIndex = 4;
            this.labMulName.Text = "         ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Minion Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(121, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 22);
            this.label14.TabIndex = 2;
            this.label14.Text = "Multi Player";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Minion Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 22);
            this.label13.TabIndex = 1;
            this.label13.Text = "Single Player";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Adobe Fangsong Std R", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(56, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 30);
            this.label12.TabIndex = 0;
            this.label12.Text = "HighScore";
            // 
            // groupBox1
            // 
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.rClient);
            this.groupBox1.Controls.Add(this.rServer);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(42, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 37);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // rServer
            // 
            this.rServer.AutoSize = true;
            this.rServer.Location = new System.Drawing.Point(9, 14);
            this.rServer.Name = "rServer";
            this.rServer.Size = new System.Drawing.Size(56, 17);
            this.rServer.TabIndex = 0;
            this.rServer.TabStop = true;
            this.rServer.Text = "Server";
            this.rServer.UseVisualStyleBackColor = true;
            // 
            // rClient
            // 
            this.rClient.AutoSize = true;
            this.rClient.Location = new System.Drawing.Point(101, 12);
            this.rClient.Name = "rClient";
            this.rClient.Size = new System.Drawing.Size(51, 17);
            this.rClient.TabIndex = 1;
            this.rClient.TabStop = true;
            this.rClient.Text = "Client";
            this.rClient.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 415);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.highScore);
            this.Controls.Add(this.p2Def);
            this.Controls.Add(this.p2Won);
            this.Controls.Add(this.p1Def);
            this.Controls.Add(this.p1Won);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.boardM);
            this.Controls.Add(this.boardS);
            this.Controls.Add(this.test2);
            this.Controls.Add(this.B2);
            this.Controls.Add(this.C1);
            this.Controls.Add(this.C2);
            this.Controls.Add(this.C3);
            this.Controls.Add(this.B3);
            this.Controls.Add(this.A2);
            this.Controls.Add(this.A3);
            this.Controls.Add(this.B1);
            this.Controls.Add(this.A1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TicTacToe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.highScore.ResumeLayout(false);
            this.highScore.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Button A1;
        private System.Windows.Forms.Button B1;
        private System.Windows.Forms.Button A3;
        private System.Windows.Forms.Button A2;
        private System.Windows.Forms.Button B3;
        private System.Windows.Forms.Button C3;
        private System.Windows.Forms.Button C2;
        private System.Windows.Forms.Button C1;
        private System.Windows.Forms.Button B2;
        private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singlePlayerToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.ToolStripMenuItem newGame;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox player2;
        private System.Windows.Forms.TextBox player1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button submitP1;
        private System.Windows.Forms.TextBox singlePlayer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cancelP1;
        private System.Windows.Forms.Button btnCancelP2;
        private System.Windows.Forms.ToolStripMenuItem scoreToolStripMenuItem;
        private System.Windows.Forms.Label test2;
        private System.Windows.Forms.ToolStripMenuItem hihgestScoreToolStripMenuItem;
        private System.Windows.Forms.Label boardS;
        private System.Windows.Forms.Label boardM;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label p1Won;
        private System.Windows.Forms.Label p1Def;
        private System.Windows.Forms.Label p2Won;
        private System.Windows.Forms.Label p2Def;
        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtNetName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel highScore;
        private System.Windows.Forms.Label labMulName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labMulScore;
        private System.Windows.Forms.Label labSinScore;
        private System.Windows.Forms.Label labSinName;
        private System.Windows.Forms.Button BtnScoureClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rClient;
        private System.Windows.Forms.RadioButton rServer;
    }
}

