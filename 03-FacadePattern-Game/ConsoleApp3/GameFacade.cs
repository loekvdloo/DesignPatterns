namespace GameApp
{
    // Facade: één simpele klasse die alle subsystemen voor de client regelt
    public class GameFacade
    {
        private GraphicsSystem graphics = new GraphicsSystem();
        private AudioSystem audio = new AudioSystem();
        private SaveSystem saveSystem = new SaveSystem();
        private NetworkService network = new NetworkService();
        private GameEngine gameEngine = new GameEngine();

        public void StartGame(bool online)
        {
            graphics.Initialize();
            graphics.SetResolution(1920, 1080);

            audio.Initialize();
            audio.SetVolume(70);

            saveSystem.LoadSettings();
            saveSystem.LoadPlayer();

            if (online)
            {
                network.Connect();
                network.Login();
            }

            gameEngine.LoadWorld();
            gameEngine.Start();
        }

        public void StopGame(bool online)
        {
            gameEngine.Stop();
            gameEngine.UnloadWorld();

            if (online)
            {
                network.Logout();
                network.Disconnect();
            }

            saveSystem.SavePlayer();
            saveSystem.SaveSettings();

            audio.Shutdown();
            graphics.Shutdown();
        }
    }
}
