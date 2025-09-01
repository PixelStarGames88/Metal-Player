using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metal_Player
{
    public class ButtonTrackVisible
    {
        private Track _track;
        private Button _buttonChoice;
        private PanelTrack _panelTrack;
        //Антон Олегович Дамрин
        public ButtonTrackVisible(Track track, PanelTrack panelTrack, int PosX, int PosY, int Wibth, int Height)
        {
            _track = track;
            _panelTrack = panelTrack;
            _buttonChoice = new Button();
            _buttonChoice.Text = (_track.Name + "\n" + _track.Artist);
            _buttonChoice.Font = new Font("Old English Text MT", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            _buttonChoice.TextAlign = ContentAlignment.TopLeft;
            _buttonChoice.Location = new Point(PosX, PosY);
            _buttonChoice.Size = new Size(Wibth, Height);
            _buttonChoice.BackColor = Consts.MainColor;
            _buttonChoice.ForeColor = Color.White;
            _buttonChoice.FlatStyle = FlatStyle.Popup;
            _buttonChoice.Click += btnShow;

            

        }

        private void btnShow(object sender, EventArgs e)
        {
            _panelTrack?.Show(_track);
        }

        public void SetParent(Control parent)
        {
            parent.Controls.Add(_buttonChoice);
        }
    }
}
