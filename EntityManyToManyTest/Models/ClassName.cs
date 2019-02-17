using System.Collections.Generic;

namespace EntityManyToManyTest.Models {
    public class ClassName {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ClassNameTopic> ClassNameTopics { get; set; }
    }

    public class Topic{
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ClassNameTopic> ClassNameTopics { get; set; }
    }

    public class ClassNameTopic {
        public int ClassNameId { get; set; }
        public ClassName ClassName { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}