using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Drawing;

namespace SistemaGEISA
{
    static class Extensions
    {

        public static bool In<T>(this T item, params T[] items)
        {
            if (items == null)
                throw new ArgumentNullException("items");

            return items.Contains(item);
        }

    }

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //reset();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("Metropolis");
            DevExpress.Utils.AppearanceObject.DefaultFont =  new Font("Calibri", 8);
            Application.Run(new frmPrincipal());
        }

        private static void reset()
        { 
            Properties.Settings.Default["Servidor"] ="";
            Properties.Settings.Default["Usuario"] = "";
            Properties.Settings.Default["Contraseña"] = "";
            Properties.Settings.Default["BaseDatos"] = "";
            Properties.Settings.Default.Save();
        }
    }
}
