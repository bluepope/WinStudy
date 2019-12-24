using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleKeySender
{
    class Program
    {

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern uint FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern uint FindWindowEx(uint hWnd1, uint hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern uint SendMessage(uint hwnd, uint wMsg, uint wParam, uint lParam);

        [DllImport("user32.dll")]
        public static extern uint PostMessage(uint hwnd, uint wMsg, uint wParam, uint lParam);

        const uint WM_KEYDOWN = 0x100;
        const uint WM_KEYUP = 0x101;
        const uint WM_CHAR = 0x102;
        const uint WM_PASTE = 0x0302;
        const uint WM_SYSCOMMAND = 0x018;
        const uint SC_CLOSE = 0x053;

        [STAThread]
        static void Main(string[] args)
        {
            uint handle;

            //핸들을 찾는다. Spy+를 통해 찾은 클래스 이름과 캡션을 이용하면 된다. 둘 중 하나만 알경우에도 찾을 수 있다. 그때는 하나의 인자를 null로 넘겨 주면된다.
            handle = FindWindow(null, "닷넷 C# 개발자 모임");
            //찾은 핸들에서 자식 윈도우 핸들을 찾기 위해서는 FindWindowEx를 이용한다.

            //EVA_VH_ListControl_Dblclk //화면창

            //RichEdit20W 텍스트창
            handle = FindWindowEx(handle, 0, "RichEdit20W", null);

            Clipboard.SetText("테스트..");
            PostMessage(handle, WM_PASTE, 0, 0);
            PostMessage(handle, WM_KEYDOWN, 0xD, 0); //enter
        }
    }
}
