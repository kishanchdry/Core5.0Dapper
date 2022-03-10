using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Identity
{
    public class SignInResult
    {
        public bool Succeeded { get; set; }
        public List<string> Errors { get; }
        public string Message { get; }
    }
}
