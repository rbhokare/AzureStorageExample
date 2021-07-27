using System;

namespace Common
{
    public static class Connections
    {
        static Connections()
        {

        }

        public static string DatabaseConnection { get; set; }
        public static string AzzureStorageConnection { get; set; }
    }
}
