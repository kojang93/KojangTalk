using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace KojangTalk
{

    // 보안문자를 위한 헬퍼 클래스 
    public static class SecureStringHelpers //보안문자에 대한 확장 메서들를 정의하는 클래스 
    {


        public static string Unsecure(this SecureString secureString)
        {
            if (secureString == null)
                return string.Empty;

            var unmanagedString = IntPtr.Zero;

            try
            {

                //패스워드를 복호화 한다. 
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);

                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                //메모리할당 초기화 
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);

            }
        }
    }
}
