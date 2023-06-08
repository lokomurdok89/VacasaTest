namespace API.Extension
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
                                                                IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
           /*services.AddDbContext<DataContext>(opt => {
                            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
                        }); 
                        configurar despues si se ocupa entity*/
            services.AddCors(opt=>{
                opt.AddPolicy("CorsPolicy",policy=>{
                    policy.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();//.WithOrigins("http://localhost:3000");
                });
            });

            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(options => options.CustomSchemaIds(type => type.ToString()));

            services.AddOptions();
            return services;
        }
    }
}