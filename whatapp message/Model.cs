using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatapp_message
{
    public class Model
    {

        public class Language
        {
            public string code { get; set; }
        }

        public class ComponentParameter
        {
            public string type { get; set; }
            public string text { get; set; }
        }

        public class Component
        {
            public string type { get; set; }
            public ComponentParameter[] parameters { get; set; }
        }

        public class Template
        {
            public string name { get; set; }
            public Language language { get; set; }
            public Component[] components { get; set; }
        }

        public class MessageRequest
        {
            public string messaging_product { get; set; }
            public string to { get; set; }
            public string type { get; set; }
            public Template template { get; set; }
        }
    }
}
