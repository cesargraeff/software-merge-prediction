namespace Application;

    public class Program {
        public IConfiguration Configuration { get; }
        public Program(IConfiguration configuration)
            => Configuration = configuration;

            public static void Main(string[] args)
                => CreateHostBuilder(args).Build().Run();

                public static IHostBuilder CreateHostBuilder(string[] args)
                    => Host.CreateDefaultBuilder(args)
                        .ConfigureWebHostDefaults(webBuilder =>
                            webBuilder.UseStartup<Startup>()
                        ).ConfigureLogging(logging => {
                            logging.ClearProviders();
                            logging.AddConsole();
                        });     
    }