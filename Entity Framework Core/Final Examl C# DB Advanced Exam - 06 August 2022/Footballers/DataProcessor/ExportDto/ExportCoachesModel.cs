using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class ExportCoachesModel
    {
        [XmlAttribute("FootballersCount")]
        public string FootballersCount { get; set; }

        [XmlElement("CoachName")]
        public string CoachName { get; set; }

        [XmlArray("Footballers")]
        public ExportFootballers[] Footballers { get; set; }
    }

    [XmlType("Footballer")]
    public class ExportFootballers
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Position")]
        public string Position { get; set; }
    }
}

//< Coach FootballersCount = "5" >
//    < CoachName > Pep Guardiola </ CoachName >
//    < Footballers >
//      < Footballer >
//        < Name > Bernardo Silva </ Name >
//        < Position > Midfielder </ Position >
//      </ Footballer >

