using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using TestConnect;
using System.Text;
using System.Threading.Tasks;


namespace Pinger
{
    class Presenter
    {
        #region //ПЕРЕМЕННЫЕ

        //
        //ИНТЕРФЕЙСЫ
        //

        //Управление формой HeadForm
        IOveralHead overalHead;

        //Управление панелью сетевых адаптеров формы Head
        IPanNetAdapHead panNetAdapHead;

        //Управление панелью сетей Wifi формы Head
        IPanWifiHead panWifiHead;

        //Управление блоком проверки соединения формы Head
        IPanCheckInternetHead panCheckInternetHead;

        //Управление панелью сетевых адаптеров фомры Settings
        IPanNetAdapSettings panNetAdapSettings;

        //Управление панелью сетевых адаптеров фомры Settings
        IPanWifiSettings panWifiSettings;

        //Управление GroupOtherSettings
        IGroupOtherSettings groupOtherSettings;

        //Управление формой добавления сетевых адаптерво
        IAddWifiForm addWifi;

        //Управление формой Settings
        IOveralSettings overalSettings;

        //Управление настройками
        IServiceSettings serviceSettings;

        //Управление сетевыми адаптерами
        IManageNetAdap manageNetAdap;

        //Управление сетями Wifi
        IMangeWifi manageWifi;

        //Проверка содинения с интернетом
        IManageConnect manageConnect;

        //
        //ПОТОКИ
        //

        //Поток обновления информации о сетевых адаптерах 
        Task taskNetAdap;

        //Периодичность обновления информации о сетевых адаптерах в мс.
        int IntervalUpdateNetAdap;

        //Ссылка на поток обновления информации о сетевых адаптерах 
        Thread _taskNetAdap;

        //Поток обновления информации о сетях Wifi
        Task taskWifi;

        //Период остановки потока, если пользователь навел курсор мыши на PanWifiHead в мс.
        int pauseUpdateWifi;

        //Ссылка на поток обновления информации о сетях Wifi
        Thread _taskWifi;

        //Периодичность обновления информации о сетях Wifi в мс.
        int IntervalUpdateWifi;

        //Поток для проверки соединения в ручном режиме
        Task taskCheckConnect;

        //Ссылка на поток для проверки соединения с интернетом
        Thread _taskCheckConnect;

        //Задача для контроля соединения в автоматическом режиме
        Task taskManageConnect;

        //Для получения ссылки на поток контроля соединеняи в автоматическом режиме 
        Thread _taskMangeConnect;

        //
        //ПРОЧИЕ
        //

        //Очередь для записи результатов проверки соединения 
        Queue<string> qCheckInterntResult;

        //Количество результатов проверки соединения, выводимых в TexBoxCheckInternet
        int maxCheckInternetResult;

        //Пауза после выполнения операций (включения, выключения сетевых адаптеров и т.д.) в режиме автоматического контроля соединения
        int pausaAfterOperation;
        #endregion

        #region //ФОРМА HEAD

        #region //УПРАВЛЕНИЕ panNetAdap (ВКЛЮЧЕНИЕ/ВЫКЛЮЧЕНИЕ СЕТЕВЫХ АДАПАТЕРОВ)

        //Коллекция для хранения информации о сетевых адаптерах, загруженная в LvNetAdap
        List<string[]> lLvNetAdap;

        //Проверяет соедржимое LvNetAdap и при несоответствии информации полученной из manageNetAdap выполняет обновление инфорации в LvNetAdap
        void CheckLvNetAdap()
        {
            //Получение коллекции из manangeNetAdap c информацией о сетевых адаптерах
            List<string[]> lInfoNetAdap = manageNetAdap.GetInfoNetAdap();

            //Если lLvNetAdap не пустой, то выполняем сравнение значений из LvNetAdap и lMangeNetAdap
            if (lLvNetAdap != null)
            {
                //Если есть различия, то выполянем обновление LvNetAdap
                if (!CompareNetAdap(lLvNetAdap, lInfoNetAdap))
                {
                    //Обновляем LvNetAdap
                    LoadLvNetAdapHead(lInfoNetAdap);

                    //Сохраняем инфомрацию о сетевых адаптерах, которую записали в LvNetAdap
                    lLvNetAdap = lInfoNetAdap;
                }
            }
            //если lLvNetAdap пустой, то выполняем обновление без дополнительных проверок
            else
            {
                //Обновляем LvNetAdap
                LoadLvNetAdapHead(lInfoNetAdap);

                //Сохраняем инфомрацию о сетевых адаптерах, которую записали в LvNetAdap
                lLvNetAdap = lInfoNetAdap;
            }

        }

        //Сравнивает содержимое LvNetAdap и информацию о сетевых адаптерах, полученную от manageNetAdap
        bool CompareNetAdap(List<string []> lLvNetAdap, List<string []> lManageNetAdap)
        {
            //Если количество элементов не совпадает возвращаем false
            if (lLvNetAdap.Count != lManageNetAdap.Count) return false;

            //Сравниваем каждый элемент
            for(int i=0; i<lLvNetAdap.Count; i++)
            {
                //Сравниваем имена адаптеров
                if (lLvNetAdap[i][0] != lManageNetAdap[i][0]) return false;

                //Сравниваем значение conneсtionStatus
                if (lLvNetAdap[i][1] != lManageNetAdap[i][1]) return false;

                //сравниаем значения состояния (включен, выключен)
                if (lLvNetAdap[i][2]!=lManageNetAdap[i][2]) return false;
            }

            return true;
        }

        //Загружает инфомрацию о сетевых адаптерах в LvNetAdap
        void LoadLvNetAdapHead(List<string[]> lManageNetAdap)
        {
            //Перед обновлением LvNetAdap выключаем кнопки на PanNetAdap
            panNetAdapHead.EnabledButOffNetAdap(false);
            panNetAdapHead.EnabledButOnNetAdap(false);

            //Очищение LvNetAdap
            panNetAdapHead.ClearLvNetAdap();

            //Добавление записей в LvNetAdap
            if (lManageNetAdap != null)
            {
                for (int i = 0; i < lManageNetAdap.Count; i++)
                {
                    //Если сетеовй адаптер не обнаружен в списке настроечной информации 
                    if(!manageNetAdap.CheckNetAdapInServiceInfo(lManageNetAdap[i][0]))
                    {
                        //Добавляем сетеовой адаптер в настроечную информацию
                        if(!manageNetAdap.AddNetAdapServiceInfo(lManageNetAdap[i][0]))
                        {
                            overalHead.ShowMessage("Не удалось записать информацию о " + lManageNetAdap[i][0] + "в \"data.bin\"");
                        }
                    }
                    panNetAdapHead.AddLvNetAdap(lManageNetAdap[i]);
                }
            }
        }

        //Управлеят свойством Enabled кнопок ButOnNetAdap и ButOffNetAdap на panLvNetAdap
        void manageButOnPanLvNetAdap()
        {
            //Обновляем информацию о сетях Wifi в LvWifi, чтобы снять выделение
            LoadLvWifiHead(manageWifi.GetInfoWifi());

            //Получаем информацию о сетевом адапетере, который выбрал пользователь в LvNetAdap
           string [] selectedLvNetAdap = panNetAdapHead.GetSelectedNetAdap();

            if (selectedLvNetAdap==null)
            {
                panNetAdapHead.EnabledButOffNetAdap(false);
                panNetAdapHead.EnabledButOnNetAdap(false);
            }
            else
            {
                if(manageNetAdap.IsNabled(selectedLvNetAdap[0]))
                {
                    panNetAdapHead.EnabledButOffNetAdap(true);
                    panNetAdapHead.EnabledButOnNetAdap(false);
                }
                else
                {
                    panNetAdapHead.EnabledButOnNetAdap(true);
                    panNetAdapHead.EnabledButOffNetAdap(false);
                }
            }

        }

        //Включает сетевой адаптер, выбранный пользователем в LvNetAdap
        void OnNetAdap()
        {
            //Получаем информацию о сетевом адапетере, который выбрал пользователь в LvNetAdap
            string[] selectedLvNetAdap = panNetAdapHead.GetSelectedNetAdap();

            manageNetAdap.OnNetAdap(selectedLvNetAdap[0]);
        }

        //Выключает сетевой адапетр, выбранный пользователем в LvNetAdap
        void OffNetAdap()
        {
            //Получаем информацию о сетевом адапетере, который выбрал пользователь в LvNetAdap
            string[] selectedLvNetAdap = panNetAdapHead.GetSelectedNetAdap();

            manageNetAdap.OffNetAdap(selectedLvNetAdap [0]);
        }

        #endregion

        #region //УПРАВЛЕНИЕ panWifi (ПОДКЛЮЧЕНИЕ/ОТКЛЮЧЕНИЕ СЕТЕЙ Wifi)

        //Коллекция для хранения инфомрации о сетях Wiif, загруженной в LvWifi
        List<string[]> lLvWifi;

        //Проверяет содержимое LvWifi и при несоответствии данных из manageWifi выполняет обновление LvWifi
        void CheckLvWifi()
        {
            //Получаем информацию о сетях wifi
            List<string[]> infoWifi = manageWifi.GetInfoWifi();

            //Если lLvWif не пустой, то выполняем сравнение значений из LvNetAdap и lMangeNetAdap
            if(lLvWifi!=null)
            {
                //Если есть различия, то выполянем обновление LvNetWifi
                if(!CompareWifi(lLvWifi, infoWifi))
                {
           
                    //Обновляем LvWifi
                    LoadLvWifiHead(infoWifi);

                    //Сохраняем инфомрацию о сетевых адаптерах, которую записали в LvNetAdap
                    lLvWifi = infoWifi;
                }
            }
            //Если lLvWif пустой, то выполняем обновление без провероки
            else
            {
                //Обновляем LvWifi
                LoadLvWifiHead(infoWifi);

                //Сохраняем инфомрацию о сетевых адаптерах, которую записали в LvNetAdap
                lLvWifi = infoWifi;
            }

        }

        //Сравнивает содержимое для lLvWifi и LvWifi
        bool CompareWifi(List<string[]>lLvWifi, List<string[]> getInfoWifi)
        {
            ////Если getInfoWifi пустой, то возвращаем false
            if (getInfoWifi == null) return false;

            //Если количество элементов не совпадает возвращаем false
            if (lLvWifi.Count != getInfoWifi.Count) return false;

            //Сравниваем каждый элемент
            for(int i=0; i<lLvWifi.Count; i++)
            {
                //Сравниваем имена сетей Wifi
                if (lLvWifi[i][0] != getInfoWifi[i][0]) return false;

                //Cравниваем уровень сигнала
                if (lLvWifi[i][1] != getInfoWifi[i][1]) return false;

                //Сравниваем значение параметра безопастность
                if (lLvWifi[i][2] != getInfoWifi[i][2]) return false;

                //Сравниваем значение статуса (Включена\Выключена)
                if (lLvWifi[i][3] != getInfoWifi[i][3]) return false;
            }

            return true;
        }

        //Загружает ифномрацию о сетях Wifi в LvWifi
        void LoadLvWifiHead(List<string[]> getInfoWifi)
        {

            //Выключаем кнопки и блок ввода пароля
            panWifiHead.EnabledButOffWifi(false);
            panWifiHead.EnabledButOnWifi(false);
            panWifiHead.EnabledEnterPass(false);

            panWifiHead.ClearLvWifi();

            
            if (getInfoWifi!= null)
            foreach(string [] arr in getInfoWifi)
            panWifiHead.AddLvWifi(arr);
        }

        //Управляет свойством Enabled кнопок ButOnWifi и ButOffWifi, областью ввода пароля на панели PanWifi
        void manageBlockWifiOnOff()
        {
            //Обновляем инфомрацию о сетевых адаптерах в LvNetAdap, чтобы снять выделение
            LoadLvNetAdapHead(manageNetAdap.GetInfoNetAdap());

            string[] selectedWifi = panWifiHead.GetSelectedWifi();

            string help = "Ввод пароля не обязателен, если он сохранен в операционной системe!";

            if(selectedWifi==null)
            {
                panWifiHead.EnabledButOffWifi(false);
                panWifiHead.EnabledButOnWifi(false);
                panWifiHead.EnabledEnterPass(false);
            }
            else
            if(manageWifi.IsConnected(selectedWifi[0]))
            {
                panWifiHead.EnabledButOnWifi(false);
                panWifiHead.EnabledButOffWifi(true);
                panWifiHead.EnabledEnterPass(false);
            }
            else
            {
                panWifiHead.EnabledButOnWifi(true);
                panWifiHead.EnabledButOffWifi(false);
                panWifiHead.EnabledEnterPass(true, help);
            }
        }

        //Подключает выбранную сеть Wifi
        void WifiOn()
        {
            //Для записи значения результата попытки подключения к сети Wifi
            int val;

            string[] selectedWifi = panWifiHead.GetSelectedWifi();

            

            if (selectedWifi != null)
            {
                string password = selectedWifi[1];

                //Если пользователь не ввел пароль при выборе Wifi, то получаем его из настроечной информации
                if(password=="")
                {
                    password = manageWifi.GetWifiPassword(selectedWifi[0]);
                }
                val = manageWifi.WifiOn(selectedWifi[0], password);

                switch (val)
                {
                    case 0:
                        overalHead.ShowMessage("Пароль неверный!");
                        break;
                    case 1:
                        overalHead.ShowMessage("Произошла неизвестная ошибка!");
                        break;
                    case 2:
                        overalHead.ShowMessage("Сеть Wifi с указанным именем не найдена!");
                        break;
                }
            }

            //Выполняем принудительное обновление о информации о сетях Wifi
            CheckLvWifi();
        }

        //Отключает выбранную сеть Wifi
        void WifiOff()
        {
            string[] selectedWifi = panWifiHead.GetSelectedWifi();

            if (selectedWifi != null)
            manageWifi.WifiOff(selectedWifi[0]);

            //Выполняем принудительное обновление о информации о сетях Wifi
            CheckLvWifi();
        }

        #endregion

        #region //УПРАВЛЕНИЕ ОБЛАСТЬЮ ПРОЕРКИ СОЕДИНЕНИЯ

        //Записывает в TexBoxCheckInternet результаты проверки соединения
        void WriteCheckInternetResult(List<TestConnectInfo> lTest, CheckInternetResult lastTest)
        {
            
            //Записываем текущее время в текст с результатами пинга
            string result =DateTime.Now.ToLongTimeString() + Environment.NewLine + Environment.NewLine;

            //Если проверка соединения с интернтом окончилась неудачно
            if (lastTest == CheckInternetResult.unsucces)
            {
                result = DateTime.Now.ToLongTimeString() + Environment.NewLine + Environment.NewLine
                    + "Соединение с интернетом отсутствует!!!" + Environment.NewLine;
            }
            else
           //Если проверку соединения с интернетом выполнять не удалось
                if (lastTest == CheckInternetResult.failed)
                {
                    result = DateTime.Now.ToLongTimeString() + Environment.NewLine + Environment.NewLine
                    + "Выполнить проверку соединения с интернетом не удалось, т.к.все адреса серверов имеют некорректный формат!" + Environment.NewLine;
                }
                else
                {
                    foreach (TestConnectInfo test in lTest)
                    {
                        if (test.result == TestConnect.Result.unformat)
                        {
                            result += "Выполнить проверочный запрос на:" + Environment.NewLine + test.url + Environment.NewLine
                            + "не удалось, т.к. \"url\"" + Environment.NewLine + "имеет некорректный формат!";
                        }
                        else
                            if (test.result == TestConnect.Result.timeout)
                            {
                                result += "Проверочный запрос на:" + Environment.NewLine + test.url + Environment.NewLine
                                + "Выполнить не удалось!" + Environment.NewLine+  "Превышен лимит ожидания ответа," + Environment.NewLine+ "возможно сайт не доступен!";

                            }
                            else
                                if (test.result == TestConnect.Result.error)
                                {
                                    result += "При выполнении запроса на: " + test.url + Environment.NewLine
                                    + "произошла неизвестная ошибка!!!";

                                }
                                else
                                {
                                    result += "Проверочный запрос на:" + Environment.NewLine + test.url + Environment.NewLine + "выполнен успешно!" + Environment.NewLine
                                   + "Использовано: " + test.time + " мс.";
                                }

                    result += Environment.NewLine + Environment.NewLine;

                }

                }   


            result += Environment.NewLine;

            //Записываем результаты последней проверки соединения с интернотом в очередь
            qCheckInterntResult.Enqueue(result);

            //Если длина очереди имеет предельное значение, удаляем элемент из головы очереди
            if (qCheckInterntResult.Count == maxCheckInternetResult) qCheckInterntResult.Dequeue();

            //Для передачи результатов пинга в TexBoxPingResult
            string allPingResult=null;

            //Записываем все результаты пинга из очереди от конца к началу
            for (int i= qCheckInterntResult.Count-1; i>=0; i--)
            {
                allPingResult += qCheckInterntResult.ElementAt(i);
            }

            //Записываем результаты пинга в TexBoxPingResult
            panCheckInternetHead.SetTexBoxCheckInternet(allPingResult);
        }

        //Проверяет соединение с интернетом по запросу пользователя
        void CheckInternet()
        {
            panCheckInternetHead.EnableButCheckInternet(false);
            WriteCheckInternetResult(manageConnect.CheckInternet(), manageConnect.GetLastCheckInternet());
            panCheckInternetHead.EnableButCheckInternet(true);
        }

        #endregion

        #endregion

        #region //ФОРМА SETTINGS

        #region //ИНИЦИЦИАЛИЗАЦИЯ ПОЛЕЙ ФОРМЫ, ОБРАБОТЧИКИ СОБЫТИЙ overal

        //Выполняет операции иницииализации интерфейсов и подпись на события перед открытием фомры Settings
        void LoadFormSettings(ISettingsForm Settings)
        {
            //
            //ИНИЦИАЛИЗАЦИЯ ИНТЕРФЕЙСОВ
            //

            //Интерфейс упрвления panNetAdap
            panNetAdapSettings = Settings;

            //Интерфейс управленяи panWifi
            panWifiSettings = Settings;

            //Интерфейс управления GroupOtherSettings формы Settings
            groupOtherSettings = Settings;

            //Интерфейс управления формой Settings
            overalSettings = Settings;

            //
            //ЗАГРУЗКА ДАННЫХ В ФОРМУ
            //

            //Загрузка настроечной информации в LvNetAdap
            LoadLvNetAdapSettings();

            //Загрузка настроечной информации в LvWifi
            LoadLvWifiSettings();

            //Загрузка списка адрессов в LbAddresses
            LoadLbAddresses();

            //Загрузка в TexBoxIntervalCheckInternet значения инетервала (в секундах) между проверками соединения с инетернетом
            groupOtherSettings.SetTexBoxChangeIntervalCheckInternet((serviceSettings.GetIntervalCheckInternet() / 1000).ToString());

            //Загрузка в TexBoxTimeoutRequest значения таймаута (в секундах) ожидания ответа от сервера при првоерке соединения
            groupOtherSettings.SetTexBoxTimeoutRequest((serviceSettings.GetTimeoutRequest() / 1000).ToString());

            //Загрузка в TexBoxPausaCheckEnableAdapter значения задержки (в секундах) перед выполнением проверки включен ли адаптер
            groupOtherSettings.SetTexBoxPausaCheckEnableAdapter((serviceSettings.GetPausaCheckEnableAdapter() / 1000).ToString());

            //Загрузка в TexBoxPausaModem значения задержки (в секундах) перед выполнением первой проверки соединения при подключении черзе 4G Modem
            groupOtherSettings.SetTexBoxPausaModem((serviceSettings.GetPausaModem() / 1000).ToString());

            //Установка значения флага запуска автоматического режима контроля соединения при запуске приложения в CheckBoxAutoModeStart
            groupOtherSettings.SetCheckBoxAutoModeStart(serviceSettings.GetAutoModeStart());

            //Установка значения флага добавления приложения в автозапуск Windows
            groupOtherSettings.SetCheckBoxAddAutoRun(serviceSettings.GetAddAutoRun());

            //Загрузка сообщения в подсказку
            overalSettings.SetTexBoxHelp(Help.baseHelp);

            //
            //ПОДПИСЬ НА СОБЫТИЯ panNetAdap
            //

            //Выделение пользователем сетевого адаптера в LvNetAdap
            panNetAdapSettings.LvNetAdapSelectedIndexChange += manageControlPanNetAdapSettings;
            panNetAdapSettings.LvNetAdapSelectedIndexChange += DisableControlPanWifiSettings;

            //Измнение пользователем comboTypeNetAdap
            panNetAdapSettings.comboTypeNetAdapSelectedIndexChanged += comboTypeNetAdapSelectedIndexChanged;

            //Нажатие кнопки сохранить настройки
            panNetAdapSettings.ButSaveSettingsClick += SaveSettingsNetAdap;

            //Нажатие кнопки удалить сетевой адаптер не обнаруженный в системе
            panNetAdapSettings.ButDelNetAdapClick += DelNotFoundNetAdap;

            //
            //ПОДПИСЬ НА СОБЫТИЯ panWifi
            //

            //Нажатие кнопки добавить сеть Wifi в список сетей использумых для подклчюения к интернету в автоматическом режиме
            panWifiSettings.AddWifiShow += LoadFormAddWifi;

            //Нажатие кнопки удаления сети Wifi из списока сетей использумых для подклчюения к интернету в автоматическом режиме
            panWifiSettings.ButDelWifiClick += DelWifiFromServiceInfo;

            //Выделение пользователем сети Wifi в LvWifi
            panWifiSettings.LvWifiSelectedIndexChanged += EnableControlPanWifiSettings;
            panWifiSettings.LvWifiSelectedIndexChanged += DisableControlPanNetAdapSettings;

            //Cохранение настроек сети Wifi
            panWifiSettings.ButSaveSettingsWifiClick += SaveSettingsWifi;

            //Изменение пользователем свойства Text в TexBoxPass
            panWifiSettings.TexBoxPassTextChanged += manageButSaveWifiSettings;

            //Выбор пользователем значения приоритета для сети Wifi
            panWifiSettings.ComboPriorityWifiSelectedIndexChanged += manageButSaveWifiSettings;

            //Нажатие кнопки сброса пароля для сети Wifi
            panWifiSettings.ButResetPassWifiClick += ResetWiifPass;

            //
            //ПОДПИСЬ НА СОБЫТИЯ groupOtherSettings
            //

            //Нажатие кнопки добавления адреса для првоерки соединения с интернетом в настроечную инфомрацию
            groupOtherSettings.ButAddAddressClick += AddAddress;

            //Нажатие кнопки удаления адреса из настроечной инфомрации
            groupOtherSettings.ButDelAddressClick += DelAddress;

            //Выбор пользователем адереса в LbAddress
            groupOtherSettings.LbAddressSelectedIndexChanged += LbAddressSelectedIndexChanged;

            //Изменение пользователем свойства Text в TexBoxAddress
            groupOtherSettings.TexBoxAddressTextChanged += TexBoxAddressTextChanged;

            //Нажатие кнопки изменить (сохранить) интервал между првоерками соединения
            groupOtherSettings.ButChangeIntervalChekcInternetClick += ButChangeIntervalChekcInternetClick;

            //Нажатие кнопки изменить (сохранить) таймаут ожидания ответа от сервера при проверке соединения
            groupOtherSettings.ButChangeTimeoutRequestClick += ButChangeTimeoutRequestClick;

            //Нажатие кнопки изменить (сохранить) значение задержки перед проверкой включен ли адаптер
            groupOtherSettings.ButChangePausaCheckAdapterClick += ButChangePausaCheckAdapter;

            //Нажатие кнопки изменить(сохранить) значние задержки перед первой проверкой соединения при подключении через 4G Modem
            groupOtherSettings.ButChangePausaModemClick += ButChangePausaModemClick;

            //Изменение свойства Checked CheckBoxAutoModeStart
            groupOtherSettings.CheckBoxAutoModeStartCheckedChanged += CheckBoxAutoModeStartCheckedChanged;

            //Изменение свойства Checked CheckBoxAddAutoRun
            groupOtherSettings.CheckBoxAddAutoRunCheckedChanged += CheckBoxAddAutoRunCheckedChanged;

            //
            //ПОДПИСЬ НА СОБЫТИЯ overalSettings
            //

            //Пользователь навел мышь на область настроек адресов для проверки соединения
            overalSettings.MouseOnGroupManageAddress += MouseOnGroupManageAddress;

            //Пользователь навел мышь на область настройки интервала между проверками соединения
            overalSettings.MouseOnGroupIntervalCheckInternet += MouseOnGroupIntervalCheckInternet;

            //Пользователь навел мышь на область настройки таймаута ожидания ответа от сервера
            overalSettings.MouseOnGroupTimeoutRequest += MouseOnGroupTimeoutRequest;

            //Пользователь навел мышь на область настройки паузы перед выполнением проверки удалось ли включить сетевой адаптер
            overalSettings.MouseOnGroupPausaCheckEnableAdapter += MouseOnGroupPausaCheckEnableAdapter;

            //Пользователь навел мышь на область настройки паузы перед первой проверкой соединения с интернетом при подключении через 4G Modem
            overalSettings.MouseOnGroupPausaModem += MouseOnGroupPausaModem;

            //Пользователь навел мышь на область настройки активации автоматического режима контроля соединения при запуске приложения
            overalSettings.MouseOnGroupAutoModeStart += MouseOnGroupAutoModeStart;

            //Пользователь навел мышь на область настроек сетевых адапетров или сетей Wifi
            overalSettings.MouseOnLvNetAdap += MouseOnLvNetAdapOrLvWifi;
            overalSettings.MouseOnLvWifi += MouseOnLvNetAdapOrLvWifi;

            //Пользователь закрыл форму, перезаписываем информации в TexBoxInfo (формы HEAD)
            overalSettings.SettingsFormFormClosed += SetTexBoxInfoManualMode;
            overalSettings.SettingsFormFormClosed += SetTexBoxIntervalCheckInternet;

        }

        //Класс, содержащий подсказки для пользователя
        static class Help
        {
            //Базовая подсказка по настройке сетевых адптеров и сетей wifi
            public static readonly string baseHelp = "Настройка сетевых адаптеров и сетей Wifi для контроля соединения с интернетом в автоматическом режиме." + Environment.NewLine + Environment.NewLine +
                "1. Для настройки сетевых адаптеров, которые будут использоваться в режиме автоматического контроля соединения с интернетом:" + Environment.NewLine +
                "- укажите тип адаптера (адаптеры с типом \"Unknown\" не могут использоваться в режиме автоматического контроля соединения);" + Environment.NewLine +
                "- назначьте приоритет подключения (0 - адаптер не используется, 1 - самый высокий приоритет, 5 - самый низкий приоритет);" + Environment.NewLine + Environment.NewLine +
                "2. Для назначения приоритета адаптеру с типом \"Wifi\", нужно назначить приоритет подключения хотя бы одной сети Wifi на панели настройки сетей Wifi." + Environment.NewLine + Environment.NewLine +
                "3. Для добавления сети Wifi на панель настройки сетей Wifi: нажмите кнопку \"Добавить Wifi\". Добавлять можно только те сети, которые обнаружены адаптером \"Wifi\" в данный момент (адаптер должен быть включен)!" + Environment.NewLine + Environment.NewLine +
                "4. Приоритеты для сетей Wifi назначаются независимо от приоритетов подключения сетевых адаптеров:" + Environment.NewLine +
                "- при переходе на сетевой адаптер с типом \"Wifi\", приложение в первую очередь попробует подключиться к сети с самым высоким приоритетом среди сетей Wifi, затем к сети с более низким приоритетом и т.д.;" + Environment.NewLine +
                "- значения приоритетов: 0 - сеть не используется, 1 - самый высокий приоритет, 10 - самый низкий приоритет;" + Environment.NewLine + Environment.NewLine +
                "5. Адаптеры, имеющие статус: \"Не обнаружен\" могут быть удалены из списка сетевых адапетеров, адапетеры со статусом: \"Подключен\" нет.";

            //Подсказка если пароль для сети wifi не сохранен
            public static readonly string passwordWifi = "Важно!" + Environment.NewLine + Environment.NewLine +
                "Рекомендуется сохранить пароль для гарантированного подключения к сети Wifi в режиме автоматического контроля соединения с интернетом!";

            //Подсказка по настройке серверов для проверки соединения с интернетом
            public static readonly string addresses = "Настройка серверов для отправки проверочного запроса с целью определить наличие соединения с интернетом." + Environment.NewLine + Environment.NewLine +
                "1. Для добавления сервера введите его   адрес в формате:" + Environment.NewLine +
                " \" http://address.com\"." + Environment.NewLine + Environment.NewLine +
                "2. Рекомендуется использовать адреса крупных интернет-порталов, таких как \"google.com\"." + Environment.NewLine + Environment.NewLine +
                "3. Для повышения эффективности проверки соединения с интернетом рекомендуется использовать минимум 3 сервера." + Environment.NewLine + Environment.NewLine +
                "4. Если все адреса будут удалены, то при перезапуске приложения будут восстановлены адреса серверов по умолчанию.";


            //Подсказка по настройке интервала между проверками соединения с интернетом
            public static readonly string intervalCheckInternet = "Настройка интервала между проверками соединения с интернетом." + Environment.NewLine + Environment.NewLine +
                "Возможные значения от 10 до 600 секунд, чем меньше значение, тем быстрее приложение будет переключаться с одного подключения на другое при отсутствии интернета в автоматическом режиме или выводить сообщения о результатах проверки соединения в ручном режиме.";

            //Подсказка по настпройке таймаута ответа от сервера 
            public static readonly string timeoutRequst = "Настройка периода ожидания ответа от сервера при направлении проверочного запроса." + Environment.NewLine + Environment.NewLine +
                "1. Возможные значения от 1 до 10 секунд." + Environment.NewLine + Environment.NewLine +
                "2. Если сервер не отвечает в течении указанного периода, то приложение отмечает его как недоступный, если все сервера недоступны, то приложение определяет, что соединение с интернетом отсутствует." + Environment.NewLine + Environment.NewLine +
                "3. Если используются медленные соединения с интернетом, например, мобильный интернет, то рекомендуется устанавливать значение параметра ближе к максимальному.";

            //Подсказка по настройке задержки перед выполнением проверки удалось ли включить сетевой адаптер
            public static readonly string pausaCheckEnableAdapter = "Настройка задержки перед выполнением проверки удалось ли включить сетевой адаптер." + Environment.NewLine + Environment.NewLine +
                "1. Возможные значения от 1 до 60 секунд." + Environment.NewLine + Environment.NewLine +
                "2. После отправки команды на включение выключенного сетевого адаптера, приложение выполняет проверку: удалось ли включить сетевой адаптер, перед выполнением такой проверки требуется пауза, т.к. операционной системе требуется время на включение сетевого адаптера." + Environment.NewLine + Environment.NewLine +
                "3. Если установить минимальное значение, то существуют вероятность, что приложение не сможет корректно определить удалось ли включить сетевой адаптер, это может привести к некорректной работе в автоматическом режиме контроля соединения с интернетом." + Environment.NewLine + Environment.NewLine +
                "4. Рекомендуется устанавливать это значение в 5 секунд и выше.";

            //Подсказа по настройке паузы перед первой проверкой соединения с интернетом
            public static readonly string pausaModem = "Настройка задержки перед выполнением первой проверки соединения с интернетом при подключении через 4G Modem" + Environment.NewLine + Environment.NewLine +
                "1. Возможные значения от 10 до 600 секунд." + Environment.NewLine + Environment.NewLine +
                "2. При включении адаптера с типом \"Modem\", устройству требуется значительное время на поиск мобильной сети и подключение к ней." + Environment.NewLine + Environment.NewLine +
                "3. Рекомендуется устанавливать значение параметра в 60 секунд и выше." + Environment.NewLine + Environment.NewLine +
                "4. Установка значения меньше 60 секунд может привести к тому, что \"4G Modem\" не будет успевать подключиться к интернету и приложение преждевременно выполнит проверку соединения с интернетом.";

            //Подсказка по настройке активации автоматического режима контроля соединения при запуске приложения
            public static readonly string autoModeStart = "Настройка активации автоматического режима при запуске приложения." + Environment.NewLine + Environment.NewLine +
                "Для активации режима автоматического контроля соединения при запуске приложения должно быть настроено не менее двух вариантов подключения.";

            //Подсказа по настройке приоритета для сетевого ададптера с типом Wifi
            public static readonly string priorityWifiAdapter = "1. Для назначения приоритета адаптеру с типом \"Wifi\", нужно назначить приоритет подключения хотя бы одной сети Wifi на панели настройки сетей Wifi." + Environment.NewLine + Environment.NewLine +
                "2. Для добавления сети Wifi на панель настройки сетей Wifi: нажмите кнопку \"Добавить Wifi\". Добавлять можно только те сети, которые обнаружены адаптером \"Wifi\" в данный момент (адаптер должен быть включен)!";
        }

        //Обработчик события MouseOnGroupManageAddress
        void MouseOnGroupManageAddress()
        {
            if(overalSettings.GetTexBoxHelp()!=Help.addresses)
            overalSettings.SetTexBoxHelp(Help.addresses);
        }

        //Обработчик события MouseOnGroupManageAddress
        void MouseOnGroupIntervalCheckInternet()
        {
            if (overalSettings.GetTexBoxHelp() != Help.intervalCheckInternet)
                overalSettings.SetTexBoxHelp(Help.intervalCheckInternet);
        }

        //Обработчки осбытия MouseOnGroupTimeoutRequest
        void MouseOnGroupTimeoutRequest()
        {
            if(overalSettings.GetTexBoxHelp()!=Help.timeoutRequst)
            {
                overalSettings.SetTexBoxHelp(Help.timeoutRequst);
            }
        }

        //Обработчки события MouseOnGroupPausaCheckAdapter
        void MouseOnGroupPausaCheckEnableAdapter()
        {
            if(overalSettings.GetTexBoxHelp()!=Help.pausaCheckEnableAdapter)
            {
                overalSettings.SetTexBoxHelp(Help.pausaCheckEnableAdapter);
            }
        }

        //Обработчик события MouseOnGroupPausaModem
        void MouseOnGroupPausaModem()
        {
            if(overalSettings.GetTexBoxHelp()!=Help.pausaModem)
            {
                overalSettings.SetTexBoxHelp(Help.pausaModem);
            }
        }

        //Обработчик события MouseOnAutoModeStart
        void MouseOnGroupAutoModeStart()
        {
            if(overalSettings.GetTexBoxHelp()!=Help.autoModeStart)
            {
                overalSettings.SetTexBoxHelp(Help.autoModeStart);
            }
        }

        //Обработчик события MouseOnLvNetAdap и MouseOnLvWifi
        void MouseOnLvNetAdapOrLvWifi()
        {
            string help = overalSettings.GetTexBoxHelp();

            if (help!= Help.baseHelp && help!=Help.passwordWifi && help!=Help.priorityWifiAdapter)
                overalSettings.SetTexBoxHelp(Help.baseHelp);
        }

        #endregion

        #region //ФОРМА SETTINGS НАСТРОЙКА СЕТЕВЫХ АДАПТЕРОВ

        //Загружает настроечную информацию в LvNetAdap
        void LoadLvNetAdapSettings()
        {
            DisableControlPanNetAdapSettings();

            panNetAdapSettings.ClearLvNetAdap();

            List<string[]> lServiceInfo = manageNetAdap.GetServiceInfoNetAdap();

            for (int i = 0; i < lServiceInfo.Count; i++)
            {
                panNetAdapSettings.AddLvNetAdap(lServiceInfo[i]);
            }
        }

        //Управляет свойством Enabled контролов на PanNetAdap
        void manageControlPanNetAdapSettings()
        {
           string [] infoNetAdap=panNetAdapSettings.GetSelectedInfoNetAdap();

            if (infoNetAdap != null)
            {
                
                bool comboType = true;
                bool comboPrioryty = false;
                bool butSave = false;
                bool butDelete = false;


                //Определяем состояние для comboPriorityNetAdap
                if (infoNetAdap[1] != "Unknown")
                {
                    if (infoNetAdap[1] == "Wifi")
                    {
                        if (manageWifi.GetCountWorkWifi() > 0)
                            comboPrioryty = true;
                        else
                        {
                            if (overalSettings.GetTexBoxHelp() != Help.priorityWifiAdapter)
                                overalSettings.SetTexBoxHelp(Help.priorityWifiAdapter,2);
                        }
                    }
                    else
                    {
                        comboPrioryty = true;
                        //Проверяем содержимое подсказки
                        if (overalSettings.GetTexBoxHelp() != Help.baseHelp)
                            overalSettings.SetTexBoxHelp(Help.baseHelp);
                    }
                }

                //Определяем состояние для butDelete (удалять можно только адаптеры не обнаруженные в системе)
                if (infoNetAdap[3] == "Не обнаружен")
                {
                    butDelete = true;
                }

                panNetAdapSettings.EnabledControlPanNetAdap(comboType, comboPrioryty, butSave, butDelete);   
            }

           
        }
        
        //Выключает контролы на PanNetAdap, кроме LvNetAdap
        void DisableControlPanNetAdapSettings()
        {
            panNetAdapSettings.EnabledControlPanNetAdap(false, false, false, false);
        }

        //Сохраняет настройки сетевых адаптеров (приоритет, тип)
        void SaveSettingsNetAdap()
        {
            //Настрйки указанные пользователем
            string[] settings = panNetAdapSettings.GetSelectedComboNetAdap();

            //Если пользователь ввел новое значение типа адаптера, то записываем его в настроечную информацию
            if (settings[0] != null)
            {
                if (settings[1] != null)
                {
                    if (!manageNetAdap.SetNetAdapType(settings[0], settings[1]))
                    {
                        overalHead.ShowMessage("Не сохранить настройки в файл данных для: " + settings[0]);
                    }
                }

                if (settings[2] != null)
                {
                    if (manageNetAdap.CheckPriority(byte.Parse(settings[2])))
                    {
                        overalHead.ShowMessage("Выбранное значение приоритета уже назаначено сетевому адаптеру, выберите другое значение!!!");
                    }
                    else
                    if(!manageNetAdap.SetNetAdapPriority(settings[0], byte.Parse(settings[2])))
                    {
                        overalHead.ShowMessage("Не сохранить настройки в файл данных для: " + settings[0]);
                    }
                }

           }

            panNetAdapSettings.EnabledControlPanNetAdap(false, false, false, false);

            LoadLvNetAdapSettings();
        }

        //Удаляет сетевой адаптер, не обнаруженный в системе, из настроечной информации
        void DelNotFoundNetAdap()
        {
            string[] select = panNetAdapSettings.GetSelectedInfoNetAdap();

            if (!manageNetAdap.DelNetAdap(select[0]))
                overalHead.ShowMessage("При удалении ифнормации о " + select[0] + " из файла данных произошла ошибка!!!");

            LoadLvNetAdapSettings();

            panNetAdapSettings.EnabledControlPanNetAdap(false, false, false, false);
        }

        //Обработчик события comboTypeNetAdapSelectedIndexChanged
        void comboTypeNetAdapSelectedIndexChanged()
        {
            string[] combo = panNetAdapSettings.GetSelectedComboNetAdap();
            string[] infoNetAdap = panNetAdapSettings.GetSelectedInfoNetAdap();

            bool butDelete = false;

            if (infoNetAdap[3] == "Не обнаружен") butDelete = true;

            if (combo[1] != "Unknown")
            {
                if (combo[1] == "Wifi")
                {
                    if (manageWifi.GetCountWorkWifi() > 0)
                        panNetAdapSettings.EnabledControlPanNetAdap(true, true, true, butDelete);
                }
                else
                {
                    panNetAdapSettings.EnabledControlPanNetAdap(true, true, true, butDelete);
                }

            }
            else
            {
                panNetAdapSettings.EnabledControlPanNetAdap(true, false, true, butDelete);
            }
        }

        #endregion

        #region //ФОРМА Settings НАСТРОЙКА Wifi

        //Загружает настроечную ифномрацию в LvWifi
        void LoadLvWifiSettings()
        {

            DisableControlPanWifiSettings();

            panWifiSettings.ClearLvWifi();

            List<string[]> lServiceInfo = manageWifi.GetServiceInfoWifi();

            for(int i =0; i<lServiceInfo.Count; i++)
            {
                panWifiSettings.AddLvWifi(lServiceInfo[i]);
            }
        }

        //Удаляет сеть Wifi из списка сетей изспользумыех для подключения интеренту в автоматическом режиме сеть Wifi
        void DelWifiFromServiceInfo()
        {
            string[] selectedWifi = panWifiSettings.GetSelectedWifi();

            if(selectedWifi!=null)
            {
                if(!manageWifi.DelWifiFromServiceInfo(selectedWifi[0]))
                {
                    overalHead.ShowMessage("При удалении: " + selectedWifi[0] + " из файла данных произошла ошибка!!!");
                }
                else
                {
                    LoadLvWifiSettings();
                }
            }

            if (overalSettings.GetTexBoxHelp() != Help.baseHelp) overalSettings.SetTexBoxHelp(Help.baseHelp);
        }

        //Включает контролы на panWifiSettings
        void EnableControlPanWifiSettings()
        {
            string[] selectedWifi = panWifiSettings.GetSelectedWifi();
            
            if (selectedWifi != null)
            {
                panWifiSettings.EnableBlockEntryPassWifi(true);
                panWifiSettings.EnableButDelWifi(true);
                panWifiSettings.EnableComboPriorityWifi(true);
            }

            if (selectedWifi[1] == "Сохранен")
            {
                //Включаем кнопку сброса пароля
                panWifiSettings.EnableButResetPassWifi(true);

                if (overalSettings.GetTexBoxHelp() != Help.baseHelp)
                    overalSettings.SetTexBoxHelp(Help.baseHelp);
            }
            else
            {
                //Если пароль не сохранен выводим подсказку
                overalSettings.SetTexBoxHelp(Help.passwordWifi, 2);

                //Выключаем кнопку сброса пароля
                panWifiSettings.EnableButResetPassWifi(false);
            }
        }

        //Выключает контролы на panWifiSettings
        void DisableControlPanWifiSettings()
        {
            panWifiSettings.EnableBlockEntryPassWifi(false);
            panWifiSettings.EnableButDelWifi(false);
            panWifiSettings.EnableButSaveSettingsWifi(false);
            panWifiSettings.EnableComboPriorityWifi(false);
            panWifiSettings.EnableButResetPassWifi(false);

            panWifiSettings.ResetBlockEntryPassWifi();
        }

        //Включает кнопку сохранить настройки
        void manageButSaveWifiSettings()
        {
            string password = panWifiSettings.GetTexBoxPass();
            string priority = panWifiSettings.GetComboPriorityWifi();

            if (priority != null || password != null)
                panWifiSettings.EnableButSaveSettingsWifi(true);
            

            if(password==null && priority==null) panWifiSettings.EnableButSaveSettingsWifi(false);
        
        }

        //Сохранение настроек
        void SaveSettingsWifi()
        {
            string[] wifi = panWifiSettings.GetSelectedWifi();

            string password = panWifiSettings.GetTexBoxPass();

            string priority = panWifiSettings.GetComboPriorityWifi();

            if (priority != null)
            {
                if (!manageWifi.CheckPriorityWifi(Byte.Parse(priority)))
                {
                    if (!manageWifi.SetWifiPriority(wifi[0], Byte.Parse(priority)))
                        overalHead.ShowMessage("Ошибка при записи в файл данных значения приоритета для: " + wifi[0] + "!!!");
                }
                else
                    overalHead.ShowMessage("В настрйоках уже сохранена сеть Wifi с аналогичным значением приоритета, выберите другое значение!!!");
            }

            /*Если в результате установки значения приоритета не осталось настроенных сетей Wifi для подключеня к интеренту в автоматичесокм режиме,
            то сбрасываем значение приоритета для сетевого адаптера с типом Wifi на 0*/

            if (manageWifi.GetCountWorkWifi() == 0)
            {
                if (!manageNetAdap.ResetPriorityNetAdapWifi())
                    overalHead.ShowMessage("Ошибка при записи в файл нового значения приоритета для адаптера с типом Wifi");

                LoadLvNetAdapSettings();
            }

            if (password != null)
                if (!manageWifi.SetWifiPassword(wifi[0], password))
                    overalHead.ShowMessage("Ошибка при записи в файл данных значения приоритета для: " + wifi[0] + "!!!");



            LoadLvWifiSettings();

            if (overalSettings.GetTexBoxHelp() != Help.baseHelp) overalSettings.SetTexBoxHelp(Help.baseHelp);
        }

        //Сброс пароля для Wifi
        void ResetWiifPass()
        {
            string[] wifi = panWifiSettings.GetSelectedWifi();

           if(!manageWifi.SetWifiPassword(wifi[0], ""))
                overalHead.ShowMessage("Ошибка при записи в файл нового пароля для: " + wifi[0] + "!!!");

            LoadLvWifiSettings();
        }

        #endregion

        #region //ФОРМА Settings ОСТАЛЬНЫЕ НАСТРОЙКИ

        //Загружает в LbAddresses адреса для проверки соединения с интернетом
        void LoadLbAddresses()
        {
            groupOtherSettings.ClearLbAddress();

            foreach(string address in serviceSettings.GetAddresses())
            {
                groupOtherSettings.AddLbAddress(address);
            }

            groupOtherSettings.EnableButAddAddress(false);
            groupOtherSettings.EnableButDelAddresses(false);
        
        }

        //Добавляет новый адрес в настроечную информацию
        void AddAddress()
        {
            string address = groupOtherSettings.GetTexBoxAddress();

            //Очищаем содержимое TexBoxAddress
            groupOtherSettings.SetTexBoxAddress();

            if(address!=null)
            {
                if(!serviceSettings.AddAddress(address))
                {
                    overalHead.ShowMessage("Произошла ошибка при записи адреса: " + address + " в файл настроек!");
                }
            }

            LoadLbAddresses();
        }

        //Удаляет адрес из насроечной информации
        void DelAddress()
        {
            string address = groupOtherSettings.GetSelectedAddresses();

            if(address!=null)
            {
                if(!serviceSettings.RemodveAddress(address))
                {
                    overalHead.ShowMessage("Произошла ошибка при записи информации о удалении адреса:" + address + " в файл настроек!");
                }
            }

            LoadLbAddresses();

        }

        //Обработчик события LbAddressSelectedIndexChanged
        void LbAddressSelectedIndexChanged()
        {
            if (groupOtherSettings.GetSelectedAddresses() != null)
            {
                groupOtherSettings.EnableButDelAddresses(true);
                groupOtherSettings.EnableButAddAddress(false);

                groupOtherSettings.SetTexBoxAddress();
            }
            else
                groupOtherSettings.EnableButDelAddresses(false);
        }

        //Обработчик события TexBoxAddressTextChanged
        void TexBoxAddressTextChanged()
        {
            if (groupOtherSettings.GetTexBoxAddress() != null)
            {
                groupOtherSettings.EnableButDelAddresses(false);
                groupOtherSettings.EnableButAddAddress(true);

                groupOtherSettings.SetNullSelectedLbAddress();
            }
            else
            {
                groupOtherSettings.EnableButAddAddress(false);
            }
        }

        //Обработчик события нажатия кнопки ButChangeIntervalChekcInternetClick
        void ButChangeIntervalChekcInternetClick()
        {
            int interval;

            if(groupOtherSettings.GetTextButChangeIntervalChekcInternet()=="Изменить")
            {
                groupOtherSettings.SetTextButChangeIntervalChekcInternet("Сохранить");
                groupOtherSettings.SetReadOnlyTexBoxChangeIntervalCheckInternet(false);

            }
            else
            {
                if(Int32.TryParse(groupOtherSettings.GetTexBoxChangeIntervalCheckInternet(), out interval))
                {
                    //Приводим interval к миллисекундам
                    interval *= 1000;

                    if(interval!=serviceSettings.GetIntervalCheckInternet())
                    {
                        if(!serviceSettings.SetIntervalCheckInternet(interval))
                        {
                            overalHead.ShowMessage("Введено некорретное значение! Допустимые значения от 10 до 600 секунд");
                            groupOtherSettings.SetTexBoxChangeIntervalCheckInternet((serviceSettings.GetIntervalCheckInternet() / 1000).ToString());
                        }
                           
                    }

                    
                    groupOtherSettings.SetTextButChangeIntervalChekcInternet("Изменить");
                    groupOtherSettings.SetReadOnlyTexBoxChangeIntervalCheckInternet(true);
                }
                else
                {
                    overalHead.ShowMessage("Введено некорретное значение! Допустимые значения от 10 до 600 секунд");

                    groupOtherSettings.SetTexBoxChangeIntervalCheckInternet((serviceSettings.GetIntervalCheckInternet() / 1000).ToString());

                    groupOtherSettings.SetTextButChangeIntervalChekcInternet("Изменить");
                    groupOtherSettings.SetReadOnlyTexBoxChangeIntervalCheckInternet(true);
                }
            }

        }

        //Обработчик события нажатия кнопки ButChangeTimeoutRequest
        void ButChangeTimeoutRequestClick()
        {
            int timeout;

            if (groupOtherSettings.GetTextButChangeTimeoutRequest() == "Изменить")
            {
                groupOtherSettings.SetTextButChangeTimeoutRequest("Сохранить");
                groupOtherSettings.SetReadOnlyTexBoxTimeoutRequest(false);
            }
            else
            {
                if (Int32.TryParse(groupOtherSettings.GetTexBoxTimeoutRequest(), out timeout))
                {
                    //Приводим timeout к миллисекундам
                    timeout *= 1000;

                    if (timeout != serviceSettings.GetTimeoutRequest())
                    {
                        if (!serviceSettings.SetTimeoutRequest(timeout))
                        {
                            overalHead.ShowMessage("Введено некорретное значение! Допустимые значения от 1 до 10 секунд");
                            groupOtherSettings.SetTexBoxTimeoutRequest((serviceSettings.GetTimeoutRequest() / 1000).ToString());
                        }

                    }


                    groupOtherSettings.SetTextButChangeTimeoutRequest("Изменить");
                    groupOtherSettings.SetReadOnlyTexBoxTimeoutRequest(true);
                }
                else
                {
                    overalHead.ShowMessage("Введено некорретное значение! Допустимые значения от 1 до 10 секунд");

                    groupOtherSettings.SetTexBoxTimeoutRequest((serviceSettings.GetTimeoutRequest() / 1000).ToString());

                    groupOtherSettings.SetTextButChangeTimeoutRequest("Изменить");
                    groupOtherSettings.SetReadOnlyTexBoxTimeoutRequest(true);
                }
            }
        }

        //Обработчки события нажатия кнопки ButChangePausaCheckAdapter
        void ButChangePausaCheckAdapter()
        {
             int pausa;

            if (groupOtherSettings.GetTextButChangePausaCheckAdapter() == "Изменить")
            {
                groupOtherSettings.SetTextButChangePausaCheckAdapter("Сохранить");
                groupOtherSettings.SetReadOnlyTexBoxPausaCheckEnableAdapter(false);
            }
            else
            {
                if (Int32.TryParse(groupOtherSettings.GetTexBoxPausaCheckEnableAdapter(), out pausa))
                {
                    //Приводим pausa к миллисекундам
                    pausa *= 1000;

                    if (pausa != serviceSettings.GetPausaCheckEnableAdapter())
                    {
                        if (!serviceSettings.SetPausaCheckEnableAdapter(pausa))
                        {
                            overalHead.ShowMessage("Введено некорретное значение! Допустимые значения от 1 до 60 секунд");
                            groupOtherSettings.SetTexBoxPausaCheckEnableAdapter((serviceSettings.GetPausaCheckEnableAdapter() / 1000).ToString());
                        }

                    }


                    groupOtherSettings.SetTextButChangePausaCheckAdapter("Изменить");
                    groupOtherSettings.SetReadOnlyTexBoxPausaCheckEnableAdapter(true);
                }
                else
                {
                    overalHead.ShowMessage("Введено некорретное значение! Допустимые значения от 1 до 60 секунд");

                    groupOtherSettings.SetTexBoxPausaCheckEnableAdapter((serviceSettings.GetPausaCheckEnableAdapter() / 1000).ToString());

                    groupOtherSettings.SetTextButChangePausaCheckAdapter("Изменить");
                    groupOtherSettings.SetReadOnlyTexBoxPausaCheckEnableAdapter(true);
                }
            }
        }

        //Обработчик события нажатия кнопки ButChangePausaModem
        void ButChangePausaModemClick ()
        {
            int pausa;

            if (groupOtherSettings.GetTextButChangePausaModem() == "Изменить")
            {
                groupOtherSettings.SetTextButChangePausaModem("Сохранить");
                groupOtherSettings.SetReadOnlyTexBoxPausaModem(false);
            }
            else
            {
                if (Int32.TryParse(groupOtherSettings.GetTexBoxPausaModem(), out pausa))
                {
                    //Приводим pausa к миллисекундам
                    pausa *= 1000;

                    if (pausa != serviceSettings.GetPausaModem())
                    {
                        if (!serviceSettings.SetPausaModem(pausa))
                        {
                            overalHead.ShowMessage("Введено некорретное значение! Допустимые значения от 10 до 600 секунд");
                            groupOtherSettings.SetTexBoxPausaModem((serviceSettings.GetPausaModem() / 1000).ToString());
                        }

                    }
                    groupOtherSettings.SetTextButChangePausaModem("Изменить");
                    groupOtherSettings.SetReadOnlyTexBoxPausaModem(true);
                }
                else
                {
                    overalHead.ShowMessage("Введено некорретное значение! Допустимые значения от 10 до 600 секунд");

                    groupOtherSettings.SetTexBoxPausaModem((serviceSettings.GetPausaModem() / 1000).ToString());

                    groupOtherSettings.SetTextButChangePausaModem("Изменить");
                    groupOtherSettings.SetReadOnlyTexBoxPausaModem(true);
                }
            }
        }

        //Обработчик изменение свойства Checked CheckBoxAutoModeStart
        void CheckBoxAutoModeStartCheckedChanged()
        {
            bool writeIsOk = true;

            
            if (groupOtherSettings.GetCheckBoxAutoModeStart())
            {
                //Если работа в автоматическом режиме возможна
                if (manageConnect.CheckAutoMode())
                {
                    //Устанавливаем флаг запуска автоматического режима контроля в true
                    if (!serviceSettings.SetAutoModeStart(true))
                        writeIsOk = false;
                }
                else
                {
                    groupOtherSettings.SetCheckBoxAutoModeStart(false);
                    overalHead.ShowMessage("Активация автоматического режима при запуске приложения невозможна,"+ 
                        "т.к. настроенных подключений для работы в автоматическом режиме меньше 2-х!");
                }
            }
            else
            {
                if (!serviceSettings.SetAutoModeStart(false))
                    writeIsOk = false;
            }

            if (!writeIsOk)
                overalHead.ShowMessage("При записи в файл настроек значения флага \"активации режима автоматического контроля соединения с инетрентом при запуске приложения\" произошла ошибка");

        }

        //Обработчик измененяи свойства Checked CheckBoxAddAutoRun
        void CheckBoxAddAutoRunCheckedChanged()
        {
            bool writeIsOk = true;

            if (groupOtherSettings.GetCheckBoxAddAutoRun())
            {
                if (!serviceSettings.SetAddAutoRun(true))
                {
                    writeIsOk = false;
                }
            }
            else
            {
                if (!serviceSettings.SetAddAutoRun(false))
                {
                    writeIsOk = false;
                }
            }

            if(!writeIsOk)
            {
                overalHead.ShowMessage("При записи в файл настроек значения флага \"Добавить в автозапуск Windows\" произошла ошибка");
            }
        }

        #endregion

        #endregion

        #region //ФОРМА ADDWIFI

        //Выполняет операции иницииализации интерфейсов и подпись на события перед открытием фомры AddWifi
        void LoadFormAddWifi (IAddWifiForm AddWifi)
        {
            //Интерфейс управления формой AddWifi
            addWifi = AddWifi;

            //Загружаем информацию о доступных сетях Wifi в LvWifi
            LoadLvWifiAddWifi();

            //
            //ПОДПИСЬ НА СОБЫТИЯ
            //

            //Нажатие кнопки добавления сети Wifi  в список сетей используемых для подключения к интернету в автоматическом режиме
            addWifi.ButAddWifiClick += AddWifiInLbWifi;

            //Нажатие кнопки добавление сети Wifi в список сетей используемых для подключения к интернету в автоматическом режме
            addWifi.ButSaveAddedWifiClick += AddWifiInServiceInfo;

            //После закрытия формы AddWifi
            addWifi.FormAddWifiClosed += LoadLvWifiSettings;

            //Нажатие кнопки удаления выбранной пользователем сети Wifi из LbWifi
            addWifi.ButDelWifiClick += RemoveWifiFromLbWifi;

            //Выделение сети Wifi в LvWifi
            addWifi.LvWifiSelectedIndexChanged += manageButAddWifi;

            //Выделение сети Wifi в LbWifi
            addWifi.LbWifiSelectedIndexChanged += manageButAddWifi;
        }

        //Загружает настроечную информацию в LvWifi
        void LoadLvWifiAddWifi()
        {
            addWifi.ClearLvWifi();

            //Разрешение на запись в LbWifi
            bool loadWifi = true;

            //Содержимое LbWiif
            string[] LbWifi = addWifi.GetAddedWifiFromLbWifi();

            //Получаем информацию о сетевых адаптерах
            List<string[]> lInfoWifi = manageWifi.GetInfoWifi();

            //Загружаем инфомрацию о сетях Wifi
            if (lInfoWifi != null)
                foreach (string[] array in lInfoWifi)
                {
                    //Проверяем есть сеть Wifi в списке используемых сетей для подключения к интернету в атоматическом режиме, если нет то загружаем,
                    //чтобы пользвоатель мог ее добавить в этот список
                    if (!manageWifi.IsWifiInlServiceInfo(array[0]))
                    {
                        //Проверяем есть ли сеть Wifi в LbWifi и если да то запрещаем запись в LvWifi, чтобы пользователь не мог ее повторно добавить в
                        //LbWifi
                        if(LbWifi!=null)
                        foreach (string name in LbWifi)
                        {
                            if (name == array[0]) loadWifi = false;
                        }

                        //Если разрешение на запись false, то возвращаем true, но сеть Wifi в LvWifi не добавляем
                        if (!loadWifi)
                        {
                            loadWifi = true;
                        }
                        else addWifi.AddLvWifi(array);
                    }
                }
        }

        //Добавляет выбранную сеть Wifi в LbWifi
        void AddWifiInLbWifi()
        {
            addWifi.AddLbWifi(addWifi.GetSelectedWifiFromLvWifi());
        }

        //Сохраняет выбранные сети Wifi в список сетей используемых для подключения к интернету в автоматическом режме
        void AddWifiInServiceInfo()
        {
            string[] wifi = addWifi.GetAddedWifiFromLbWifi();

            foreach(string wf in wifi)
            {
                if (!manageWifi.SetWifiInServiceInfo(wf))
                    overalHead.ShowMessage("Не удалось записать информацию о сети Wifi: " + wf + "в файл данных: \"data.bin\"");
            }

            addWifi.ClearLbWifi();
        }

        //Удаляет выбранную сеть Wifi из LbWifi
        void RemoveWifiFromLbWifi()
        {
            addWifi.RemoveSelectedFromLbWifi();

            //Перегружаем LvWifi, чтобы отобразить в LvWifi удаленную из LbWiif сеть Wifi
            LoadLvWifiAddWifi();
        }

        //Изменяет свойство Enabled кнопки ButAddWifi при выделении пользователем сети Wifi в LvWifi
        void manageButAddWifi()
        {
            //Если пользователь выделил сеть Wifi в LvWifi
            string lvWifi = addWifi.GetSelectedWifiFromLvWifi();

            if (lvWifi != null)
            {
                addWifi.EnabledButAddWifi(true);
                addWifi.EnabledButAddedWifi(false);
                addWifi.EnabledButDelWifi(false);
            }
            else
            {
                addWifi.EnabledButAddWifi(false);
            }
            //Если в LbWifi добавлены сети Wifi
            if(addWifi.GetItemsLbWifi()!=0)
            {   
                addWifi.EnabledButAddedWifi(true);

                //Если пользователь выделил сеть в LbWifi включаем кнопку удаления
                if (addWifi.isSelectedLbWifi())
                    addWifi.EnabledButDelWifi(true); 
            }
            else
            {
                addWifi.EnabledButAddedWifi(false);
                addWifi.EnabledButDelWifi(false);
            }
         }

        #endregion

        #region //КОНТРОЛЬ СОЕДИНЕНИЯ В АВТОМАТИЧЕСКОМ РЕЖИМЕ И РУЧНОМ РЕЖИМЕ

        //Запуск и остановка потоков проверки соединения в автоматическом и ручном режиме
        void startStopAutoMode()
        {
            bool start = overalHead.GetCheckBoxAutoMode();

            //Изменяем свойство контролов на форме Head
            overalHead.ManageControlChekedAutoMode(start);

            if (start)
            {
                if (manageConnect.CheckAutoMode())
                {
                    //Останавливем поток проверки соединения в обычном режиме
                    if (_taskCheckConnect != null)
                    {
                        _taskCheckConnect.Abort();
                        _taskCheckConnect = null;
                    }
                    //Запускаем поток проверки соединения в автомтаическом режиме
                    if (_taskMangeConnect == null)
                        taskManageConnect = Task.Factory.StartNew(TaskAutoManageConnect);
                }
                else
                {
                    overalHead.ShowMessage("Переход в режим автоматического контроля соединения невозможен, т.к. настроено меньше двух вариантов подключения к интернету. Перейдите в меню \"Настройки\" и настройте варианты подключения!");
                    overalHead.SetCheckBoxAutoMode(false);
                }
            }
            else
            {
                //Изменяем свойство контролов на форме Head
                overalHead.ManageControlChekedAutoMode(start);

                //Останавливем поток проверки соединения в автоматическом режиме
                if (_taskMangeConnect != null)
                {
                    _taskMangeConnect.Abort();
                    _taskMangeConnect = null;
                }
                //Запускаем поток проверки соединения в ручном режиме
                if(_taskCheckConnect==null)
                taskCheckConnect = Task.Factory.StartNew(TaskCheckConnect);
            }
       }
           
        //Заполнение служебной информацией TexBoxInfo в ручном режиме контроля соединения
        void SetTexBoxInfoManualMode()
        {
            string infoManual;

            //Устанавливаем черный цвет для для TexBoxInfo
            overalHead.SetColorTexBoxInfo();

            //Если переход в режим автоматического контроля соединения возможен
       
            infoManual = "Приложение работает в режиме \"Ручного\" управления подключениями к интернету." + Environment.NewLine+Environment.NewLine;
     
            infoManual += GetCurrentConnectManualMode();

            overalHead.SetTexBoxInfo(infoManual, 1);
        }

        //Заполнение TexBoxIntervalChekcInternet
        void SetTexBoxIntervalCheckInternet()
        {         
            overalHead.SetTexBoxIntervalCheckInernet("Периодичность проверки соединения с инетернетом: " + Environment.NewLine+
                (serviceSettings.GetIntervalCheckInternet() / 1000).ToString() + " секунд.");
        }

        //Возвращает строку с информацией о текущих активных подключениях
        string GetCurrentConnectManualMode()
        {
            string currentConnect=null;

            List<InfoConnect> lInfo = manageConnect.GetCurrentConnect();

            currentConnect += "Текущие активные подключения:" + Environment.NewLine;

            if (lInfo != null)
            {

                foreach (InfoConnect info in lInfo)
                {
                    if (info.type == "Wifi")
                    {
                        currentConnect += "Сеть Wifi: \"" + info.name + "\";" + Environment.NewLine;
                    }
                    else
                        currentConnect += "Сетевой адаптер: \"" + info.name + "\" тип: \"" + info.type + "\";" + Environment.NewLine;
                }
                currentConnect = currentConnect.Remove(currentConnect.Count() - 3, 3);
                currentConnect += ".";
            }
            else
                currentConnect+= "Активных подключений нет!";
            return currentConnect;
        }

        //Возвращает строку с текущим соединением для вывовда в TexBoxAutoInfo при работе в автоматическом режиме контроля соединения
        string GetCurrentConnectAutoMode()
        {
            string info=null;

            if (manageConnect.GetCurrentConnectType() != "Wifi")
            {
                info=DateTime.Now.ToLongTimeString() + Environment.NewLine +
                    "Проверка соединения с интернетом выполнена успешно!" + Environment.NewLine +
                    "Текущее подключение: \"" + manageConnect.GetCurrentConnectName() + "\"." + Environment.NewLine +
                    "Тип адаптера: " + manageConnect.GetCurrentConnectType() + ". Приоритет: " + manageConnect.GetCurrentConnectPriority() + ".";
            }
            else
            {
                info=DateTime.Now.ToLongTimeString() + Environment.NewLine +
                    "Проверка соединения с интернетом выполнена успешно!" + Environment.NewLine +
                    "Текущее подключение сеть Wifi: \"" + manageConnect.GetCurrentConnectName() + "\". Приоритет сети: " + manageConnect.GetCurrentConnectPriority()
                    + "." + Environment.NewLine + "Aдаптер: \"" + manageConnect.GetWifiAdapterName()
                    + "\". Приоритет: " + manageConnect.GetWifiAdapterPriority() + ".";
            }

            return info;
        }

        //
        //ОБРАБОТЧИКИ СОБЫТИЙ
        //

        //Событие попытка подключения к сетевому адаптеру
        void TryEnableAdapter(InfoConnect info)
        {
           
            string text = overalHead.GetTexBoxInfo();
            if (text != "") text += Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine;
            else text = DateTime.Now.ToLongTimeString() + Environment.NewLine;

            overalHead.SetTexBoxInfo(text +
                "Включаю сетевой адаптер: \"" + info.name + "\" c приоритетом: " + info.priority);

            //Пауза для чтения сообщения пользователем
            Thread.Sleep(pausaAfterOperation);
        }

        //Событие подключение к сетевому адапетру выполнено успешно
        void GoodTryEnableAdapter(InfoConnect info)
        {
            //Устанавливаем черный цвет для для TexBoxInfo
            overalHead.SetColorTexBoxInfo();

            string text = overalHead.GetTexBoxInfo();

            if (text != "") text += Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine;
            else text = DateTime.Now.ToLongTimeString() + Environment.NewLine;

            if (info.type != "Wifi")
            {
                overalHead.SetTexBoxInfo(text +
                 "Включение выполнено успешно! Ожидайте проверки соединения с интернетом.");
            }
            else
            {
                overalHead.SetTexBoxInfo(text +
                 "Включение выполнено успешно! Выполняю поиск сетей Wifi.");
            }
            //Пауза для чтения сообщения пользователем
            Thread.Sleep(pausaAfterOperation);
        }

        //Событие подключение к сетевому адаптеру выполнить не удалось
        void BadTryEnableAdapter(InfoConnect info)
        {
            //Устанавливаем красный цвет для для TexBoxInfo
            overalHead.SetColorTexBoxInfo(1);

            string text = overalHead.GetTexBoxInfo();

            if (text != "") text += Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine;
            else text = DateTime.Now.ToLongTimeString() + Environment.NewLine;

            overalHead.SetTexBoxInfo(text + 
               "Не удалось выполнить подключение к адаптеру: " + info.name + "." +Environment.NewLine + 
                "Выполняю подключение к следующему по приоритетности подключению.");

            //Пауза для чтения сообщения пользователем
            Thread.Sleep(pausaAfterOperation);
        }

        //Событие адаптер не обнаружен в системе
        void AdapterNotFound(InfoConnect info)
        {
            //Устанавливаем красный цвет для для TexBoxInfo
            overalHead.SetColorTexBoxInfo(1);

            string text = overalHead.GetTexBoxInfo();

            if (text != "") text += Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine;
            else text = DateTime.Now.ToLongTimeString() + Environment.NewLine;

          
                overalHead.SetTexBoxInfo(text+
                "Aдаптер: \"" + info.name + "\" с приоритетом: "+ info.priority +" не обнаржуен!" + Environment.NewLine+ 
                "Выполняю подключение к следующему по приоритетности подключению.");

            //Пауза для чтения сообщения пользователем
            Thread.Sleep(pausaAfterOperation);
        }

        //Событие попытка подключения к сети Wifi
        void TryConnectWifi(InfoConnect info)
        {
            
            string text = overalHead.GetTexBoxInfo();

            if (text != "") text += Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine;
            else text = DateTime.Now.ToLongTimeString() + Environment.NewLine;

            overalHead.SetTexBoxInfo(text +
                "Подключаюсь к сети Wifi: \"" + info.name + "\" c приоритетом: " + info.priority);

            //Пауза для чтения сообщения пользователем
            Thread.Sleep(pausaAfterOperation);
        }

        //Подключиться к сети Wifi не получилось
        void BadTryConnectWifi(InfoConnect info)
        {
            //Устанавливаем красный цвет для для TexBoxInfo
            overalHead.SetColorTexBoxInfo(1);

            string text = overalHead.GetTexBoxInfo();

            if (text != "") text += Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine;
            else text = DateTime.Now.ToLongTimeString() + Environment.NewLine;

            overalHead.SetTexBoxInfo(text + 
                "Не удалось выполнить подключение к сети Wifi: \"" + info.name +"\""+ Environment.NewLine+
                "Выполняю подключение к следующему по приоритетности подключению.");

            //Пауза для чтения сообщения пользователем
            Thread.Sleep(pausaAfterOperation);
        }

        //Подключение к сети Wifi выполнить не удалось, т.к. пароль неверен
        void BadPasswordWifi(InfoConnect info)
        {
            //Устанавливаем красный цвет для для TexBoxInfo
            overalHead.SetColorTexBoxInfo(1);

            string text = overalHead.GetTexBoxInfo();

            if (text != "") text += Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine;
            else text = DateTime.Now.ToLongTimeString() + Environment.NewLine;

            overalHead.SetTexBoxInfo(text +
                "Не удалось выполнить подключение к сети Wifi: \"" + info.name +
                "\" пароль, сохраненный в настройках, неверен!" + Environment.NewLine +
                "Выполняю подключение к следующему по приоритетности подключению.");

            //Пауза для чтения сообщения пользователем
            Thread.Sleep(pausaAfterOperation);
        }

        //Сеть Wifi не обнаружена
        void WifiNotFound(InfoConnect info)
        {
            //Устанавливаем красный цвет для для TexBoxInfo
            overalHead.SetColorTexBoxInfo(1);

            string text = overalHead.GetTexBoxInfo();

            if (text != "") text += Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine;
            else text = DateTime.Now.ToLongTimeString() + Environment.NewLine;

            overalHead.SetTexBoxInfo(text +
                "Сеть Wifi: \"" + info.name + "\" c приоритетом: " + info.priority +
                " не обнаружена!"+Environment.NewLine+
                "Выполняю подключение к следующему по приоритетности подключению.");

            //Пауза для чтения сообщения пользователем
            Thread.Sleep(pausaAfterOperation);
        }

        //Подключние к сети Wifi выполнено успешно
        void GoodTryConnectWifi(InfoConnect info)
        {
            //Устанавливаем черный цвет для для TexBoxInfo
            overalHead.SetColorTexBoxInfo();

            string text = overalHead.GetTexBoxInfo();

            if (text != "") text += Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine;
            else text = DateTime.Now.ToLongTimeString() + Environment.NewLine;

            overalHead.SetTexBoxInfo(text +
                "Подключение выполнено успешно! Ожидайте проверки соединения c интернетом.");

            //Пауза для чтения сообщения пользователем
            Thread.Sleep(pausaAfterOperation);
        }

        //Выполнена попытка подключения ко всем настроенным подключениям
        void AllConnectEnumerated(InfoConnect info)
        {
            //Устанавливаем красный цвет для для TexBoxInfo
            overalHead.SetColorTexBoxInfo(1);

            string text = overalHead.GetTexBoxInfo();

            if (text != "") text += Environment.NewLine + DateTime.Now.ToLongTimeString() + Environment.NewLine;
            else text = DateTime.Now.ToLongTimeString() + Environment.NewLine;

            overalHead.SetTexBoxInfo(text +
                "Выполнена попытка подключения ко всем настроенным подключениям. Не удалось подключиться ни к одному настроенному подключению! Возможная причина: настроенные сетевые адапетеры или сети Wifi не обнаружены!" + Environment.NewLine+ Environment.NewLine +
                "Ожидайте следующей попытки подключения через: " + (serviceSettings.GetIntervalCheckInternet()/1000).ToString() + " секунд.");
        }

        #endregion

        #region //ПОТОКИ

        //Задача для taskNetAdap
        void TaskNetAdap()
        {
            
            //Пауза перед запуском потока
            Thread.Sleep(1000);

            //получаем ссылку на поток
            _taskNetAdap = Thread.CurrentThread;

            while(true)
            {
                //Проверяет соедржимое LvNetAdap и при несоответствии информации полученной из manageNetAdap выполняет обновление
                CheckLvNetAdap();
                Thread.Sleep(IntervalUpdateNetAdap);
            }

        }

        //Задача для taskWifi
        void TaskWifi()
        {
            //Пауза перед начналом работы
            Thread.Sleep(1000);

            //Получаем ссылку на поток
            _taskWifi = Thread.CurrentThread;

            //Проверяет содержимое LvWifi и при несоответствии данных из manageWifi выполняет обновление LvWifi
            CheckLvWifi();
            Thread.Sleep(IntervalUpdateWifi);

            while (true)
            {
                //Если курсор мыши на PanWifi, то останавливаем поток на 10 секунд
                if (panWifiHead.MouseOnPanWifi())
                    Thread.Sleep(pauseUpdateWifi);

                //Проверяет содержимое LvWifi и при несоответствии данных из manageWifi выполняет обновление LvWifi
                CheckLvWifi();
                Thread.Sleep(IntervalUpdateWifi);

            }
        }

        //Задача для taskCheckConnect
        void TaskCheckConnect()
        {
            //Пауза перед началом работы потока
            Thread.Sleep(1000);
            
            //Очиащаем содержимое TexBoxInfo
            overalHead.SetTexBoxInfo(null);
            
            //получаем ссылку на поток
            _taskCheckConnect = Thread.CurrentThread;

            while (true)
            {
                //Выводим в TexBoxIntervalCheckInternet значение интервала между проверками соединения с интернетом
                SetTexBoxIntervalCheckInternet();

                //Перед проверкой соединения выключаем кнопку ButCheckInternet
                panCheckInternetHead.EnableButCheckInternet(false);

                //Выполняем проверку соединения с интернетом
                List<TestConnectInfo> lTest = manageConnect.CheckInternet();
                CheckInternetResult lastResult = manageConnect.GetLastCheckInternet();

                //Проверка выполнена успешно
                if(lastResult==CheckInternetResult.succes)
                {
                    //Устанавливаем черный цвет для для TexBoxInfo
                    overalHead.SetColorTexBoxInfo();
                   
                   //Добавляем в TexBoxInfo станадартную инфомрацию о работе в ручном режиме контроля соединения 
                   SetTexBoxInfoManualMode();

                   overalHead.SetTexBoxInfo(overalHead.GetTexBoxInfo() + Environment.NewLine + Environment.NewLine +
                        "Последняя провeрка соединения с интернетом в " + DateTime.Now.ToLongTimeString() + " выполнена успешно!", 1);
                }
                else
                //Соединение с интернетом отсутствует
                if(lastResult==CheckInternetResult.unsucces)
                {
                    //Устанавливаем красный цвет для для TexBoxInfo
                    overalHead.SetColorTexBoxInfo(1);

                    overalHead.SetTexBoxInfo("По результатам проверки в " + DateTime.Now.ToLongTimeString() +
                        " соединение с интернетом отсутствует!" + Environment.NewLine + Environment.NewLine+
                        "Выполните переключение на другой вариант подключения к интернету или включите автоматический режим контроля соединения!" + Environment.NewLine + Environment.NewLine +
                        GetCurrentConnectManualMode(), 1);
                }
                else
                //Выполнить проверку не удалось, т.к. адреса серверов для проверки соединения имеют некорректный формат
                if(lastResult==CheckInternetResult.failed)
                {
                    //Устанавливаем красный цвет для для TexBoxInfo
                    overalHead.SetColorTexBoxInfo(1);

                    overalHead.SetTexBoxInfo("Не удалось выполнить проверку соединения с интернетом в " + DateTime.Now.ToLongTimeString() + ", все адреса серверов для направления проверочных запросов имеют некорректный формат!" + Environment.NewLine + Environment.NewLine +
                    "Исправьте адреса или удалите все адреса в меню настроек и перезапустите приложение, произойдет востановление значений адресов по умолчанию!" + Environment.NewLine + Environment.NewLine +
                    GetCurrentConnectManualMode(), 1);
                }
                
                //Записываем результаты проверки соединения в ТеxBoxCheckInternet  
                WriteCheckInternetResult(lTest, lastResult);

                //После завершения проверки включаем кнопку ButCheckInternet
                panCheckInternetHead.EnableButCheckInternet(true);

                //Делаем паузу перед следующей проверкой
                Thread.Sleep(serviceSettings.GetIntervalCheckInternet());
            }
        }

        //Задача для TaskAutoManageConnect
        void TaskAutoManageConnect()
        {
            //Пауза перед началом работы потока
            Thread.Sleep(1000);

            //Очиащаем содержимое TexBoxInfo
            overalHead.SetTexBoxInfo(null);

            //Устанавливаем черный цвет для для TexBoxInfo
            overalHead.SetColorTexBoxInfo();

            //Получаем ссылку на поток
            _taskMangeConnect = Thread.CurrentThread;

            //Коллекция для хранения результатов проверки соединения с интернетом
            List<TestConnectInfo> lTest;

            //Переменная для хранения полседнего результата проверки соединения с интернетом
            CheckInternetResult result;

            //Флаг - наличия активного настроенного подключения
            bool isConnect = false;

             overalHead.SetTexBoxInfo(DateTime.Now.ToLongTimeString() + Environment.NewLine +
             "Выполняю переход в режим автоматического контроля соединения!");

            //Выводим в TexBoxIntervalCheckInternet значение интервала между проверками соединения с интернетом
            SetTexBoxIntervalCheckInternet();

                while (true)
                {
                    //Выполняем процедуру администрирования сетевых адаптеров, при первом проходе цикла: для деактивации подключений не имеющих рабочий приоритет,
                   // при последующих похода для проверки:что активно только одно подключение с рабочим приоритетом 
                    isConnect=manageConnect.StartAutoMode();
                    
                    //Выполняем проверку соединения с интернетом, если есть активное настроенное подключение
                    if (isConnect)
                    {
                        //Устанавливаем черный цвет для для TexBoxInfo
                        overalHead.SetColorTexBoxInfo();

                        overalHead.SetTexBoxInfo(DateTime.Now.ToLongTimeString() + Environment.NewLine +
                           "Выполняю проверку соединения с интернетом.");

                        //Выполняем проверку соединения
                        lTest = manageConnect.CheckInternet();
                        result = manageConnect.GetLastCheckInternet();

                        //Записываем результаты проверки соединения с интернетом в TexBoxCheckInternet
                        WriteCheckInternetResult(lTest, result);

                        //Проверка соединения выполнена успешно
                        if (result == CheckInternetResult.succes)
                        {
                            //Устанавливаем цвет текста черный
                            overalHead.SetColorTexBoxInfo();

                            overalHead.SetTexBoxInfo(overalHead.GetTexBoxInfo() + Environment.NewLine + GetCurrentConnectAutoMode());
                        }
                        else
                        //Соединение с интернетом отсутствует
                        if (result == CheckInternetResult.unsucces)
                        {
                            //Устанавливаем красный цвет для для TexBoxInfo
                            overalHead.SetColorTexBoxInfo(1);

                            overalHead.SetTexBoxInfo(overalHead.GetTexBoxInfo() + Environment.NewLine +
                                DateTime.Now.ToLongTimeString() + Environment.NewLine +
                                "Cоединение с интернетом отсутствует!" + Environment.NewLine +
                                "Выполняю переключение на следующее по приоритетности подключение!", 1);

                            //Пауза, чтобы пользователь успел прочитать сообщение
                            Thread.Sleep(pausaAfterOperation);

                            //Пробуем выполнить переключение на альтернативное соединение с интернетом в соответствии с настройками приоритетности
                            isConnect = manageConnect.GetNextConnect();
                        }
                        else
                        //Выполнить проверку не удалось, т.к. адреса серверов для проверки соединения имеют некорректный формат
                        if (result == CheckInternetResult.failed)
                        {
                            //Устанавливаем красный цвет для для TexBoxInfo
                            overalHead.SetColorTexBoxInfo(1);

                            overalHead.SetTexBoxInfo(overalHead.GetTexBoxInfo() + Environment.NewLine +
                                DateTime.Now.ToLongTimeString() + Environment.NewLine +
                                "Выполнить проверку соединения с интернетом не удалось, т.к. все адреса имеют некорректный формат!");
                        }

                    }

                    //Делаем паузу перед следующей проверкой соединения с интерентом в автоматическом режиме контроля соединения
                    Thread.Sleep(serviceSettings.GetIntervalCheckInternet());

                    //Очиащаем содержимое TexBoxInfo
                    overalHead.SetTexBoxInfo(null);
                }      
        }

        //Остановка потоков
        void StopTasks()
        {
            

            if (_taskNetAdap!=null)  
            _taskNetAdap.Abort();

            if(_taskWifi!= null)
            _taskWifi.Abort();

            //Если работает поток автоматического контроля соединения, то останавливаем его
            if (_taskMangeConnect != null)
                _taskMangeConnect.Abort();
           
            //Если работает поток проверки соединения в обычном режиме, то останавливаем его
            if (_taskCheckConnect != null)
                _taskCheckConnect.Abort();  
        }

        #endregion

        //Конструктор
        public Presenter(IHeadForm Head, IService Service)
        {

            //
            //ИНИЦИАЛИЗАЦИЯ ИНТЕРФЕЙСОВ
            //

            //Общий интерфейс упрвления HeadForm
            overalHead = Head;

            //Интерфейс управления panNetAdap формы HEAD
            panNetAdapHead = Head;

            //Интерфейс управления panWifi формы HEAD
            panWifiHead = Head;

            //Интерфейс управления областью проверки соединения формы HEAD
            panCheckInternetHead = Head;

            //Интерфейс управления настройками
            serviceSettings = Service;

            //Интерфейс упрвления сетевыми адаптерами
            manageNetAdap = Service;

            //Интерфейс управления сетями Wifi
            manageWifi = Service;

            //Интерфейс управления проверкой соединения с интернетом
            manageConnect = Service;
                    
            //
            //ПОДПИСЬ НА СОБЫТИЯ Overal ФОРМЫ HEAD
            //

            //Закрытие формы Head
            overalHead.HeadFormClosing += StopTasks;

            //Открытие формы Settings
            overalHead.formSettingsShow += LoadFormSettings;

            //Изменнеие пользователем значения CheckBoxAutoMode
            overalHead.CheckBoxAutoModeCheckedChanged += startStopAutoMode;

            //
            //ПОДПИСЬ НА СОБЫТИЯ PanLvNetAdap ФОРМЫ HEAD, ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ 
            //

            //Выбора пользователем сетевого адаптера в LvNetAdap
            panNetAdapHead.LvNetAdapSelectedIndexChange += manageButOnPanLvNetAdap;

            //Нажатие кнопки включения сетевого адапетра
            panNetAdapHead.ButOnNetAdapClick += OnNetAdap;

            //Нажатие кнопки выключения сетевого адаптера
            panNetAdapHead.ButOffNetAdapClick += OffNetAdap;

            //Инициализация периода обновления информации о сетевых адаптерах в мс.
            IntervalUpdateNetAdap = 1000;

            //
            //ПОДПИСЬ НА СОБЫТИЯ PanWifi ФОРМЫ HEAD, ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
            //

            //Подпись на событие выбора пользоателем сети Wifi
            panWifiHead.LvWifiSelectedIndexChange += manageBlockWifiOnOff;

            //Нажатие кнопки ButOnWifi
            panWifiHead.ButOnWifiClick += WifiOn;
            
            //Нажатие кнопки ButOffWifi
            panWifiHead.ButOffWifiClick += WifiOff;

            //Инициализация периода остановки потока обновления информации о сетях Wifi, если пользователь навел курсор мыши на PanWifiHead в мс.
            pauseUpdateWifi = 10000;

            //Инициализация период обновления информации о сетях Wifi в мс.
            IntervalUpdateWifi = 1000;

            //
            //ПОДПИСЬ НА СОБЫТИЯ ОБЛАСТИ ПРОВЕРКИ СОЕДИНЕНИЯ ФОРМЫ HEAD, ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ 
            //

            //Нажатие кнопки ButCheckInternet
            panCheckInternetHead.ButCheckInternetClick += CheckInternet;

            //Инициализация очереди для хранения результатов проверки соединения
            qCheckInterntResult = new Queue<string>();

            //Инициализация максимального количества результатов, выводимых в TexBoxCheckInternet
            maxCheckInternetResult = 50;

            //
            //ПОДПИСЬ НА СОБЫТИЯ manageConnect, ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ 
            //

            //Попытка влкючения сетевого адаптера
            manageConnect.TryEnableAdapter += TryEnableAdapter;

            //Подключение к адаптеру завершилось успешно
            manageConnect.GoodTryEnableAdapter += GoodTryEnableAdapter;

            //Подключение к сетевому адаптеру выполнить не удалось
            manageConnect.BadTryEnableAdapter += BadTryEnableAdapter;

            //Адапетр в системе не обнаружен
            manageConnect.AdapterNotFound += AdapterNotFound;

            //Попытка подключения к сети Wifi
            manageConnect.TryConnectWifi += TryConnectWifi;

            //Подключение к сети Wifi выполнить не удалось
            manageConnect.BadTryConnectWifi += BadTryConnectWifi;

            //Подключение к сети Wifi выполнить не удалось, т.к. пароль неверен
            manageConnect.BadPasswordWifi += BadPasswordWifi;

            //Сеть Wifi не обнаружена
            manageConnect.WifiNotfound += WifiNotFound;

            //Подключние к сети Wifi выполнено успешно
            manageConnect.GoodTryConnectWifi += GoodTryConnectWifi;

            //Выполнена попытка подключения ко всем настроенным подключениям
            manageConnect.AllConnecEnumerated += AllConnectEnumerated;

            //Инициалиазция паузы после выполнения операций (включения, выключения сетевых адаптеров и т.д.) в режиме автоматического контроля соединения
            pausaAfterOperation = 3000;

            //
            //ПОТОКИ
            //

            //Инициалиазция ссылок на потоки null
            _taskNetAdap = null;
            _taskWifi = null;
            _taskCheckConnect = null;
            _taskMangeConnect = null;
         
            //Запуск потока мониторинга сетевых адаптерах
            taskNetAdap = Task.Factory.StartNew(TaskNetAdap);

            //Запуск потока мониторинга сетей Wifi
            taskWifi = Task.Factory.StartNew(TaskWifi);

            //Если значение autoModeStart true запускаем контроль соединения в автоматическом режиме при запуске приложения
            if (serviceSettings.GetAutoModeStart())
            {
                //Вызовет событие, которое приведет к запуску потока контроля соединения в автоматическом режиме
                overalHead.SetCheckBoxAutoMode(true);
            } 
            //Иначе запускаем поток проверки соединения в ручном режиме
            else  
            taskCheckConnect = Task.Factory.StartNew(TaskCheckConnect);

        }


    }
}
