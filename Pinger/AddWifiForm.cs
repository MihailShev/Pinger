using System;
using System.Windows.Forms;

namespace Pinger
{
    #region //ИНТЕРФЕЙСЫ

    //Интерфейс управления формой 
    public interface IAddWifiForm
    {
        //Добавляет в LvWifi информацию о сети Wifi
        void AddLvWifi(string[] array);

        //Добавляет сеть Wifi в LbChoiseWifi
        void AddLbWifi(string name);

        //Очищает LvWifi
        void ClearLvWifi();

        //Очищает LbWifi
        void ClearLbWifi();

        //Возвращает имя сети Wifi, выбранной в LvWifi
        string GetSelectedWifiFromLvWifi();

        //Возвращает имена сетей Wifi, выбранные для добавления в список сетей используемых для подключения к интернету в автоматическом режме
        string[] GetAddedWifiFromLbWifi();

        //Возвращает количетсво элементов в LbWifi
        int GetItemsLbWifi();

        //Возвращает true, если пользователь выделил сеть в LbWifi
        bool isSelectedLbWifi();

        //Удаляет выбранную сеть Wifi в LbWifi
        void RemoveSelectedFromLbWifi();

        //Управляет свойством Enabled кнопки ButAddWifi
        void EnabledButAddWifi(bool enabled);

        //Управляет свойством Enabled кнопки ButDelWifi
        void EnabledButDelWifi(bool enabled);

        //Управляет свойством Enabled кнопки ButSaveAddedWifi
        void EnabledButAddedWifi(bool enabled);

        //Нажатие кнопки добавления сети Wifi в список сетей используемых для подключения к интернету в автоматическом режме
        event PingerEvent ButAddWifiClick;

        //Нажатие кнопки сохранить выбранные сети Wiif в список сетей используемых для подключения к интернету в автоматическом режме
        event PingerEvent ButSaveAddedWifiClick;

        //Нажатие кнопки удаления выбранной пользователем сети Wifi из LbWifi
        event PingerEvent ButDelWifiClick;

        //После закрытия формы AddWifi
        event PingerEvent FormAddWifiClosed;

        //Выделение пользователем сети Wifi в LvWifi
        event PingerEvent LvWifiSelectedIndexChanged;

        //Выделение пользователем сети Wifi в LbWifi
        event PingerEvent LbWifiSelectedIndexChanged;
    }

    #endregion

    public partial class AddWifiForm : Form, IAddWifiForm
    {
        #region //РЕАЛИЗАЦИЯ IAddWifi

        //Обновляет список сетей Wifi в LvWifi     
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

        //Добавляет сеть Wifi в LbChoiseWifi
        public void AddLbWifi(string name)
        {
            if(name!=null)
            LbWifi.Items.Add(name);
        }

        //Очищает LbWifi
        public void ClearLbWifi()
        {
            LbWifi.Items.Clear();
        }

        //Возвращает имя выбранной сети Wifi в LvWifi
        public string GetSelectedWifiFromLvWifi()
        {
            ListViewItem select = null;

            if (LvWifi.SelectedItems.Count != 0)
            {
                select = LvWifi.SelectedItems[0];

                return select.SubItems[0].Text;
            }

            return null;
        }

        //Возвращает имена сетей Wifi, выбранные для добавления в список сетей используемых для подключения к интернету в автоматическом режме
        public string[] GetAddedWifiFromLbWifi()
        {
            string[] selectedWifi = null;

            if (LbWifi.Items.Count != 0)
            {
                selectedWifi = new string[LbWifi.Items.Count];
                LbWifi.Items.CopyTo(selectedWifi, 0);
            }

            return selectedWifi;
        }
        
        //Возвращает количетсво элементов в LbWifi
        public int GetItemsLbWifi()
        {
            return LbWifi.Items.Count;
        }

        //Возвращает true, если пользователь выделил сеть в LbWifi
        public bool isSelectedLbWifi()
        {
            if (LbWifi.SelectedItem != null) return true;

            return false;
        }

        //Удаляет выбранную сеть Wifi в LbWifi
        public void RemoveSelectedFromLbWifi()
        {
            if(LbWifi.SelectedItem!=null)
            LbWifi.Items.Remove(LbWifi.SelectedItem);
        }

        //Управляет свойством Enabled кнопки ButAddWifi
        public void EnabledButAddWifi(bool enabled)
        {
            ButAddWifi.Enabled = enabled;
        }

        //Управляет свойством Enabled кнопки ButDelWifi
        public void EnabledButDelWifi(bool enabled)
        {
            ButDelWifi.Enabled = enabled;
        }

        //Управляет свойством Enabled кнопки ButSaveAddedWifi
        public void EnabledButAddedWifi(bool enabled)
        {
            ButSaveAddedWifi.Enabled = enabled;
        }

        //
        //
        //СОБЫТИЯ
        //

        //Нажатие кнопки добавления сети Wifi  в список сетей используемых для подключения к интернету в автоматическом режиме
        public event PingerEvent ButAddWifiClick;

        //Нажатие кнопки сохранить выбранные сети Wiif в список сетей используемых для подключения к интернету в автоматическом режме
        public event PingerEvent ButSaveAddedWifiClick;

        //После закрытия формы AddWifi
        public event PingerEvent FormAddWifiClosed;

        //Нажатие кнопки удаления выбранной пользователем сети Wifi из LbWifi
        public event PingerEvent ButDelWifiClick;

        //Выделение пользователем сети Wifi в LvWifi
        public event PingerEvent LvWifiSelectedIndexChanged;

        //Выделение пользователем сети Wifi в LbWifi
        public event PingerEvent LbWifiSelectedIndexChanged;

        //
        //ОБРАБОТЧИКИ
        //

        //Нажатие кнопки добавления сети Wifi  в список сетей используемых для подключения к интернету в автоматическом режиме
        private void ButAddWifi_Click(object sender, EventArgs e)
        {
            if (ButAddWifiClick != null) ButAddWifiClick.Invoke();

            if(LvWifi.SelectedItems.Count!=0)
            {
                //Удаляем выбранную пользвоателем сеть Wifi из LvWifi
                ListViewItem select = LvWifi.SelectedItems[0];
                select.Remove();
            }
        }

        //Нажатие кнопки сохранить выбранные сети Wiif в список сетей используемых для подключения к интернету в автоматическом режме
        private void ButSaveAddedWifi_Click(object sender, EventArgs e)
        {
            if (ButSaveAddedWifiClick != null) ButSaveAddedWifiClick.Invoke();
            this.Close();
        }

        //После закрытия формы AddWifi
        private void AddWifiForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(FormAddWifiClosed != null) FormAddWifiClosed.Invoke();
        }

        //Удаление сети Wifi из LbWifi
        private void ButDelWifi_Click(object sender, EventArgs e)
        {
            if (ButDelWifiClick != null) ButDelWifiClick.Invoke();
        }

        //Выделение пользователем сети Wifi в LvWifi
        private void LvWifi_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (LvWifi.SelectedItems.Count != 0)
                if (LvWifiSelectedIndexChanged != null) LvWifiSelectedIndexChanged.Invoke(); 
        }

        //Выделение пользователем сети Wiif в LbWifi
        private void LbWifi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LbWifiSelectedIndexChanged != null) LbWifiSelectedIndexChanged.Invoke();
        }

        #endregion

        public AddWifiForm()
        {
            InitializeComponent();
        }
     
    }
}
