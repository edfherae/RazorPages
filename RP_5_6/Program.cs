using Microsoft.Extensions.DependencyInjection;

namespace RazorPages
{
    internal class Program
    {
        public interface ILogger
        {
            void Log(string message);
        }
        public interface IMusic
        {
            string GetGenre();
        }
        class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine(message);
            }
        }
        class ClassicalMusic : IMusic
        {
            private string genre = "classical";
            public string GetGenre()
            {
                return genre;
            }
        }
        class MusicPlayer
        {
            ILogger _logger;
            IMusic _music;
            public MusicPlayer(ILogger logger, IMusic music)
            {
                _logger = logger;
                _music = music;
            }
            public void PlayMusic()
            {
                _logger.Log($"Playing {_music.GetGenre()} music...");
            }
        }
        static void Main(string[] args)
        {
            //new MusicPlayer(new ConsoleLogger(), new ClassicalMusic()).PlayMusic();

            ///////////////

            ServiceCollection serviceCollection = new();
            serviceCollection.AddSingleton<ILogger, ConsoleLogger>();
            serviceCollection.AddSingleton<IMusic, ClassicalMusic>();
            serviceCollection.AddSingleton<MusicPlayer>();

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetRequiredService<MusicPlayer>().PlayMusic();
        }

    }
}