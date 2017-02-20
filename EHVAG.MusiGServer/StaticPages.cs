using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHVAG.MusiGServer
{
    public static class StaticPages
    {
        public static string InternalServerError { get { return @"\InternalServerError.html"; } }
        public static string BadRequest { get { return @"\BadRequest.html"; } }
        public static string AlreadyAuthenticated { get { return @"\ChannelAlreadyAuthenticated.html"; } }
    }
}
