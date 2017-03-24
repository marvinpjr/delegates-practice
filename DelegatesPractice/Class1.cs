using System.Collections.Generic;

namespace DelegatesPractice
{
    public delegate void DoSomethingTo(Person person);
    
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Party Party { get; set; }
        public Mood Mood { get; set; }
    }

    public enum Mood { Depressed, Ambivalent, Happy }
    public enum Party { Democratic, Republican, Independent, Green }

    public class PoliticalPersonProcessor
    {
        private IList<Person> _politicals;
        public PoliticalPersonProcessor(List<Person> politicals)
        {
            _politicals = politicals;
        }

        public void DoSomethingOnDemocrats(DoSomethingTo dst)
        {
            foreach (Person p in _politicals) { if (p.Party == Party.Democratic) dst(p); }
        }
    }

    public class ElectionResultsReporter
    {
        public void TellThemBarrackWon(Person p)
        {
            p.Mood = Mood.Happy;
        }
        public void TellThemMittWon(Person p)
        {
            p.Mood = Mood.Depressed;
        }
    }
    
}
