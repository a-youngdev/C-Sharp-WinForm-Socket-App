using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace librarySERVER
{
    class elipseCONTROL: Component
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreatRoundRectRgn
            (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBotomRect,
             int nWidthElipse,
             int nHeghtElipse
            );
        private Control _cntrl;
        private int _CornerRidius = 30;

        public Control TargetControl
        {
            get { return _cntrl; }

            set { _cntrl = value;

                _cntrl.SizeChanged += (sender, eventArgs) => _cntrl.Region = Region.FromHrgn(CreatRoundRectRgn(0, 0,_cntrl.Width, _cntrl.Height, _CornerRidius, _CornerRidius));

            }

        }
        public int CornerRadius
        {
            get { return _CornerRidius; }
            set
            {
                _CornerRidius = value;
                if (_cntrl != null)
                {
                    _cntrl.Region = Region.FromHrgn(CreatRoundRectRgn(0, 0, _cntrl.Width, _cntrl.Height, _CornerRidius, _CornerRidius));
                }
            }
        }
}
}
