using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OnlineMathTest.Common
{
    public static class EnumSettings
    {
        public static int DefaultPageSize = 0;
        public static int DefaultPageLength = 10;
    }

    public enum Role
    {
        [Description("Admin")]
        ADMIN = 1,
        [Description("User")]
        USER = 2
    }
}
