using System.Collections;
using System.Collections.Generic;
using EntityManyToManyTest.Models;

namespace EntityManyToManyTest.ModelViews {
    public class ModelViewClassNameTopic {
        public ClassName ClassName { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ClassNameTopic ClassNameTopic { get; set; }
    }
}