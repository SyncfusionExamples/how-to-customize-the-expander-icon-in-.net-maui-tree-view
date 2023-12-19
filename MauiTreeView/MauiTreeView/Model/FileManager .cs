using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiTreeView
{
    public class FileManager : INotifyPropertyChanged
    {
        private string itemName;
        private ImageSource imageIcon;
        private ObservableCollection<FileManager> subFiles;
        //private bool isExpanded;

        public ObservableCollection<FileManager> SubFiles
        {
            get { return subFiles; }
            set
            {
                subFiles = value;
                RaisedOnPropertyChanged("SubFiles");
            }
        }

        public string ItemName
        {
            get { return itemName; }
            set
            {
                itemName = value;
                RaisedOnPropertyChanged("ItemName");
            }
        }

        public ImageSource ImageIcon
        {
            get { return imageIcon; }
            set
            {
                imageIcon = value;
                RaisedOnPropertyChanged("ImageIcon");
            }
        }

        //public bool IsExpanded
        //{
        //    get { return isExpanded; }
        //    set
        //    {
        //        isExpanded = value;
        //        RaisedOnPropertyChanged("IsExpanded");
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
