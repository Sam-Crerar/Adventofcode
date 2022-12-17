using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventcode7
{
    public class Folder
    {
        public List<Folder> subfolder;
        public List<Filestr> subfiles;
        public int size;
        public string Name;

        public Folder(string name)
        {
            subfolder = new List<Folder>();
            subfiles = new List<Filestr>();
            Name = name;

        }

        public void addingfolder(string name)
        {
            Folder newfolder = new Folder(name);
            subfolder.Add(newfolder);
        }
        public void addingfilestr(int size, string name)
        {
            Filestr filestr = new Filestr(size, name);
            subfiles.Add(filestr);
        }

        public Folder Searchfor(string namefind)
        {
            foreach(Folder folder in subfolder)
            {
                if(folder.Name == namefind)
                {
                    return folder;
                }
            }
            return null;
        }
        public int calculatesize()
        {
            foreach(Folder F in subfolder)
            {
                size += F.calculatesize();
            }
            foreach(Filestr F in subfiles)
            {
                size += F.size;
            }
            return size;
        }
        public void sizeoffilebelow()
        {
            foreach (Folder F in subfolder)
            {
                F.sizeoffilebelow();
            }
            if(size <= 100000)
            {
                Program.total += size;
            }
        }
        public void listofbigenoughfiles()
        {
            foreach (Folder F in subfolder)
            {
                F.listofbigenoughfiles();
            }
            if(size > Program.sizeneeded)
            {
                Program.bigenough.Add(this);
            }
        }
    }
}
