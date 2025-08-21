using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveManagementAppDatabase.Models
{
    public class Response<T>
    {
        public T? ValueOrDefault { get; set; }
        public T? Value { get; set; }
        public bool IsFailed { get; set; }
        public bool IsSuccess { get; set; }
        public List<string>? Reasons { get; set; }
        public List<string>? Errors { get; set; }
        public List<string>? Successes { get; set; }
    }
}
