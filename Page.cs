using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metal_Player
{
    public class Page
    {
        protected ControlPages _masterOfPages;
        protected int _wibth;
        protected int _height;
        public Button PageHeader { get; private set; }
        protected Panel _panel;
        protected Label _text;

        protected Color _btnColor;
        protected Color _headerColor;
        protected Color _pageColor;
        protected Color _textColor;

        public Page(ControlPages parent, int Wibth, int Height, string namePage = "Page", string textPage = "Only Text")
        {
            _wibth = Wibth;
            _height = Height;

            _panel = new Panel();
            PageHeader = new Button();
            _text = new Label();

            _btnColor = Consts.MainColor;
            _pageColor = Consts.MainColor;
            _textColor = Color.White;
            _headerColor = Color.White;

            PageHeader.Text = namePage;
            PageHeader.FlatStyle = FlatStyle.Popup;
            PageHeader.BackColor = _btnColor;
            PageHeader.ForeColor = _headerColor;
            PageHeader.Click += ChoiceTab;

            _text.Text = textPage;
            _panel.Size = new Size(_wibth - 150, _height);
            _panel.Location = new Point(150, 0);
            _panel.Controls.Add(_text);
            _panel.BackColor = _pageColor;
            _panel.ForeColor = _textColor;
            _panel.Visible = true;

            _text.Location = new Point(25, 25);
            _text.Size = new Size(200, 30);
            _masterOfPages = parent;
        }

        public Page(ControlPages library, int Wibth, int Height, Color BtnColor, Color PageColor, Color HeaderColor, Color TextColor, string namePage = "Page", string textPage = "Only Text")
        {
            _wibth = Wibth;
            _height = Height;

            _panel = new Panel();
            PageHeader = new Button();
            _text = new Label();

            _btnColor = BtnColor;
            _pageColor = PageColor;
            _textColor = TextColor;
            _headerColor = HeaderColor;

            PageHeader.Text = namePage;
            PageHeader.FlatStyle = FlatStyle.Popup;
            PageHeader.BackColor = _btnColor;
            PageHeader.ForeColor = _headerColor;
            PageHeader.Click += ChoiceTab;

            _text.Text = textPage;
            _panel.Size = new Size(_wibth - 150, _height);
            _panel.Location = new Point(150, 0);
            _panel.Controls.Add(_text);
            _panel.BackColor = _pageColor;
            _panel.ForeColor = _textColor;
            _panel.Visible = true;

            _text.Location = new Point(25, 25);
            _text.Size = new Size(200, 30);

            _masterOfPages = library;
        }

        public virtual void AddPage(Form form, int PosX, int PosY, int NuberPages)
        {
            PageHeader.Size = new Size(150, (_height - 100) / (NuberPages + 1));
            PageHeader.Location = new Point(PosX, PosY); 

            form.Controls.Add(PageHeader);
            form.Controls.Add(_panel);
        }

        public void Hide() { _panel.Visible = false; }
        public void Show() { _panel.Visible = true; }
        public void ChoiceTab(object o, EventArgs args)
        {
            for(int i = 0; i < _masterOfPages.Pages.Length; i++)
            {
                if (_masterOfPages.Pages[i] == this)
                {
                    _masterOfPages.OpenClose(i, true);
                }
                else
                {
                    _masterOfPages.OpenClose(i, false);
                }
            }
        }

        public virtual void AddElements()
        {
           
        }
    }
}
