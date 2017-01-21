using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pinger
{
    #region //ИНТЕРФЕЙСЫ

    //Интрефейс управления панелью PanNetAdap
    public interface IPanNetAdapHead
    {
        //Обновляет информацию в ListView 
        void AddLvNetAdap(string[] array);

        //Очистка LvNetAdap
        void ClearLvNetAdap();

        //Возвращает информацию о сетевом адаптере, выбранным пользователем в LvNetAdap (Имя, Cтатус, Cocтояние)
        string[] GetSelectedNetAdap();

        //Управление свойством Enabled кнопки ButOnNetAdap
        void EnabledButOnNetAdap(bool enabled);

        //Управление свойством Enabled кнопки ButOnNetAdap
        void EnabledButOffNetAdap(bool enabled);

        //Выделение пользовтелем сетевого адаптера в LvNetAdap
        event PingerEvent LvNetAdapSelectedIndexChange;

        //Нажатие кнопки включения сетевого адаптера
        event PingerEvent ButOnNetAdapClick;

        //Нажатие кнопки выключения сетевого адаптера
        event PingerEvent ButOffNetAdapClick;

    }

    //Интерфейс управления панелью PanWifi
    interface IPanWifiHead
    {
        //Добавляет в LvWifi информацию о сети Wifi
        void AddLvWifi(string[] array);

        //Очищает LvWifi
        void ClearLvWifi();

        //Управляет свойством Enabled кнопки ButOnWifi
        void EnabledButOnWifi(bool enabled);

        //Управляет свойством Enabled кнопки ButOffWifi
        void EnabledButOffWifi(bool enabled);

        //Управляет свойстом Enabled TexBoxPassWifi a также свойством LabEnterPass и LabWifiHelp
        void EnabledEnterPass(bool enabled, string help = "");

        //Возвращает выбранное пользователем имя сети Wifi в LvWifi и пароль, введенный в TexBoxPassWifi
        string[] GetSelectedWifi();

        //Проверка находится ли курсор мыши на PanWifi
        bool MouseOnPanWifi();

        //
        //События
        //

        //Выделение пользовтелем сети Wifi в LvWifi
        event PingerEvent LvWifiSelectedIndexChange;

        //Нажатие кнопки ButOnWifi
        event PingerEvent ButOnWifiClick;

        //Нажатие кнопки ButOffWifi
        event PingerEvent ButOffWifiClick;

    }

    //Интерфейс управления панелью проверки соединения
    interface IPanCheckInternetHead
    {
        //Записывает текст в TexBoxCheckInternet
        void SetTexBoxCheckInternet(string text);

        //Управляет свойством Enabled кнопки ButCheckInternet
        void EnableButCheckInternet(bool enabled);

        //События
        //

        //Нажатие кнопки ButCheckInternet
        event PingerEvent ButCheckInternetClick;
    }

    //Общий интерфейс для всей формы
    interface IOveralHead
    {
        //Управляет свойством Text TexBoxIntervalCheckIneternet
        void SetTexBoxIntervalCheckInernet(string text=null);

        //Возвращает свойство Text из TexBoxIntervalCheckIneternet
        string GetTexBoxIntervalCheckInernet();

        //Управляет свойством Text TexBoxInfo
        void SetTexBoxInfo(string text, int method = 0);

        //Управляет свойством Fore.Color TexBoxAutoMode 0 - черный, 1-красный
        void SetColorTexBoxInfo(int color = 0);

        //Возвращает текст из TexBoxAutoMode
        string GetTexBoxInfo();

        //Возвращает значение свойства checked CheckBoxAutoMode
        bool GetCheckBoxAutoMode();

        //Управравляет свойством checked CheckBoxAutoMode
        void SetCheckBoxAutoMode(bool check);

        //Управляет совойством Enabled контролов в зависимости от значения CheckBoxAutoMode
        void ManageControlChekedAutoMode(bool start);

        //Изменение пользовтелем значения checked CheckBoxAutoMode
        event PingerEvent CheckBoxAutoModeCheckedChanged;

        //Закрытие формы
        event PingerEvent HeadFormClosing;

        //Открытие формы Settings
        event PingerEventSettingsShow formSettingsShow;

        //Вызов MessageBox
        void ShowMessage(string message);
    }

    //Обобщенный интерфейс
    interface IHeadForm : IPanNetAdapHead, IPanWifiHead, IPanCheckInternetHead, IOveralHead
    {

    }

    #endregion

    public partial class HeadForm : Form, IHeadForm
    {

        #region //ДЕЛЕГАТЫ

        //Объявляем делегат для перевызова методов из потока HeadForm для overal
        DelString _ShowMessage;
        DelStringInt _SetTexBoxInfo;
        DelBool _SetCheckBoxAutoMode;
        DelReturnString _GetTexBoxInfo;
        DelInt _SetColorTexBoxAutoMode;
        DelString _SetTexBoxIntervalCheckInternet;
        DelReturnString _GetTexBoxIntervalCheckInernet;

        ///Объявляем делегаты для перевызова методов из потока HeadForm для PanNetAdap
        DelStringArray _AddLvNetAdap;
        Del _ClearLvNetAdap;
        DelReturnStringArray _GetSelectedNetAdap;
        DelBool _EnabledButOnNetAdap;
        DelBool _EnableButOffNetAdap;


        //Объявляем делегаты для перевызова методов из потока HeadForm для PanWifi
        DelStringArray _AddLvWifi;
        Del _ClearLvWifi;
        DelBool _EnabledButOnWifi;
        DelBool _EnabledButOffWifi;
        DelBoolString _EnabledEnteredPass;
        DelReturnStringArray _GetSelectedWifi;
        DelReturnBool _MouseOnPanWifi;

        //Объявляем делегаты для перевызова методов из потока HeadForm для блока проверки соединения
        DelString _SetTexBoxCheckInternet;
        DelBool _EnabledButCheckInternet;

        #endregion

        #region //РЕАЛИЗАЦИЯ IOveral

        //
        //МЕТОДЫ
        //

        //Управляет свойством Text TexBoxIntervalCheckIneternet
        public void SetTexBoxIntervalCheckInernet(string text)
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                this.Invoke(_SetTexBoxIntervalCheckInternet, text);
                return;
            }

            //Реализация метода 
            TextBoxIntervalCheckInternet.Text = text;
        }

        //Возвращает свойство Text из TexBoxIntervalCheckIneternet
        public string GetTexBoxIntervalCheckInernet()
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                return (string)this.Invoke(_GetTexBoxIntervalCheckInernet);
            }

            if (TextBoxIntervalCheckInternet.Text != null)
                return TextBoxIntervalCheckInternet.Text;

            return null;
        }

        //Управравляет свойством checked CheckBoxAutoMode
        public void SetCheckBoxAutoMode(bool check)
        {
            //Перевызов метода из потока формы
            if(this.InvokeRequired)
            {
                this.Invoke(_SetCheckBoxAutoMode, check);
                return;
            }

            //Реализация метода 
            CheckBoxAutoMode.Checked = check;
        }

        //Возвращает значение свойства checked CheckBoxAutoMode
        public bool GetCheckBoxAutoMode()
        {
            if (this.InvokeRequired)
            {
                return (bool)this.Invoke(_GetTexBoxInfo);
            }
            return CheckBoxAutoMode.Checked;
        }

        //Управляет свойством Text TexBoxInfo
        public void SetTexBoxInfo(string text, int method)
        {
            //Перевызов метода из потока формы
            if(this.InvokeRequired)
            {
                try
                {
                    this.Invoke(_SetTexBoxInfo, text, method);
                    return;
                }
                catch { }
            }

            //Реализация метода 
            if (method == 0)
            {
                TexBoxInfo.Text = null;

                if(text!=null)
                TexBoxInfo.AppendText(text);
            }
            else
            {
                TexBoxInfo.Text = text;
            }

        }

        //Возвращает текст из TexBoxInfo
        public string GetTexBoxInfo()
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                string text;
                text =(string) this.Invoke(_GetTexBoxInfo);
                return text;
            }

            //Реалиазция метода
            return TexBoxInfo.Text;
        }

        //Управляет свойством Fore.Color TexBoxInfo 0 - черный, 1-красный
        public void SetColorTexBoxInfo(int color)
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                this.Invoke(_SetColorTexBoxAutoMode, color);
                return;
            }
            //Реалиазция метода
            if (color == 1) TexBoxInfo.ForeColor = Color.Red;
            else
                TexBoxInfo.ForeColor = Color.Black; 
        }

        //Выводит сообщения для пользователя
        public void ShowMessage(string message)
        {
            //Перевызываем метод в потоке HeadForm
            if(this.InvokeRequired)
            {
                this.Invoke(_ShowMessage, message);
                return;
            }

            //Реализация метода
            MessageBox.Show(message);
        }

        //Управляет совойством Enabled контролов в зависимости от значения CheckBoxAutoMode
        public void ManageControlChekedAutoMode(bool start)
        {
            if(start)
            {
                ButSettings.Enabled = false;
                ButCheckInternet.Enabled = false;
                PanNetAdap.Enabled = false;

                ButOnNetAdap.Enabled = false;
                ButOffNetAdap.Enabled = false;
                PanWifi.Enabled = false;

                ButOnWifi.Enabled = false;
                ButOffWifi.Enabled = false;

                EnabledEnterPass(false);
            }
            else
            {
                ButSettings.Enabled = true;
                ButCheckInternet.Enabled = true;

                PanWifi.Enabled = true;
                PanNetAdap.Enabled = true;
            }
        }

        //
        //СОБЫТИЯ
        //

        //Закрытие формы Head
        public event PingerEvent HeadFormClosing;

        //Открыети формы Settings
        public event PingerEventSettingsShow formSettingsShow;

        //Изменение пользовтелем значения checked CheckBoxAutoMode
        public event PingerEvent CheckBoxAutoModeCheckedChanged;

        //
        //ОБРАБОТЧИКИ
        //

        //Изменение пользовтелем значения checked CheckBoxAutoMode
        private void CheckBoxAutoMode_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAutoModeCheckedChanged != null) CheckBoxAutoModeCheckedChanged.Invoke();
        }

        //Закрытие формы
        private void HeadForm_FormClosing(object sender, FormClosingEventArgs e)
            {
       
                if (HeadFormClosing != null) HeadFormClosing.Invoke();
                
             }

        //Открытие формы Settings
        private void ButSettings_Click(object sender, EventArgs e)
        {
            //Создаем форму настроек
            SettingsForm settingsForm = new SettingsForm();

            if (formSettingsShow != null) formSettingsShow(settingsForm);

            //Показываем форму
            settingsForm.ShowDialog();
   
        }

        
        #endregion

        #region //РЕАЛИЗАЦИЯ IPanNetAdap

        //
        //МЕТОДЫ
        //

        //Добавляет запись в LvNetAdap
        public void AddLvNetAdap(string [] array)
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                //приводим array к object, т.к. Invoke не может работать с массивом
                this.Invoke(_AddLvNetAdap, (object)array);
                return;
            }

            //Реализация метода
            ListViewItem Item = new ListViewItem(array[0]);

            for (int i = 1; i < array.Length; i++)
                Item.SubItems.Add(array[i]);
          
            LvNetAdap.Items.Add(Item);
        }

        //Очищает LvNetAdap
        public void ClearLvNetAdap()
        {
            ///Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                this.Invoke(_ClearLvNetAdap);
                return;
            }

            //Реализация метода
            LvNetAdap.Items.Clear();
        }
        
        //Возвращает массив с информацией о сетевом адаптере, выбранном пользователем в LvNetAdap, если ничего не выбранно то возвращает null
        public string [] GetSelectedNetAdap()
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                string [] NetAdap;
                return NetAdap = (string [])this.Invoke(_GetSelectedNetAdap);
            }

            //Реализация метода
            string[] netAdap=null;

            ListViewItem select;

            if (LvNetAdap.SelectedItems.Count != 0)
            {
                select = LvNetAdap.SelectedItems[0];

                //Добавляем в массив имя, статус и состояние
                netAdap = new string[3] { select.SubItems[0].Text, select.SubItems[2].Text, select.SubItems[3].Text };
                return netAdap;
            }

            else return null;
        }

        //Управляет совйством Enabled кнопки включения сетевого адаптера
        public void EnabledButOnNetAdap(bool enabled)
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                this.Invoke(_EnabledButOnNetAdap, enabled);
                return;
            }

            //Реализация метода
            ButOnNetAdap.Enabled = enabled;
        }

        //Управляет свойством Enabled кнопки выключения сетевого адаптера
        public void EnabledButOffNetAdap(bool enabled)
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                this.Invoke(_EnableButOffNetAdap, enabled);
                return;
            }

            //Реализация метода
            ButOffNetAdap.Enabled = enabled;
        }

        //
        //СОБЫТИЯ
        //

        //Нажатие кнопки влкючения сетевого адаптера
        public event PingerEvent ButOnNetAdapClick;

        //Нажатие кнопки выключения сетевого адаптера
        public event PingerEvent ButOffNetAdapClick;

        //Выбор сетевого адаптера в LvNetAdap
        public event PingerEvent LvNetAdapSelectedIndexChange;

        //
        //ОБРАБОТЧИКИ
        //

        //Нажатие кнопки влкючения сетевого адаптера
        private void ButOnNetAdap_Click(object sender, EventArgs e)
        {
            if (ButOnNetAdapClick != null) ButOnNetAdapClick.Invoke();
        }

        //Нажатие кнопки выключения сетевого адаптера
        private void ButOffNetAdap_Click(object sender, EventArgs e)
        {
            if (ButOffNetAdapClick != null) ButOffNetAdapClick.Invoke();   
        }
        
        //Выделение пользователем сетевого адаптера в LvNetAdap
        private void LvNetAdap_SelectedIndexChanged(object sender, EventArgs e)
        {
          if(LvNetAdap.SelectedItems.Count!=0)
          if(LvNetAdapSelectedIndexChange!=null) LvNetAdapSelectedIndexChange.Invoke();
        }

        #endregion

        #region //РЕФЛИЗАЦИЯ IPanWifi

        //
        //МЕТОДЫ
        //

        //Обновляет список сетей Wifi в LvWifi     
        public void AddLvWifi(string [] array)
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                //Приводим array к object, т.к. Invoke не может работать с массивом
                this.Invoke(_AddLvWifi, (object)array);
                return;
            }

            //Реализация метода
            ListViewItem Item = new ListViewItem(array[0]);
            for(int i=1; i<array.Length;i++)
                Item.SubItems.Add(array[i]);

            LvWifi.Items.Add(Item);
        }
        
        //Очищает LvWifi
        public void ClearLvWifi()
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                this.Invoke(_ClearLvWifi);
                return;
            }

            //Реализация метода
            LvWifi.Items.Clear();
        }    

        //Управляет свойством Enabled кнопки подключения к сети Wifi
        public void EnabledButOnWifi(bool enabled)
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                this.Invoke(_EnabledButOnWifi, enabled);
                return;
            }

            //Реализация метода
            ButOnWifi.Enabled = enabled;
        }

        //Управляет свойством Enabled кнопки отключения от сети Wifi
        public void EnabledButOffWifi(bool enabled)
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                this.Invoke(_EnabledButOffWifi, enabled);
                return;
            }

            //Реализация метода
            ButOffWifi.Enabled = enabled;
        }

        //Управляет свойстами контролов ввода пароля для Wifi(TexBoxPassWifi,LabEnterPass,LabWifiHelp, CheckShowPassWifi)
        public void EnabledEnterPass (bool enabled, string help="")
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                this.Invoke(_EnabledEnteredPass, enabled, help);
                return;
            }
            
            //Реализция метода
            LabEnterPass.Enabled = enabled;
            TexBoxPassWifi.Enabled = enabled;
            TexBoxPassWifi.Text = "";
            LabWifiHelp.Enabled = enabled;
            LabWifiHelp.Text = help;
            CheckShowPassWifi.Enabled = enabled;
            CheckShowPassWifi.Checked = false;
        }

        //Возвращает выбранное пользователем имя сети Wifi в LvWifi и пароль, введенный в TexBoxPassWifi
        public string[] GetSelectedWifi()
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                string [] wifi;

                wifi = (string [])this.Invoke(_GetSelectedWifi);
                return wifi;
            }

            //Реализация метода
            if (LvWifi.SelectedItems.Count != 0)
            {
                ListViewItem select = LvWifi.SelectedItems[0];

                string[] wifi = new string[] { select.SubItems[0].Text, TexBoxPassWifi.Text};
                return wifi;
            }

                return null;
        }

        //Проверяет находится ли курсор мыши на PanWifi
        public bool MouseOnPanWifi()
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                if ((bool)this.Invoke(_MouseOnPanWifi)) return true;
                else return false;
            }

            //Реализация метода
            return MouseOnFrom(PanWifi, this);
        }

        //
        //СОБЫТИЯ
        //

        //Выделение пользователем сети Wifi в LvWifi
        public event PingerEvent LvWifiSelectedIndexChange;

        //Нажатие кнопки отключения от сети Wifi
        public event PingerEvent ButOnWifiClick;

        //Нажатие кнопки отключения от сети Wifi
        public event PingerEvent ButOffWifiClick;

        //
        //ОБРАБОТЧИКИ
        //

        //Выделение пользователем сети Wifi в LvWifi
        private void LvWifi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LvWifi.SelectedItems.Count!=0)
            if (LvWifiSelectedIndexChange != null) LvWifiSelectedIndexChange.Invoke();
        }

        //Нажатие кнопки отключения от сети Wifi
        private void ButOnWifi_Click(object sender, EventArgs e)
        {
            if (ButOnWifiClick != null) ButOnWifiClick.Invoke();
        }

        //Нажатие кнопки отключения от сети Wifii
        private void ButOffWifi_Click(object sender, EventArgs e)
        {
            if (ButOffWifiClick != null) ButOffWifiClick.Invoke();
        }

        #endregion

        #region //РЕАЛИЗАЦИЯ ICheckInternet

        //
        //МЕТОДЫ
        //

        //Изменяет содержание TexBoxCheckInternet
        public void SetTexBoxCheckInternet(string text)
        {
            //Перевызов метода из потока формы
            if (this.InvokeRequired)
            {
                this.Invoke(_SetTexBoxCheckInternet, text);
                return;
            }

            //Реализация метода
            TexBoxCheckInternet.Text = text;
        }

        //Управляет свойством Enabled кнопки ButCheckInternet
        public void EnableButCheckInternet(bool enabled)
        {
            //Перевызов метода из потока формы
            if(this.InvokeRequired)
            {
                this.Invoke(_EnabledButCheckInternet, enabled);
                return;
            }
            //Реализация метода
            ButCheckInternet.Enabled = enabled;
        }

        //
        //СОБЫТИЯ
        //

        //Нажатие кнопки проверки соединения
        public event PingerEvent ButCheckInternetClick;

        //
        //ОБРАБОТЧИКИ
        //

        //Нажатие кнопки ButCheckInternet
        private void ButCheckInternet_Click(object sender, EventArgs e)
        {
            if (ButCheckInternetClick != null) ButCheckInternetClick.Invoke();
        }

        #endregion

        #region //ВНУТРЕННИЕ МЕТОДЫ

        //Изменяет свойство PaswordChar поля ввода пароля для Wifi
        private void CheckShowPassWifi_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckShowPassWifi.Checked == true) TexBoxPassWifi.PasswordChar = (char)0;
            else TexBoxPassWifi.PasswordChar = '*';
        }

        //Проверяет находится ли курсор мыши на контроле
        public static bool MouseOnFrom(Control element, Control form)
        {
            int x1, x2, y1, y2;

            Point p = new Point();

            p = form.PointToScreen(new Point(element.Location.X, element.Location.Y));

            x1 = Control.MousePosition.X;
            x2 = p.X;
            y1 = Control.MousePosition.Y;
            y2 = p.Y;

            if ((x1 >= x2 && x1 <= x2 + element.Width) && (y1 >= y2 && y1 <= y2 + element.Height))
                return true;
            else
                return false;
        }

        //Не дает изменять пользователю содержимое TexBoxAutoMode
        private void TexBoxAutoMode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //
        //Убирание окна в трей
        //

        //Обработчик при двойном клике на иконку в трее
        private void notifi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            notifi.Visible = true;
            this.ShowInTaskbar = true;
            WindowState = FormWindowState.Normal;
        }

        //Обработчик изменения состояния формы
        private void HeadForm_Resize(object sender, EventArgs e)
        {
            //Если пользователь сворачивает форму
            if (WindowState == FormWindowState.Minimized)
            {
                this.notifi.Visible = true;
                this.ShowInTaskbar = false;
            }
        }

        //Сворачиваем форму при загрузке
        private void HeadForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        //Конструктор
        public HeadForm()
        {
            InitializeComponent();

            //Присваеваем делегатам для Overal HeadForm ссылки на методы
            _ShowMessage = ShowMessage;
            _SetTexBoxInfo = SetTexBoxInfo;
            _SetCheckBoxAutoMode = SetCheckBoxAutoMode;
            _GetTexBoxInfo = GetTexBoxInfo;
            _SetColorTexBoxAutoMode = SetColorTexBoxInfo;
            _GetTexBoxIntervalCheckInernet = GetTexBoxIntervalCheckInernet;
            _SetTexBoxIntervalCheckInternet = SetTexBoxIntervalCheckInernet;

            //Присваеваем делегатам для PanNetAdap ссылки на методы
            _AddLvNetAdap = AddLvNetAdap;
            _ClearLvNetAdap = ClearLvNetAdap;
            _MouseOnPanWifi = MouseOnPanWifi;
            _EnabledButOnNetAdap = EnabledButOnNetAdap;
            _EnableButOffNetAdap = EnabledButOffNetAdap;
            _GetSelectedNetAdap = GetSelectedNetAdap;

            //Присваеваем делегатам для PanWifi ссылки на методы
            _AddLvWifi = AddLvWifi;
            _ClearLvWifi = ClearLvWifi;
            _EnabledButOnWifi = EnabledButOnWifi;
            _EnabledButOffWifi = EnabledButOffWifi;
            _EnabledEnteredPass = EnabledEnterPass;
            _GetSelectedWifi = GetSelectedWifi;

            //Присваеваем делегатам для панели проверки соединения ссылки на методы
            _SetTexBoxCheckInternet = SetTexBoxCheckInternet;
            _EnabledButCheckInternet = EnableButCheckInternet;
        }

     
    }
}
