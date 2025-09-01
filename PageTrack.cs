using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metal_Player
{
    public class PageTrack : Page
    {
        private Panel _textBox;
        private List<ButtonTrackVisible> _list;
        private Library _library;
        private PanelTrack _panelTrack;

        public PageTrack(ControlPages parent, int Wibth, int Height, Library library, PanelTrack panelTrack,
                         string namePage = "Page", string textPage = "Only Text") : base(parent, Wibth, Height, namePage, textPage)
        {
            _list = new List<ButtonTrackVisible>();
            _textBox = new Panel();
            _textBox.Location = new System.Drawing.Point(0, 80);
            _textBox.Size = new System.Drawing.Size(_wibth - 165, 570);
            _textBox.BackColor = Consts.MainColor;
            _textBox.AutoScroll = true;
            _panel.Controls.Add(_textBox);
            _library = library;
            _panelTrack = panelTrack;
        }
        public override void AddElements()
        {
            for(int i = 0; i < _library.Tracks.Count; i++)
            {
                if(i == 0)
                {
                    _list.Add(new ButtonTrackVisible(_library.Tracks[i], _panelTrack, 0, 0, _textBox.Width - 25, 60));
                }
                else
                {
                    _list.Add(new ButtonTrackVisible(_library.Tracks[i], _panelTrack, 0, 60 * i, _textBox.Width - 25, 60));
                }
                _list[i].SetParent(_textBox);
            }
        }
    }
}
