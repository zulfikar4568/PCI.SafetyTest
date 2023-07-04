using System.Drawing;

namespace PCI.SafetyTest.Components
{
    public static class ZIAlertBox
    {
        public static void ZIAlertBoxShow(Color BackColor, Color Color, string Title, string Text, Image Icon)
        {
            FormAlert form = new FormAlert();
            form.BackColor = BackColor;
            form.ColorAlertBox = Color;
            form.TitleAlertBox = Title;
            form.TextAlertBox = Text;
            form.IconAlertBox = Icon;
            form.ShowDialog();
        }

        public static void Information(string Title, string Message)
        {
            ZIAlertBoxShow(Color.LightSteelBlue, Color.DodgerBlue, Title, Message, Properties.Resources.information);
        }
        public static void Error(string Title, string Message)
        {
            ZIAlertBoxShow(Color.LightPink, Color.DarkRed, Title, Message, Properties.Resources.error);
        }
        public static void Warning(string Title, string Message)
        {
            ZIAlertBoxShow(Color.LightGoldenrodYellow, Color.Goldenrod, Title, Message, Properties.Resources.exclamation);
        }
        public static void Success(string Title, string Message)
        {
            ZIAlertBoxShow(Color.LightGray, Color.SeaGreen, Title, Message, Properties.Resources.success);
        }
    }
}
