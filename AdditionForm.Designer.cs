namespace NEVOD
{
    partial class AdditionForm
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
            this.PathToDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AddDetStation = new System.Windows.Forms.Button();
            this.RemoveDetStation = new System.Windows.Forms.Button();
            this.RemoveCluster = new System.Windows.Forms.Button();
            this.AddCluster = new System.Windows.Forms.Button();
            this.AddDetStationTB = new System.Windows.Forms.TextBox();
            this.AddClusterTB = new System.Windows.Forms.TextBox();
            this.RemoveDetStationTB = new System.Windows.Forms.TextBox();
            this.RemoveClusterTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.VoltageTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PathToDB
            // 
            this.PathToDB.Location = new System.Drawing.Point(155, 6);
            this.PathToDB.Name = "PathToDB";
            this.PathToDB.Size = new System.Drawing.Size(473, 20);
            this.PathToDB.TabIndex = 1;
            this.PathToDB.Text = "C:/Users/Николай/Desktop/Nevod.accdb";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Путь к базе данных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(374, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Добавить детектирующую станцию №";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(361, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Удалить детектирующую станцию №";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(209, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Добавить кластер №";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(10, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(196, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Удалить кластер №";
            // 
            // AddDetStation
            // 
            this.AddDetStation.Location = new System.Drawing.Point(508, 97);
            this.AddDetStation.Name = "AddDetStation";
            this.AddDetStation.Size = new System.Drawing.Size(120, 28);
            this.AddDetStation.TabIndex = 7;
            this.AddDetStation.Text = "Добавить";
            this.AddDetStation.UseVisualStyleBackColor = true;
            this.AddDetStation.Click += new System.EventHandler(this.AddDetStation_Click);
            // 
            // RemoveDetStation
            // 
            this.RemoveDetStation.Location = new System.Drawing.Point(508, 142);
            this.RemoveDetStation.Name = "RemoveDetStation";
            this.RemoveDetStation.Size = new System.Drawing.Size(120, 28);
            this.RemoveDetStation.TabIndex = 8;
            this.RemoveDetStation.Text = "Удалить";
            this.RemoveDetStation.UseVisualStyleBackColor = true;
            this.RemoveDetStation.Click += new System.EventHandler(this.RemoveDetStation_Click);
            // 
            // RemoveCluster
            // 
            this.RemoveCluster.Location = new System.Drawing.Point(346, 267);
            this.RemoveCluster.Name = "RemoveCluster";
            this.RemoveCluster.Size = new System.Drawing.Size(120, 28);
            this.RemoveCluster.TabIndex = 9;
            this.RemoveCluster.Text = "Удалить";
            this.RemoveCluster.UseVisualStyleBackColor = true;
            this.RemoveCluster.Click += new System.EventHandler(this.RemoveCluster_Click);
            // 
            // AddCluster
            // 
            this.AddCluster.Location = new System.Drawing.Point(346, 207);
            this.AddCluster.Name = "AddCluster";
            this.AddCluster.Size = new System.Drawing.Size(120, 28);
            this.AddCluster.TabIndex = 10;
            this.AddCluster.Text = "Добавить";
            this.AddCluster.UseVisualStyleBackColor = true;
            this.AddCluster.Click += new System.EventHandler(this.AddCluster_Click);
            // 
            // AddDetStationTB
            // 
            this.AddDetStationTB.Location = new System.Drawing.Point(392, 65);
            this.AddDetStationTB.Name = "AddDetStationTB";
            this.AddDetStationTB.Size = new System.Drawing.Size(100, 20);
            this.AddDetStationTB.TabIndex = 11;
            // 
            // AddClusterTB
            // 
            this.AddClusterTB.Location = new System.Drawing.Point(227, 212);
            this.AddClusterTB.Name = "AddClusterTB";
            this.AddClusterTB.Size = new System.Drawing.Size(100, 20);
            this.AddClusterTB.TabIndex = 12;
            // 
            // RemoveDetStationTB
            // 
            this.RemoveDetStationTB.Location = new System.Drawing.Point(392, 145);
            this.RemoveDetStationTB.Name = "RemoveDetStationTB";
            this.RemoveDetStationTB.Size = new System.Drawing.Size(100, 20);
            this.RemoveDetStationTB.TabIndex = 13;
            // 
            // RemoveClusterTB
            // 
            this.RemoveClusterTB.Location = new System.Drawing.Point(227, 272);
            this.RemoveClusterTB.Name = "RemoveClusterTB";
            this.RemoveClusterTB.Size = new System.Drawing.Size(100, 20);
            this.RemoveClusterTB.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(106, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(280, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Укажите напряжение питания(в вольтах)";
            // 
            // VoltageTB
            // 
            this.VoltageTB.Location = new System.Drawing.Point(392, 100);
            this.VoltageTB.Name = "VoltageTB";
            this.VoltageTB.Size = new System.Drawing.Size(100, 20);
            this.VoltageTB.TabIndex = 16;
            // 
            // AdditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(648, 342);
            this.Controls.Add(this.VoltageTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.RemoveClusterTB);
            this.Controls.Add(this.RemoveDetStationTB);
            this.Controls.Add(this.AddClusterTB);
            this.Controls.Add(this.AddDetStationTB);
            this.Controls.Add(this.AddCluster);
            this.Controls.Add(this.RemoveCluster);
            this.Controls.Add(this.RemoveDetStation);
            this.Controls.Add(this.AddDetStation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PathToDB);
            this.Name = "AdditionForm";
            this.Text = "Добавление(удаление) новых кластеров, детектирующих станций";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox PathToDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AddDetStation;
        private System.Windows.Forms.Button RemoveDetStation;
        private System.Windows.Forms.Button RemoveCluster;
        private System.Windows.Forms.Button AddCluster;
        private System.Windows.Forms.TextBox AddDetStationTB;
        private System.Windows.Forms.TextBox AddClusterTB;
        private System.Windows.Forms.TextBox RemoveDetStationTB;
        private System.Windows.Forms.TextBox RemoveClusterTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox VoltageTB;
    }
}