using System.Collections.Generic;
using EntityManyToManyTest.Models;

namespace EntityManyToManyTest.ModelViews {
    public class ClassNameTopicViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CheckBoxItem> AvailableTopics { get; set; }
    }
}