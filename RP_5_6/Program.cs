using Autofac;
using Autofac.Features.AttributeFilters;
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

        enum Filter
        {
            filter1,
            filter2
        }
        class MusicPlayer
        {
            ILogger _logger;
            IMusic _music;
            public MusicPlayer(
                [KeyFilter(Filter.filter1)] ILogger logger, 
                [KeyFilter("Classical")]IMusic music)
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
            ///

            Console.WriteLine("Microsoft DI");

            ServiceCollection serviceCollection = new();
            serviceCollection.AddSingleton<ILogger, ConsoleLogger>();
            serviceCollection.AddSingleton<IMusic, ClassicalMusic>();
            serviceCollection.AddSingleton<MusicPlayer>();

            //serviceCollection.AddKeyedSingleton<MusicPlayer>(Enum.Value);

            ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetRequiredService<MusicPlayer>().PlayMusic();

            ///////////////
            ///
            Console.WriteLine("\nAutofac");


			var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLogger>().As<ILogger>().Keyed<ILogger>(Filter.filter1);
            builder.RegisterType<ClassicalMusic>().As<IMusic>().Named<IMusic>("Classical");
            builder.RegisterType<MusicPlayer>().WithAttributeFiltering();

            IContainer container = builder.Build();

            container.Resolve<MusicPlayer>().PlayMusic();

            Console.WriteLine(typeof(Program).Assembly);
		}

	}
}