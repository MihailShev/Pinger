using ManageNetworkAdapter;
using WrapSimpleWifi;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.IO;
using TestConnect;
using System.Threading;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pinger
{
    #region //НАБОР ПУБЛИЧНЫХ ТИПОВ

    //Класс для хранения информации о соединении
    public class InfoConnect
    {
        public readonly string name;
        public readonly string type;
        public readonly string priority;
        public readonly string wifiAdapterPriority;

        public InfoConnect(string name, string type, string priority, string wifiAdapterPriority = null)
        {
            this.name = name;
            this.type = type;
            this.priority = priority;
            this.wifiAdapterPriority = wifiAdapterPriority;
        }

    }

    //Результат проверки соединения с интернетом
    public enum CheckInternetResult
    {
        undone,
        succes,
        unsucces,
        failed
    }

    //Делегат для создания событий при контроле соединения в атоматическом режме
    public delegate void ManageConnectEvent(InfoConnect info);

    #endregion

    #region //ИНТЕРФЕЙСЫ

    //Управления сетевыми адаптерами
    public interface IManageNetAdap 
    {
        //Проверяет есть ли адаптер в данных с настройками
        bool CheckNetAdapInServiceInfo(string name);

        //Добавляет адаптер в данные с настройками
        bool AddNetAdapServiceInfo(string name);

        //Возвращает тип сетевого адаптера адаптера, если адаптер не найден в данных с найстройками возвращает Unknown
        string GetNetAdapType(string name);

        //Записывает тип сетевого адаптера в данные с настройками, если не удалось записать информацию в файл данных возвращает false
        bool SetNetAdapType(string name, string netAdapType);

        //Записывает приоритет подключения сетевого адаптера в данные с настройками, если не удалось записать информацию в файл данных возвращает false
        bool SetNetAdapPriority(string name, byte priority);

        //Устанавливает значение приоритета для сетевого адптера с типом Wifi на 0
        bool ResetPriorityNetAdapWifi();

        //Проверяет есть ли в системе адаптер с аналогичным значением приоритета
        bool CheckPriority(byte priority);

        //Удаляет сетевой адаптер из данных с настройками, не обнаруженный в системе.
        bool DelNetAdap(string name);

        //Возвращает служебную инфомрацию о сетевых адаптерах используемую для контроля соедениня в атоматическом режиме
        List<string[]> GetServiceInfoNetAdap();

        //Возврщает информацию о сетевых адаптерах из операционной системы
        List<string []> GetInfoNetAdap();

        //Проверяет состояния сетевого адаптера (включен или выключен)
        bool IsNabled(string name);

        //Выключает все сетевые адапетры
        void OffAllNetAdap();

        //Включает все сетевые адаптеры
        void OnAllNetAdap();

        //Включает сетеврй адаптер
        void OffNetAdap(string name);

        //Выключате сетеврй адаптер
        void OnNetAdap(string name);

        //Возвращает количество настроенных сетевых адаптеров для контроля соединения в автоматическом режиме (конкретная сеть Wifi cчитается как отдельный сетевой адаптер)
        int GetCountWorkNetAdap();
    }

    //Управление сетями Wifi
    public interface IMangeWifi
    {
        /*Включает сеть Wifi, возвращает 0 если введен неверный пароль, 1 неизвестная ошибка, 2 сеть Wifi не найдена (некорректнео имя), 
        больше 2 подключение к сети произведено*/
        int WifiOn(string name, string password);

        //Выключает сеть Wifi
        void WifiOff(string name);

        /*Возвращает коллекцию массивов с информацией о сетях Wifi (name, signalStreght (урвоень сигнала), isSecure(Защищена, Без пароля) 
        IsConnected (Подклчюена, Отключена))*/
        List<string[]> GetInfoWifi();

        //Проверяет подключена ли сеть Wifi, если сеть с такми именем не обнаружна возвращает false
        bool IsConnected(string name);

        //Возвращает коллекцию массивов с настроечной информацией о сетях Wifi
        List<string[]> GetServiceInfoWifi();

        //Добавляет в настроечную инфомрацию сеть Wifi
        bool SetWifiInServiceInfo(string name);

        //Добавляет значение приоритета для сети Wifi
        bool SetWifiPriority(string name, byte priority);

        //Добавляет в настроечную информацию пароль для сети Wifi
        bool SetWifiPassword(string name, string password);

        //Проверяет есть ли в списке используемых сетей для контроля соединения в автоматическом режиме сеть Wifi
        bool IsWifiInlServiceInfo(string name);

        //Удаляет сеть Wifi из списка сетей изспользумыех для контроля соединения в автоматическом режиме
        bool DelWifiFromServiceInfo(string name);

        //Возвращает имя сети Wifi к который выполнено подключение или null
        string GetConnectWifi();

        //Возвращает количество настроенных сетей Wifi для контроля соединения в автоматическом режиме
        int GetCountWorkWifi();

        //Проверяет есть ли в настроечных данных сеть Wifi с аналогичным значением приоритета
        bool CheckPriorityWifi(byte priority);

        //Возвращает пароль для сети Wifi из настроечной информации
        string GetWifiPassword(string name);
    }

    //Управление режимом контроля соединения в автоматическом режиме
    public interface IManageConnect
    {
        //Выполняет проверку возможен ли запуск режима автоматического контроля соединения
        bool CheckAutoMode();

        //Проверяет соединение с интернетом
        List<TestConnectInfo> CheckInternet();

        //Возвращает результат последней проверки соединения с интернетом
        CheckInternetResult GetLastCheckInternet(); 

        //Выполняет переход в автоматический режим контроля соединения   
        bool StartAutoMode();

        //Переключение на следующий сетевой адаптер или сеть Wifi в режиме автоматического контроля соедиения
        bool GetNextConnect();

        //Возвращает имя текущего соединения в режиме автоматического контроля соединения
        string GetCurrentConnectName();

        //Возвращает тип адаптера текущего соедиения в режиме автоматического контроля соединения
        string GetCurrentConnectType();

        //Возвращает приоритет текущего соединения в режиме автоматического контроля соединения
        string GetCurrentConnectPriority();

        //Возвращает приоритет адаптера Wifi в режиме автоматического контроля соединения
        string GetWifiAdapterPriority();

        //Возвращет имя адаптера Wifi в режиме автоматического контроля соединения
        string GetWifiAdapterName();

        //Возвращает коллекцию активных подключений
        List<InfoConnect> GetCurrentConnect();

        //Попытка включения сетевого адаптера
        event ManageConnectEvent TryEnableAdapter;

        //Подключение к сетевому адаптеру выполнено успешно
        event ManageConnectEvent GoodTryEnableAdapter;

        //Подключение к сетевому адаптеру выполнить не удалось
        event ManageConnectEvent BadTryEnableAdapter;

        //Адапетр в системе не обнаружен
        event ManageConnectEvent AdapterNotFound;

        //Попытка подаключения к сети Wifi
        event ManageConnectEvent TryConnectWifi;

        //Подключение к сети Wifi выполнено успешно
        event ManageConnectEvent GoodTryConnectWifi;

        //Подключение к сети Wifi не удалось, т.к. пароль неверен
        event ManageConnectEvent BadPasswordWifi;

        //Подключение к сети Wifi выполнить не удалось
        event ManageConnectEvent BadTryConnectWifi;

        //Сеть Wifi не обнаружена
        event ManageConnectEvent WifiNotfound;
 
        //Выполнена попытка подключения ко всем настроенным подключениям
        event ManageConnectEvent AllConnecEnumerated;
    }

    //Управление настрйоками
    public interface IServiceSettings
    {
        //Возвращает коллекицю адресов для проверки соединения с интернетом
        List<string> GetAddresses();

        //Добавляет адрес в коллекцию адресов для проверки соединения с интернетом
        bool AddAddress(string name);

        //Удаляет адрес из коллекции адресов для првоерки соединения с интернетом
        bool RemodveAddress(string name);

        //Возвращает значение интервала между првоерками соединения с интернетом
        int GetIntervalCheckInternet();

        //Устанавливает значение интервала между првоерками соединения с интернетом
        bool SetIntervalCheckInternet(int interval);

        //Возвращает таймаут ожидания ответа от сервера при проверке соединения
        int GetTimeoutRequest();

        //Устанавливает значение таймаута ожидания ответа от сервера при проверке соединения
        bool SetTimeoutRequest(int timeout);

        //Возвращает значение задержки перед првоеркой удались включить адаптер
        int GetPausaCheckEnableAdapter();

        //Устанавливает значение задержки перед првоеркой удались включить адаптер
        bool SetPausaCheckEnableAdapter(int pausa);

        //Возвращает значение задержки перед первой проверкой соединения при подключении через 4G Modem
        int GetPausaModem();

        //Устанавливает значение задержки перед первой проверкой соединения при подключении через 4G Modem
        bool SetPausaModem(int pausa);

        //Возвращает флаг запуска автоматического режима контроля соединения при запуске приложения
        bool GetAutoModeStart();

        //Устанавливает флаг запуска автоматического режима контроля соединения при запуске приложения
        bool SetAutoModeStart(bool start);

        //Возвращает флаг добавления приложения в автозапуск Windows
        bool GetAddAutoRun();

        //Устанавливает флаг добавления приложения в автозапуск Windows
        bool SetAddAutoRun(bool run);
    }

    //Обобщенный интерфейс
    public interface IService : IManageNetAdap, IMangeWifi, IManageConnect, IServiceSettings
    {
       
    }

    #endregion

    public class Service : IService
    {
        #region //ПЕРЕМЕННЫЕ И ВНУТРЕННИЕ ТИПЫ

        //Управление сетевыми адаптерами
        ManageNetAdap manageNetAdap;

        //Управление сетями Wifi 
        ManageWifi manageWifi;

        //Перечисление тип сетевого адаптера
        enum NetAdapType
        {
            Unknown, //тип неизвестен
            Wan, //подключение по кабелю
            Wifi, //подключение по Wifi
            Bluetooth, //подключение через блютуз
            Modem //подключение по 3G/4G модем
        };

        //Класс содержащий инфомрацию о сетевых адаптерах и сетях Wifi, используется в режиме автоматического контроля соединения
        class AutoModeConnectInfo
        {
            public readonly string name; // Для сетей Wifi записывается имя конкретной сети Wifi а не имя сетевого адаптера
            public readonly NetAdapType type;
            public readonly byte priority;
            public readonly ServiceInfoNetAdap wifiAdapter;// используется только для сетей Wifi

            public AutoModeConnectInfo(string name, NetAdapType type, byte priority, ServiceInfoNetAdap wifiAdapter = null)
            {
                this.name = name;
                this.type = type;
                this.priority = priority;
                this.wifiAdapter = wifiAdapter;

            }

            //используется только для создания информации именно по сетевому адаптеру с типом Wifi, а не по конкретной сети
            public AutoModeConnectInfo(ServiceInfoNetAdap wifi)
            {
                name = wifi.name;
                type = wifi.netAdapType;
                priority = wifi.priority;
            }

        }

        //Хранит текущее подключение для использования в режиме автоматического контроля соединения
        AutoModeConnectInfo currentConnet;

        //Класс для сохранения служебной информации, используемой для автоматического контроля соединения с интернетом
        class ServiceInfoNetAdap
        {
            public string name { get; set; }//Имя
            public NetAdapType netAdapType { get; set; }//тип сетевого адаптера
            public byte priority { get; set; }//приоритет подключения в автоматическом режиме

            public ServiceInfoNetAdap(string name)
            {
                this.name = name;
                this.netAdapType = NetAdapType.Unknown;
                this.priority = 0;
            }
            public ServiceInfoNetAdap(AutoModeConnectInfo connect)
            {
                name = connect.name;
                netAdapType = connect.type;
                priority = connect.priority;
            }
            public ServiceInfoNetAdap() { }
        }

        //Коллекция известных сетевых адаптеров со служебной информации
        List<ServiceInfoNetAdap> lServiceInfoNetAdap;

        //Класс для хранения настроечной информации о сети Wifi, используемой для контроля соединения с интернетом в автоматическом режиме
        class ServiceInfoWifi
        {
            public string name { set; get; }
            public string password { set; get; }
            public byte priority { set; get; }

            public ServiceInfoWifi(string password = "")
            {
                this.password = password;
            }
        }

        //Коллекция для хранения настроечной инфомрации 
        List<ServiceInfoWifi> lServiceInfoWifi;

        //Коллекция адрессов для проверки соединения с интернетом
        List<string> lAddresses;

        //Интервал проверки соединения с интернетом
        int intervalCheckInternet;

        //Время ожидания в мс. ответа от сервера при тестировании соединеняи
        int timeoutRequest;

        //Задержка перед проверкой удались ли включить адаптер
        int pausaCheckEnableAdapter;

        //Задержка перед первой проверкой соединения при подключении через 4G Modem
        int pausaFirstCheckInternetModem;

        //Флаг запуска автоматического режима контроля соединения при запуске приложения
        bool autoModeStart;

        //Флаг добавления в автозапуск Windows
        bool addAutoRun;

        #endregion

        #region //РЕАЛИЗАЦИЯ IManageNetAdap

        //
        //УПРАВЛЕНИЕ, ПОЛУЧЕНИЕ ОБЩЕЙ ИНФОРМАЦИИ
        //

        //Получение информации о сетевых адаптерах из операционной системы
        public List<string[]> GetInfoNetAdap()
        {

            List<string[]> lInfoNetAdap = new List<string[]>();

            List<NetAdapterInfo> lNetAdapterInfo = manageNetAdap.GetInfoNetAdaper();

            for (int i = 0; i < lNetAdapterInfo.Count; i++)
            {

                string enabled;

                if (lNetAdapterInfo[i].enabled) enabled = "Включен";
                else enabled = "Выключен";

                string[] netAdap = new string[4]
                {
                    lNetAdapterInfo[i].name,

                    //Получаем значение типа из настроечной информации
                    GetNetAdapType(lNetAdapterInfo[i].name),

                    lNetAdapterInfo[i].GetConnectStatusToSring(),
                    enabled
                };

                lInfoNetAdap.Add(netAdap);
            }

            return lInfoNetAdap;

        }

        //Проверка состояния сетевого адаптера (включен или выключен)
        public bool IsNabled(string name)
        {
            return manageNetAdap.IsEnabled(name);
        }

        //Выключает все адапетры
        public void OffAllNetAdap()
        {
            manageNetAdap.ManageAllAdapter(ActionNetAdap.Off);
        }

        //Включает все адаптеры
        public void OnAllNetAdap()
        {
            manageNetAdap.ManageAllAdapter(ActionNetAdap.On);
        }

        //Включает адапетр по name
        public void OffNetAdap(string name)
        {
            manageNetAdap.ManageAdapter(ActionNetAdap.Off, name);
        }

        //Выключает адаптер по name
        public void OnNetAdap(string name)
        {
            manageNetAdap.ManageAdapter(ActionNetAdap.On, name);
        }

        //
        //НАСТРОЙКА СЕТЕВЫХ АДАПТЕРОВ
        //

        //Возвращает настроечную инфомрацию о сетевых адаптерах используемую для контроля соедениня в автоматическом режиме
        public List<string[]> GetServiceInfoNetAdap()
        {
            List<string[]> lDataNetAdapter = new List<string[]>();

            foreach (ServiceInfoNetAdap adap in lServiceInfoNetAdap)
            {

                string[] serviceInfoNetAdap = new string[4];

                //Имя
                serviceInfoNetAdap[0] = adap.name;

                //Тип
                serviceInfoNetAdap[1] = adap.netAdapType.ToString();

                //Приоритет подключения
                serviceInfoNetAdap[2] = adap.priority.ToString();

                //Статуc в системе - подключен или не обнаружен
                try
                {
                    manageNetAdap.IsEnabled(adap.name);

                    //если не возникло исключение badName записываем, что адаптер в системе обнаружен
                    serviceInfoNetAdap[3] = "Подключен";
                }
                //если возникло исключение, то записываем, что адаптер в системе не обнаружен
                catch (Exception)
                {
                    serviceInfoNetAdap[3] = "Не обнаружен";
                }

                lDataNetAdapter.Add(serviceInfoNetAdap);
            }

            return lDataNetAdapter;
        }

        //Проверяет есть ли адаптер в данных с настройками
        public bool CheckNetAdapInServiceInfo(string name)
        {
            foreach (ServiceInfoNetAdap adap in lServiceInfoNetAdap)
            {
                if (name == adap.name) return true;
            }

            return false;
        }

        //Добавляет адаптер в данные с настройками
        public bool AddNetAdapServiceInfo(string name)
        {
            ServiceInfoNetAdap serviceNetAdap = new ServiceInfoNetAdap(name);
            lServiceInfoNetAdap.Add(serviceNetAdap);

            //Перезаписываем файл с данными
            if (WriteData()) return true;
            else return false;
        }

        //Возвращает тип сетевого адаптера адаптера, если адаптер не найден в списке известных адапетров возвращает Unknown
        public string GetNetAdapType(string name)
        {
            string netAdapterType = "Unknown";

            foreach (ServiceInfoNetAdap adap in lServiceInfoNetAdap)
            {
                if (name == adap.name)
                {
                    netAdapterType = adap.netAdapType.ToString();
                    return netAdapterType;
                }
            }

            return netAdapterType;
        }

        //Записывает тип сетевого адаптера в данные с настройками, если не удалось записать информацию в файл данных возвращает false
        public bool SetNetAdapType(string name, string netAdapType)
        {
            NetAdapType type;

            //Определяем тип сетевого адаптера
            switch (netAdapType)
            {

                case "Wan":
                    type = NetAdapType.Wan;
                    break;
                case "Wifi":
                    type = NetAdapType.Wifi;
                    break;
                case "Bluetooth":
                    type = NetAdapType.Bluetooth;
                    break;
                case "Modem":
                    type = NetAdapType.Modem;
                    break;
                default:
                    type = NetAdapType.Unknown;

                    //Если тип адаптра Unknown сбрасываем на ноль значение приориета
                    SetNetAdapPriority(name, 0);
                    break;
            }

            foreach (ServiceInfoNetAdap adap in lServiceInfoNetAdap)
            {
                if (name == adap.name)
                {
                    adap.netAdapType = type;
                }
            }

            //Если запись в файл данных прошла успешна возвращаем true
            if (WriteData()) return true;
            else return false;
        }

        //Записывает приоритет подключения сетевого адаптера в данные с настройками, если не удалось записать информацию в файл данных возвращает false
        public bool SetNetAdapPriority(string name, byte priority)
        {
            foreach (ServiceInfoNetAdap adap in lServiceInfoNetAdap)
            {
                if (name == adap.name)
                {
                    adap.priority = priority;
                }
            }

            //Если запись в файл данных прошла успешна возвращаем true
            if (WriteData()) return true;
            else return false;
        }

        //Проверяет есть ли в системе адаптер с аналогичным значением приоритета
        public bool CheckPriority(byte priority)
        {
            //Значение 0 может быть больше чем у одного адаптера, поэтому сразу возвращаем false
            if (priority == 0) return false;

            foreach (ServiceInfoNetAdap adap in lServiceInfoNetAdap)
            {
                if (priority == adap.priority) return true;
            }

            return false;
        }

        //Удаляет сетевой адаптер из настроечной информации
        public bool DelNetAdap(string name)
        {
            for (int i = 0; i < lServiceInfoNetAdap.Count; i++)
            {
                if (name == lServiceInfoNetAdap[i].name)
                {
                    lServiceInfoNetAdap.RemoveAt(i);
                    if (WriteData()) return true;
                    return false;

                }
            }

            return false;
        }

        //Устанавливает значение приоритета для сетевого адптера с типом Wifi на 0
        public bool ResetPriorityNetAdapWifi()
        {

            foreach (ServiceInfoNetAdap netAdap in lServiceInfoNetAdap)
            {
                if (netAdap.netAdapType == NetAdapType.Wifi)
                    if (!SetNetAdapPriority(netAdap.name, 0))
                        return false;
            }

            return true;
        }

        //Возвращает количество настроенных сетевых адаптеров для контроля соединения в автоматическом режиме (конкретная сеть Wifi cчитается как отдельный сетевой адаптер)
        public int GetCountWorkNetAdap()
        {
            int count = 0;

            foreach (ServiceInfoNetAdap netAdap in lServiceInfoNetAdap)
            {
                if (netAdap.priority > 0)
                {
                    if (netAdap.netAdapType == NetAdapType.Wifi)
                    {
                        count += GetCountWorkWifi();
                    }
                    else
                        count++;
                }
            }

            return count;
        }

        //Возвращает значение приоритета для сетевого адаптера из настроечной информации, если адаптер не обнаружен возвращает 0
        byte GetPriorityNetAdap(string name)
        {
            foreach (ServiceInfoNetAdap netAdap in lServiceInfoNetAdap)
            {
                if (netAdap.name == name) return netAdap.priority;
            }

            return 0;
        }

        #endregion

        #region //РЕАЛИАЗЦИЯ IManageWifi

        //
        //УПРАВЛЕНИЕ, ПОЛУЧЕНИЕ ОБЩЕЙ ИНФОРМАЦИИ
        //

        /*Включает сеть Wifi, возвращает 0 если введен неверный пароль, 1 неизвестная ошибка, 2 сеть Wifi не найдена (некорректнео имя), 
        больше 2 подключение к сети произведено*/
        public int WifiOn(string name, string password = "")
        {
            try
            {
                manageWifi.wifiOn(name, password);
            }
            catch (ManageWifiExeption exp)
            {
                return exp.exeptionNumber;
            }

            return 100;
        }

        //Выключает сеть wifi
        public void WifiOff(string name)
        {
            manageWifi.WifiOff(name);
        }

        //Проверяет подключена ли сеть Wifi, если сеть с такми именем не обнаружна возвращает false
        public bool IsConnected(string name)
        {
            return manageWifi.IsConnect(name);
        }

        /*Возвращает коллекцию массивов с информацией о сетях Wifi (name, signalStreght (урвоень сигнала), isSecure(Защищена, Без пароля) 
        IsConnected (Подклчюена, Отключена))*/
        public List<string[]> GetInfoWifi()
        {
            List<InfoWifi> lInfoWifi = null;

            try
            {
                lInfoWifi = manageWifi.GetWifiInfo();
            }
            catch (Exception) { }



            if (lInfoWifi != null)
            {
                List<string[]> infoWifi = new List<string[]>();

                for (int i = 0; i < lInfoWifi.Count; i++)
                {
                    string[] arrayInfoWifi = new string[4];

                    arrayInfoWifi[0] = lInfoWifi[i].name;
                    arrayInfoWifi[1] = lInfoWifi[i].signalStrenght.ToString() + "%";

                    if (lInfoWifi[i].isSecure) arrayInfoWifi[2] = "Защищена";
                    else arrayInfoWifi[2] = "Без пароля";

                    if (lInfoWifi[i].isConnected) arrayInfoWifi[3] = "Подключена";
                    else arrayInfoWifi[3] = "Отключeна";

                    infoWifi.Add(arrayInfoWifi);
                }
                return infoWifi;
            }

            return null;
        }
 
        //Возвращает имя сети, к который выполнено полкючение в данный момент или null
        public string GetConnectWifi()
        {

            List<InfoWifi> lInfoWifi = null;

            try
            {
                lInfoWifi = manageWifi.GetWifiInfo();
            }
            catch (Exception) { }

            foreach (InfoWifi wifi in lInfoWifi)
            {
                if (wifi.isConnected == true)
                    return wifi.name;
            }

            return null;
        }

        //
        //НАСТРОЙКА СЕТЕЙ WIFI
        //

        //Возвращает коллекцию массивов с настреочной инфомрацией о сетях Wifi
        public List<string[]> GetServiceInfoWifi()
        {
            List<string[]> lDataWifi = new List<string[]>();

            foreach (ServiceInfoWifi wifi in lServiceInfoWifi)
            {
                string[] dataWifi = new string[5];

                //Записывакем имя
                dataWifi[0] = wifi.name;

                //Определяем сохранен ли в настроечной информации пароль
                if (wifi.password == "") dataWifi[1] = "Не сохранен";
                else dataWifi[1] = "Сохранен";

                //Записываем приоритет
                dataWifi[2] = wifi.priority.ToString();

                //Опердеяем обнаружена ли сеть Wifi
                if (manageWifi.Isfound(wifi.name)) dataWifi[3] = "Обнаружена";
                else dataWifi[3] = "Не обнаружена";



                lDataWifi.Add(dataWifi);
            }

            return lDataWifi;
        }

        //Добавляет в настроечную инфомрацию сеть Wifi, если не удалось записать данные в файл с настройками возвращает false
        public bool SetWifiInServiceInfo(string name)
        {
            ServiceInfoWifi wifi = new ServiceInfoWifi();

            wifi.name = name;

            lServiceInfoWifi.Add(wifi);

            if (WriteData()) return true;

            return false;
        }

        //Добавляет в настроечную информацию значение приоритета для сети Wifi, если не удалось записать данные в файл с настройками возвращает false
        public bool SetWifiPriority(string name, byte priority)
        {
            for (int i = 0; i < lServiceInfoWifi.Count; i++)
            {
                if (lServiceInfoWifi[i].name == name)
                {
                    lServiceInfoWifi[i].priority = priority;

                    if (!WriteData()) return false;

                    return true;
                }
            }

            return false;
        }

        //Добавляет в настроечную информацию пароль для сети Wifi, если не удалось записать данные в файл с настройками возвращает false
        public bool SetWifiPassword(string name, string password)
        {
            for (int i = 0; i < lServiceInfoWifi.Count; i++)
            {
                if (lServiceInfoWifi[i].name == name)
                {
                    lServiceInfoWifi[i].password = password;

                    if (!WriteData()) return false;

                    return true;
                }
            }

            return false;
        }

        //Проверяет есть ли сеть Wifi в данных с настройками
        public bool IsWifiInlServiceInfo(string name)
        {
            foreach (ServiceInfoWifi wifi in lServiceInfoWifi)
            {
                if (name == wifi.name) return true;
            }

            return false;
        }

        //Удаляет сеть Wifi из списка сетей изспользумыех для контроля в автоматическом режиме сеть Wifi
        public bool DelWifiFromServiceInfo(string name)
        {
            for (int i = 0; i < lServiceInfoWifi.Count; i++)
            {
                if (name == lServiceInfoWifi[i].name)
                {
                    lServiceInfoWifi.RemoveAt(i);

                    if (!WriteData()) return false;

                    return true;
                }
            }

            return false;
        }

        //Проверяет есть ли в настроечных данных сеть Wifi с аналогичным значением приоритета
        public bool CheckPriorityWifi(byte priority)
        {
            if (priority == 0) return false;

            foreach (ServiceInfoWifi wifi in lServiceInfoWifi)
            {
                if (wifi.priority == priority)
                    return true;
            }

            return false;
        }

        //Возвращает значение приоритета для сети Wifi, если сеть не найдена в настроечной информации возвращает 0
        byte GetPriorityWifi(string name)
        {
            foreach (ServiceInfoWifi wifi in lServiceInfoWifi)
            {
                if (wifi.name == name) return wifi.priority;
            }

            return 0;
        }

        //Возвращает пароль для сети Wifi, если сеть не найдена в настроечной информации возвращает null
        public string GetWifiPassword(string name)
        {
            foreach(ServiceInfoWifi wifi in lServiceInfoWifi)
            {
                if (name == wifi.name) return wifi.password;
            }

            return null;
        }

        //Возвращает количество настроенных сетей Wifi для контроля соединения в автоматическом режиме
        public int GetCountWorkWifi()
        {
            int count = 0;

            foreach (ServiceInfoWifi wifi in lServiceInfoWifi)
            {
                if (wifi.priority > 0) count++;
            }
            return count;
        }

        #endregion

        #region //РЕАЛИЗАЦИЯ IManageConnect

        //
        //PUBLIC МЕТОДЫ
        //

        //Проверяет соединение с интернетом
        public List<TestConnectInfo> CheckInternet()
        {
            List<TestConnectInfo> lTest = new List<TestConnectInfo>();


            //Отправляем запросы по url
            foreach (string url in lAddresses)
            {
                lTest.Add(TestUrl(url, timeoutRequest));
            }

            //Анализируем результаты
            int countBadRequest = 0;//количество неудачных запросов
            int countBadUrl = 0;//количество некорретных имен url

            foreach (TestConnectInfo info in lTest)
            {
                if (info.result != Result.succes) countBadRequest++;

                if (info.result == Result.unformat) countBadUrl++;
            }

            //Если все url некорретные, то записываем, что проверить соединение с интернетом не удалось
            if (countBadUrl == lTest.Count)
                LastCheckInternet = CheckInternetResult.failed;
            //Если все запросы завершились неудачно, то записываем, что соединение с интернетом отсутсвует
            else
            if (countBadRequest == lTest.Count)
                LastCheckInternet = CheckInternetResult.unsucces;
            else
                LastCheckInternet = CheckInternetResult.succes;

            return lTest;
        }

        //Возвращает результат последней проверки соединения с интернетом
        public CheckInternetResult GetLastCheckInternet()
        {
            return LastCheckInternet;
        }

        //Выполняет проверку возможен ли контроль подключения к интернету в автматическом режиме
        public bool CheckAutoMode()
        {
            if (GetCountWorkNetAdap() > 1) return true;

            return false;
        }

        //Проверка соединения в автоматическом режиме
        public bool StartAutoMode()
        {
            //Сбрасываем значение текущего соединения на null, чтобы значние из предыдущего сеанса в автоматическом режиме не привело к ошибкам
            currentConnet = null;

            AutoModeConnectInfo connect = CheckNetAdapter();

            //Если отсутствуют подключения
            if (connect == null)
            {
                if (!TryConnect(connect)) return false;
                else return true;
            }

            //Записываем текущее подключение в переменную хранящуюю текущее подключение
            currentConnet = connect;

            return true;
        }

        //Возвращает имя текущего соединения
        public string GetCurrentConnectName()
        {
            if (currentConnet != null)
                return currentConnet.name;
            else return null;
        }

        //Возвращает тип адаптера текущего соедиения
        public string GetCurrentConnectType()
        {
            if (currentConnet != null)
                return currentConnet.type.ToString();
            else return null;
        }

        //Возвращает приоритет текущего соединения
        public string GetCurrentConnectPriority()
        {
            if (currentConnet != null)
                return currentConnet.priority.ToString();
            else return null;
        }

        //Возвращает приоритет адаптера Wifi
        public string GetWifiAdapterPriority()
        {
            if (currentConnet != null && currentConnet.type == NetAdapType.Wifi)
            {
                return currentConnet.wifiAdapter.priority.ToString();
            }

            return null;
        }

        //Возвращет имя адаптера Wifi
        public string GetWifiAdapterName()
        {
            if (currentConnet != null && currentConnet.type == NetAdapType.Wifi)
            {
                return currentConnet.wifiAdapter.name;
            }

            return null;
        }

        //Переключение на следующий адаптер или сеть Wifi в режиме автоматического контроля соедиения
        public bool GetNextConnect()
        {
            AutoModeConnectInfo connect = null;

            if (currentConnet == null)
                connect = CheckNetAdapter();
            else
                connect = currentConnet;

            if (!TryConnect(connect)) return false;

            return true;
        }

        //Возвращает коллекцию активных подключений
        public List<InfoConnect> GetCurrentConnect()
        {
            List<AutoModeConnectInfo> lAuto = GetConnect();

            if (lAuto.Count != 0)
            {
                List<InfoConnect> lInfo = new List<InfoConnect>();

                foreach (AutoModeConnectInfo auto in lAuto)
                {
                    InfoConnect info;

                    if (auto.type == NetAdapType.Wifi)
                        info = new InfoConnect(auto.name, auto.type.ToString(), auto.priority.ToString(), auto.wifiAdapter.priority.ToString());
                    else
                        info = new InfoConnect(auto.name, auto.type.ToString(), auto.priority.ToString());

                    lInfo.Add(info);
                }

                return lInfo;
            }
            return null;
        }

        //
        //PRIVATE МЕТОДЫ
        //

        //Результат последней проверки соединения с интернетом
        CheckInternetResult LastCheckInternet;
        
        //Првоеряет соединение c интернетом
        TestConnectInfo TestUrl(string url, int timeout)
        {
            TestConnectInfo result = null;
            result = new Test().TestUrl(url, timeout);
            return result;
        }

        /*Проверяет сетевые адаптеры и сети Wifi в атоматическом режиме контроля соединения, если включено больше одного сетевого адаптера с рабочими 
        приоритетом, то оставляет включенным адаптер или сеть Wifi c наивысшим приоритетом
        если включенных адапетров с рабочим приоритетом нет, то возвращает null*/
        AutoModeConnectInfo CheckNetAdapter()
        {
            //Получаем коллекцию включенных адаптеров и(или) подключенную сеть Wifi 
            List<AutoModeConnectInfo> lConnect = GetConnect();

            AutoModeConnectInfo currentConnect = null;

            //Если нет включенных адапетров возвращаем null
            if (lConnect.Count == 0) return null;

            //Если коллекция содержит один включенный сетевой адаптер или одну подключенную сеть Wifi с рабочим приоритетом
            if (lConnect.Count == 1)
            {
                if (lConnect[0].priority > 0)
                {
                    return currentConnect = lConnect[0];
                }
            }
          
           //Проверяем есть ли включенные адаптеры без рабочего приоритета и выключаем их
           foreach(AutoModeConnectInfo auto in lConnect)
            {
                if(auto.priority==0)
                {
                    if(auto.type!=NetAdapType.Wifi)
                    {
                        manageNetAdap.ManageAdapter(ActionNetAdap.Off, auto.name);
                    }
                    else
                    {
                        manageWifi.WifiOff(auto.name);
                    }
                }
            }

            //Повторно получаем коллекцию включенных адаптеров и(или) подключенную сеть Wifi, в коллекции остаются адаптеры только с рабочими приоритетами
            lConnect = GetConnect();

            //Если включенных адаптеров с рабочим приоритетом
            if (lConnect.Count == 0) return null;

            //Если включенный адаптер с рабочим приоритетом один, то завершаем работу метода
            if (lConnect.Count == 1)
            {
                return currentConnect = lConnect[0];
            }

            //Если включенных адаптеров с рабочим приоритетом больше одного, то определяем адаптер, который нужно оставить включенным, остальные выключаем
            if (lConnect.Count >= 1)
            {
                byte priority = 0;
                AutoModeConnectInfo prevConnect = null;

                foreach (AutoModeConnectInfo connect in lConnect)
                {

                    if (priority == 0)
                    {
                        priority = connect.priority;
                        currentConnect = connect;
                        prevConnect = connect;
                    }
                    else
                    //Если у следующего адаптера приоритет выше, то перезаписываем значение приоритета и выключаем предыдущий адаптер
                    if (priority > connect.priority && connect.priority!=0)
                    {
                        priority = connect.priority;
                        currentConnect = connect;

                        if (prevConnect.type != NetAdapType.Wifi)
                        {
                            manageNetAdap.ManageAdapter(ActionNetAdap.Off, prevConnect.name);
                        }
                        else
                        {
                            manageWifi.WifiOff(prevConnect.name);
                        }

                        prevConnect = connect;
                    }
                    //Если у предыдущего адаптера приоритет выше, то выключаем текущий адаптер или отключаемся от сети Wifi
                    else
                    {

                        if (connect.type != NetAdapType.Wifi)
                        {
                            manageNetAdap.ManageAdapter(ActionNetAdap.Off, connect.name);
                        }
                        else
                        {
                            manageWifi.WifiOff(connect.name);
                        }
                    }
                }

                return currentConnect;
            }

            return null;
        }

        //Возвращает следующее за текущим соединением, соединение к которому нужно подключиться
        AutoModeConnectInfo SelectConnect(AutoModeConnectInfo currentConnect)
        {
            AutoModeConnectInfo connect = null;

            if (currentConnect != null)
            {
                if (currentConnect.type == NetAdapType.Wifi)
                {
                    connect = GetNextPriorityWifi(currentConnect.priority, currentConnect.wifiAdapter);

                    //Для корректного перехода от сетей Wifi к сетевым адаптерам запрашиваем сеть Wifi c самым высоким приоритетом 
                    AutoModeConnectInfo highPriorityWifi = GetHighPriorityWifi(currentConnect.wifiAdapter);

                    /*Если текущая сеть Wifi не является сетью с самым высоким приоритетом и следующая сеть Wifi равна сети с самым высоким приоритетом,
                    или
                    если текущая сеть Wifi равна следующей по приоритетности сети,
                    то
                    все сети Wifi были перебраны и нужно переходить к следующему сетевому адпетеру*/
                    if (currentConnect.name != highPriorityWifi.name && connect.name == highPriorityWifi.name || connect.name == currentConnect.name)
                    {
                        connect = GetNextPriorityNetAdap(currentConnect.wifiAdapter.priority);

                        //Если следующий адаптер имеет тип Wifi (возможно Wifi адаптер единственный настроенный), запрашиваем сеть Wifi c наивысшим приоритетом
                        if (connect.type == NetAdapType.Wifi)
                        {
                            connect = GetHighPriorityWifi(new ServiceInfoNetAdap(connect));
                        }

                        return connect;
                    }
                    else
                    {
                        return connect;
                    }

                }
                else
                {
                    connect = GetNextPriorityNetAdap(currentConnect.priority);
                    if (connect.type == NetAdapType.Wifi)
                    {
                        connect = GetHighPriorityWifi(new ServiceInfoNetAdap(connect));
                    }
                    return connect;
                }
            }

            else
            {
                connect = GetHighPriorityNetAdap();

                //Если адаптер имеет тип Wifi запрашиваем сеть wifi c наивысшим приоритетом
                if (connect.type == NetAdapType.Wifi)
                {
                    connect = GetHighPriorityWifi(new ServiceInfoNetAdap(connect));
                }

            }

            return connect;
        }

        //Перебирает все доступные адаптеры и пытается выполнить подключение, если попытка подключения ко всем адаптерам завершилась неудачно, то возвращает false
        bool TryConnect(AutoModeConnectInfo connect)
        {
            AutoModeConnectInfo firstConnect = null;

            //Флаг для опередения, что нужно выполнить проверку, перебранны ли все возможные подключения
            bool flag = false;

            do
            {
                //Получае следующее соединение к которому нужно попробовать подключиться
                connect = SelectConnect(connect);

                if (flag == false)
                {
                    firstConnect = connect;
                }
                //Если полученное соединение равно первому соединению, которое пробовали подключить, значит перепробовали все варианты подключенния
                if (flag && firstConnect.name == connect.name)
                {
                    //Вызываем событие выполнена попытка подключения ко всем настроенным подключениям
                    if (AllConnecEnumerated != null) AllConnecEnumerated.Invoke(null);

                    //Обнуляем текущее соединение
                    currentConnet = null;

                    return false;
                }
                else
                {
                    flag = true;

                    try
                    {
                        //Проверка и при необходимости влкючение адаптера
                        if (connect.type == NetAdapType.Wifi)
                        {
                            if (!manageNetAdap.IsEnabled(connect.wifiAdapter.name))
                            {
                                //Если сетевой адаптер выключен, то включаем его
                                manageNetAdap.ManageAdapter(ActionNetAdap.On, connect.wifiAdapter.name);

                                InfoConnect infoConnect = new InfoConnect(connect.wifiAdapter.name, connect.type.ToString(), connect.wifiAdapter.priority.ToString());

                                //Отправляем сообщение о попытке включения сетевого адаптера
                                if (TryEnableAdapter != null) TryEnableAdapter.Invoke(infoConnect);

                                Thread.Sleep(pausaCheckEnableAdapter);

                                //Проверяем удалось ли включить адаптер
                                if (manageNetAdap.IsEnabled(connect.wifiAdapter.name))
                                {
                                    if (GoodTryEnableAdapter != null) GoodTryEnableAdapter.Invoke(infoConnect);
                                }
                                else
                                    throw (new Exception());
                            }
                        }
                        else
                        {
                            if (!manageNetAdap.IsEnabled(connect.name))
                            {
                                //Если сетевой адаптер выключен, то включаем его
                                manageNetAdap.ManageAdapter(ActionNetAdap.On, connect.name);

                                InfoConnect infoConnect = new InfoConnect(connect.name, connect.type.ToString(), connect.priority.ToString());

                                //Отправляем сообщение о попытке включения сетевого адаптера
                                if (TryEnableAdapter != null) TryEnableAdapter.Invoke(infoConnect);

                                Thread.Sleep(pausaCheckEnableAdapter);

                                //Проверяем удалось ли включить адаптер
                                if (manageNetAdap.IsEnabled(connect.name))
                                {
                                    if (GoodTryEnableAdapter != null) GoodTryEnableAdapter.Invoke(infoConnect);
                                }
                                else
                                    throw (new Exception());
                            }
                        }

                        //Если соединение имеет тип Wifi
                        if (connect.type == NetAdapType.Wifi)
                        {

                            //Если сеть обнаружена то подключаемся к ней
                            if (manageWifi.Isfound(connect.name))
                            {
                                InfoConnect infoConnect = new InfoConnect(connect.name, connect.type.ToString(), connect.priority.ToString());

                                //Вызываем событие попытка подключения к сети Wifi
                                if (TryConnectWifi != null) TryConnectWifi.Invoke(infoConnect);
                              
                                //Пытаемся подключиться к сети
                                try
                                { 
                                    manageWifi.wifiOn(connect.name, GetWifiPassword(connect.name));
                                }
                                catch(ManageWifiExeption exc)
                                {
                                    if (exc.exeptionNumber == 0)
                                    {
                                        //Вызываем событие подключение к сети Wifi выполнить не удалось, т.к. пароль неверен
                                        if (BadPasswordWifi != null) BadPasswordWifi.Invoke(infoConnect);
                                    }
                                    else
                                    {
                                        //Вызываем событие подключение к сети Wifi выполнить не удалось по неизвестной причине
                                        if (BadTryConnectWifi != null) BadTryConnectWifi.Invoke(infoConnect);
                                    }
                                }

                                //Если подключились, то завершаем работу
                                if (manageWifi.IsConnect(connect.name))
                                {
                                    //Вызываем событие подключение к сети Wifi проишло успешно
                                    if (GoodTryConnectWifi != null) GoodTryConnectWifi.Invoke(infoConnect);

                                    //Пробуем отключить предыдущее соединение
                                    try
                                    {
                                        //Отключаем текущее соединение
                                        if(currentConnet!=null && currentConnet.name!=connect.name)
                                        DisableConnect(currentConnet);
                                    }
                                    catch { }

                                    //Записываем данные нового подключения в текущее соединение
                                    currentConnet = connect;

                                    return true;
                                }
                                                
                            }
                            //Если сеть wifi не обнаружена
                            else
                            {
                                InfoConnect infoConnect = new InfoConnect(connect.name, connect.type.ToString(), connect.priority.ToString());

                                //Вызываем событие сеть Wifi не обнаружена
                                if (WifiNotfound != null) WifiNotfound.Invoke(infoConnect);
                            }
                        }
                        //Если сетевой адаптер имеет другой тип
                        else
                        {
                            //Если адаптер имеет тип 4G Modem, то запускаем задержку перед первой проверкой соединения с интернетом
                            if(connect.type==NetAdapType.Modem)
                            {
                                Thread.Sleep(pausaFirstCheckInternetModem);
                            }

                            //Пробуем отключить предыдущее соединение
                            try
                            {
                                if (currentConnet != null && currentConnet.name != connect.name)
                                    DisableConnect(currentConnet);
                            }
                            catch { }

                            currentConnet = connect;
                            return true;
                        }
                    }
                    //Сетевой адаптер в системе не обнаружен
                    catch (Exception exc)
                    {
                        InfoConnect infoConnect = null;

                        if (connect.type == NetAdapType.Wifi)
                            infoConnect = new InfoConnect(connect.wifiAdapter.name, connect.type.ToString(), connect.wifiAdapter.priority.ToString());
                        else
                            infoConnect = new InfoConnect(connect.name, connect.type.ToString(), connect.priority.ToString());


                        if (exc.Message == ManageNetAdap.badName.Message)
                        {
                            if (AdapterNotFound != null) AdapterNotFound.Invoke(infoConnect);
                        }
                        else
                            if (BadTryEnableAdapter != null) BadTryEnableAdapter.Invoke(infoConnect);
                    }
                }
            } while (true);
        }

        //Возввращает коллекцию включенных адаптеров, их типы и значения приоритетов, для Wifi возвращает имя сети и приоритет
        List<AutoModeConnectInfo> GetConnect()
        {
            List<AutoModeConnectInfo> lConnectedAdap = new List<AutoModeConnectInfo>();

            //Определяем включенные сетевые адаптеры
            foreach (ServiceInfoNetAdap netAdap in lServiceInfoNetAdap)
            {
                try
                {
                    if (manageNetAdap.IsEnabled(netAdap.name))
                    {
                        if (netAdap.netAdapType != NetAdapType.Wifi)
                        {
                            AutoModeConnectInfo adapter = new AutoModeConnectInfo(netAdap.name, netAdap.netAdapType, netAdap.priority);
                            lConnectedAdap.Add(adapter);
                        }
                        //Если адаптер c типом Wifi, то проверяем есть ли подключенная сеть, если да, то записываем ее данные в качестве подключеннго соединения и приоритет самого адаптера
                        else
                        {
                            try
                            {
                                string nameConnectedWifi = manageWifi.GetConnectedWifi();

                                if (nameConnectedWifi != null)
                                {
                                    AutoModeConnectInfo adapter = new AutoModeConnectInfo(nameConnectedWifi, NetAdapType.Wifi, GetPriorityWifi(nameConnectedWifi), netAdap);
                                    lConnectedAdap.Add(adapter);
                                }
                            }
                            catch { }
                        }

                    }

                }
                catch { }
            }

            return lConnectedAdap;
        }

        //Выполянет отключение от сети Wifi или выключает сетевой адаптер
        void DisableConnect(AutoModeConnectInfo connect)
        {
            if(connect.type==NetAdapType.Wifi)
            {
               manageWifi.WifiOff(connect.name);
            }
            else
            {
                manageNetAdap.ManageAdapter(ActionNetAdap.Off, connect.name);
            }
        }

        //Возвращает адаптер с самым высоким приоритетом
        AutoModeConnectInfo GetHighPriorityNetAdap()
        {
            AutoModeConnectInfo highPriorityNetAdap = null;

            byte highpriority = 0;

            //Определяем самое высокое значение приоритета (самое низкое значение кроме нуля)
            foreach (ServiceInfoNetAdap netAdap in lServiceInfoNetAdap)
            {
                if (highpriority == 0)
                {
                    if (netAdap.priority != 0)
                        highpriority = netAdap.priority;
                }
                else
                    if (netAdap.priority != 0 && netAdap.priority < highpriority)
                        highpriority = netAdap.priority;
                    
            }

            //Записываем данные адаптера с самым высоким значением приоритета
            foreach (ServiceInfoNetAdap netAdap in lServiceInfoNetAdap)
            {
                if (netAdap.priority == highpriority)
                {
                    highPriorityNetAdap = new AutoModeConnectInfo(netAdap.name, netAdap.netAdapType, netAdap.priority);
                }
            }

            return highPriorityNetAdap;
        }

        //Возвращает следующий по приоритетности адаптер или если такого нет, то адаптер с самым высоким значением приоритета
        AutoModeConnectInfo GetNextPriorityNetAdap(byte currentPriority)
        {
            AutoModeConnectInfo nextPriorityNetAdap = null;

            byte next = GetNextPriority(currentPriority, lServiceInfoNetAdap);


            //Записываем данные сетевого адаптера
            if (next != 0)
            {
                foreach (ServiceInfoNetAdap netAdap in lServiceInfoNetAdap)
                {
                    if (netAdap.priority == next)
                        nextPriorityNetAdap = new AutoModeConnectInfo(netAdap.name, netAdap.netAdapType, netAdap.priority);
                }
            }
            else
            //Если не могли определить следующий адаптер с более низким значением приоритета, то получаем значение адапетра с самым высоком значением приоритета
            if (next == 0)
                nextPriorityNetAdap = GetHighPriorityNetAdap();

            return nextPriorityNetAdap;
        }

        //Возвращает сеть Wifi c самым высоким значением приоритета, в качестве аргумента принимает значение приоритета сетевого адаптера Wifi
        AutoModeConnectInfo GetHighPriorityWifi(ServiceInfoNetAdap wifiAdapter)
        {
            AutoModeConnectInfo highPriorityWifi = null;

            byte highPriority = 0;

            //Определяем самое высокое значение приоритета (самое низкое значение кроме 0)
            foreach (ServiceInfoWifi wifi in lServiceInfoWifi)
            {
                if (highPriority == 0)
                {
                    if (wifi.priority != 0)
                        highPriority = wifi.priority;
                }
                else
                    if (wifi.priority < highPriority && wifi.priority != 0)
                    highPriority = wifi.priority;
            }

            //Записываем данные сети Wifi с самым выскоми приоритетом
            foreach(ServiceInfoWifi wifi in lServiceInfoWifi)
            {
                if (wifi.priority == highPriority)
                    highPriorityWifi = new AutoModeConnectInfo(wifi.name, NetAdapType.Wifi, wifi.priority, wifiAdapter);
            }

            return highPriorityWifi;
        }

        //Возвращает следующую по приоритетности сеть Wifi, в качестве аргументов принимает текущий приоритет сети Wifi и приоритет сетевого адаптера Wifi
        AutoModeConnectInfo GetNextPriorityWifi(byte currentPriority, ServiceInfoNetAdap wifiAdapter)
        {
            AutoModeConnectInfo nextPriorityWifi = null;

            byte next = GetNextPriority(currentPriority, lServiceInfoWifi);

            //Записываем даныне сетевого адаптера
            if(next!=0)
                foreach(ServiceInfoWifi wifi in lServiceInfoWifi)
                {
                    if (wifi.priority == next)
                        nextPriorityWifi = new AutoModeConnectInfo(wifi.name, NetAdapType.Wifi, wifi.priority, wifiAdapter);
                }
            else
            //Если не cмогли определить следующий адаптер с более низким значением приоритета, то получаем значение адапетра с самым высоким значением приоритета
            if (next == 0)
                nextPriorityWifi = GetHighPriorityWifi(wifiAdapter);

            return nextPriorityWifi;
        }

        //Возвращает следующее значение приоритета для сетей Wifi
        byte GetNextPriority(byte currentPriority, List<ServiceInfoWifi> lServiceInfoWifi)
        {
            byte next = 0;

            //Сортируем коллекуиию по приоритету сетей Wifi
            lServiceInfoWifi.Sort(delegate (ServiceInfoWifi x, ServiceInfoWifi y)
            {
                return x.priority.CompareTo(y.priority);
            });


            lServiceInfoWifi.Sort(delegate (ServiceInfoWifi x, ServiceInfoWifi y)
                {
                    return x.priority.CompareTo(y.priority);
                });

            foreach(ServiceInfoWifi wifi in lServiceInfoWifi)
            {
                if(wifi.priority>currentPriority)
                {
                    return next = wifi.priority;
                }
            }

            return next;
        }

        //Возвращает следующее значение приоритета для сетевых адаптеров
        byte GetNextPriority(byte currentPriority, List<ServiceInfoNetAdap> lServiceInfoNetAdap)
        {
            byte next = 0;

            //Сортируем коллекуиию по приоритету сетей Wifi
            lServiceInfoNetAdap.Sort(delegate (ServiceInfoNetAdap x, ServiceInfoNetAdap y)
            {
                return x.priority.CompareTo(y.priority);
            });

            foreach (ServiceInfoNetAdap adap in lServiceInfoNetAdap)
            {
                if (adap.priority > currentPriority)
                {
                  return  next = adap.priority;
                }
            }

            return next;
        }

        //
        //События
        //

        //Попытка влкючения сетевого адаптера
        public event ManageConnectEvent TryEnableAdapter;

        //Попытка подаключения к сети Wifi
        public event ManageConnectEvent TryConnectWifi;

        //Подключение к сети Wifi выполнено успешно
        public event ManageConnectEvent GoodTryConnectWifi;

        //Подключение к сети Wifi выполнить не удалось
        public event ManageConnectEvent BadTryConnectWifi;

        //Подключение к сети Wifi не удалось, т.к. пароль неверен
        public event ManageConnectEvent BadPasswordWifi;

        //Сеть Wifi не обнаружена
        public event ManageConnectEvent WifiNotfound;

        //Подключение к сетевому адаптеру выполнено успешно
        public event ManageConnectEvent GoodTryEnableAdapter;

        //Подключение к сетевому адаптеру выполнить не удалось
        public event ManageConnectEvent BadTryEnableAdapter;

        //Адапетр в системе не обнаружен
        public event ManageConnectEvent AdapterNotFound;

        //Выполнена попытка подключения ко всем настроенным подключениям
        public event ManageConnectEvent AllConnecEnumerated;

        #endregion

        #region //РЕАЛИАЗЦИЯ IServiceSettings

        //
        //PUBLIC МЕТОДЫ
        //

        //Возвращает коллекицю адресов для проверки соединения с интернетом
        public List<string> GetAddresses()
        {
            return lAddresses;
        }

        //Добавляет адрес в коллекцию адресов для проверки соединения с интернетом
        public bool AddAddress(string name)
        {
            lAddresses.Add(name);
            if (!WriteData()) return false;

            return true;
        }

        //Удаляет адрес из коллекции адресов для првоерки соединения с интернетом
        public bool RemodveAddress(string name)
        {
            for (int i = 0; i < lAddresses.Count; i++)
            {
                if (lAddresses[i] == name)
                {
                    lAddresses.RemoveAt(i);
                }
            }

            if (!WriteData())
                return false;

            return true;
        }

        //Возвращает значение интервала между првоерками соединения с интернетом
        public int GetIntervalCheckInternet()
        {
            return intervalCheckInternet;
        }

        //Устанавливает значение интервала между првоерками соединения с интернетом
        public bool SetIntervalCheckInternet(int interval)
        {
            if (interval < 10000 || interval > 600000) return false;

            intervalCheckInternet = interval;
            WriteData();
            return true;
        }

        //Возвращает таймаута ожидания ответа от сервера при проверке соединения
        public int GetTimeoutRequest()
        {
            return timeoutRequest;
        }

        //Устанавливает значение таймаута ожидания ответа от сервера при проверке соединения
        public bool SetTimeoutRequest(int timeout)
        {
            if (timeout < 1000 || timeout > 10000) return false;

            timeoutRequest = timeout;
            WriteData();
            return true;
        }

        //Возвращает значение задержки перед првоеркой удалось включить адаптер
        public int GetPausaCheckEnableAdapter()
        {
            return pausaCheckEnableAdapter;
        }

        //Устанавливает значение задержки перед првоеркой удалось включить адаптер
        public bool SetPausaCheckEnableAdapter(int pausa)
        {
            if (pausa < 1000 || pausa > 60000) return false;

            pausaCheckEnableAdapter = pausa;
            WriteData();
            return true;
        }

        //Возвращает значение задержки перед первой проверкой соединения при подключении через 4G Modem
        public int GetPausaModem()
        {
            return pausaFirstCheckInternetModem;
        }

        //Устанавливает значение задержки перед первой проверкой соединения при подключении через 4G Modem
        public bool SetPausaModem(int pausa)
        {
            if (pausa < 10000 || pausa > 600000)
                return false;

            pausaFirstCheckInternetModem = pausa;
            WriteData();
            return true;
        }

        //Возвращает флаг запуска автоматического режима контроля соединения при запуске приложения
        public bool GetAutoModeStart()
        {
            return autoModeStart;
        }

        //Устанавливает флаг запуска автоматического режима контроля соединения при запуске приложения
        public bool SetAutoModeStart(bool start)
        {
            autoModeStart = start;

            if (!WriteData()) return false;

            return true;
        }

        //Возвращает флаг добавления приложения в автозапуск Windows
        public bool GetAddAutoRun()
        {
            return addAutoRun;
        }

        //Устанавливает флаг добавления приложения в автозапуск Windows
        public bool SetAddAutoRun(bool run)
        {
            addAutoRun = run;

            //Добавляем данные в реестр Windows
            AddAutoRun(run);

            if (!WriteData()) return false;

            return true;
        }

        //
        //PRIVATE МЕТОДЫ
        //

        //Читает настроечную информацию из файла данных
        bool loadDataNetAdap()
        {
            BinaryReader rd;

            //
            //Создаем временные коллекции для сохранения иноформации из файла данных, если чтение пройдет успешно, то запишем в основные коллекции
            //

            //Коллекция сетевых адаптеров 
            List<ServiceInfoNetAdap> _lServiceInfoNetAdap;

            //Коллекция сетей Wifi
            List<ServiceInfoWifi> _lServiceInfoWifi;

            //Коллекция адресов для проверки соединения с интернетом
            List<string> _lAddresses;

            //Пробуем открыть файл
            try
            {
                
                rd = new BinaryReader(new FileStream(Application.StartupPath +@"\data.bin", FileMode.Open));
            }
            catch (IOException)
            {
                return false;
            }

            try
            {
                _lServiceInfoNetAdap = new List<ServiceInfoNetAdap>();
                _lServiceInfoWifi = new List<ServiceInfoWifi>();
                _lAddresses = new List<string>();

                while (rd.PeekChar() > -1)
                {
                    //Считываем колечиество блоков настроечной информации для сетевых адаптеров
                    int countOfNetAdap = rd.ReadInt32();

                    //Считваем количество блоков настроечной инфомрации для сетей Wifi
                    int countOfWifi = rd.ReadInt32();

                    //Считываем количество адрессов для проверки соединения с интернетом
                    int countOfAddresses = rd.ReadInt32();

                    //Считываем интервал проверки соединения с интернетом
                    intervalCheckInternet = rd.ReadInt32();

                    //Считываем таймаут ожидания ответа от сервера при проверке соединения
                    timeoutRequest = rd.ReadInt32();

                    //Считываем задержку перед првоеркой удались включить адаптер
                    pausaCheckEnableAdapter = rd.ReadInt32();

                    //Считываем значение задержки перед первой проверкой соединения при подключении через 4G Modem
                    pausaFirstCheckInternetModem = rd.ReadInt32();

                    //Считываем значение флага запуска автоматического режима контроля соединения при запуске приложения
                    autoModeStart = rd.ReadBoolean();

                    //Считываем значение флага добавления в автозапуск Windows
                    addAutoRun = rd.ReadBoolean();

                    //Считываем настроечную информацию для сетевых адаптеров во временную коллекцию
                    for (int i = 0; i < countOfNetAdap; i++)
                    {
                        ServiceInfoNetAdap adap = new ServiceInfoNetAdap();

                        adap.name = rd.ReadString();
                        adap.netAdapType = (NetAdapType)rd.ReadUInt32();
                        adap.priority = rd.ReadByte();
                        _lServiceInfoNetAdap.Add(adap);
                    }

                    //Считываем настроечную инфомрацию для сетей Wifi
                    for (int i = 0; i < countOfWifi; i++)
                    {
                        ServiceInfoWifi wifi = new ServiceInfoWifi();

                        wifi.name = rd.ReadString();
                        wifi.priority = rd.ReadByte();
                        wifi.password = rd.ReadString();

                        _lServiceInfoWifi.Add(wifi);
                    }
                    //Считываем адресса для проверки соединения с интернетом
                    for (int i = 0; i < countOfAddresses; i++)
                    {
                        string address = rd.ReadString();
                        _lAddresses.Add(address);
                    }
                }
                rd.Close();
            }
            catch (IOException)
            {
                return false;
            }

            //Если чтение прошло успешно, перезаписываем  lServiceInfoNetAdap
            lServiceInfoNetAdap = _lServiceInfoNetAdap;

            //Если чтение прошло успешно, перезаписываем lServiceInfoWifi
            lServiceInfoWifi = _lServiceInfoWifi;

            //Если чтение прошло успешно, перезаписываем lAddress
            lAddresses = _lAddresses;


            return true;
        }

        //Запиcывает информацию о настройках в файл данных
        bool WriteData()
        {
            BinaryWriter wr;

            try
            {
                wr = new BinaryWriter(new FileStream(Application.StartupPath+@"\data.bin", FileMode.Create));
            }
            catch (IOException)
            {
                return false;
            }

            try
            {
                //Записываем количество блоков настроечной инфомрации о сетевых адаптерах
                wr.Write(lServiceInfoNetAdap.Count);

                //Записывваем колчичество блоков настреочной информации о сетях Wifi
                wr.Write(lServiceInfoWifi.Count);

                //Записываем количетсов адреесов для проверки соединения с интернетом
                wr.Write(lAddresses.Count);

                //Записываем интервал между проверками соединеняи с интернетом
                wr.Write(intervalCheckInternet);

                //Запиываем таймаут ожидания ответа от сервера при проверке соединения
                wr.Write(timeoutRequest);

                //Записываем задержку перед првоеркой удались включить адаптер
                wr.Write(pausaCheckEnableAdapter);

                //Записываем значение задержки перед первой проверкой соединения при подключении через 4G Modem
                wr.Write(pausaFirstCheckInternetModem);

                //Записываем значение флага запуска автоматического режима контроля соединения при запуске приложения
                wr.Write(autoModeStart);

                //Записываем значение флага добавления в автозапуск Windows
                wr.Write(addAutoRun);

                //Записывавем информацию о сетевых адаптерах
                foreach (ServiceInfoNetAdap adap in lServiceInfoNetAdap)
                {
                    wr.Write(adap.name);
                    wr.Write((int)adap.netAdapType);
                    wr.Write(adap.priority);
                }

                //Записываем настроечнyю информацию о сетях Wifi
                foreach (ServiceInfoWifi wifi in lServiceInfoWifi)
                {
                    wr.Write(wifi.name);
                    wr.Write(wifi.priority);
                    wr.Write(wifi.password);
                }

                //Записываем адресса для проверки соединения с интернетом
                foreach (string address in lAddresses)
                {
                    wr.Write(address);
                }

                wr.Close();
            }
            catch (IOException)
            {
                return false;
            }

            return true;
        }

        //Добавлет или удаляет приложение из автозапуска Windows
        void AddAutoRun(bool add)
        {
            RegistryKey key = Registry.CurrentUser;
            key = key.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");

            if (add)
            {
                try
                {
                    key.SetValue("PingerAutoRun", Application.StartupPath + "\\Pinger.exe");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                key.DeleteValue("PingerAutoRun");
            }

        }

        #endregion

        //Конструктор
        public Service()
        {
            //Иниициализируем объекты для управления сетевыми адаптерами и сетями Wifi
            manageNetAdap = new ManageNetAdap();
            manageWifi = new ManageWifi();

            //Присваиваем null переменной хранящей текущее активное подключение в режиме автоматического контроля соединения
            currentConnet = null;

            //Указываем, что проврека с интернетом еще не производилась
            LastCheckInternet = CheckInternetResult.undone;

            //Инициализируем интервал между проверками соединения c интернетом значением по умолчанию
            intervalCheckInternet = 30000;

            //Инициализируем время ожидания в мс. ответа от сервера при тестировании соединения по умолчанию
            timeoutRequest = 3000;

            //Инициализируем задержку перед проверкой удались включить адаптер
            pausaCheckEnableAdapter = 5000;

            //Инициализируем задержку перед первой проверкой соединения при подключении через 4G Modem значением по умолчанию
            pausaFirstCheckInternetModem = 60000;

            //Инициализация флага запуска автоматического режима контроля соединения при запуске приложения значением по умолчанию
            autoModeStart = false;

            //Инициализируем флаг добавления приложения в автозапуск Windows
            addAutoRun = false;

            //Загружаем настроечную информацию из файла с настройками, если этого сделать не удалось инициализируем коллекции содержащие настроечную информацию
            if(!loadDataNetAdap())
            {
                lServiceInfoNetAdap = new List<ServiceInfoNetAdap>();
                lServiceInfoWifi = new List<ServiceInfoWifi>();
                lAddresses = new List<string>();
            }

            //Если в файле настроек отсутствуют адреса для проверки соединения, то добавляем значения по умолчанию
         
                if (lAddresses.Count == 0)
                {
                    lAddresses.Add("http://yandex.ru");
                    lAddresses.Add("http://mail.ru");
                    lAddresses.Add("http://google.ru");
                }
            
            

        }
    }
}
