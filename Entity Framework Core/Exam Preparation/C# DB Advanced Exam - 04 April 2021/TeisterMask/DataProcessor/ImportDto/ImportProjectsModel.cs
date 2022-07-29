using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ImportProjectsModel
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TasksImportModel[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class TasksImportModel
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        [Required]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        [Required]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Required]
        public string ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Required]
        public string LabelType { get; set; }
    }
}

//•	Id - integer, Primary Key
//•	Name - text with length [2, 40] (required)
//•	OpenDate - date and time(required)
//•	DueDate - date and time(required)
//•	ExecutionType - enumeration of type ExecutionType, with possible values (ProductBacklog, SprintBacklog, InProgress, Finished) (required)
//•	LabelType - enumeration of type LabelType, with possible values (Priority, CSharpAdvanced, JavaAdvanced, EntityFramework, Hibernate) (required)
//•	ProjectId - integer, foreign key(required)
//•	Project - Project
//•	EmployeesTasks - collection of type EmployeeTask

//< Project >
//    < Name > S </ Name >
//    < OpenDate > 25 / 01 / 2018 </ OpenDate >
//    < DueDate > 16 / 08 / 2019 </ DueDate >
//    < Tasks >
//      < Task >
//        < Name > Australian </ Name >
//        < OpenDate > 19 / 08 / 2018 </ OpenDate >
//        < DueDate > 13 / 07 / 2019 </ DueDate >
//        < ExecutionType > 2 </ ExecutionType >
//        < LabelType > 0 </ LabelType >
//      </ Task >
//    </ Tasks >
//  </ Project >

