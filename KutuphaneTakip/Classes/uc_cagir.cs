using System.Windows.Controls;

namespace KutuphaneTakip.Classes
{
    public class uc_cagir
    {

        public static void Uc_Ekle(Grid grid, UserControl userControl)
        {
            if (grid.Children.Count > 0)
            {
                grid.Children.Clear();
                grid.Children.Add(userControl);
            }
            else
            {
                grid.Children.Add(userControl);
            }
        }

    }
}
