﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALMRestClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ALMClientTests.Tests
{

	[TestClass()]
	public class ALMClientTests
	{
		private static string ALMAddress = global::ALMClientTests.Properties.Settings.Default.ALMAddress;
		private static string UserName = global::ALMClientTests.Properties.Settings.Default.ALMUserName;
		private static string Password = global::ALMClientTests.Properties.Settings.Default.ALMPassword;
        private static string Domain = global::ALMClientTests.Properties.Settings.Default.Domain;
        private static string Project = global::ALMClientTests.Properties.Settings.Default.Project;

        private ALMRestClient.ALMClient wrapper;

		[ClassInitialize]
		public static void Setup(TestContext context)
		{
			
		}
		
		[TestInitialize]
		public void TestSetup()
		{
			wrapper = new ALMRestClient.ALMClient(ALMAddress, UserName, Password, Domain, Project);
			wrapper.HideCustomExceptions = true;
		}

		[TestCleanup]
		public void TestCleanup()
		{
			if (wrapper != null)
			{
				wrapper.Dispose();
			}

		}

		[TestMethod()]
		public void LoginTest()
		{
			Assert.IsTrue(wrapper.Login());
		}

		[TestMethod()]
		public void LogoutTest()
		{
			Assert.IsTrue(wrapper.Login());
			Assert.IsTrue(wrapper.Logout());
		}

		[TestMethod]
		public void IsAuthenticatedTest_False()
		{
			Assert.IsFalse(wrapper.IsAuthenticated());
		}

		[TestMethod]
		public void IsAuthenticatedTest_True()
		{
			Assert.IsTrue(wrapper.Login());
			Assert.IsTrue(wrapper.IsAuthenticated());
		}

		[TestMethod()]
		public void GetDefectsTest()
		{
			Assert.IsTrue(wrapper.Login());

			List<ALMRestClient.ALMItem> items = wrapper.GetDefects();

			Assert.IsNotNull(items);
		}

        [TestMethod()]
	    public void GetDefectTest()
	    {
	        Assert.IsTrue(wrapper.Login());

	        ALMRestClient.ALMItem item = wrapper.GetDefect("3740");

	        Assert.IsNotNull(item);
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            Assert.IsNotNull(wrapper.GetUsers());

            //List<ALMRestClient.ALMItem> items = wrapper.GetDefects();

            Assert.IsNotNull(null);
        }
    }
}
