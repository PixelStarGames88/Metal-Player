using NAudio.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metal_Player
{
    public class PanelTrack
    {
        private Track _track;

        private Button _outsideButton;

        private bool isPanelShown;
        private Panel _body;
        private Button _quit;
        private Button _play;
        private Button _pause;
        private Button _nextTrack;
        private Button _previousTrack;

        private Label _title;
        private Label _junTitle;

        private int _wibth;
        private System.Windows.Forms.Timer _timer;
        
        public PanelTrack(Control parent, int Wibth, int Height)
        {
            _wibth = Wibth;
            _body = new Panel();
            _body.Size = new Size(_wibth, Height);
            _body.Location = new Point(_wibth, 0);
            _body.BackColor = Color.Black;

            _body.Font = new Font("Old English Text MT", 20, FontStyle.Regular);

            _quit = new Button();
            _quit.Location = new Point(20, 20);
            _quit.Size = new Size(100, 50);
            _quit.Text = "Back";
            _quit.FlatStyle = FlatStyle.Popup;
            _quit.BackColor = Color.Black;
            _quit.ForeColor = Color.White;
            _quit.Click += btnQuit;
            _body.Controls.Add(_quit);

            _play = new Button();
            _play.Size = new Size(100, 100);
            _play.Location = new Point(_wibth/2 - 50, Height * 3/4);
            _play.Text = "Play";
            _play.ForeColor = Color.White;
            _play.BackColor = Color.Black;
            _play.FlatStyle = FlatStyle.Popup;
            _play.Click += PlayBtn;
            _play.Visible = false;
            _body.Controls.Add(_play);

            _pause = new Button();
            _pause.Size = new Size(100, 100);
            _pause.Location = new Point(_wibth / 2 - 50, Height * 3 / 4);
            _pause.Text = "Pause";
            _pause.ForeColor = Color.White;
            _pause.BackColor = Color.Black;
            _pause.FlatStyle = FlatStyle.Popup;
            _pause.Click += PauseBtn;
            _body.Controls.Add(_pause);

            _previousTrack = new Button();
            _previousTrack.Font = new Font("Old English Text MT", 10, FontStyle.Regular);
            _previousTrack.Size = new Size(50, 50);
            _previousTrack.Location = new Point(_wibth / 2 - 150, Height * 3 / 4 + 25);
            _previousTrack.Text = "Last";
            _previousTrack.ForeColor = Color.White;
            _previousTrack.BackColor = Color.Black;
            _previousTrack.FlatStyle = FlatStyle.Popup;
            _body.Controls.Add(_previousTrack);

            _nextTrack = new Button();
            _nextTrack.Size = new Size(50, 50);
            _nextTrack.Location = new Point(_wibth / 2 + 100, Height * 3 / 4 + 25);
            _nextTrack.Font = new Font("Old English Text MT", 10, FontStyle.Regular);
            _nextTrack.Text = "Next";
            _nextTrack.ForeColor = Color.White;
            _nextTrack.BackColor = Color.Black;
            _nextTrack.FlatStyle = FlatStyle.Popup;
            _body.Controls.Add(_nextTrack);

            _title = new Label();
            _title.Size = new Size(400, 50);
            _title.Location = new Point(_wibth / 2 - 200, Height * 3 / 4 - 75);
            _title.TextAlign = ContentAlignment.MiddleCenter;
            _title.ForeColor = Color.White;
            _title.BackColor = Color.Black;

            _junTitle = new Label();
            _junTitle.Font = new Font("Old English Text MT", 15, FontStyle.Regular);
            _junTitle.Size = new Size(200, 50);
            _junTitle.Location = new Point(_wibth / 2 - 100, Height * 3 / 4 - 40);
            _junTitle.TextAlign = ContentAlignment.MiddleCenter;
            _junTitle.ForeColor = Color.White;
            _junTitle.BackColor = Color.Black;

            _outsideButton = new Button();
            _outsideButton.Size = new Size(_wibth, 65);
            _outsideButton.Location = new Point(-5, Height - 100);
            _outsideButton.Font = new Font("Old English Text MT", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            _outsideButton.ForeColor = Color.White;
            _outsideButton.BackColor = Color.Black;
            _outsideButton.FlatStyle = FlatStyle.Standard;
            _outsideButton.TextAlign = ContentAlignment.MiddleLeft;
            _outsideButton.Click += outsideButton;

            _body.Controls.Add(_junTitle);
            _body.Controls.Add( _title);

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1;

            isPanelShown = false;

            parent.Controls.Add(_body);
            parent.Controls.Add(_outsideButton);
        }
        private void PauseBtn(object sender, EventArgs e)
        {
            PauseTrack();
        }
        private void PauseTrack()
        {
            if (_pause.Visible)
            {
                _pause.Visible = false;
                _play.Visible = true;
            }
            _track.GetPause();
        }
        private void PlayBtn(object sender, EventArgs e)
        {
            PlayTrack();
            
        }
        private void PlayTrack()
        {
            if (_play.Visible)
            {
                _play.Visible = false;
                _pause.Visible = true;
            }
            _track.GetPlay();
        }
        private void AnimationOn(bool panelShow)
        {
            _timer.Tick -= SlideOn;
            _timer.Tick -= SlideOff;

            if (panelShow)
            {
                _timer.Tick += SlideOn;
            }
            else
            {
                _timer.Tick += SlideOff;
            }
            
        }
        private void SlideOn(object sender, EventArgs e)
        {
            _body.Left -= 30;
            if( _body.Left <= 0 )
            {
                _timer.Stop();
                isPanelShown = true;
            }
        }
        private void SlideOff(object sender, EventArgs e)
        {
            _body.Left += 30;
            if (_body.Left >= _wibth)
            {
                _timer.Stop();
                isPanelShown = false;
            }
        }
        private void btnQuit(object sender, EventArgs e)
        {
            if(isPanelShown)
            {
                AnimationOn(false);
                _timer.Start();
            }
        }
        public void Show(Track track)
        {
            if (!isPanelShown)
            {
                if(_track != track)
                {
                    if(_track != null)
                    {
                        _track.GetStop();
                    }
                    _track = track;
                    _title.Text = _track.Name;
                    _junTitle.Text = _track.Artist;
                    _outsideButton.Text = _track.Name + "\n" + _track.Artist;
                    PlayTrack();
                }
                AnimationOn(true);
                _timer.Start();
            }
        }

        private void outsideButton(object sender, EventArgs e)
        {
            if(_track != null & !isPanelShown)
            {
                AnimationOn(true);
                _timer.Start();
            }
        }
    }
}
