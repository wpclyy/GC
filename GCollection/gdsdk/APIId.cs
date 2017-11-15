using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace com.goudiw
{
    public class APIId
    {
        private String namespaceValue;

        public String NamespaceValue
        {
            get { return namespaceValue; }
            set { namespaceValue = value; }
        }
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        private int version;

        public int Version
        {
            get { return version; }
            set { version = value; }
        }

        private String strtypename;

        public String Strtypename
        {
            get { return strtypename; }
            set { strtypename = value; }
        }

        private String strtypevalue;

        public String Strtypevalue
        {
            get { return strtypevalue; }
            set { strtypevalue = value; }
        }

        private String filedname;

        public String Filedname
        {
            get { return filedname; }
            set { filedname = value; }
        }
        private String filedvalue;

        public String Filedvalue
        {
            get { return filedvalue; }
            set { filedvalue = value; }
        }
    }
}
