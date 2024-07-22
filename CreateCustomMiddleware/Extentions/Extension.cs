using CreateCustomMiddleware.Middlewares;

namespace CreateCustomMiddleware.Extentions
{
	public static class Extension
	{
		public static IApplicationBuilder UseHello(this IApplicationBuilder applicationBuilder)
		{
			return applicationBuilder.UseMiddleware<HelloMiddleware>();
		}
	}
}
