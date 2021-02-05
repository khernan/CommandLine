using CommandLine.helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CommandLineTest
{
    [TestClass]
    public class CommandsTest
    {
        [TestMethod]
        public void TouchFileTest()
        {
            Command command = new Command();           
            try
            {
                command.TouchFile("Test.txt");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }            
        }

        [TestMethod]
        public void ChangeFileTest()
        {
            Command command = new Command();
            try
            {
                command.ChangeFile("mv test.txt test1.txt");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void MoveFileTest()
        {
            Command command = new Command();
            try
            {
                command.ChangeFile("mv c:/test.txt c:/test/test.txt");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ListFilesTest()
        {
            Command command = new Command();
            try
            {
                command.ListFiles();
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ListFilesRecursiveTest()
        {
            Command command = new Command();
            try
            {
                command.ListFilesRecursive();
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ChangeDirectoryTest()
        {
            Command command = new Command();
            try
            {
                command.ChangeDirectory("C:/");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void helpCommandTest()
        {
            Command command = new Command();
            try
            {
                command.HelpCommand("help ls");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
