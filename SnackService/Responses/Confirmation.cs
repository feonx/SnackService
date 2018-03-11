using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackService.Responses
{
    public enum StatusEnum
    {
        Error               = 0,
        RecordExists        = 1,
        RecordNotFound      = 2,
        RecordCreated       = 3
    }

    public class Confirmation
    {
        public StatusEnum Status { get; set; }
    }
}
