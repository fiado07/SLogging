using NUnit.Framework;
using System;

namespace SLogging.NTest
{
    [TestFixture]
    public class TestSLog
    {


        Log log;
        Person person;

        public TestSLog()
        {

            log = Log.GetLog(new SqlServerContext().SqlContext, @"c:\dir\");
            person = new Person { Name = "Name", Age = 2 };

        }



        [Test]
        public void Log_info_Object()
        {

            
            log.Info(person, "x120801", "inf", Common.LogAppender.all);
            
            Assert.IsTrue(true);


        }


        [Test]
        public void Log_debug()
        {


            log.Debug("x120801", "debug", new Exception("error"), Common.LogAppender.all);
            
            Assert.IsTrue(true);

        }

        [Test]
        public void Log_debug_object()
        {


            log.Debug(person , "x120801", "debug", new Exception("error"), Common.LogAppender.all);
            
            Assert.IsTrue(true);


        }


        [Test]
        public void Log_Error()
        {


            log.Error("x120801", "info", new Exception("error"), Common.LogAppender.all);
            
            Assert.IsTrue(true);


        }

        [Test]
        public void Log_Error_Object()
        {

         
            log.Error(person, "x120801", "info", new Exception("error"), Common.LogAppender.all);
            
            Assert.IsTrue(true);


        }
    }
}
