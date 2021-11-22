using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class Pager
    {
        public int TotalItens { get; private set; }
        public int CurrentPage { get; private set; }
        public int TotalPage { get; private set; }
        public int PageSize { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public string ActionName { get; private set; }
        public string ControllerName { get; private set; }

        public Pager()
        {

        }

        public Pager(int totalItens, int page, string controller, string actionName, int pageSize = 10)
        {
            int totalPage = (int)Math.Ceiling((decimal)totalItens / (decimal)pageSize);
            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;

            if (startPage <= 0)
            {
                endPage -= (startPage - 1);
                startPage = 1;
            }

            if (endPage > totalPage)
            {
                endPage = totalPage;

                if (endPage > 10)
                    startPage = endPage - 9;
            }

            TotalItens = totalItens;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalPage = totalPage;
            StartPage = startPage;
            EndPage = endPage;
            ControllerName = controller;
            ActionName = actionName;
        }
    }
}
