namespace GameApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool ModeLoop = false;
            GameFacade NormalMode_game = new GameFacade();
            GameFacade DeveloperMode_game = new GameFacade();

            while (!ModeLoop)
            {
                Console.WriteLine("Enter 1. developer mode or 2. normalmode:");
                int Mode = Convert.ToInt32(Console.ReadLine());
                if (Mode > 2)
                {
                    continue;
                }

                Console.WriteLine("Enter 1. online or 2. offline:");
                int OnlineOffline = Convert.ToInt32(Console.ReadLine());
                if (OnlineOffline > 2)
                {
                    continue;
                }
                bool online = OnlineOffline == 1;

                Console.WriteLine("Enter 1. start or 2. stop:");
                int StartStop = Convert.ToInt32(Console.ReadLine());
                if (StartStop > 2)
                {
                    continue;
                }

                if (Mode == 1 && StartStop == 1)
                {
                    Console.WriteLine("developermode start");
                    DeveloperMode_game.StartGame(online);
                }
                else if (Mode == 1 && StartStop == 2)
                {
                    Console.WriteLine("developermode stop");
                    DeveloperMode_game.StopGame(online);
                }
                else if (Mode == 2 && StartStop == 1)
                {
                    Console.WriteLine("normalmode start");
                    NormalMode_game.StartGame(online);
                }
                else if (Mode == 2 && StartStop == 2)
                {
                    Console.WriteLine("normalmode stop");
                    NormalMode_game.StopGame(online);
                }
            }
        }
    }
}
