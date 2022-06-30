using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> Renovators ;
        public int Count { get { return Renovators.Count; } }
        // •	Name: string
        //•	NeededRenovators: int
        //•	Project: string
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int neededRenovators;
        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }

        private string project;
        public string Project
        {
            get { return project; }
            set { project = value; }
        }
        public Catalog(string name, int renovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = renovators;
            this.Project = project;
            this.Renovators = new List<Renovator>();
        }
        public string AddRenovator(Renovator renovator)
        {
            //            •	string AddRenovator(Renovator renovator) -adds a renovator to the catalog's collection, if renovators are still needed. Before adding a renovator, check:
            //o If the name or specialty are null or empty, return "Invalid renovator's information.".
            //o If renovators are no more needed, return "Renovators are no more needed.".Renovators are needed when the count of the added renovators is less than the NeededRenovators property of the Catalog.
            //o If the rate is above 350 BGN, return "Invalid renovator's rate.".

            //o Otherwise, return: "Successfully added {renovatorName} to the catalog.".
            if (Renovators.Count + 1 > NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            else if (renovator.Name == String.Empty || renovator.Name == null || renovator.Type == String.Empty || renovator.Type == null)
                    return "Invalid renovator's information.";
                
            else if (renovator.Rate >= 350)
                        return "Invalid renovator's rate.";
            else
            {
                Renovators.Add(renovator);
                return $"Successfully added {renovator.Name} to the catalog.";
            }   
        }
        public bool RemoveRenovator(string name)
        {
            // •	bool RemoveRenovator(string name) -removes a renovator by given name.
            //o If such exists returns true;
            //o Otherwise, returns false.
            int index = Renovators.FindIndex(x => x.Name == name);
            if (index >= 0)
            {
                Renovators.RemoveAt(index);
                return true;
            }
            return false;

           
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            //            •	int RemoveRenovatorBySpecialty(string type) -removes all renovators by the given specialty.
            //o If such exist(s), returns the count of the removed renovators;
            //
            //    o Otherwise, returns 0.
            int count = Renovators.RemoveAll(x => x.Type == type);
            if (count == -1)
            {
                return 0;
            }
            return count;

        }
        public Renovator HireRenovator(string name)
        {
            //•	Renovator HireRenovator(string name) method – hire(set their available property to true without removing them from the collection) the renovator with the given name, if they exist.As a result, return the renovator, or null, if they don't exist.
            int index = Renovators.FindIndex(x => x.Name == name);
            if (index >= 0)
            {
                Renovators[index].Hired = true;
                return Renovators[index];
            }
            return null;
            
        }
        public List<Renovator> PayRenovators(int days)
        {
            /*List<Renovator> PayRenovators(int days) method – return a list with all renovators that have been working for days days or more.*/
            return Renovators.FindAll(x=>x.Days>=days);
        }
        public string Report()
        {
            //            •	Report() – returns a string with information about the catalog and renovators who are not hired in the following format:
            //            "Renovators available for Project {project}:
            //{ Renovator1}
            //            { Renovator2}
            //            {…}
            //            "
            return $"Renovators available for Project {this.Project}:{Environment.NewLine}" +
                $"{string.Join(Environment.NewLine, Renovators.Where(x => x.Hired == false))}";

        }
    }

}

