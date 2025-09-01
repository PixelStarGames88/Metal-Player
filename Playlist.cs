using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metal_Player
{
    public class Playlist
    {
        private string _name;
        private PagePlaylists _parent;
        private Panel _body;
        private Button _buttonChoice;
        private Button _quit;
        private Label _title;
        
        public Playlist(string name, PagePlaylists parent, int PosX, int PosY, int Wibth, int Height)
        {
            _name = name;
            _parent = parent;

            _body = new Panel();
            _body.Size = parent.GetSize;
            _body.Location = new Point(0, 0);
            _body.BackColor = Consts.MainColor;
            _body.ForeColor = Color.White;
            _body.Visible = false;

            _title = new Label();
            _title.Text = name;

        }
    }
}
