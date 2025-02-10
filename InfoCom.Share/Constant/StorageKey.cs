namespace InfoCom.Share.Constant
{
    public static class StorageKeyConstant
    {
        public const string StorageKeyName = "Session";

        public const string ActivationKeyName = "Activation";

        public const string ActivationCodeExpireKeyName = "ActivationCodeExpire";

        public const string MenusName = "Menus List";
    }

    public enum ServiceResponseTypes : short
    {
        SUCCESS,
        BADPARAMETERS,
        ERROR,
        TIMEOUT,
        UNKNOWN,
        UNAUTHORIZED,
        THIRDPARTYERROR,
        BADREQUEST,
        NOTFOUND
    }
}
