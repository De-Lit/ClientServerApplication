using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ServerWPF
{
    class Server
    {
        TcpListener Listener; // Объект, принимающий TCP-клиентов

        // Запуск сервера
        public Server(int Port)
        {
            // Создаем "слушателя" для указанного порта


            Listener = new TcpListener(IPAddress.Any, Port);
            Listener.Start(); // Запускаем его
            Method();

            // В бесконечном цикле
            async void Method()
            {
                await Task.Run(() =>
                {
                    while (true)
                    {
                        // Принимаем новых клиентов и передаем их на обработку новому экземпляру класса Client
                        new Client(Listener.AcceptTcpClient());
                    }
                });
            }
        }

        // Остановка сервера
        ~Server()
        {
            // Если "слушатель" был создан
            if (Listener != null)
            {
                // Остановим его
                Listener.Stop();
            }
        }
    }    
}
