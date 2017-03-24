using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DelegatesPractice.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Person palmer = new Person { LastName = "Palmer", Mood = Mood.Ambivalent, Party = Party.Democratic };
            Person smith = new Person { LastName = "Smith", Mood = Mood.Ambivalent, Party = Party.Independent };
            Person jones = new Person { LastName = "Jones", Mood = Mood.Ambivalent, Party = Party.Republican };
            Person brown = new Person { LastName = "Brown", Mood = Mood.Ambivalent, Party = Party.Green };

            List<Person> people = new List<Person>() { palmer, smith, jones, brown };

            PoliticalPersonProcessor pp = new PoliticalPersonProcessor(people);
            pp.DoSomethingOnDemocrats(new DoSomethingTo(new ElectionResultsReporter().TellThemMittWon));

            Assert.AreEqual(palmer.Mood, Mood.Depressed);

            pp.DoSomethingOnDemocrats(new DoSomethingTo(new ElectionResultsReporter().TellThemBarrackWon));
            Assert.AreEqual(palmer.Mood, Mood.Happy);
        }
    }
}
