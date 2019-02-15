using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LinqToXMLExercise
{
    public class EmployeeManager
    {
        private XDocument XmlDocument { get; set; }
        private string PathToXml { get; set; }

        public EmployeeManager(string pathToXml)
        {
            PathToXml = pathToXml;
            XmlDocument = XDocument.Load(pathToXml);

            //Another way of create the XDocument
            //var xmlContent = File.ReadAllText(documentPath);
            //var xmlDocument2 = XDocument.Parse(xmlContent);
        }

        public IReadOnlyList<XElement> Search(string search)
        {
            search = search.ToLower();

            var results = (from employees in XmlDocument.Descendants("employee")
                           where employees.Element("Name").Value.ToLower().Contains(search) ||
                           employees.Element("Email").Value.ToLower().Contains(search) ||
                           employees.Element("PersonalNumber").Value.ToLower().Contains(search)
                           select employees).ToList();

            return results;
        }

        public void Add(string name, string email, 
            string phone, string personalNumber, DateTime hiredDate)
        {
            var personalNumberInt = Convert.ToInt32(personalNumber);

            if (DoesEmployeeExist(personalNumber))
            {
                throw new BusinessRuleException("Employee already exists");
            }

            XmlDocument
                .Element("records")
                .Add(new XElement("employee",
                        new XElement("Name", name),
                        new XElement("Email", email),
                        new XElement("Phone", phone),
                        new XElement("PersonalNumber", personalNumber),
                        new XElement("Hired", hiredDate.ToString("dd/MM/yyyy"))));

            Save();
        }

        public void Remove(string personalNumber)
        {
            var result = (from employee in XmlDocument.Descendants("employee")
                          where employee.Element("PersonalNumber").Value == personalNumber
                          select employee).FirstOrDefault();

            if (result != null)
            {
                result.Remove();
                Save();
            }
        }

        private void Save()
        {
            XmlDocument.Save(PathToXml);
        }

        private bool DoesEmployeeExist(string personalNumber)
        {
            return (from employee in XmlDocument.Descendants("employee")
                          where employee.Element("PersonalNumber").Value == personalNumber
                          select employee).Any();
            
        }
    }
}
