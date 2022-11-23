using System.ComponentModel;

namespace BotApplication.Bot.Code
{
    public class Pagination
    {
        public static Pagination All = new Pagination(int.MaxValue, 1);
    
        public Pagination(int pageSize = 20, int pageNumber = 1)
        {
            this.PageSize = pageSize;
            this.PageNumber = pageNumber;
        }
    
        [DefaultValue(1)] public int PageNumber { get; set; } = 1;

        [DefaultValue(20)] public int PageSize { get; set; } = 20;
    
        public int GetSkip() => (PageNumber - 1) * PageSize;
    }
 
}