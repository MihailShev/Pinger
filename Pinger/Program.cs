using System;
using System.Windows.Forms;


namespace Pinger
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Сооздаем главную форму
            HeadForm headForm = new HeadForm();

            //Создаем объект модели
            IService service = new Service();
            
            //Создаем объект presenter
            Presenter presenter = new Presenter(headForm, service);
            
            Application.Run(headForm);
        }
    }
}
