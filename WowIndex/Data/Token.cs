using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WowIndex.Data
{
    public class Token
    {
        public int Id { get; set; }

        public string token { get; set; }

        public int RequestsThisHour { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
