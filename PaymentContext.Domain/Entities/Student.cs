using System.Collections.Generic;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private List<Subscription> _subscripton;
        public Student(Name name, Document document, Email email)
        {

            Name = name;
            Document = document;
            Email = email;
            _subscripton = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set;}
        public Email Email { get; private set;}
        public Address Address { get; private set;}        
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