using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private List<Subscription> _subscripton;
        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscripton = new List<Subscription>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set;}
        public string Document { get; private set;}
        public string Email { get; private set;}
        public string Address { get; private set;}        
        public IReadOnlyCollection<Subscription> Subscription { get { return _subscripton.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            foreach(var sub in Subscription)
            {
                sub.Inactivate();
            }
            _subscripton.Add(subscription);
            
        }
    }
}