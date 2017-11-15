using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goudiw.sdk.entity
{
    public class ResponseStatus
    {
        private String code;

        public String Code
        {
            get { return code; }
            set { code = value; }
        }
        private String message;

        public String Message
        {
            get { return message; }
            set { message = value; }
        }


    }
}
