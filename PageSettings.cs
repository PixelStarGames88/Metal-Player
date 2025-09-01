using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Drawing;
using NAudio.Wave;
using System.IO;

namespace Metal_Player
{
    public class PageSettings : Page
    {
        private Label _addPath;
        private TextBox _editPath;
        private Button _buttonFile;
        private Button _buttonAccept;
        private Library _library;

        public PageSettings(ControlPages parent, int Wibth, int Height, Color BtnColor, Color PageColor,
                            Color HeaderColor, Color TextColor, Library library, string namePage = "Page", string textPage = "Only Text") 
                            : base(parent, Wibth, Height, BtnColor, PageColor, HeaderColor, TextColor, namePage, textPage)
        {
            _library = library;

            _addPath = new Label();
            _addPath.Size = new System.Drawing.Size(200, 30);
            _addPath.Location = new System.Drawing.Point(25, 70);
            _addPath.Text = "Specify the path to audio files.";
            _addPath.ForeColor = TextColor;

            _editPath = new TextBox();
            _editPath.Size = new System.Drawing.Size(300, 30);
            _editPath.Location = new System.Drawing.Point(25, 110);
            _editPath.ForeColor = TextColor;
            _editPath.BackColor = Color.Black;
            _editPath.Font = new Font("Century Gothic", 11, FontStyle.Regular);
            _editPath.Text = "";

            _buttonAccept = new Button();
            _buttonAccept.Size = new System.Drawing.Size(100, 40);
            _buttonAccept.Location = new System.Drawing.Point(25, 150);
            _buttonAccept.Text = "Accept";
            _buttonAccept.Font = new Font("Old English Text MT", 20, FontStyle.Regular);
            _buttonAccept.FlatStyle = FlatStyle.Popup;
            _buttonAccept.ForeColor = System.Drawing.Color.White;
            _buttonAccept.BackColor = _panel.BackColor;
            _buttonAccept.Click += btnAccept;

            _buttonFile = new Button();
            _buttonFile.Size = new System.Drawing.Size(60, _editPath.Height);
            _buttonFile.Location = new System.Drawing.Point(325, 110);
            _buttonFile.Text = "...";
            _buttonFile.Font = new Font("Old English Text MT", 10, FontStyle.Regular);
            _buttonFile.FlatStyle = FlatStyle.Popup;
            _buttonFile.ForeColor = System.Drawing.Color.White;
            _buttonFile.BackColor = _panel.BackColor;
            _buttonFile.Click += btnDialog;

            _panel.Controls.Add(_buttonFile);
            _panel.Controls.Add(_buttonAccept);
            _panel.Controls.Add(_addPath);
            _panel.Controls.Add(_editPath);
        }

        private void btnDialog(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();

            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                _editPath.Text = folderDialog.SelectedPath;
            }
        }
        private void btnAccept(object sender, EventArgs e)
        {
            if(_editPath.Text != "" && _library != null)
            {
                _library.AppendTrack(_editPath.Text);
                _masterOfPages.FillPages();
            }
            
        }

    }

}
