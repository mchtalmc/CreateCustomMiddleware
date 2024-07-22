namespace CreateCustomMiddleware.Middlewares
{
	public class HelloMiddleware
	{
        RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next)
        {
            _next=next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            //Custom Operation.
            Console.WriteLine("Hi");
            await _next.Invoke(httpContext);  // Invoke Ile bir sonra ki middleware'ye gecmezsem Shot Circut (Kisa devre) yaparim
                                                    //Bunun neticesi hataya kadar gidebilir.
            Console.WriteLine("By Dude");
        }
    }
}
