﻿using GPG4OutlookLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using GPG4OutlookLib.Tools;

namespace GPG4OutlookTest
{


    /// <summary>
    ///Dies ist eine Testklasse für "GPG4OutlookToolboxTest" und soll
    ///alle GPG4OutlookToolboxTest Komponententests enthalten.
    ///</summary>
    [TestClass()]
    public class GPG4OutlookToolboxTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Ruft den Testkontext auf, der Informationen
        ///über und Funktionalität für den aktuellen Testlauf bietet, oder legt diesen fest.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Zusätzliche Testattribute
        // 
        //Sie können beim Verfassen Ihrer Tests die folgenden zusätzlichen Attribute verwenden:
        //
        //Mit ClassInitialize führen Sie Code aus, bevor Sie den ersten Test in der Klasse ausführen.
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Mit ClassCleanup führen Sie Code aus, nachdem alle Tests in einer Klasse ausgeführt wurden.
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Mit TestInitialize können Sie vor jedem einzelnen Test Code ausführen.
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Mit TestCleanup können Sie nach jedem einzelnen Test Code ausführen.
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Ein Test für "checkMailAddressesInString"
        ///</summary>
        [DeploymentItem("GPG4Outlook.dll"), TestMethod()]
        public void checkMailAddressesInStringTest()
        {
            Dictionary<String, Boolean> testAddresses = new Dictionary<String, Boolean>();
            testAddresses.Add(@"NotAnEmail", false);
            testAddresses.Add(@"@NotAnEmail", false);
            testAddresses.Add(@"""test\\blah""@example.com", true);
            testAddresses.Add(@"""test\blah""@example.com", false);
            testAddresses.Add("\"test\\\rblah\"@example.com", true);
            testAddresses.Add("\"test\rblah\"@example.com", false);
            testAddresses.Add(@"""test\""blah""@example.com", true);
            testAddresses.Add(@"""test""blah""@example.com", false);
            testAddresses.Add(@"customer/department@example.com", true);
            testAddresses.Add(@"$A12345@example.com", true);
            testAddresses.Add(@"!def!xyz%abc@example.com", true);
            testAddresses.Add(@"_Yosemite.Sam@example.com", true);
            testAddresses.Add(@"~@example.com", true);
            testAddresses.Add(@".wooly@example.com", false);
            testAddresses.Add(@"wo..oly@example.com", false);
            testAddresses.Add(@"pootietang.@example.com", false);
            testAddresses.Add(@".@example.com", false);
            testAddresses.Add(@"""Austin@Powers""@example.com", true);
            testAddresses.Add(@"Ima.Fool@example.com", true);
            testAddresses.Add(@"""Ima.Fool""@example.com", true);
            testAddresses.Add(@"""Ima Fool""@example.com", true);
            testAddresses.Add(@"Ima Fool@example.com", false);
            testAddresses.Add(@"harry.hirsch@example.com", true);

            testAddresses.Add(@"niceandsimple@example.com", true);
            testAddresses.Add(@"simplewith+symbol@example.com", true);
            testAddresses.Add(@"less.common@example.com", true);
            testAddresses.Add(@"a.little.more.unusual@dept.example.com", true);
            testAddresses.Add(@"""much.more\\ unusual""@example.com", true);
            testAddresses.Add(@"""very.unusual.@.unusual.com""@example.com", true);
            testAddresses.Add(@"!#$%&'*+-/=?^_`{}|~@example.org", true);
            testAddresses.Add(@"""()<>[]:,;@\\\""!#$%&'*+-/=?^_`{}|\\ \\ ~\\ \\ \\ ?\\ \\ \\ ^_`{}|~.a""@example.org", true);
            testAddresses.Add(@"""""@example.org", true);

            testAddresses.Add(@"'@[10.10.10.10]", false);
            testAddresses.Add(@"user@[IPv6:2001:db8:1ff::a0b:dbd0]", false);
            testAddresses.Add(@"""very.(),:;<>[]\\"".VERY.\\""very@\\\ \\""very\\"".unusual""@strange.example.com", false);
            testAddresses.Add(@"0@a", false);
            testAddresses.Add(@"postbox@com (top-level domains are valid hostnames)", false);

            testAddresses.Add(@"Abc.example.com", false);
            testAddresses.Add(@"Abc.@example.com", false);
            testAddresses.Add(@"Abc..123@example.com", false);
            testAddresses.Add(@"A@b@c@example.com", false);
            testAddresses.Add(@"a""b(c)d,e:f;g<h>i[j\k]l@example.com", false);
            testAddresses.Add(@"just""not""right@example.com", false);
            testAddresses.Add(@"this is""not\allowed@example.com", false);
            testAddresses.Add(@"this\ still\""not\\allowed@example.com", false);

            int counter = 0;

            foreach (String testAddress in testAddresses.Keys)
            {
                counter++;
                Boolean actual = Regex.IsMatch(testAddress, "^" + GPG4OutlookToolbox_Accessor.mailRegexPattern + "$", RegexOptions.IgnoreCase);
                Match match = Regex.Match(testAddress, "^" + GPG4OutlookToolbox_Accessor.mailRegexPattern + "$", RegexOptions.IgnoreCase);
                Assert.AreEqual(testAddresses[testAddress], actual, "for " + testAddress + " at: " + counter + " for " + match.ToString());
            }
        }
    }
}
