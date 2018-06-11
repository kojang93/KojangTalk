using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace KojangTalk
{

    //왜 분리 시켰는가???
    //안분리 시키면 어덯게 되는가 ?
    public interface IHavePassword
    {

        SecureString SecurePassword { get; }
    }
}
