
namespace Pinger
{
    //Для проброса событий
    public delegate void PingerEvent();
    public delegate void PingerEventSettingsShow(SettingsForm form);
    public delegate void PingerEventAddWifiShow(AddWifiForm form);

    //Для перевызова методов из потока формы
    delegate void Del();
    delegate void DelBool(bool enbled);
    delegate string [] DelReturnStringArray();
    delegate void DelStringArray(string [] array);
    delegate void DelString(string str);
    delegate void DelStringInt(string str, int number);
    delegate void DelBoolString(bool enabled, string str);
    delegate void DelInt(int number);
    delegate bool DelReturnBool();
    delegate string DelReturnString();


}
