using NUnit.Framework;
using ReportMe;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Windows;
using ReportMe.Backend;

namespace ReportMe.Test
{
    [TestFixture]
    class JiraCalls
    {
    [TestCase]
    public void SuccesfulLogin()
        {
            string user = "<<General Users>>";
            string pass = "<<General user pass>>";
            string auth = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(user + ":" + pass));
            var sut = new AllTheShinies();
            Assert.That(sut.JRvalid(user).IsSuccessStatusCode);
        }

    [TestCase]
     public void RetrieveId()
        {
            string user = "<<General Users>>";
            string pass = "<<General user pass>>";
            string jiraInstance = "19";
            string auth = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(user + ":" + pass));
            var sut = new AllTheShinies();
            Assert.That(sut.GetUbiPrioId(jiraInstance, auth), Contains.Substring("custom").IgnoreCase );
        }

        [TestCase]
        public void FailedRetrieveCustomId()
        {
            string user = "<<General Users>>";
            string pass = "<<General user pass>>";
            string jiraInstance = "da";
            string auth = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(user + ":" + pass));
            var sut = new AllTheShinies();
            Assert.That(sut.GetUbiPrioId(jiraInstance, auth), Contains.Substring("n/a").IgnoreCase);
        }
    }
}
