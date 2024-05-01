namespace Application.Common.Statics;

public static class RegularExpressions
{
    public const string Characters = "^[^\"'!@#%\\^&\\*()_\\-\\+=~`\\[\\]\\{\\}\\|;:<>\\?\\/,\\\\]{1,}$";
    public const string Address = "^[^\"'!@#%\\^&\\*()_\\-\\+=~`\\[\\]\\{\\}\\|;:<>\\?\\/,\\\\]{1,}$";
    public const string Number = "^[0-9]{1,}$";
    public const string Serial = "^[0-9]{18}$";
    public const string DeviceModelSerial = "^[0-9]{8}$";
    public const string Mac = "^(?:[0-9a-fA-F]{2}:){5}[0-9a-fA-F]{2}|(?:[0-9a-fA-F]{2}-){5}[0-9a-fA-F]{2}|(?:[0-9a-fA-F]{2}){5}[0-9a-fA-F]{2}$";
    public const string Guuid = "^((?!00000000-0000-0000-0000-000000000000).)*$";



}
