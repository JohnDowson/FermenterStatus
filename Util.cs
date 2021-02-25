namespace FermenterStatus
{
    static class Util
    {
        public static void DBG(string str = "")
        {
            UnityEngine.Debug.Log((typeof(FermenterStatus).Namespace + " ") + str);
        }
    }
}
