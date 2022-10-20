namespace LojaWebApp.MVC.Models;

public class ResponseResult
{
    public string Title { get; set; }
    public int Status { get; set; }
    public ResponseExtensions Errors { get; set; }
}

public class ResponseExtensions
{
    public List<string> Mensagens { get; set; }
}