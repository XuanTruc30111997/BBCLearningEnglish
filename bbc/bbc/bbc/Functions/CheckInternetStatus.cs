using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;

namespace bbc.Functions
{
    public class CheckInternetStatus
    {
        public static bool CheckInternet()
        {
            //if (!CrossConnectivity.Current.IsConnected) 
            //{
            //    return false; // Chưa kết nối
            //}
            //return true; // Đã kết nối

            return CrossConnectivity.Current.IsConnected;
        }
    }
}
