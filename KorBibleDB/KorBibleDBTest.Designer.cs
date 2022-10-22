
namespace KorBibleDB
{
    partial class KorBibleDBTest
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbEndBook = new System.Windows.Forms.ComboBox();
            this.BtnExtract = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.BtnCreateDB = new System.Windows.Forms.Button();
            this.NumEndPassage = new System.Windows.Forms.NumericUpDown();
            this.NumEndChapter = new System.Windows.Forms.NumericUpDown();
            this.NumStartPassage = new System.Windows.Forms.NumericUpDown();
            this.NumStartChapter = new System.Windows.Forms.NumericUpDown();
            this.CmbStartBook = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumEndPassage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumEndChapter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumStartPassage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumStartChapter)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.CmbEndBook);
            this.panel1.Controls.Add(this.BtnExtract);
            this.panel1.Controls.Add(this.txtOutput);
            this.panel1.Controls.Add(this.BtnCreateDB);
            this.panel1.Controls.Add(this.NumEndPassage);
            this.panel1.Controls.Add(this.NumEndChapter);
            this.panel1.Controls.Add(this.NumStartPassage);
            this.panel1.Controls.Add(this.NumStartChapter);
            this.panel1.Controls.Add(this.CmbStartBook);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 220);
            this.panel1.TabIndex = 9;
            // 
            // CmbEndBook
            // 
            this.CmbEndBook.FormattingEnabled = true;
            this.CmbEndBook.Location = new System.Drawing.Point(12, 38);
            this.CmbEndBook.Name = "CmbEndBook";
            this.CmbEndBook.Size = new System.Drawing.Size(121, 20);
            this.CmbEndBook.TabIndex = 9;
            // 
            // BtnExtract
            // 
            this.BtnExtract.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnExtract.Location = new System.Drawing.Point(260, 37);
            this.BtnExtract.Name = "BtnExtract";
            this.BtnExtract.Size = new System.Drawing.Size(138, 22);
            this.BtnExtract.TabIndex = 8;
            this.BtnExtract.Text = "Extract";
            this.BtnExtract.UseVisualStyleBackColor = true;
            this.BtnExtract.Click += new System.EventHandler(this.BtnExtract_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(11, 63);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(387, 152);
            this.txtOutput.TabIndex = 7;
            this.txtOutput.Text = "";
            // 
            // BtnCreateDB
            // 
            this.BtnCreateDB.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnCreateDB.Location = new System.Drawing.Point(260, 11);
            this.BtnCreateDB.Name = "BtnCreateDB";
            this.BtnCreateDB.Size = new System.Drawing.Size(138, 20);
            this.BtnCreateDB.TabIndex = 6;
            this.BtnCreateDB.Text = "Create DB";
            this.BtnCreateDB.UseVisualStyleBackColor = true;
            this.BtnCreateDB.Click += new System.EventHandler(this.BtnCreateDB_Click);
            // 
            // NumEndPassage
            // 
            this.NumEndPassage.Location = new System.Drawing.Point(199, 38);
            this.NumEndPassage.Name = "NumEndPassage";
            this.NumEndPassage.Size = new System.Drawing.Size(55, 21);
            this.NumEndPassage.TabIndex = 5;
            this.NumEndPassage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumEndChapter
            // 
            this.NumEndChapter.Location = new System.Drawing.Point(138, 38);
            this.NumEndChapter.Name = "NumEndChapter";
            this.NumEndChapter.Size = new System.Drawing.Size(55, 21);
            this.NumEndChapter.TabIndex = 4;
            this.NumEndChapter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumEndChapter.ValueChanged += new System.EventHandler(this.NumEndChapter_ValueChanged);
            // 
            // NumStartPassage
            // 
            this.NumStartPassage.Location = new System.Drawing.Point(199, 10);
            this.NumStartPassage.Name = "NumStartPassage";
            this.NumStartPassage.Size = new System.Drawing.Size(55, 21);
            this.NumStartPassage.TabIndex = 2;
            this.NumStartPassage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumStartPassage.ValueChanged += new System.EventHandler(this.NumStartPassage_ValueChanged);
            // 
            // NumStartChapter
            // 
            this.NumStartChapter.Location = new System.Drawing.Point(138, 10);
            this.NumStartChapter.Name = "NumStartChapter";
            this.NumStartChapter.Size = new System.Drawing.Size(55, 21);
            this.NumStartChapter.TabIndex = 1;
            this.NumStartChapter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumStartChapter.ValueChanged += new System.EventHandler(this.NumStartChapter_ValueChanged);
            // 
            // CmbStartBook
            // 
            this.CmbStartBook.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CmbStartBook.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CmbStartBook.FormattingEnabled = true;
            this.CmbStartBook.Location = new System.Drawing.Point(11, 11);
            this.CmbStartBook.Name = "CmbStartBook";
            this.CmbStartBook.Size = new System.Drawing.Size(121, 20);
            this.CmbStartBook.TabIndex = 0;
            this.CmbStartBook.SelectedIndexChanged += new System.EventHandler(this.CmbBook_SelectedIndexChanged);
            // 
            // KorBibleDBTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 220);
            this.Controls.Add(this.panel1);
            this.Name = "KorBibleDBTest";
            this.Text = "KorBibleDB Test";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumEndPassage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumEndChapter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumStartPassage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumStartChapter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown NumStartChapter;
        private System.Windows.Forms.ComboBox CmbStartBook;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button BtnCreateDB;
        private System.Windows.Forms.NumericUpDown NumEndPassage;
        private System.Windows.Forms.NumericUpDown NumEndChapter;
        private System.Windows.Forms.NumericUpDown NumStartPassage;
        private System.Windows.Forms.Button BtnExtract;
        private System.Windows.Forms.ComboBox CmbEndBook;
    }
}

