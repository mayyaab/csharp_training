using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AuthTestBase : TestBase
    {
        //перед выполнением каждого тестового метода которому требуется авторизованная сессия
        //должен выолнится логин под именем пользователя админ, но если залогинены см. LoginHelper.IsLoggedIn
        [SetUp]
        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
