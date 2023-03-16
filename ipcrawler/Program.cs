using System.Net.NetworkInformation;

Console.Write("Hvilke IP-adresser vil du søke etter? "); // f.eks. "192.168.10";
string ipformat = Console.ReadLine();
int start = 1;
int slutt = 255;

List<string> ipliste = new List<string>();

for (int i = start; i <= slutt; i++)
{
    for (int j = start; j <= slutt; j++)
    {
        string ip = ipformat + "." + j;
        try
        {
            using (Ping ping = new Ping())
            {
                PingReply reply = ping.Send(ip);
                Console.WriteLine("Prøver: " + ip);
                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Funnet: " + ip);
                    ipliste.Add(ip);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Feil ved ping til " + ip + ": " + ex.Message);
        }
    }
}

Console.ReadKey();
