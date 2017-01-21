using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pinger
{
    #region //ИНТЕРФЕЙСЫ

    //Интерфейс управления панелью настроек сетевых адапетров
    public interface IPanNetAdapSettings
    {
        //Добавляет запись в LvNetAdap
        void AddLvNetAdap(string[] array);

        //Очищает LvNetAdap
        void ClearLvNetAdap();

        //Возвращает имя сетевого адаптера, выбранного пользователем в LvNetAdap
        string [] GetSelectedInfoNetAdap();

        //Возращает значения выбранные пользователем в comboTypeNetAdap и comboPriorityNetAdap
        string [] GetSelectedComboNetAdap();

        //Управляет свойством Enabled контролов на PanNetAdap
        void EnabledControlPanNetAdap(bool comboType, bool comboPriority, bool ButSave, bool ButDelete);

        //Выделение пользователем сетевого адаптера в LvNetAdap
        event PingerEvent LvNetAdapSelectedIndexChange;

        //Нажатие кнопки сохранить настройки
        event PingerEvent ButSaveSettingsClick;

        //Нажатие кнопки удалить сетевой адаптер не обнаруженный в системе
        event PingerEvent ButDelNetAdapClick;

        //Выбор пользователем типа адаптера в comboTypeNetAdap
        event PingerEvent comboTypeNetAdapSelectedIndexChanged;

    }

    //Управление панелью настроек сетей Wifi
    public interface IPanWifiSettings
    {
        //Добавляет запись в LvWifi
        void AddLvWifi(string[] array);

        //Очищает LvWifi
        void ClearLvWifi();

        //Возвращает строку выделенную пользователем в LvWifi
        string[] GetSelectedWifi();

        //Возвращает выбранное пользователем значение из ComboPriorityWifi
        string GetComboPriorityWifi();

        //Возвращает пароль введенный пользователем в TexBoxPass
        string GetTexBoxPass();

        //Управляет свойством Enabled ComboPriorityWifi
        void EnableComboPriorityWifi(bool enabled);

        //Управляет свойством Enabled ButDelWifi
        void EnableButDelWifi(bool enabled);

        //Управляет свойством Enabled ButSave
        void EnableButSaveSettingsWifi(bool enabled);

        //Управляет свойством Enabled TexBoxPass, CheckBoxShowPass и LabTexBoxPass
        void EnableBlockEntryPassWifi(bool enabled);

        //Управляет свойством Enabled ButResetPass
        void EnableButResetPassWifi(bool enbled);

        //Сбрасывает свойства контролов TexBoxPass и CheckBoxShowPass на значения по умолчанию
        void ResetBlockEntryPassWifi();

        //Нажатие кнопки октрыть меню добавления сетей Wifi
        event PingerEventAddWifiShow AddWifiShow;

        //Нажатие кнопки удалить сеть Wiif
        event PingerEvent ButDelWifiClick;

        //Выделение пользователем сети Wifi в LvWifi
        event PingerEvent LvWifiSelectedIndexChanged;

        //Нажатие кнопки сохранение настроек
        event PingerEvent ButSaveSettingsWifiClick;

        //Изменение пользователем свойства Text в TexBoxPass
        event PingerEvent TexBoxPassTextChanged;

        //Выбор пользователем значения приоритета для сети Wifi
        event PingerEvent ComboPriorityWifiSelectedIndexChanged;

        //Нажатие кнопки сброса настроек
        event PingerEvent ButResetPassWifiClick;
    }

    //Управление группой OtherSettings
    public interface IGroupOtherSettings
    {
        //
        //НАСТРОЙКА АДРЕСОВ ДЛЯ ПРОВЕРКИ СОЕДИНЕНИЯ С ИНТЕРНЕТОМ
        //

        //Добавляет запись в LbAddress
        void AddLbAddress(string name);

        //Удаляет запись из LbAdress
        void RemoveLbAddress();

        //Очищает LbAddress
        void ClearLbAddress();

        //Возвращает адрес LbAddresses, выбранный пользователем
        string GetSelectedAddresses();

        //Возвращает текст из TexBoxAddress
        string GetTexBoxAddress();

        //Убирает выделение в LbAddresses
        void SetNullSelectedLbAddress();

        //Управляет свойством Text TexboxAddress
        void SetTexBoxAddress(string text = null);

        //Управляет свойстом Enabled кнопки ButDelAddress
        void EnableButDelAddresses(bool enable);

        //Управляет свойстом Enabled кнопки ButAddAddress
        void EnableButAddAddress(bool enable);

        //Выбор пользователем элемента в LbAddresses
        event PingerEvent LbAddressSelectedIndexChanged;

        //Нажатие кнопки ButAddAddresses
        event PingerEvent ButAddAddressClick;

        //Нажатие кнопки ButDelAddress
        event PingerEvent ButDelAddressClick;

        //Изменение свойста пользователем текста в TexBoxAddress
        event PingerEvent TexBoxAddressTextChanged;

        //
        //НАСТРОЙКА ИНТЕРВАЛА ПРОВЕРКИ СОЕДИНЕНИЯ
        //

        //Управляет свойством Text TexBoxChangeIntervalCheckInternet
        void SetTexBoxChangeIntervalCheckInternet(string text);

        //Возвращает text из TexBoxChangeIntervalCheckInternet
        string GetTexBoxChangeIntervalCheckInternet();

        //Управляет свойством ReadOnly TexBoxChangeIntervalCheckInternet
        void SetReadOnlyTexBoxChangeIntervalCheckInternet(bool readOnly);

        //Управляет свойством Text кнопки ButChangeIntervalChekcInternet
        void SetTextButChangeIntervalChekcInternet(string text);

        //Возвращает свойство Text кнопки ButChangeIntervalChekcInternet
        string GetTextButChangeIntervalChekcInternet();

        //Нажатие кнопки ButChangeIntervalChekcInternet
        event PingerEvent ButChangeIntervalChekcInternetClick;

        //
        //НАСТРОЙКА ТАЙМАУТА ОЖИДАНИЯ ОТВЕТА ОТ СЕРВЕРА ПРИ ПРОВЕРКЕ СОЕДИНЕНИЯ
        //

        //Управляет свойством Text TexBoxTimeoutRequest
        void SetTexBoxTimeoutRequest(string text);

        //Возвращает text из TexBoxTimeoutRequest
        string GetTexBoxTimeoutRequest();

        //Управляет свойством ReadOnly TexBoxTimeoutRequest
        void SetReadOnlyTexBoxTimeoutRequest(bool readOnly);

        //Управляет свойством Text кнопки ButChangeTimeoutRequest
        void SetTextButChangeTimeoutRequest(string text);

        //Возвращает свойство Text кнопки ButChangeIntervalChekcInternet
        string GetTextButChangeTimeoutRequest();

        //Нажатие кнопки ButChangeIntervalChekcInternet
        event PingerEvent ButChangeTimeoutRequestClick;

        //
        //НАСТРОЙКА ЗАДЕРЖКИ ПЕРЕД ВЫПОЛНЕНИЕМ ПРОВЕРКИ ВКЛЮЧЕН ЛИ АДАПТЕР
        //

        //Управляет свойством Text TexBoxPausaCheckEnableAdapter
        void SetTexBoxPausaCheckEnableAdapter(string text);

        //Возвращает text из TexBoxTimeoutRequest
        string GetTexBoxPausaCheckEnableAdapter();

        //Управляет свойством ReadOnly TexBoxTimeoutRequest
        void SetReadOnlyTexBoxPausaCheckEnableAdapter(bool readOnly);

        //Управляет свойством Text кнопки ButChangeTimeoutRequest
        void SetTextButChangePausaCheckAdapter(string text);

        //Возвращает свойство Text кнопки ButChangeIntervalChekcInternet
        string GetTextButChangePausaCheckAdapter();

        //Нажатие кнопки ButChangeIntervalChekcInternet
        event PingerEvent ButChangePausaCheckAdapterClick;

        //
        //НАСТРОЙКА ЗАДЕРЖКИ ПЕРЕД ВЫПОЛНЕНИЕМ ПЕРВОЙ ПРОВЕРКИ СОЕДИНЕНИЯ ПРИ ПОДКЛЮЧЕНИИ ЧЕРЕЗ 4G MODEM
        //

        //Управляет свойством Text TexBoxPausaModem
        void SetTexBoxPausaModem(string text);

        //Возвращает text из TexBoxPausaModem
        string GetTexBoxPausaModem();

        //Управляет свойством ReadOnly TexBoxPausaModem
        void SetReadOnlyTexBoxPausaModem(bool readOnly);

        //Управляет свойством Text кнопки ButChangePausaModem
        void SetTextButChangePausaModem(string text);

        //Возвращает свойство Text кнопки ButChangePausaModem
        string GetTextButChangePausaModem();

        //Нажатие кнопки ButChangePausaModem
        event PingerEvent ButChangePausaModemClick;

        //
        //НАСТРЙОКА АКТИВАЦИИ ЗАПУСКА АВТОМАТИЧЕСКОГО РЕЖИМА ПРИ ЗАПУСКЕ ПРИЛОЖЕНИЯ
        //

        //Устанавливает свойство Checked CheckBoxAutoModeStart
        void SetCheckBoxAutoModeStart(bool start);

        //Возвращает свойство Checked CheckBoxAutoModeStart
        bool GetCheckBoxAutoModeStart();

        //Изменение свойства Checked CheckBoxAutoModeStart
        event PingerEvent CheckBoxAutoModeStartCheckedChanged;

        //
        //НАСТРОЙКА ДОБАВЛЕНИЯ В АВТОЗАПУСК WINDOWS
        //

        //Устанавливает свойство Checked CheckBoxAddAutoRun    
        void SetCheckBoxAddAutoRun(bool run);

        //Возвращает значение свойства Checked CheckBoxAddAutoRun
        bool GetCheckBoxAddAutoRun();

        //Изменение свойства Checked CheckBoxAddAutoRun
        event PingerEvent CheckBoxAddAutoRunCheckedChanged;

    }

    //Общий интерфейс для всей формы
    public interface IOveralSettings
    {
        //Управление свойством Text TexBoxHelp
        void SetTexBoxHelp(string help, int color=0);

        //Возвращает свойство Text из TexBoxHelp
        string GetTexBoxHelp();

        //Пользователь навел мышь на GroupManageAddress
        event PingerEvent MouseOnGroupManageAddress;

        //Пользователь навел мышь на GroupIntervalCheckInternet
        event PingerEvent MouseOnGroupIntervalCheckInternet;

        //Пользователь навел мышь на GroupTimeoutRequest
        event PingerEvent MouseOnGroupTimeoutRequest;

        //Пользователь навел мышь на GroupPausaCheckEnableAdapter
        event PingerEvent MouseOnGroupPausaCheckEnableAdapter;

        //Пользователь навел мышь на GroupPausaModem
        event PingerEvent MouseOnGroupPausaModem;

        //Пользователь навел мышь на GroupAutoModeStart
        event PingerEvent MouseOnGroupAutoModeStart;

        //Пользователь навел мышь на LvNetAdap
        event PingerEvent MouseOnLvNetAdap;

        //Пользовател навел мышь на LvWifi
        event PingerEvent MouseOnLvWifi;

        //Форма закрыта
        event PingerEvent SettingsFormFormClosed;
    }

    //Обобщенный интерфейс
    public interface ISettingsForm: IPanNetAdapSettings, IPanWifiSettings, IGroupOtherSettings, IOveralSettings
    { }

    #endregion

    public partial class SettingsForm : Form, ISettingsForm
    {

        #region //Реализация IOveral

        //
        //Методы
        //

        //Управление свойством Text TexBoxHelp
        public void SetTexBoxHelp(string help, int color = 0)
        {
            TexBoxHelp.Text = help;

            if (color == 1)
                TexBoxHelp.ForeColor = Color.Green;
            else
            if (color == 2)
                TexBoxHelp.ForeColor = Color.Red;
            else
                TexBoxHelp.ForeColor = Color.Black;
        }

        //Возвращает свойство Text из TexBoxHelp
        public string GetTexBoxHelp()
        {
            return TexBoxHelp.Text;
        }

        //
        //СОБЫТИЯ
        //

        //Пользователь навел мышь на GroupManageAddress
        public event PingerEvent MouseOnGroupManageAddress;

        //Пользователь навел мышь на GroupIntervalCheckInternet
        public event PingerEvent MouseOnGroupIntervalCheckInternet;

        //Пользователь навел мышь на GroupTimeoutRequest
        public event PingerEvent MouseOnGroupTimeoutRequest;

        //Пользователь навел мышь на GroupPausaCheckEnableAdapter
        public event PingerEvent MouseOnGroupPausaCheckEnableAdapter;

        //Пользователь навел мышь на GroupPausaModem
        public event PingerEvent MouseOnGroupPausaModem;

        //Пользователь навел мышь на GroupAutoModeStart
        public event PingerEvent MouseOnGroupAutoModeStart;

        //Пользователь навел мышь на LvNetAdap
        public event PingerEvent MouseOnLvNetAdap;

        //Пользовател навел мышь на LvWifi
        public event PingerEvent MouseOnLvWifi;

        //Форма закрыта
        public event PingerEvent SettingsFormFormClosed;

        //
        //ОБРАБОТЧИИКИ
        //

        //Отслеживает местоположении мыши на форме
        private void TimerMouseCatcher_Tick(object sender, EventArgs e)
        {

            if (HeadForm.MouseOnFrom(GroupManageAddress, this))
            {
                if (MouseOnGroupManageAddress != null) MouseOnGroupManageAddress.Invoke();
                return;
            }

            if (HeadForm.MouseOnFrom(GroupIntervalCheckInternet, this))
            {
                if (MouseOnGroupIntervalCheckInternet != null) MouseOnGroupIntervalCheckInternet.Invoke();
                return;
            }

            if (HeadForm.MouseOnFrom(GroupTimeoutRequest, this))
            {
                if (MouseOnGroupTimeoutRequest != null) MouseOnGroupTimeoutRequest.Invoke();
                return;
            }

            if (HeadForm.MouseOnFrom(GroupPausaCheckEnableAdapter, this))
            {
                if (MouseOnGroupPausaCheckEnableAdapter != null) MouseOnGroupPausaCheckEnableAdapter.Invoke();
                return;
            }

            if (HeadForm.MouseOnFrom(GroupPausaModem, this))
            {
                if (MouseOnGroupPausaModem != null) MouseOnGroupPausaModem.Invoke();
                return;
            }

            if (HeadForm.MouseOnFrom(GroupAutoModeStart, this))
            {
                if (MouseOnGroupAutoModeStart != null) MouseOnGroupAutoModeStart.Invoke();
                return;
            }

            if (HeadForm.MouseOnFrom(PanNetAdap, this))
            {
                if (MouseOnLvNetAdap != null) MouseOnLvNetAdap.Invoke();
                return;
            }

            if (HeadForm.MouseOnFrom(PanWifi, this))
            {
                if (MouseOnLvWifi != null) MouseOnLvWifi.Invoke();
                return;
            }

        }

        //Форма закрыта
        private void SettingsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (SettingsFormFormClosed != null) SettingsFormFormClosed.Invoke();
            TimerMouseCatcher.Stop();
        }

        #endregion

        #region //РЕАЛИЗАЦИЯ IPanNetAdap

        //
        //Методы
        //

        //Добавляет запись в LvNetAdap
        public void AddLvNetAdap(string[] array)
        {
           
            ListViewItem Item = new ListViewItem(array[0]);

            for (int i = 1; i < array.Length; i++)
                Item.SubItems.Add(array[i]);

            LvNetAdap.Items.Add(Item);
        }

        //Очищает LvNetAdap
        public void ClearLvNetAdap()
        {
            LvNetAdap.Items.Clear();
        }

        //Управляет свойством Enabled контролов на PanNetAdap
        public void EnabledControlPanNetAdap(bool comboType, bool comboPriority, bool ButSave, bool ButDelete)
        {
            if (comboPriority == false)
                comboPriorityNetAdap.Text = "Приоритет";

            comboPriorityNetAdap.Enabled = comboPriority;

            if (comboType == false)
                comboTypeNetAdap.Text = "Тип адаптера";

            comboTypeNetAdap.Enabled = comboType;
            ButSaveSettings.Enabled = ButSave;
            ButDelNetAdap.Enabled = ButDelete;
        }

        //Возвращет строку, выбранную пользователем в LvNetAdap
        public string [] GetSelectedInfoNetAdap()
        {
            string [] info = null;

            if(LvNetAdap.SelectedItems.Count!=0)
            {
                ListViewItem select = LvNetAdap.SelectedItems[0];

                info = new string[]
                {
                     select.SubItems[0].Text,
                     select.SubItems[1].Text,
                     select.SubItems[2].Text,
                     select.SubItems[3].Text
                };
                
            }

            return info;
        }

        //Возвращает содержимое контролов Combo
        public string[] GetSelectedComboNetAdap()
        {
            string[] comboSelected = new string[3];

            if (LvNetAdap.SelectedItems.Count != 0)
            {
                ListViewItem select = LvNetAdap.SelectedItems[0];

                //Записываем имя
                comboSelected[0] = select.SubItems[0].Text;

                //Записываем тип
                if (comboTypeNetAdap.Text == "Тип адаптера") comboSelected[1] = null;
                else
                    comboSelected[1] = comboTypeNetAdap.Text;

                //Записываем приоритет
                if (comboPriorityNetAdap.Text == "Приоритет") comboSelected[2] = null;
                else
                    comboSelected[2] = comboPriorityNetAdap.Text;

                return comboSelected;
            }

            return null;
        }

      
        //
        //СОБЫТИЯ
        //

        public event PingerEvent LvNetAdapSelectedIndexChange;

        public event PingerEvent ButSaveSettingsClick;

        public event PingerEvent ButDelNetAdapClick;

        public event PingerEvent comboTypeNetAdapSelectedIndexChanged;

        //
        //ОБРАБОТЧИКИ
        //

        //Выделение пользователем сетевого адаптера в LvNetAdap
        private void LvNetAdap_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(LvNetAdap.SelectedItems.Count!=0)
            if (LvNetAdapSelectedIndexChange != null) LvNetAdapSelectedIndexChange.Invoke();
        }

        //Выбор пользователем типа адаптера в comboTypeNetAdap
        private void comboTypeNetAdap_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButSaveSettings.Enabled = true;
            if (comboTypeNetAdapSelectedIndexChanged != null) comboTypeNetAdapSelectedIndexChanged.Invoke();
        }

        //Выбор пользователем приоритета подключения для сетевого адаптера
        private void comboPriorityNetAdap_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButSaveSettings.Enabled = true;
        }

        //Нажатие кнопки сохранить настройки на LvNetAdap
        private void ButSaveSettings_Click(object sender, EventArgs e)
        {
          
            if (ButSaveSettingsClick != null) ButSaveSettingsClick.Invoke();

            //Возвращаем инзначанльные значения в  comboPriorityNetAdap и comboTypeNetAdap
            comboPriorityNetAdap.Text = "Приоритет";
            comboTypeNetAdap.Text = "Тип адаптера";
        }

        //Нажатие кнопки удалить сетевой адаптер не обнаруженный в системе
        private void ButDelNetAdap_Click(object sender, EventArgs e)
        {
            if (ButDelNetAdapClick != null) ButDelNetAdapClick.Invoke();

            //Возвращаем инзначанльные значения в  comboPriorityNetAdap и comboTypeNetAdap
            comboPriorityNetAdap.Text = "Приоритет";
            comboTypeNetAdap.Text = "Тип адаптера";
        }

        #endregion

        #region //РЕАЛИЗАЦИЯ IPanWifi

        //Добавляет запись в LvWifi
        public void AddLvWifi(string[] array)
        {
            ListViewItem Item = new ListViewItem(array[0]);

            for (int i = 1; i < array.Length; i++)
                Item.SubItems.Add(array[i]);

            LvWifi.Items.Add(Item);
        }

        //Очищает LvWifi
        public void ClearLvWifi()
        {
            LvWifi.Items.Clear();
        }

        //Возвращает строку выделенную пользователем в LvWifi
        public string [] GetSelectedWifi()
        {
            string [] wifi = null;

            if(LvWifi.SelectedItems.Count!=0)
            {
                ListViewItem select = LvWifi.SelectedItems[0];

                wifi = new string[select.SubItems.Count];

                for(int i=0; i<wifi.Length; i++)
                {
                    wifi[i] = select.SubItems[i].Text;
                }
            }

            return wifi;
        }

        //Возвращает выбранное пользователем значение из ComboPriority
        public string GetComboPriorityWifi()
        {
            
            string combo = null;
            if (ComboPriorityWifi.Text != "Приоритет") return combo = ComboPriorityWifi.Text;

            return combo;
        }

        //Возвращает пароль введенный пользователем в TexBoxPassword
        public string GetTexBoxPass()
        {
            if(TexBoxPass.Text!="")
            return TexBoxPass.Text;

            return null;
        }

        //Управляет свойством Enabled ComboPriorityWifi
        public void EnableComboPriorityWifi(bool enabled)
        {
            ComboPriorityWifi.Enabled = enabled;
        }

        //Управляет свойством Enabled ButDelWifi
        public void EnableButDelWifi(bool enabled)
        {
            ButDelWifi.Enabled = enabled;
        }

        //Управляет свойством Enabled ButSave
        public void EnableButSaveSettingsWifi(bool enabled)
        {
            ButSaveSettingsWifi.Enabled = enabled;
        }

        //Управляет свойством Enabled TexBoxPass, CheckBoxShowPass и LabTexBoxPass
        public void EnableBlockEntryPassWifi(bool enabled)
        {
            TexBoxPass.Enabled = enabled;
            CheckBoxShowPass.Enabled = enabled;
            LabTexBoxPass.Enabled = enabled;
        }

        //Управляет свойством Enabled ButResetPass
        public void EnableButResetPassWifi(bool enabled)
        {
            ButResetPassWifi.Enabled = enabled;
        }

        //Сбрасывает свойства контролов TexBoxPass, CheckBoxShowPass на значения по умолчанию
        public void ResetBlockEntryPassWifi()
        {
            CheckBoxShowPass.Checked = false;
            ComboPriorityWifi.Text = "Приоритет";
            TexBoxPass.Text = "";
            TexBoxPass.PasswordChar = '*';
        }

        //
        //СОБЫТИЯ
        //

        //Нажатие кнопки октрыть меню добавления сетей Wifi
        public event PingerEventAddWifiShow AddWifiShow;

        //Нажатие кнопки удалить сеть Wifi
        public event PingerEvent ButDelWifiClick;

        //Выделение пользователем сети Wifi в LvWifi
        public event PingerEvent LvWifiSelectedIndexChanged;

        //Нажатие кнопки сохранение настроек
        public event PingerEvent ButSaveSettingsWifiClick;

        //Изменение пользователем свойства Text в TexBoxPass
        public event PingerEvent TexBoxPassTextChanged;

        //Выбор пользователем значения приоритета для сети Wifi
        public event PingerEvent ComboPriorityWifiSelectedIndexChanged;

        //Нажатие кнопки сброса настроек
        public event PingerEvent ButResetPassWifiClick;

        //
        //ОБРАБОТЧИКИ
        //

        //Нажатие кнопки добавить сеть Wifi в список сетей для полкючения к интеренету в автоматическом режиме
        private void ButAddWifi_Click(object sender, EventArgs e)
        {
            //Создаем форму добавления сети wifi
            AddWifiForm addWifiForm = new AddWifiForm();

            if (AddWifiShow != null) AddWifiShow.Invoke(addWifiForm);

            //Показываем форму
            addWifiForm.ShowDialog();
        }

        //Нажатие кнопки удалить сеть Wifi
        private void ButDelWifi_Click(object sender, EventArgs e)
        {
            if (ButDelWifiClick != null) ButDelWifiClick.Invoke();
        }

        //Выделение пользователем сети Wifi в LvWifi
        private void LvWifi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LvWifi.SelectedItems.Count != 0)
                if (LvWifiSelectedIndexChanged != null) LvWifiSelectedIndexChanged.Invoke();
        }

        //Нажатие кнопки сохранение настроек
        private void ButSaveSettingsWifi_Click(object sender, EventArgs e)
        {
            if (ButSaveSettingsWifiClick != null) ButSaveSettingsWifiClick.Invoke();
        }

        //Изменение пользователем свойства Text в TexBoxPass
        private void TexBoxPass_TextChanged(object sender, EventArgs e)
        {
            if (TexBoxPassTextChanged != null) TexBoxPassTextChanged.Invoke();
        }

        //Выбор пользователем значения приоритета для сети Wifi
        private void ComboPriorityWifi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboPriorityWifiSelectedIndexChanged != null) ComboPriorityWifiSelectedIndexChanged.Invoke();
        }

        //Нажатие кнопки сброса настроек
        private void ButResetPassWifi_Click(object sender, EventArgs e)
        {
            if (ButResetPassWifiClick != null) ButResetPassWifiClick.Invoke();
        }

        #endregion

        #region //Реализация GroupOtherSettings

        //
        //МЕТОДЫ
        //

        //Управляет свойстом Enabled кнопки ButDelAddress
        public void EnableButDelAddresses(bool enable)
        {
            ButDelAddress.Enabled = enable;
        }

        //Управляет свойстом Enabled кнопки ButAddAddress
        public void EnableButAddAddress(bool enable)
        {
            ButAddAddress.Enabled = enable;
        }

        //Очищает LbAddress
        public void ClearLbAddress()
        {
            LbAddress.Items.Clear();
        }

        //Добавляет запись в LbAddress
        public void AddLbAddress(string name)
        {
            LbAddress.Items.Add(name);
        }

        //Удаляет запись из LbAddress
        public void RemoveLbAddress()
        {
            if (LbAddress.SelectedItem != null)
                LbAddress.Items.Remove(LbAddress.SelectedItem);
        }

        //Возвращает адрес LbAddresses, выбранный пользователем
        public string GetSelectedAddresses()
        {
            if (LbAddress.SelectedIndices.Count != 0)
            {
                return (string)LbAddress.SelectedItem;
            }
            return null;
        }

        //Возвращает текст из TexBoxAddress
        public string GetTexBoxAddress()
        {
            if(TexBoxAddress.Text.Length!=0)
            {
                return TexBoxAddress.Text;
            }

            return null;
        }

        //Управляет свойством Text TexboxAddress
        public void SetTexBoxAddress(string text=null)
        {
            TexBoxAddress.Text = text;
        }

        //Убирает выделение в LbAddresses
        public void SetNullSelectedLbAddress()
        {
            LbAddress.SelectedItem = null;
        }

        //Управляет свойством Text TexBoxChangeIntervalCheckInternet
        public void SetTexBoxChangeIntervalCheckInternet(string text)
        {
            TexBoxIntervalCheckInternet.Text = text;
        }

        //Возвращает text из TexBoxChangeIntervalCheckInternet
        public string GetTexBoxChangeIntervalCheckInternet()
        {
            return TexBoxIntervalCheckInternet.Text;
        }

        //Управляет свойством ReadOnly TexBoxChangeIntervalCheckInternet
        public void SetReadOnlyTexBoxChangeIntervalCheckInternet(bool readOnly)
        {
            TexBoxIntervalCheckInternet.ReadOnly = readOnly;
        }

        //Возвращает свойство Text кнопки ButChangeIntervalChekcInternet
        public string GetTextButChangeIntervalChekcInternet()
        {
            return ButChangeIntervalChekcInternet.Text;
        }

        //Управляет свойством Text кнопки ButChangeIntervalChekcInternet
        public void SetTextButChangeIntervalChekcInternet(string text)
        {
            ButChangeIntervalChekcInternet.Text = text;
        }

        //Управляет свойством Text TexBoxTimeoutRequest
        public void SetTexBoxTimeoutRequest(string text)
        {
            TexBoxTimeoutRequest.Text = text;
        }

        //Возвращает text из TexBoxTimeoutRequest
        public string GetTexBoxTimeoutRequest()
        {
            return TexBoxTimeoutRequest.Text;
        }

        //Управляет свойством ReadOnly TexBoxTimeoutRequest
        public void SetReadOnlyTexBoxTimeoutRequest(bool readOnly)
        {
            TexBoxTimeoutRequest.ReadOnly = readOnly;
        }

        //Управляет свойством Text кнопки ButChangeTimeoutRequest
        public void SetTextButChangeTimeoutRequest(string text)
        {
            ButChangeTimeoutRequest.Text = text;
        }

        //Возвращает свойство Text кнопки ButChangeIntervalChekcInternet
        public string GetTextButChangeTimeoutRequest()
        {
            return ButChangeTimeoutRequest.Text;
        }

        //Управляет свойством Text TexBoxPausaCheckEnableAdapter
        public void SetTexBoxPausaCheckEnableAdapter(string text)
        {
            TexBoxPausaCheckEnableAdapter.Text = text;
        }

        //Возвращает text из TexBoxTimeoutRequest
        public string GetTexBoxPausaCheckEnableAdapter()
        {
            return TexBoxPausaCheckEnableAdapter.Text;
        }

        //Управляет свойством ReadOnly TexBoxTimeoutRequest
        public void SetReadOnlyTexBoxPausaCheckEnableAdapter(bool readOnly)
        {
            TexBoxPausaCheckEnableAdapter.ReadOnly = readOnly;
        }

        //Управляет свойством Text кнопки ButChangeTimeoutRequest
        public void SetTextButChangePausaCheckAdapter(string text)
        {
            ButChangePausaCheckAdapter.Text = text;
        }

        //Возвращает свойство Text кнопки ButChangeIntervalChekcInternet
        public string GetTextButChangePausaCheckAdapter()
        {
            return ButChangePausaCheckAdapter.Text;
        }

        //Управляет свойством Text TexBoxPausaModem
        public void SetTexBoxPausaModem(string text)
        {
            TexBoxPausaModem.Text = text;
        }

        //Возвращает text из TexBoxPausaModem
        public string GetTexBoxPausaModem()
        {
            return TexBoxPausaModem.Text;
        }

        //Управляет свойством ReadOnly TexBoxPausaModem
        public void SetReadOnlyTexBoxPausaModem(bool readOnly)
        {
            TexBoxPausaModem.ReadOnly = readOnly;
        }

        //Управляет свойством Text кнопки ButChangePausaModem
        public void SetTextButChangePausaModem(string text)
        {
            ButChangePausaModem.Text = text;
        }

        //Возвращает свойство Text кнопки ButChangePausaModem
        public string GetTextButChangePausaModem()
        {
            return ButChangePausaModem.Text;
        }

        //Устанавливает свойство Checked CheckBoxAutoModeStart
        public void SetCheckBoxAutoModeStart(bool start)
        {
            CheckBoxAutoModeStart.Checked = start;
        }

        //Возвращает свойство Checked CheckBoxAutoModeStart
        public bool GetCheckBoxAutoModeStart()
        {
            return CheckBoxAutoModeStart.Checked;
        }

        //Устанавливает свойство Checked CheckBoxAddAutoRun    
        public void SetCheckBoxAddAutoRun(bool run)
        {
            CheckBoxAddAutoRun.Checked = run;
        }

        //Возвращает значение свойства Checked CheckBoxAddAutoRun
        public bool GetCheckBoxAddAutoRun()
        {
            return CheckBoxAddAutoRun.Checked;
        }
       
        //
        //СОБЫТИЯ
        //

        //Выбор пользователем элемента в LbAddresses
        public event PingerEvent LbAddressSelectedIndexChanged;

        //Нажатие кнопки ButAddAddresses
        public event PingerEvent ButAddAddressClick;

        //Нажатие кнопки ButDelAddress
        public event PingerEvent ButDelAddressClick;

        //Изменение свойста пользователем текста в TexBoxAddress
        public event PingerEvent TexBoxAddressTextChanged;

        //Нажатие кнопки ButChangeIntervalChekcInternet
        public event PingerEvent ButChangeIntervalChekcInternetClick;

        //Нажатие кнопки ButChangeTimeoutRequest
        public event PingerEvent ButChangeTimeoutRequestClick;

        //Нажатие кнопки ButChangeIntervalChekcInternet
        public event PingerEvent ButChangePausaCheckAdapterClick;

        //Нажатие кнопки ButChangePausaModem
        public event PingerEvent ButChangePausaModemClick;

        //Изменение свойства Checked CheckBoxAutoModeStart
        public event PingerEvent CheckBoxAutoModeStartCheckedChanged;

        //Изменение свойства Checked CheckedBoxAddAutoRun
        public event PingerEvent CheckBoxAddAutoRunCheckedChanged;

        //
        //ОБРАБОТЧИКИ
        //

        //Выбор пользователем элемента в LbAddresses
        private void LbAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbAddressSelectedIndexChanged != null) LbAddressSelectedIndexChanged.Invoke();
        }

        //Нажатие кнопки ButAddAddress
        private void ButAddAddress_Click(object sender, EventArgs e)
        {
            if (ButAddAddressClick != null) ButAddAddressClick.Invoke();
        }

        //Нажатие кнопки ButDelAddress
        private void ButDelAddress_Click(object sender, EventArgs e)
        {
            if (ButDelAddressClick != null) ButDelAddressClick.Invoke();
        }

        //Изменение свойста пользователем текста в TexBoxAddress
        private void TexBoxAddress_TextChanged(object sender, EventArgs e)
        {
            if (TexBoxAddressTextChanged != null) TexBoxAddressTextChanged.Invoke();
        }

        //Нажатие кнопки ButChangeIntervalChekcInternet
        private void ButChangeIntervalChekcInternet_Click(object sender, EventArgs e)
        {
            if (ButChangeIntervalChekcInternetClick != null) ButChangeIntervalChekcInternetClick.Invoke();
        }

        //Нажатие кнопки ButChangeTimeoutRequest
        private void ButChangeTimeoutRequest_Click(object sender, EventArgs e)
        {
            if (ButChangeTimeoutRequestClick != null) ButChangeTimeoutRequestClick.Invoke();
        }

        //Нажатие кнопки ButChangePausaCheckAdapter
        private void ButChangePausaCheckAdapter_Click(object sender, EventArgs e)
        {
            if (ButChangePausaCheckAdapterClick != null) ButChangePausaCheckAdapterClick.Invoke();
        }

        //Нажатие кнопки ButChangePausaModem
        private void ButChangePausaModem_Click(object sender, EventArgs e)
        {
            if (ButChangePausaModemClick != null) ButChangePausaModemClick.Invoke();
        }

        //Изменение свойства Checked CheckBoxAutoModeStart
        private void CheckBoxAutoModeStart_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAutoModeStartCheckedChanged != null) CheckBoxAutoModeStartCheckedChanged.Invoke();
        }

        //Изменение свойства Checked CheckBoxAddAutoRun
        private void CheckBoxAddAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxAddAutoRunCheckedChanged != null) CheckBoxAddAutoRunCheckedChanged.Invoke();
        }

        #endregion

        #region //ВНУТРЕННИЕ МЕТОДЫ

        //Не дает изменять пользователю содержимое TexBoxHelp
        private void TexBoxHelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //Изменяет свойство PasswordChar TexBoxPass
        private void CheckBoxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxShowPass.Checked == true)
                TexBoxPass.PasswordChar = (char)0;
            else
                TexBoxPass.PasswordChar = '*';
        }

        //Запускает таймер, опеределюящий положении мыши и вызывающий события: мышь на контроле ...
        private void SettingsForm_Load(object sender, EventArgs e)
        {
            TimerMouseCatcher.Start();
        }

        #endregion

        //Конструктор
        public SettingsForm()
        {
            InitializeComponent();     
        }


    }
}
