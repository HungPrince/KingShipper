using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KingShipper.Models
{
    public class ResponseModel<T>
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<T> DataList { get; set; }
        public T Data { get; set; }
        public int TotalPage { get; set; }

        public ResponseModel() { }

        public ResponseModel(string status, string message, List<T> dataList, T data, int totalPage)
        {
            this.Status = status;
            this.Message = message;
            this.DataList = dataList;
            this.Data = data;
            this.TotalPage = totalPage;
        }

    }
}