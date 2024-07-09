
using System.ComponentModel.DataAnnotations;

namespace test1.Entities
{
    public class Person
    {
        public int Id { get; set; }


        [Key]
        public string Name { get; set; }

        public string Description { get; set; }
        public int Age { get; set; }

    }
}
