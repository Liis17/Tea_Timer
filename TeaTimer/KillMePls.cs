using System.Diagnostics;

namespace TeaTimer
{
    class KillMePls
    {
        public static void Kill()
        {
            Process.GetCurrentProcess().Kill();
        }

    }
}
