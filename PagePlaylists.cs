using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metal_Player
{
    public class PagePlaylists : Page
    {
        private Library _library;
        public Size GetSize
        {
            get { return _panel.Size; }
        }

        PagePlaylists(ControlPages parent, Library library, int Wibth, int Height, string namePage, string textPage) 
            : base(parent, Wibth, Height, namePage, textPage)
        {
            _library = library;
        }
        public override void AddElements()
        {

        }

    }
}
