using SportProject.Models;

namespace SportProject
{
internal static class Program
{
        [STAThread]
        static void Main()
        {
            bool exitProgram = false;
            while (!exitProgram)
            {
                using (var formLogin = new FormLogin())
                {
                    if (formLogin.ShowDialog() == DialogResult.OK)
                    {
                        using (var formMenu = new FormMenu(
                            formLogin.CurrentUser,
                            formLogin.IsGuest))
                        {
                            if (formMenu.ShowDialog() == DialogResult.Cancel)
                            {
                                continue;
                            }
                            else
                            {
                                exitProgram = true;
                            }
                        }
                    }
                    else
                    {
                        exitProgram = true;
                    }
                }
            }
        }
    }
}