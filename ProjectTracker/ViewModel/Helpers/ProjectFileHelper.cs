using ProjectTracker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ProjectTracker.ViewModel.Helpers
{
    public class ProjectFileHelper
    {
        public static string projectSaveFolder = Directory.GetCurrentDirectory() + @"\Projects";

        public static void SaveProjectToFile(Project project)
        {
            Directory.CreateDirectory(projectSaveFolder);

            XmlSerializer writer = new XmlSerializer(typeof(Project));
            FileStream file = File.Create(Path.Combine(projectSaveFolder + "\\" + project.Name + ".ptf"));
            writer.Serialize(file, project);
            file.Close();
        }

        public static Project ReadProjectFromFile(string filePath)
        {
            Project project = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Project));
            
            using(Stream stream = new FileStream(filePath, FileMode.Open))
            {
                project = (Project)serializer.Deserialize(stream);
            }

            return project;
        }
    }
}
