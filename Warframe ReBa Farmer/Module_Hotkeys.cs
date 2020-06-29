//http://www.pinvoke.net/default.aspx/user32.getasynckeystate

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Warframe_ReBa_Farmer
{
    class Module_Hotkeys
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey); // Keys enumeration

        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(int vKey);

        public static void Module_Hotkeys_Initialize()
        {
            HeldKeys.Add(Keys.Insert, false);
            HeldKeys.Add(Keys.Home, false);
            HeldKeys.Add(Keys.End, false);
            HeldKeys.Add(Keys.Delete, false);

            HotkeyTimer.Tick += HotkeyTimer_Tick;
            HotkeyTimer.Start();
        }

        public static Timer HotkeyTimer = new Timer();
        private static Dictionary<Keys, bool> HeldKeys = new Dictionary<Keys, bool>();
        private static void HotkeyTimer_Tick(object sender, EventArgs e)
        {
            int Button_Insert = GetAsyncKeyState(Keys.Insert);
            int Button_Home = GetAsyncKeyState(Keys.Home);
            int Button_End = GetAsyncKeyState(Keys.End);
            int Button_Delete = GetAsyncKeyState(Keys.Delete);
            int Button_PageUp = GetAsyncKeyState(Keys.PageUp);
            int Button_PageDown = GetAsyncKeyState(Keys.PageDown);
            int Button_WindowsKey = GetAsyncKeyState(Keys.LWin);

            if (Button_Insert != 0)
            {
                if (Button_Home != 0 && HeldKeys[Keys.Home] == false)
                {
                    HotkeyTimer.Stop();
                    Form_Main._FormReference.Relic_Button.PerformClick();
                }
                else if (Button_End != 0 && HeldKeys[Keys.End] == false)
                {
                    Form_Main._FormReference.Baro_Button.PerformClick();
                }
                else if (Button_Delete != 0)
                {
                    if (Form_OverlayRelic._FormReference != null)
                    {
                        HotkeyTimer.Stop();
                        Form_OverlayRelic._FormReference.Close();
                    }
                }
            }
            HeldKeys[Keys.Home] = Button_Home != 0;
            HeldKeys[Keys.End] = Button_End != 0;

            if (Button_PageUp != 0)
            {
                Form_Main._FormReference.CB_LockCursor.Checked = true;
            }
            else if (Button_PageDown != 0 | Button_WindowsKey != 0)
            {
                Form_Main._FormReference.CB_LockCursor.Checked = false;
            }
        }

    }
}
