using System;
using System.Drawing;
using System.Windows.Forms;

namespace Metal_Player
{
    class MainForm : Form
    {

        public MainForm()
        {
            int wibth = 600;
            int height = 750;
            this.MinimumSize = new System.Drawing.Size(wibth, height);
            this.MaximumSize = new System.Drawing.Size(wibth, height);
            this.Font = new Font("Old English Text MT", 20, FontStyle.Regular);
            this.Text = "MetaL Player";
            this.Icon = new Icon("Red.ICO");
            this.BackColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            this.ForeColor = Color.Black;

            ControlPages pages = new ControlPages(8, wibth, height);
            Library tracks = new Library();
            PanelTrack trackControl = new PanelTrack(this, wibth, height);
            
            pages.Add(new PageSlide(pages, wibth, height, tracks, trackControl, "Tracks", "Tracks"));
            pages.Add(new Page(pages, wibth, height, "Albums", "Albums"));
            pages.Add(new Page(pages, wibth, height, "Artists", "Artists"));
            pages.Add(new Page(pages, wibth, height, "Genres", "Genres"));
            pages.Add(new Page(pages, wibth, height, "Countries", "Countries"));
            pages.Add(new Page(pages, wibth, height, "Playlists", "Your playlists"));
            pages.Add(new PageSettings(pages, wibth, height, Color.Black, 
                       Consts.MainColor, Color.DarkRed, Color.White, tracks, "Settings", "Settings"));
            pages.Add(new Page(pages, wibth, height, Color.Black, Consts.MainColor, Color.DarkRed, Color.White, "Authors", "Authors"));

            pages.AddToForm(this);

        }
    }
}
