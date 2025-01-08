using System;
using System.Net;
using System.Net.Sockets;
using Platform.Network.Time;
using NodaTime;
using Microsoft.Recognizers.Text.DataTypes.TimexExpression;
namespace ntp1Exercice {

    internal class Programm
    {
        static void Main(string[] args)
        {
            string ntpServer = "0.ch.pool.ntp.org";
            byte[] ntpData = new byte[48];
            ntpData[0] = 0x1B; //LI = 0 (no warning), VN = 3 (IPv4 only), Mode = 3 (Client Mode)

            IPEndPoint ntpEndpoint = (new IPEndPoint(Dns.GetHostAddresses(ntpServer)[0], 123));
            UdpClient ntpClient = new UdpClient();

            ntpClient.Connect(ntpEndpoint);
            ntpClient.Send(ntpData, ntpData.Length);
            ntpData = ntpClient.Receive(ref ntpEndpoint);
            DateTime ntpTime = NtpPacket.ToDateTime(ntpData);

            TimeSpan timeDiff = DateTime.Now - ntpTime;
            Console.WriteLine("Différence de temps : " + timeDiff.TotalSeconds + " secondes");

            DateTime timeCalculate = ntpTime.Add(timeDiff);
            DateTime UTCtime = timeCalculate.ToUniversalTime();
            DateTime localTime = UTCtime.ToLocalTime();
            Console.WriteLine("Heure actuelle : " + UTCtime);

            DateTime gmtTime = localTime.ToUniversalTime().AddHours(-1); // Suisse en GMT+1 Console.WriteLine("Heure GMT : " + gmtTime.ToString());
            localTime = gmtTime.AddHours(1); // Ajustez l'ajustement horaire en fonction de votre fuseau horaire
            Console.WriteLine("Heure locale (à partir de l'heure GMT) : " + localTime.ToString());
            ntpClient.Close();
        }
        /*public static DateTime ToDateTime(byte[] ntpData)
        {
            ulong intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | (ulong)ntpData[43];
            ulong fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | (ulong)ntpData[47];

            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            var networkDateTime = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds);
            return networkDateTime;
        }*/
    }


}