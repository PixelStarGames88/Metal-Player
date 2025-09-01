using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;


namespace Metal_Player
{
    public class ControlPages
    {
        private int _height;
        private int _width;
        private int _size;
        private int _top;
        public Page[] Pages { get; set; }

        private string _path;

        public string Path
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
            }
        }

        public ControlPages(int size, int width, int height)
        {
            _height = height;
            _width = width;
            _size = size;

            _top = -1;
            Pages = new Page[_size];
        }

        public void Add(Page page)
        {
            if(_top + 1 < _size)
            {
                _top++;
                Pages[_top] = page;
            }
        }
        public void AddToForm(Form form)
        {
            if(_top >= 0)
            {
                for(int i = 0 ; i <= _top; i++)
                {
                    if(i == 0)
                    {
                        Pages[i].AddPage(form, 0, 0, _top);
                    }
                    else
                    {
                        Pages[i].AddPage(form, 0, Pages[i-1].PageHeader.Height * i, _top);
                    }
                }
            }
        }

        public void OpenClose(int index, bool visible)
        {
            if(visible)
            {
                Pages[index].Show();
            }
            else
            {
                Pages[index].Hide();
            }
        }

        public void FillPages()
        {
            for(int i = 0 ; i< 1; i++)
            {
                Pages[i].AddElements();
            }
        }
    }
}
