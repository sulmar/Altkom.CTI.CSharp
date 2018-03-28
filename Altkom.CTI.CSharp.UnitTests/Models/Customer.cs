using System;
using System.Collections.Generic;
using System.Text;

namespace Allegro.Models
{
    public abstract class Base
    {
        public int Id { get; set; }
    }

    public class Customer : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public Customer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Customer()
        {

        }
    }
}
